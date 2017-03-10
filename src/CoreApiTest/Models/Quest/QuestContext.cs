using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiTest.Models.Quest
{
    public class QuestContext : DbContext
    {
        public QuestContext(DbContextOptions<QuestContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Quest> QuestItems { get; set; }

    }
}