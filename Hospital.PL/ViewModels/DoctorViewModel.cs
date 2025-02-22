using Hospital.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{
    public class DoctorViewModel : EmployeeViewModel
    {
        public string? Specialization { get; set; }
       
        //Navigational proparty = [one]
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    }
}
