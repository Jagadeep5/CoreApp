namespace CoreApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Cost { get; set; }
        public List<User>? Users { get; set; }
    }
}
