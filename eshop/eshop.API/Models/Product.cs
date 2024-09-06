using System.ComponentModel.DataAnnotations;

namespace eshop.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [MinLength(3, ErrorMessage = "En az üç harfli olmalı")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
