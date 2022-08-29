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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Content).HasMaxLength(500);
            builder.Property(q => q.Title).HasMaxLength(100);
            builder.HasMany(q => q.QuestionAnswers).WithOne(qa => qa.Question).HasForeignKey(qa => qa.QuestionId).OnDelete(DeleteBehavior.NoAction);

            //builder.HasData(new Question
            //{
            //    Id = 1,
            //    Title = "Example Question Title",
            //    Content = "Example Question",
            //    CreatedDate = DateTime.Now,
            //    PostId = 1,
            //    UserId = 1,
            //});
        }
    }
}
