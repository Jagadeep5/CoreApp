using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.Models
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public DateTime DOB { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
