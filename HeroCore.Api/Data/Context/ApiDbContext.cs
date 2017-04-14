using HeroCore.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroCore.Api.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Hero> HeroItems { get; set; }
        public DbSet<Quest> QuestItems { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            /* Quest */
            modelBuilder.Entity<Quest>()
                .ToTable("Quest");
            modelBuilder.Entity<Quest>()
                .Property(q => q.HeroId)
                .IsRequired();
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.Hero)
                .WithMany(h => h.Quests);

            /* Hero */
            modelBuilder.Entity<Hero>()
                .ToTable("Hero");
            modelBuilder.Entity<Hero>()
                .Property(h => h.Name)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}