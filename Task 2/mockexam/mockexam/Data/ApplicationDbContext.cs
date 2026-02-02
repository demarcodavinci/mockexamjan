using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mockexam.Models;

namespace mockexam.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<mockexam.Models.Rooms> Rooms { get; set; } = default!;
        public DbSet<mockexam.Models.Staff> Staff { get; set; } = default!;
        public DbSet<mockexam.Models.Bookings> Bookings { get; set; } = default!;
    }
}
