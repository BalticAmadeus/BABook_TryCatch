using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess.Configuration
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
        {
        public CommentConfiguration()
        {
            ToTable(nameof(Comment));
            HasKey(x => x.CommentId);
        }
    }
}
