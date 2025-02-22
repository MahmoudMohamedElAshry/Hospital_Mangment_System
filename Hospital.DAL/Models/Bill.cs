using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Bill : ModelBase 
    {
        public decimal Amount { get; set; }
        public DateTime BookingDate { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }


    }
}
