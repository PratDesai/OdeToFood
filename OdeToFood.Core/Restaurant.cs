using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public CuisineType CuisineType { get; set; }
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Location { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }
    }
}