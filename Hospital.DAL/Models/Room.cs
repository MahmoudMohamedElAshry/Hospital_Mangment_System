using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Room : ModelBase
    {
        public int RoomNumber { get; set; }
        public string Type { get; set; }
        public bool Availability { get; set; } = true;

        //Navigational proparty = [Many]
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>();
    }
}
