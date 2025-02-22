using Hospital.BLL.Interfases;
using Hospital.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        IQueryable<Department> SearchByName(string Name);
    }
}
