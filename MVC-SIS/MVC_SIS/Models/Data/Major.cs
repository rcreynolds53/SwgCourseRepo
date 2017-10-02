using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major : IValidatableObject
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(MajorName))
            {
                errors.Add(new ValidationResult("You must enter a major", new[] { "MajorName" }));
            }
            return errors;
        }
    }    
}