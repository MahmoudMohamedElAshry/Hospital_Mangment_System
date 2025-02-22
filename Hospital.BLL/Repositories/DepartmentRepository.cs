using Hospital.BLL.Interfaces;
using Hospital.DAL.Data;
using Hospital.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext Context) : base(Context)
        {
        }

        public IQueryable<Department> SearchByName(string Name)
          =>_dbContext.Departments.Where(D => D.Name == Name.ToLower());
        
    }
}
