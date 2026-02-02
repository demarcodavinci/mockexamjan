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
            if (await context.Rooms.AnyAsync() == false) // checks for any rooms in table
            {
                var SeededRooms = new List<Rooms> // creates a new list for rooms to be seeded
                {
                    new Rooms // individual rooms
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
                await context.SaveChangesAsync(); // saves changes
            }

        }
        public static async Task SeedRoles(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Manager", "Staff", "User" }; // list of role names
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
                }
            }
            var adminUser = await userManager.FindByEmailAsync("admin@example.com"); // admin credentials
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com", EmailConfirmed = true };
                await userManager.CreateAsync(adminUser, "Admin123!");
            }
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.CreateAsync(adminUser, "Admin");
            }

            var managerpositionUser = await userManager.FindByEmailAsync("manager@example.com"); // manager credentials
            if (managerpositionUser == null)
            {
                managerpositionUser = new IdentityUser { UserName = "manager@example.com", Email = "manager@example.com", EmailConfirmed = true };
                await userManager.CreateAsync(managerpositionUser, "Manager123!");
            }
            if (!await userManager.IsInRoleAsync(managerpositionUser, "Manager"))
            {
                await userManager.CreateAsync(managerpositionUser, "Manager");
            }

            var staffUser = await userManager.FindByEmailAsync("staff@example.com"); // staff credentials
            if (staffUser == null)
            {
                staffUser = new IdentityUser { UserName = "staff@example.com", Email = "staff@example.com", EmailConfirmed = true };
                await userManager.CreateAsync(staffUser, "Staff123!");
            }
            if (!await userManager.IsInRoleAsync(staffUser, "Staff"))
            {
                await userManager.CreateAsync(staffUser, "Staff");
            }

            var standardUser1 = await userManager.FindByEmailAsync("user1@example.com");
            if (standardUser1 == null)
            {
                standardUser1 = new IdentityUser { UserName = "user1@example.com", Email = "user1@example.com", EmailConfirmed = true };
                await userManager.CreateAsync(standardUser1, "User1123!");
            }
            if (!await userManager.IsInRoleAsync(standardUser1, "User"))
            {
                await userManager.CreateAsync(standardUser1, "User");
            }
        }
    }
}
