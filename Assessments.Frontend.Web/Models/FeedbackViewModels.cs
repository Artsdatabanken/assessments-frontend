using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assessments.Data.Models;

namespace Assessments.Frontend.Web.Models
{
    public class FeedbackFormViewModel
    {
        [Required(ErrorMessage = "{0} er påkrevd")]
        [MinLength(5, ErrorMessage = "{0} må ha minst {1} tegn")]
        [MaxLength(100, ErrorMessage = "{0} kan ha maks {1} tegn")]
        [Display(Name = "Navn")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} er påkrevd")]
        [MaxLength(200, ErrorMessage = "{0} kan ha maks {1} tegn")]
        [EmailAddress(ErrorMessage = "{0} må være en gyldig e-postadresse")]
        [Display(Name = "E-postadresse")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} er påkrevd")]
        [MinLength(5, ErrorMessage = "{0} må ha minst {1} tegn")]
        [MaxLength(10000, ErrorMessage = "{0} kan ha maks {1} tegn")]
        [Display(Name = "Kommentar")]
        public string Comment { get; set; }
        
        [Required, HiddenInput]
        public int AssessmentId { get; set; }

        [Required, HiddenInput]
        public int Year { get; set; }

        [Required, HiddenInput]
        public string ExpertGroup { get; set; }

        [Required, HiddenInput]
        public FeedbackType Type { get; set; }

        [Display(Name = "Filer")]
        public List<IFormFile> FormFiles { get; set; }
    }
}
