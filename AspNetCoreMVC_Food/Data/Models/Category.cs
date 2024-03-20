using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVC_Food.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name Can Not Be Empty !")]
        [StringLength(20, ErrorMessage = "You Can Type Maximum 5-20 Characters !", MinimumLength = 5)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public List<Food> Foods { get; set; }
    }
}
