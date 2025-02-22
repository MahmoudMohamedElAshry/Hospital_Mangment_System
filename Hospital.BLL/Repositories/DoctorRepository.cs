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
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext Context) : base(Context)
        {
        }
        public IQueryable<Doctor> SearchByName(string Name)
             => _dbContext.Doctors.Where(D => D.Name == Name.ToLower());
    }
}
