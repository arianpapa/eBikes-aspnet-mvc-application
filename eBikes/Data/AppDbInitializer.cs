
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
                            imageName = "https://www.edinburghbicycle.com/images/3816/1537/1536/giant-colorbconcrete.jpg",
                            Description = "This is the description of the Road bikes"
                        },
                        new Category()
                        {
                            Name = "Mountain bikes",
                            imageName = "https://www.edinburghbicycle.com/images/1116/1537/1538/mountain-bike.jpeg",
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
                            Title = "This sunday trip to Bovilla",
                            Description = "Our group is organizing a trip to bovilla lake this saturday. " +
                            "Departure will be at 8:00 from Mother Teresa Square. For more information contact the number 355123.",
                            Author = "Edi Sokoli",
                            imageName = "https://i0.wp.com/alpventurer.com/wp-content/uploads/2019/03/Bovilla-lake-2020-scaled.jpg?resize=771%2C514&ssl=1",

                        },
                        new Blog()
                        {
                            Title = "Lake Race",
                            Description = "Grab your bike and assemble your crew to take on a mountains-to-low country " +
                            "challenge on two wheels over the course of 48 hours.",
                            Author = "Jonel Miska",
                            imageName = "https://images.squarespace-cdn.com/content/v1/5a20ab3e010027b949b0534d/1512508984750-2J5AVRAIEAWSTIHDVJON/MoabSkinnyTireEvents_04.jpg?format=300w",

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