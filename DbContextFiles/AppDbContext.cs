using IndigoBilet1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndigoBilet1.DbContextFiles
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
