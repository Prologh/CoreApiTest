using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiTest.Models.Hero;
using CoreApiTest.Models.Quest;

namespace CoreApiTest.Data.Context
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
            //builder.Entity<Hero>()

            //    .HasOne(q => q.Quests)
            //    .WithOne(h => h.Owner);
        }

        public DbSet<Hero> HeroItems { get; set; }
        public DbSet<Quest> QuestItems { get; set; }
    }
}