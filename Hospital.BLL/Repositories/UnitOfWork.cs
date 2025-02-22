using Hospital.BLL.Interfaces;
using Hospital.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public ITestReportRepository TestReportRepository { get; set; }
        public IReceptionistRepository ReceptionistRepository { get; set; }
        public IBillRepository BillRepository { get; set; }
        public IDoctorRepository DoctorRepository { get; set; }
        public INurseRepository NurseRepository { get; set; }
        public IPatientRepository PatientRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IRoomRepository RoomRepository { get; set; }
        public UnitOfWork(AppDbContext dbContext)
        {
            TestReportRepository = new TestReportRepository(dbContext);
            ReceptionistRepository = new ReceptionistRepository(dbContext);
            BillRepository = new BillRepository(dbContext);
            DoctorRepository = new DoctorRepository(dbContext);
            NurseRepository = new NurseRepository(dbContext);
            PatientRepository = new PatientRepository(dbContext);
            DepartmentRepository = new DepartmentRepository(dbContext);
            RoomRepository = new RoomRepository(dbContext);
            _dbContext = dbContext;
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
            => _dbContext.Dispose();
    }
}
