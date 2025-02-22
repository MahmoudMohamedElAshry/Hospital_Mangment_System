using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Patient: ModelBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime? BookingDate { get; set; }
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
