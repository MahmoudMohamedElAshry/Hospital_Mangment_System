using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class Department : ModelBase
    {
        public string Name { get; set; }    
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        
    }
}
