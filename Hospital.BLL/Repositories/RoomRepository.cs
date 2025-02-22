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
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext Context) : base(Context)
        {
            
        }
            public IQueryable<Room> SearchByNumber(int Number)
            => _dbContext.Rooms.Where(r => r.RoomNumber == Number);
       
    }
}
