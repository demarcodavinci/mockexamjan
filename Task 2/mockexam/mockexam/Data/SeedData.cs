using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mockexam.Models;
using System.Threading.Tasks;

namespace mockexam.Data
{
    public class SeedData
    {
        public static async Task mockexamAsync(ApplicationDbContext context)
        {
            if (await context.Rooms.AnyAsync() == false)
            {
                var SeededRooms = new List<Rooms>
                {
                    new Rooms
                    {
                        RoomName = "Room 1",
                        Description = "This room is a newly furnished office space.",
                        Capacity = 10,
                        HourlyRate = 120.99,
                        City = "Wolverhampton",
                        isAvailable = true,

                    },
                    new Rooms
                    {
                        RoomName = "Room 2",
                        Description = "This room is a newly furnished apartment",
                        Capacity = 4,
                        HourlyRate = 30.49,
                        City = "Wednesbury",
                        isAvailable = true,

                    },
                    new Rooms
                    {
                        RoomName = "Room 3",
                        Description = "This room is abandoned.",
                        Capacity = 1,
                        HourlyRate = 1.99,
                        City = "Wednesbury",
                        isAvailable = false,

                    }

                };
                await context.Rooms.AddRangeAsync(SeededRooms);
                await context.SaveChangesAsync();
            }

        }
        public static async Task SeedRoles(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Manager", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
                }
            }
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com", EmailConfirmed = true };
                await userManager.CreateAsync(adminUser, "Admin123!");
            }
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.CreateAsync(adminUser, "Admin");
            }
        }
    } 
}
