using Hospital.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{
    public class DepartmentViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
        public ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();
        public ICollection<Receptionist> Receptionists { get; set; } = new HashSet<Receptionist>();
    }
}
