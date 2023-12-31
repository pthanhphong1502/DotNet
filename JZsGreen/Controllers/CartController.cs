using JZsGreen.Models;
using JZsGreen.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JZsGreen.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly JZenoDbContext _context;
        public const string CARTKEY = "cart";
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public CartController(JZenoDbContext context, ILogger<CartController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY)!;
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart)!;
            }
            return new List<CartItem>();
        }
        public JsonResult jsonCartItems()
        {
            var cart = GetCartItems();
            return Json(cart);
        }
        public JsonResult CheckQuantity(string productid)
        {
            var product = _context.Product
               .Select(e => new Product
               {
                   Id = e.Id,
                   quantity = e.quantity,
                   unit = e.unit
               }).ToList().FirstOrDefault(e => e.Id == productid);
            return Json(product);
        }

        public IActionResult GetToTal()
        {
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            var total = GetCartItems().Select(e => e.product!.totalPrice * e.quantity).Sum();
            return Ok(string.Format(info, "{0:c}", total));
        }
        public IActionResult GetTotalDiscount()
        {
            return Ok(GetDiscount());
        }
        public double GetDiscount()
        {
            var total = GetCartItems().Select(e => e.product!.totalPrice * e.quantity).Sum();
            if (total > 1000000)
            {
                return 8;
            }
            else if (total >= 100000)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
        public IActionResult GetTotalBill()
        {
            return Ok(totalBill());
        }
        public double totalBill()
        {
            var total = GetCartItems().Select(e => e.product!.totalPrice * e.quantity).Sum();
            if (total > 1000000)
            {
                return (double)(total - total * 0.08) + 30000;
            }
            else if(total > 100000)
            {
                return (double)(total - total * 0.05) + 30000;
            }
            else
            {
                return (double) total! + 30000;
            }
        }
        public IActionResult GetTotalItemInCart()
        {
          return Ok(GetCartItems().Count);
        }

        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        [Route("addcart/{productid}", Name = "addcart")]
        public JsonResult AddToCart([FromRoute] string productid)
        {
            var product = _context.Product
                .Where(p => p.Id == productid)
                .Select(e => new Product
                {
                    Id = e.Id,
                    name = e.name,
                    images = e.images,
                    Category = e.Category,
                    price = e.price,
                    totalPrice = e.totalPrice,
                    discount = e.discount
                }
               ).ToList()
                .FirstOrDefault();
            
            var cart = GetCartItems();

            var cartitem = cart.Find(p => p.product!.Id == productid);
            if (cartitem != null)
            {
                cartitem.quantity++;
            }
            else
            {
                cart.Add(new CartItem() { quantity = 1, product = product });
            }

            SaveCartSession(cart);
            return Json(cart);
        }
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] string productid, [FromForm] int quantity)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product!.Id == productid);
            if (cartitem != null)
            {
                cartitem.quantity = quantity;
            }
            if (cartitem!.quantity < 1)
            {
                cart.Remove(cartitem);
            }
            SaveCartSession(cart);
            return Ok();
        }
        [Route("/removecart/{productid}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] string productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product!.Id == productid);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
        [Route("/checkout")]
        [HttpPost]
        public IActionResult CheckOut(IFormCollection form)
        {
            String idGUID = Guid.NewGuid().ToString();
            var cart = GetCartItems();
            try
            {
                Bill bill = new Bill();
                bill.billID = idGUID;
                bill.date = DateTime.Now;
                bill.phone = form["phone"].ToString();
                bill.fullName = form["fullname"].ToString();
                bill.address = form["city"] + ", " + form["district"] + ", " + form["ward"] + ", " + form["address"].ToString();
                bill.point = 0;
                bill.totalPrice = (decimal) totalBill();
                bill.percentDiscount = (decimal) GetDiscount();
                bill.payment = 0;
                bill.price = (decimal?) cart.Sum(s => s.product!.totalPrice * s.quantity);
                if (_signInManager.IsSignedIn(User) == true)
                {
                    bill.UserId = _userManager.GetUserAsync(User).Result!.Id;
                }
                _context.Add(bill);
                foreach (var item in cart)
                {
                    var product = _context.Product.FindAsync(item.product!.Id);
                    DetailOrder detailOrder = new DetailOrder();
                    detailOrder.billID = bill.billID;
                    detailOrder.quantity = item.quantity;
                    detailOrder.productId = item.product.Id;
                    detailOrder.product = product.Result;
                    _context.Add(detailOrder);
                    var pro = _context.Product.ToList().FirstOrDefault(e => e.Id == item.product.Id);
                    pro!.quantity -= item.quantity;
                    if(pro.quantity == 0)
                    {
                        pro.isActive = false;
                    }
                    _context.Update(pro);
                }
                 _context.SaveChanges();
                ClearCart();
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
            return RedirectToAction("Index", "Bills",new { searchPhone = form["phone"].ToString() });
        }


        [Route("/cart/checkout")]
        public IActionResult CartCheckOut()
        {
            return View(GetCartItems());
        }
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {        
            return View(GetCartItems());
        }

    }
}
