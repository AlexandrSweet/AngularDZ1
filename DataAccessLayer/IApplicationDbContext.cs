using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IApplicationDbContext
    {
        public DbSet<UserPrivate> UserPrivate { get; set; }
        public DbSet<UserPublic> UserPublic { get; set; }
    }
}
