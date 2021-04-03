using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<ApiRequestsLogs> ApiRequestsLogs { get; set; }
        public DbSet<UserPrivate> UserPrivate { get; set; }
        public DbSet<UserPublic> UserPublic { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
