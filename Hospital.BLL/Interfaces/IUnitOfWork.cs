using Hospital.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ITestReportRepository TestReportRepository { get; set; }
        public IReceptionistRepository ReceptionistRepository  { get; set; }
        public IBillRepository BillRepository { get; set; }
        public IDoctorRepository DoctorRepository { get; set; }
        public INurseRepository NurseRepository { get; set; }
        public IPatientRepository PatientRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IRoomRepository RoomRepository { get; set; }
        public int Complete();

    }
}
