using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;
using Clinic.Models;
using Clinic.App_Start;

namespace Clinic.DAL
{
    public class BaseRepository<T> where T : class
    {
        protected DbContext _context = IocConfig.GetInstance<ApplicationDbContext>();
        protected DbSet<T> DbSet;

        public BaseRepository()
        {
            DbSet = _context.Set<T>();
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}