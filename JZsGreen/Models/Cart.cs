using JZsGreen.Models;
using Microsoft.Build.Framework;

namespace JZsGreen.Models
{
    public class CartItem
    {
        public Product? product { get; set; }
        [Required]
        public int? quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items { get; set; } = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

       
    }
}
