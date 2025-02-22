using Hospital.BLL.Interfases;
using Hospital.DAL.Data;
using Hospital.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext Context)
        {
           _dbContext = Context;
        }
        public void Create(T entity)
           => _dbContext.Add(entity);
        public void Delete(T entity)
           => _dbContext.Remove(entity);
        public void Update(T entity)
           => _dbContext.Update(entity);
        public T GetById(int Id)
        {
            if(typeof(T) ==(typeof(Doctor)))
            {
             
              return _dbContext.Doctors.Include(d => d.Department).AsNoTracking()
                    .FirstOrDefault(d => d.ID == Id) as T;
            }
            else if (typeof(T) == (typeof(Patient)))
            {

                return _dbContext.Patients.Include(p => p.Room).AsNoTracking()
                      .Include(p => p.Doctor).FirstOrDefault(d => d.ID == Id) as T;
            }
            else if (typeof(T) == (typeof(Receptionist)))
            {

                return _dbContext.Receptionists.Include(p => p.Department).AsNoTracking()
                     .FirstOrDefault(d => d.ID == Id) as T;
            }
            else if (typeof(T) == typeof(Nurse))
            {

                return _dbContext.Nurses.Include(p => p.Department).AsNoTracking()
                    .Include(n => n.Room).AsNoTracking().FirstOrDefault(d => d.ID == Id) as T;
            }
            else if (typeof(T) == typeof(TestReport))
            {

                return _dbContext.TestReports.Include(p => p.Patient).AsNoTracking().FirstOrDefault(d => d.ID == Id) as T;
            }
            else if (typeof(T) == typeof(Bill))
            {

                return _dbContext.Bills.Include(p => p.Patient).AsNoTracking().FirstOrDefault(d => d.ID == Id) as T;
            }
            else
            {
                return _dbContext.Find<T>(Id);
            }
           
        }
        public IEnumerable<T> GetAll()
        {
            if(typeof(T) == typeof(Patient))
            {
                return (IEnumerable<T>)_dbContext.Patients.Include(P => P.Room)
                    .AsNoTracking().Include(P => P.Doctor).AsNoTracking().ToList(); 
            }
            else if(typeof(T) == typeof(Doctor))
            {
                  return (IEnumerable<T>)_dbContext.Doctors.Include(D => D.Department)
                    .AsNoTracking().Include(D => D.Patients).AsNoTracking().ToList();
            }
            else if(typeof(T) == typeof(Nurse))
            {
                  return (IEnumerable<T>)_dbContext.Nurses.Include(N => N.Room)
                    .Include(N => N.Department).AsNoTracking().ToList();
            }
            else if(typeof(T) == typeof(Receptionist))
            {
                  return (IEnumerable<T>)_dbContext.Receptionists.Include(R => R.Department)
                    .AsNoTracking().ToList();
            }
            else if(typeof(T) == typeof(Room))
            {
                  return (IEnumerable<T>)_dbContext.Rooms.Include(R => R.Patients)
                    .AsNoTracking().ToList();
            }
            else if(typeof(T) == typeof(TestReport))
            {
                  return (IEnumerable<T>)_dbContext.TestReports.Include(t => t.Patient)
                    .AsNoTracking().ToList();
            }
            else if(typeof(T) == typeof(Bill))
            {
                  return (IEnumerable<T>)_dbContext.Bills.Include(t => t.Patient)
                    .AsNoTracking().ToList();
            }
            else
            {
                 return _dbContext.Set<T>().AsNoTracking().ToList();
            }
        }

		
	}
}
