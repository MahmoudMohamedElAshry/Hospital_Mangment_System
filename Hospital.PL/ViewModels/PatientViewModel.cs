using Hospital.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.PL.ViewModels
{ 
    public enum Genders
    {
        Male,
        Female
    }
    public class PatientViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }
       
        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]
        public Genders Gender { get; set; }
        [Display(Name = "Booking Date")]
        [Required(ErrorMessage = "Booking Date is Required")]
        public DateTime BookingDate { get; set; } 
        [Phone]
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }
        //Navigational proparty = [one]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        
        public ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
        public ICollection<TestReport> TestReports { get; set; } = new HashSet<TestReport>();
    }
}
