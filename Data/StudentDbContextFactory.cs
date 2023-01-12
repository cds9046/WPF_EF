using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
    {
        public StudentDbContext CreateDbContext(string[] args = null)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
            var configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("DefaultConnection");


            var options = new DbContextOptionsBuilder<StudentDbContext>();
            options.UseOracle(connectionString, b => b.UseOracleSQLCompatibility("11"));

            return new StudentDbContext(options.Options);
        }
    }
}
