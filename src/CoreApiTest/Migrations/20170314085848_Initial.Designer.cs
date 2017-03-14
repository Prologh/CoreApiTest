using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreApiTest.Data.Context;

namespace CoreApiTest.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20170314085848_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreApiTest.Models.Hero.Hero", b =>
                {
                    b.Property<int>("IdHero")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsRetired");

                    b.Property<string>("Name");

                    b.HasKey("IdHero");

                    b.ToTable("HeroItems");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest.Quest", b =>
                {
                    b.Property<int>("IdQuest")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdHero");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("Title");

                    b.HasKey("IdQuest");

                    b.HasIndex("IdHero");

                    b.ToTable("QuestItems");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest.Quest", b =>
                {
                    b.HasOne("CoreApiTest.Models.Hero.Hero", "Hero")
                        .WithMany("Quests")
                        .HasForeignKey("IdHero")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
