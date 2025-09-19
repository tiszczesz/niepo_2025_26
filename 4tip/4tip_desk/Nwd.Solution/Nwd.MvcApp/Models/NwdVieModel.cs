using System.ComponentModel.DataAnnotations;

namespace Nwd.MvcApp.Models
{
    public class NwdVieModel
    {
        [Required(ErrorMessage = "Podaj a")]
        public int? NumberA { get; set; }

        [Required(ErrorMessage = "Podaj b")]
        public int? NumberB { get; set; }
        public string MethodCalc { get; set; }
        
    }
}
