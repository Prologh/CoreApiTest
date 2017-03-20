using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreApiTest.Data.Context;

namespace CoreApiTest.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20170320150716_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreApiTest.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsRetired");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HeroItems");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IdHero");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("IdHero");

                    b.ToTable("QuestItems");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest", b =>
                {
                    b.HasOne("CoreApiTest.Models.Hero", "Hero")
                        .WithMany("Quests")
                        .HasForeignKey("IdHero");
                });
        }
    }
}
