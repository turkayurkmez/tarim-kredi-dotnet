using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetAllProducts
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public string? Description { get; set; }     
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
