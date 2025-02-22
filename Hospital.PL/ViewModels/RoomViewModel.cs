using Hospital.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "Room Number is Required")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Type is Required")]
        public string Type { get; set; }
        //Navigational proparty = [Many]
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();

        public ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();
    }
}
