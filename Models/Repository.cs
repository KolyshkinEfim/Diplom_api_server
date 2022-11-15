using System.Collections.Generic;
using System.Linq;
using test_crud.Entity;
using test_crud.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace test_crud.Models
{
    public class Repository : IRepository 
    {
        ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> Get<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().AsNoTracking().ToList().ToArray();
        }

        public TEntity FindById<TEntity>(int id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Create<TEntity>(TEntity item) where TEntity : class
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
        }

        public void Update<TEntity>(TEntity item) where TEntity : class
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove<TEntity>(TEntity item) where TEntity : class
        {
            _context.Set<TEntity>().Remove(item);
            _context.SaveChanges();
        }
    }
}
