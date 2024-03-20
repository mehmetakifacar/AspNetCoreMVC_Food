namespace AspNetCoreMVC_Food.Data.Models
{
    public class AddProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

    }
}
