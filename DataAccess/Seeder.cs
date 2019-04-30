using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Seeder
    {
        public static async Task Initialize(BlogDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(role);
                role = new IdentityRole
                {
                    Name = "Moderator"
                };
                await roleManager.CreateAsync(role);
                role = new IdentityRole
                {
                    Name = "Blogger"
                };
                await roleManager.CreateAsync(role);
            }
            if (!context.Users.Any())
            {
                User user = new User
                {
                    FirstName = "Predrag",
                    LastName = "Jovicic",
                    Biography = "I am an administrator",
                    Email = "predragjovicic333@gmail.com",
                    UserName = "adminpeksi",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "P@ssWord3!");
                await userManager.AddToRoleAsync(user, "Administrator");
                user = new User
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Biography = "Example of a biography",
                    Email = "johndoe@mail.com",
                    UserName = "janedoe",
                    EmailConfirmed = true,
                    UrlLinkedIn = "www.linkedin.com/johndoe"
                };
                await userManager.CreateAsync(user, "P@ssWord3!");
                await userManager.AddToRoleAsync(user, "Blogger");
            }
        }
    }
}
