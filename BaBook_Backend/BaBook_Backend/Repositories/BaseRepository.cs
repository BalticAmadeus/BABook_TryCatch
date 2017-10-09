using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BaBook_Backend.Context;

namespace BaBook_Backend.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly DataContext _context;

        public BaseRepository()
        {
            _context = new DataContext();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public void Add(T model)
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> models)
        {
            _context.Set<T>().AddRange(models);
            _context.SaveChanges();
        }

        public void Remove(T model)
        {
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
        }
    }
}
}