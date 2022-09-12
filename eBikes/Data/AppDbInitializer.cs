
using eBikes.Data.Static;
using eBikes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBikes.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Road bikes",
                            imageName = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",

                            Description = "This is the description of the Road bikes"
                        },
                        new Category()
                        {
                            Name = "Mountain bikes",
                            imageName = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",

                            Description = "This is the description of the Mountain bikes"
                        },
                    });
                    context.SaveChanges();
                }

                //Blogs
                if (!context.Blogs.Any())
                {
                    context.Blogs.AddRange(new List<Blog>()
                    {
                        new Blog()
                        {
                            Title = "Blog 1",
                            Description = "This is the Blog of the second race",
                            Author = "Edi Mimo",
                            imageName = "http://dotnethow.net/images/actors/actor-4.jpeg",

                        },
                        new Blog()
                        {
                            Title = "Blog 2",
                            Description = "This is the Blog of the first race",
                            Author = "Sokol Nimi",
                            imageName = "http://dotnethow.net/images/actors/actor-5.jpeg",

                        }
                    });
                    context.SaveChanges();
                }

                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Raven",
                            Description = "Cyclocross is not for the faint of heart. It’s all about getting dirty, and every weekend, hardcore racers endure cold, pain, and filth.",
                            Price = 200,
                            imageName = "https://cdn.shopify.com/s/files/1/2318/5263/files/Name1_2048x2048.jpg?v=1572560469",

                            Created_at = DateTime.Now.AddDays(-10),
                            Updated_at = DateTime.Now.AddDays(-2),
                            CategoryId = 6,
                            Quantity = 3,
                        },
                        new Product()
                        {
                            Name = "Thunderbolt",
                            Description = "Pivot Cycles makes fantastic mountain bikes, but its names have never caught my attention.",
                            Price = 150,
                            imageName = "https://cdn.shopify.com/s/files/1/2318/5263/files/Name4_2048x2048.jpg?v=1572560509",

                            Created_at = DateTime.Now.AddDays(-10),
                            Updated_at = DateTime.Now.AddDays(-2),
                            CategoryId = 7,
                            Quantity = 2,

                        }
                    });
                    context.SaveChanges();
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@ebikes.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@ebikes.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}