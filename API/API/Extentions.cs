using System;
using System.Data.Common;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace API
{
    public static class StartupExtensions
    {
        public static void Migrate(this IServiceCollection services, DbConnection connection)
        {
            var path = Path.GetDirectoryName(
                    Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase ?? string.Empty)
                        .Path));
                var evolve = new Evolve.Evolve(connection, Console.WriteLine)
                {
                    Locations = new[] {Path.Join(path, "Migrations")},
                    IsEraseDisabled = true,
                };

                evolve.Migrate();
        }
    }
}