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
    public class ReceptionistRepository : GenericRepository<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepository(AppDbContext Context) : base(Context)
        {
        }

        public IQueryable<Receptionist> SearchByName(string Name)
           => _dbContext.Receptionists.Where(R => R.Name == Name.ToLower());
        
    }
}
