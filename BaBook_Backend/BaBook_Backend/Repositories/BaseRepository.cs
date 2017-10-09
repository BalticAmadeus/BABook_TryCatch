using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BaBook_Backend.Context;

namespace BaBook_Backend.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly DataContext _context;

        public BaseRepository()
        {
            _context = new DataContext();
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context?.Dispose();
        }
    }
}
