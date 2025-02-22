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
    public class TestReportRepository : GenericRepository<TestReport>, ITestReportRepository
    {
        public TestReportRepository(AppDbContext Context) : base(Context)
        {
        }
    }
}
