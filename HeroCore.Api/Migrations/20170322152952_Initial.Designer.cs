using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HeroCore.Api.Data.Context;

namespace HeroCore.Api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20170322152952_Initial")]
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HeroId");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Quest");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest", b =>
                {
                    b.HasOne("CoreApiTest.Models.Hero", "Hero")
                        .WithMany("Quests")
                        .HasForeignKey("HeroId");
                });
        }
    }
}
