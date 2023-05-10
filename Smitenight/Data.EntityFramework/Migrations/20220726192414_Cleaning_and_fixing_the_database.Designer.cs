﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smitenight.Persistence.Data.EntityFramework;

#nullable disable

namespace SmitenightApp.Persistence.Migrations
{
    [DbContext(typeof(SmitenightDbContext))]
    [Migration("20220726192414_Cleaning_and_fixing_the_database")]
    partial class Cleaning_and_fixing_the_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SmitenightApp.Domain.Models.Abilities.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AbilityType")
                        .HasColumnType("int");

                    b.Property<string>("Cooldown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GodId")
                        .HasColumnType("int");

                    b.Property<int>("SmiteId")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GodId");

                    b.ToTable("Abilities", (string)null);
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Abilities.AbilityRank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.ToTable("AbilityRanks", (string)null);
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Abilities.AbilityTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.ToTable("AbilityTags", (string)null);
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Gods.BasicAttackDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GodId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GodId");

                    b.ToTable("BasicAttackDescriptions", (string)null);
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Gods.God", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("AttackSpeed")
                        .HasColumnType("real");

                    b.Property<float>("AttackSpeedPerLevel")
                        .HasColumnType("real");

                    b.Property<bool>("AutoBanned")
                        .HasColumnType("bit");

                    b.Property<string>("GodCardUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GodIconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("HealthPerFive")
                        .HasColumnType("int");

                    b.Property<int>("HealthPerLevel")
                        .HasColumnType("int");

                    b.Property<float>("Hp5PerLevel")
                        .HasColumnType("real");

                    b.Property<bool>("LatestGod")
                        .HasColumnType("bit");

                    b.Property<string>("Lore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MagicProtection")
                        .HasColumnType("real");

                    b.Property<float>("MagicProtectionPerLevel")
                        .HasColumnType("real");

                    b.Property<int>("MagicalPower")
                        .HasColumnType("int");

                    b.Property<float>("MagicalPowerPerLevel")
                        .HasColumnType("real");

                    b.Property<int>("Mana")
                        .HasColumnType("int");

                    b.Property<float>("ManaPerFive")
                        .HasColumnType("real");

                    b.Property<int>("ManaPerLevel")
                        .HasColumnType("int");

                    b.Property<float>("Mp5PerLevel")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnFreeRotation")
                        .HasColumnType("bit");

                    b.Property<string>("Pantheon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhysicalPower")
                        .HasColumnType("int");

                    b.Property<float>("PhysicalPowerPerLevel")
                        .HasColumnType("real");

                    b.Property<float>("PhysicalProtection")
                        .HasColumnType("real");

                    b.Property<float>("PhysicalProtectionPerLevel")
                        .HasColumnType("real");

                    b.Property<string>("Pros")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("SmiteId")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gods", (string)null);
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Items.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("ChildItemId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Glyph")
                        .HasColumnType("bit");

                    b.Property<string>("ItemIconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemTier")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RestrictedRoles")
                        .HasColumnType("int");

                    b.Property<int?>("RootItemId")
                        .HasColumnType("int");

                    b.Property<string>("SecondaryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SmiteId")
                        .HasColumnType("int");

                    b.Property<bool>("StartingItem")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChildItemId");

                    b.HasIndex("RootItemId");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Items.ItemDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemDescriptions", (string)null);
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Abilities.Ability", b =>
                {
                    b.HasOne("SmitenightApp.Domain.Models.Gods.God", "God")
                        .WithMany("Abilities")
                        .HasForeignKey("GodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("God");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Abilities.AbilityRank", b =>
                {
                    b.HasOne("SmitenightApp.Domain.Models.Abilities.Ability", "Ability")
                        .WithMany("AbilityRanks")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Abilities.AbilityTag", b =>
                {
                    b.HasOne("SmitenightApp.Domain.Models.Abilities.Ability", "Ability")
                        .WithMany("AbilityTags")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Gods.BasicAttackDescription", b =>
                {
                    b.HasOne("SmitenightApp.Domain.Models.Gods.God", "God")
                        .WithMany("BasicAttackDescriptions")
                        .HasForeignKey("GodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("God");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Items.Item", b =>
                {
                    b.HasOne("SmitenightApp.Domain.Models.Items.Item", "ChildItem")
                        .WithMany()
                        .HasForeignKey("ChildItemId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SmitenightApp.Domain.Models.Items.Item", "RootItem")
                        .WithMany()
                        .HasForeignKey("RootItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChildItem");

                    b.Navigation("RootItem");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Items.ItemDescription", b =>
                {
                    b.HasOne("SmitenightApp.Domain.Models.Items.Item", "Item")
                        .WithMany("ItemDescriptions")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Abilities.Ability", b =>
                {
                    b.Navigation("AbilityRanks");

                    b.Navigation("AbilityTags");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Gods.God", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("BasicAttackDescriptions");
                });

            modelBuilder.Entity("SmitenightApp.Domain.Models.Items.Item", b =>
                {
                    b.Navigation("ItemDescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}