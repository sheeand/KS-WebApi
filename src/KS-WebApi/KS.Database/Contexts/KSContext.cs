using KS.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KS.Database.Contexts
{
    public class KSContext : DbContext
    {
        // this is a MS Core thing
        public KSContext(DbContextOptions<KSContext> options) : base(options) { }

        public DbSet<UserEntity> UserTableAccess { get; set; }
    }
}
