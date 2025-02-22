using Hospital.BLL.Interfaces;
using Hospital.DAL.Data;
using Hospital.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext Context) : base(Context)
        {
        }
        //public IEnumerable<Patient> GetPatientByRoomId(int Id)
        //   => _dbContext.Patients.Where(p => p.RoomId == Id).Include(p => p.Room).ToList();
        public IQueryable<Patient> SearchByName(string Name)
            => _dbContext.Patients.Where(P => P.Name.ToLower().Contains(Name));
    }
}
