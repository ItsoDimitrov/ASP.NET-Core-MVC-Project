using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using AngleSharp;
using AngleSharp.Parser.Html;
using FMCApp.Data;
using FMCApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            
            var db = serviceProvider.GetService<FMCAppContext>();
            //Console.WriteLine(db.Users.Count());
            // TODO : Code here 
            //var config = Configuration.Default.WithDefaultLoader();
            //var context = BrowsingContext.New(config);
            //for (int i = 4400; i <= 4469; i++)
            //{
            //    var url = "https://www.boxofficemojo.com/news/?id=" + i;
            //    var document = context.OpenAsync(url).GetAwaiter().GetResult();
            //    var newsTitle = document.QuerySelector(".h1").TextContent; 
            //    var newsContent = document.QuerySelector()
            //}


        }


        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<FMCAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

        }
    }
}



