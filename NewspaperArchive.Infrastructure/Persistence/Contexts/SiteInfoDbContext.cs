using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Infrastructure.Persistence.Contexts
{
    public class SiteInfoDbContext : DbContext
    {

        public SiteInfoDbContext(DbContextOptions<SiteInfoDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Query<UserModel>();
        //}
        public virtual DbSet<UserModel> GetUserInfo { get; set; }
        //public virtual DbSet<LoginModel> LoginModel { get; set; }
    }
    //public class SiteInfoDbContext : ObjectContext
    //{
    //    public SiteInfoDbContext(string ConnectionString) : base(ConnectionString)
    //    {
    //    }
    //   // public virtual DbSet<UserModel> GetUserInfo { get; set; }
    //}
}
