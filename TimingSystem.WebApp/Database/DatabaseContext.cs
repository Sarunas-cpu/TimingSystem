using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimingSystem.WebApp.Database.Entities;

namespace TimingSystem.WebApp.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Tournament> tournaments { get; set; }
    }
}
