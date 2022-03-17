using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using SanValero.Daw.Ecommerce.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hoviedo.Ecommerce.Api.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }


        [StringLength(1000)]
        public string Description { get; set; }

        [JsonIgnore]
        public IEnumerable<Product> Products { get; set; }

    }
}
