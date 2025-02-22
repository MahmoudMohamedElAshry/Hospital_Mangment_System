using Hospital.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{ 
    public enum Gender
    {
        Male,
        Female
    }
    public class EmployeeViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(20,60)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Phone]
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }
       
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Display(Name = "Year Of Experience")]
        [Required(ErrorMessage = "Year Of Experience is Required")]
        public int? YearOfExp { get; set; }
        [Required(ErrorMessage = "Qualification is Required")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
