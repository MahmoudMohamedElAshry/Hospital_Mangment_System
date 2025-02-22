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
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(AppDbContext Context) : base(Context)
        {
        }
    }
}
