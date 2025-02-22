using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Models
{
    public class TestReport : ModelBase
    {
        public string TestType { get; set; }
        public string Result { get; set; }
        public string? Treatment { get; set; }
        public int PatientID { get; set; }   
        public Patient Patient { get; set; }

    }
}
