using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZZB.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ZZBDbContext>
    {
        public ZZBDbContext CreateDbContext(string[] args )
        {
            var optionsBuilder = new DbContextOptionsBuilder<ZZBDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolContext6;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ZZBDbContext(optionsBuilder.Options);
        }


        //public ZZBDbContext CreateDbContext(string[] args)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.json")
        //     .Build();
        //    var builder = new DbContextOptionsBuilder();
        //    builder.UseSqlServer("server=.;uid=sa;pwd=102489;database=IdentityDemo");
        //    return new ZZBDbContext(builder.Options);

        //}
    }
}

