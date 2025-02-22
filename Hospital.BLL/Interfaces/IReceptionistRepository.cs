using Hospital.BLL.Interfases;
using Hospital.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Interfaces
{
    public interface IReceptionistRepository : IGenericRepository<Receptionist>
    {
        IQueryable<Receptionist> SearchByName(string Name);
    }
}
