﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

using CoreApiTest.Data.Context;

namespace CoreApiTest.Migrations
{
    [DbContext(typeof(HeroContext))]
    partial class HeroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreApiTest.Models.Hero.Hero", b =>
                {
                    b.Property<int>("HeroId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsRetired");

                    b.Property<string>("Name");

                    b.HasKey("HeroId");

                    b.ToTable("HeroItems");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest.Quest", b =>
                {
                    b.Property<int>("QuestId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("QuestOwnerId");

                    b.Property<string>("Title");

                    b.HasKey("QuestId");

                    b.HasIndex("QuestOwnerId");

                    b.ToTable("QuestItems");
                });

            modelBuilder.Entity("CoreApiTest.Models.Quest.Quest", b =>
                {
                    b.HasOne("CoreApiTest.Models.Hero.Hero", "Hero")
                        .WithMany("Quests")
                        .HasForeignKey("QuestOwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
