using Hospital.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.PL.ViewModels
{
    public class BillViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Amount is Required")]
        public decimal Amount { get; set; }
        [Display(Name = "Booking Date")]
        [Required(ErrorMessage = "Booking Date is Required")]
        public DateTime BookingDate { get; set; }
        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
