using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Data
{
    public static class DbSeeder
    {
        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<NewsDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                    await SeedClassificationsAsync(context);
                    await SeedDefaultUserAsync(userManager);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }


        private static async Task SeedClassificationsAsync(NewsDbContext context)
        {
            if (await context.Classifications.AnyAsync())
            {
                return;
            }

            var classifications = new List<Classification>
        {
            new Classification
            {
                Name = "Health News",
                IsDelete = false,
                CreatedAt = DateTime.Now,
            },
                   new Classification
            {
                Name = "Science and Technology News",
                IsDelete = false,
                CreatedAt = DateTime.Now,
            },
                          new Classification
            {
                Name = "Social News",
                IsDelete = false,
                CreatedAt = DateTime.Now,
            },
                                 new Classification
            {
                Name = "Sports News",
                IsDelete = false,
                CreatedAt = DateTime.Now,
            },
                                        new Classification
            {
                Name = "Local News",
                IsDelete = false,
                CreatedAt = DateTime.Now,
            },
        };

            await context.Classifications.AddRangeAsync(classifications);
            await context.SaveChangesAsync();
        }


        private static async Task SeedDefaultUserAsync(UserManager<IdentityUser> userManager)
        {
            if (await userManager.Users.AnyAsync())
            {
                return;
            }

            var user = new IdentityUser
            {
                UserName = "m.h.jmian@gmail.com",
                Email = "m.h.jmian@gmail.com",
                EmailConfirmed = true,
            };

            await userManager.CreateAsync(user, "@Mohammed123#");
        }
    }
}
