using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Persistence.DbConfiguration.EntityTypeConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(100);
            builder.HasIndex(x => x.Title).IsUnique();
            builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.Questions).WithOne(q => q.Post).HasForeignKey(q => q.PostId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.PostDetail).WithOne(pd => pd.Post).HasForeignKey<PostDetail>(pd => pd.PostId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
