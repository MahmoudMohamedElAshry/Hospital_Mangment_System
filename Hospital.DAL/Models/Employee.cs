using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Employee : ModelBase
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }    
        public string Email { get; set; }
        public int YearOfExp { get; set; }
        public string Qualification { get; set; }
        public string? Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
