using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Doctor : Employee
    {
        
        public string? Specialization { get; set; }


        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();

    }
}
