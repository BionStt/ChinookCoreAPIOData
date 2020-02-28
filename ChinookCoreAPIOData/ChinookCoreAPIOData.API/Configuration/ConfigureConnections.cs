﻿using System;
using System.Runtime.InteropServices;
 using ChinookCoreAPIOData.Data;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

 namespace ChinookCoreAPIOData.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = String.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = configuration.GetConnectionString("ChinookDbWindows") ??
                                 "Server=.;Database=Chinook;Trusted_Connection=True;Application Name=ChinookCoreAPIOData";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                connection = configuration.GetConnectionString("ChinookDbDocker") ??
                                 "Server=localhost,1433;Database=Chinook;User=sa;Password=Pa55w0rd;Trusted_Connection=False;Application Name=ChinookCoreAPIOData";
            }
            
            services.AddDbContextPool<ChinookContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}