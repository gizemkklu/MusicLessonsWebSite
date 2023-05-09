using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=MusicDb; integrated security=true;");
        }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
   
    }
}
