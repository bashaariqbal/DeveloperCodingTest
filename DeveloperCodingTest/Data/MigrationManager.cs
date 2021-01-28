using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DeveloperCodingTest.Data
{
    public static class MigrationManager
    {

        public static IHost MigrateDataBase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DeveloperCodingContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch(Exception)
                    {
                        throw;
                    }
                }

            }
            return host;
        }
    }
}
