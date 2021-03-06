﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using AngleSharp;
using AngleSharp.Parser.Html;
using FMCApp.Data;
using FMCApp.Data.Models;
using FMCApp.Data.Models.Enums;
using FMCApp.ViewModels.ViewModels.VisualizationModels.Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Array;

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
            //var db = serviceProvider.GetService<FMCAppContext>();
            //var userManager = serviceProvider.GetService<UserManager<FMCAppUser>>();
            ////Console.WriteLine(db.Users.Count());
            //// TODO : Code here 
            ////var config = Configuration.Default.WithDefaultLoader();
            ////var context = BrowsingContext.New(config);
            ////for (int i = 4400; i <= 4469; i++)
            ////{
            ////    var url = "https://www.boxofficemojo.com/news/?id=" + i;
            ////    var document = context.OpenAsync(url).GetAwaiter().GetResult();
            ////    var newsTitle = document.QuerySelector(".h1").TextContent; 
            //    var newsContent = document.QuerySelector()

            int numberOfCandles = int.Parse(Console.ReadLine());
            List<int> result = Console.ReadLine().Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
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



