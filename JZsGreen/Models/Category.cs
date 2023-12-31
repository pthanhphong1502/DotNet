using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Twilio.Types;

namespace JZsGreen.Models
{
    public class Category
    {
        [Key]
        public string? Id { get; set; }
        [StringLength(42)]
        [Display(Name = "Danh Mục")]
        public string? name { get; set; }
        public List<CategoryChild>? CategoryChild { get; set; }
    }
    [Index(nameof(name), IsUnique = true)]
    public class CategoryChild
    {
        [Key]
        public string? Id { get; set; }
        [StringLength(25)]
        [Display(Name = "Danh Mục")]
        public string? name { get; set; }

        [ForeignKey("Id")]
        public string? categoryId { get; set; }
        [Display(Name ="Danh Mục Chính")]
        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }
    }
}
