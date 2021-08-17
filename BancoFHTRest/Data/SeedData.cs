using BancoFHTRest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoFHTRest.Data
{
    public class SeedData
    {
        public static void InitDatabase(IServiceProvider serviceProvider)
        {
            using
                (var context = new BancoFHTContext(
                    serviceProvider.GetRequiredService<DbContextOptions<BancoFHTContext>>()
                )
            )
            {
                context.Database.Migrate();

                
                
            }
        }
    }
}
