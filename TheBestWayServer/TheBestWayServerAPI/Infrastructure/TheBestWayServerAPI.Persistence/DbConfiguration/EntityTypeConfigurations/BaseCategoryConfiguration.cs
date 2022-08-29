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
    public class BaseCategoryConfiguration : IEntityTypeConfiguration<BaseCategory>
    {
        public void Configure(EntityTypeBuilder<BaseCategory> builder)
        {
            builder.Property(bc => bc.Name).HasMaxLength(100);
            builder.HasIndex(bc=>bc.Name).IsUnique();
            builder.Property(bc => bc.Description).HasMaxLength(500);
            builder.HasMany(bc => bc.Categories).WithOne(c => c.BaseCategory).HasForeignKey(c => c.BaseCategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
