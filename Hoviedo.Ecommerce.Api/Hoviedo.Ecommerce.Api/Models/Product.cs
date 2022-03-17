using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Hoviedo.Ecommerce.Api.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }


        public string ImageProduct { get; set; }


        [Range(0, 1999.99)]
        public decimal Price { get; set; }


        [Required]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

    }
}
