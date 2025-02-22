using Hospital.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{
    public class TestReportViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Test Type is Required")]
        [Display(Name ="Test Type")]
        public string TestType { get; set; }
        [Required(ErrorMessage = "Result is Required")]
        public string Result { get; set; }
        
        [Required(ErrorMessage = "Treatment is Required")]
        public string? Treatment { get; set; }
        public int? PatientID { get; set; }
        public Patient? Patient { get; set; }
    }
}
