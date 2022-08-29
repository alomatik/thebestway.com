using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.ViewModels.PostModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Persistence.Contexts
{
    public class TheBestWayDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<BaseCategory> BaseCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostDetail> PostDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public DbSet<GetPostViewModel> GetPostViewModels { get; set; }

        //public TheBestWayDbContext(DbContextOptions<TheBestWayDbContext> dbContextOptions) : base(dbContextOptions)
        //{ 

        //} 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BIP45B1\SQLEXPRESS;Database=TheBestWay;Trusted_Connection=True;").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-BIP45B1\SQLEXPRESS;Database=TheBestWay;Trusted_Connection=True;").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GetPostViewModel>().HasNoKey();
            builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }


    }
}
