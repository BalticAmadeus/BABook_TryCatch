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

        public Group GetGroupId(int eventId)
        {
            return _context.Groups
                .FirstOrDefault(x => x.GroupEvents
                .FirstOrDefault(y => y.EventId == eventId) != null);
        }

        public Group GetLoadedGroup(int groupId)
        {
            return _context.Groups
                .Include(x => x.GroupEvents
                    .Select(e => e.Attendances
                        .Select(a => a.User)))
                .Include(x => x.GroupEvents.Select(y => y.OwnerUser))
                .SingleOrDefault(x => x.GroupId == groupId);
        }
    }
}
