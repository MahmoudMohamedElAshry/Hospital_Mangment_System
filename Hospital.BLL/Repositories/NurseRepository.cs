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
    public class NurseRepository : GenericRepository<Nurse>, INurseRepository
    {
        public NurseRepository(AppDbContext Context) : base(Context)
        {
        }

        public IQueryable<Nurse> SearchByName(string Name)
            => _dbContext.Nurses.Where(N => N.Name == Name.ToLower());
    }
}
