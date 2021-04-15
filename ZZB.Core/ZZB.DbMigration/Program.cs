using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using ZZB.DAL;
using ZZB.DAL.Admin;

namespace ZZB.DbMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json");

            var configuration = configurationBuilder.Build();
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContextPool<ZZBDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            var service = serviceCollection.BuildServiceProvider();

            var instance = ActivatorUtilities.CreateInstance<AddressCurd>(service);

            instance.Run();

            Console.WriteLine("Hello World!");

        }
    }

    public class AddressCurd
    {
        private readonly ZZBDbContext _context;

        public AddressCurd(ZZBDbContext context)
        {
            _context = context;
        }
        public void Run()
        {
            //初始化数据

            _context.Set<User>().Add(new User
            {
                UserName = "王小12明",
                IsAdministrator = true,
                PassWork = "18012155050"
            });
            _context.SaveChanges();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ZZBDbContext>
    {
        public ZZBDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json");

            var configuration = configurationBuilder.Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ZZBDbContext>();

            dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ZZBDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
