using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiTest.Models.Hero
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Hero> HeroItems { get; set; }

    }
}