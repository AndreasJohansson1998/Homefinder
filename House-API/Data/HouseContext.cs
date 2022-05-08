using House_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace House_API.Data
{
    public class HouseContext : IdentityDbContext
    {
        public DbSet<House> Houses => Set<House>();
        public DbSet<Interest> Interests => Set<Interest>();
        
        public HouseContext(DbContextOptions<HouseContext> options) : base(options)
        {
        }
    }
}