using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Configuration
{
    public class InvitationConfiguration : EntityTypeConfiguration<Invitation>
    {
        public InvitationConfiguration()
        {
            ToTable(nameof(Invitation));
            HasKey(x => new {x.EventId, x.UserId});
        }
    }
}
