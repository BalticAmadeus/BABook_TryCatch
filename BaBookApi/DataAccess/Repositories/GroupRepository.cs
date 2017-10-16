using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class GroupRepository : BaseRepository<Group>
    {
        public List<Group> GetLoadedList()
        {
            return _context.Groups
                .Include(x => x.GroupEvents)
                .ToList();
        }
    }
}
