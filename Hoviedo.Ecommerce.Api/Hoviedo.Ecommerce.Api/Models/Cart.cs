using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json.Serialization;
using SanValero.Daw.Ecommerce.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hoviedo.Ecommerce.Api.Models
{
    public class Cart
    {
        public int Id { get; set; }

        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(0, 10)]
        public int Quantity { get; set; }

        public string ImageCart { get; set; }

        [Required]
        public int ProductId { get; set; }


        [JsonIgnore]
        public Product Product { get; set; }

        public string ProductName => Product?.Name;
        //public decimal Price => Product.Price;
        //public decimal Total => Product.Price * Quantity;


    }
}