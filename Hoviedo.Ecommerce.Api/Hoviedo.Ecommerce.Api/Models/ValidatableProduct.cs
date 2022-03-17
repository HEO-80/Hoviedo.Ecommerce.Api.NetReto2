using GenFu.ValueGenerators.Music;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hoviedo.Ecommerce.Api.Models
{
    public class ValidatableProduct : IValidatableObject
    {
        private const int _classicYear = 1960;

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        public Genre GeneroName { get; set; }

        public bool Preorder { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (GeneroName == GeneroName && ReleaseDate.Year > _classicYear)
            {
                yield return new ValidationResult(
                    $"Classic product must have a release year no later than {_classicYear}.",
                    new[] { nameof(ReleaseDate) });
            }
        }
    }
   
}
