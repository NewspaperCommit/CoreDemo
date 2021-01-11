using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using NewspaperArchive.Application.Common.Dtos;
using NewspaperArchive.Application.Common.Dtos.User;

namespace NewspaperArchive.Infrastructure.Persistence.Contexts
{
   public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<EventModel> Event { get; set; }
        public virtual DbSet<EventListDTO> EventList { get; set; }
        public virtual DbSet<LoginStatusDTO> Login { get; set; }

        public virtual DbSet<ResultDTO> StatusValue { get; set; }
        public virtual DbSet<EventTypeModel> EventType { get; set; }
        public virtual DbSet<VenueModel> Venue { get; set; }
        public virtual DbSet<CheckUserExistDto> CheckUserExist { get; set; }

    }
}
