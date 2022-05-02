using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using House_API.Models;
using Microsoft.EntityFrameworkCore;

namespace House_API.Data
{
    public class HouseContext : DbContext
    {
        public DbSet<House> Houses => Set<House>();
                public HouseContext (DbContextOptions<HouseContext> options) : base(options)
        {
        }
    }
}