using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Domain
{
    
    public class Product :  IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [MinLength(3, ErrorMessage = "En az üç harfli olmalı")]
        [MaxLength(100, ErrorMessage = "En fazla 100 harfli olmalı")]

        public string Name { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Stock { get; set; }

        //Navigation Property
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }

    }
}
