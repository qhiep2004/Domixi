namespace MVC04.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public required string ImageURL { get; set; }
        public decimal ProductPrice { get; set; }
        public required string Description { get; set; }
    }
}
