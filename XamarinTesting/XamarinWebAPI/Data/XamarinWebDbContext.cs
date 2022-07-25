using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Data
{
    public class XamarinWebDbContext : DbContext
    {
        public XamarinWebDbContext(DbContextOptions<XamarinWebDbContext> options) : base(options)
        {
        }
        public DbSet<Profile> Profile { get; set; }

    }
}
