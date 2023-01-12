using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Student { get;set; }
        public StudentDbContext()
        {

        }

        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(e => e.Id);
        }
    }
}
