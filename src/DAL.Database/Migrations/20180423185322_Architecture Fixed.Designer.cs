﻿// <auto-generated />
using DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using UserService.Domain.Models;

namespace DAL.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180423185322_Architecture Fixed")]
    partial class ArchitectureFixed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnemyService.Domain.Models.Enemy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentHP");

                    b.Property<int>("MaxDamage");

                    b.Property<int>("MaxHP");

                    b.Property<string>("Name");

                    b.Property<int>("RewardGold");

                    b.Property<int>("RewardXP");

                    b.HasKey("ID");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("InventoryItem.Domain.InventoryItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ItemID");

                    b.Property<int?>("PlayerID");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.HasIndex("PlayerID");

                    b.ToTable("InventoryItem");
                });

            modelBuilder.Entity("ItemService.Domain.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("NamePlural");

                    b.HasKey("ID");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("LocationService.Domain.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("EnemyLivingHereID");

                    b.Property<int?>("ItemRequiredToEnterID");

                    b.Property<string>("Map");

                    b.Property<string>("Name");

                    b.Property<int?>("QuestAvailableHereID");

                    b.HasKey("ID");

                    b.HasIndex("EnemyLivingHereID");

                    b.HasIndex("ItemRequiredToEnterID");

                    b.HasIndex("QuestAvailableHereID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("LootItemService.Domain.Models.LootItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DropPercentage");

                    b.Property<int?>("EnemyID");

                    b.Property<bool>("IsDefaultItem");

                    b.Property<int?>("ItemID");

                    b.HasKey("ID");

                    b.HasIndex("EnemyID");

                    b.HasIndex("ItemID");

                    b.ToTable("LootItem");
                });

            modelBuilder.Entity("PlayerQuestService.Domain.Models.PlayerQuest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCompleted");

                    b.Property<int?>("PlayerID");

                    b.Property<int?>("QuestID");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("QuestID");

                    b.ToTable("PlayerQuest");
                });

            modelBuilder.Entity("PlayerService.Domain.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentHP");

                    b.Property<int?>("CurrentLocationID");

                    b.Property<int?>("CurrentWeaponID");

                    b.Property<int>("Gold");

                    b.Property<int>("MaxHP");

                    b.Property<string>("Name");

                    b.Property<int>("XP");

                    b.HasKey("ID");

                    b.HasIndex("CurrentLocationID");

                    b.HasIndex("CurrentWeaponID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("QuestCompletionItemService.Domain.Models.QuestCompletionItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ItemID");

                    b.Property<int>("Quantity");

                    b.Property<int?>("QuestID");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.HasIndex("QuestID");

                    b.ToTable("QuestCompletionItem");
                });

            modelBuilder.Entity("QuestService.Domain.Models.Quest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("RewardGold");

                    b.Property<int?>("RewardItemID");

                    b.Property<int>("RewardXP");

                    b.HasKey("ID");

                    b.HasIndex("RewardItemID");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("UserService.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateChanged");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Email");

                    b.Property<string>("ImgUrl");

                    b.Property<bool>("IsEmailConfirmed");

                    b.Property<string>("Password");

                    b.Property<int>("PlayerID");

                    b.Property<int>("UserRole");

                    b.Property<string>("Username");

                    b.Property<string>("ValidationCode");

                    b.HasKey("Id");

                    b.HasIndex("PlayerID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeaponService.Domain.Models.Weapon", b =>
                {
                    b.HasBaseType("ItemService.Domain.Models.Item");

                    b.Property<int>("MaxDamage");

                    b.Property<int>("MinDamage");

                    b.ToTable("Weapon");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("InventoryItem.Domain.InventoryItem", b =>
                {
                    b.HasOne("ItemService.Domain.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID");

                    b.HasOne("PlayerService.Domain.Models.Player")
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerID");
                });

            modelBuilder.Entity("LocationService.Domain.Models.Location", b =>
                {
                    b.HasOne("EnemyService.Domain.Models.Enemy", "EnemyLivingHere")
                        .WithMany()
                        .HasForeignKey("EnemyLivingHereID");

                    b.HasOne("ItemService.Domain.Models.Item", "ItemRequiredToEnter")
                        .WithMany()
                        .HasForeignKey("ItemRequiredToEnterID");

                    b.HasOne("QuestService.Domain.Models.Quest", "QuestAvailableHere")
                        .WithMany()
                        .HasForeignKey("QuestAvailableHereID");
                });

            modelBuilder.Entity("LootItemService.Domain.Models.LootItem", b =>
                {
                    b.HasOne("EnemyService.Domain.Models.Enemy")
                        .WithMany("LootTable")
                        .HasForeignKey("EnemyID");

                    b.HasOne("ItemService.Domain.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID");
                });

            modelBuilder.Entity("PlayerQuestService.Domain.Models.PlayerQuest", b =>
                {
                    b.HasOne("PlayerService.Domain.Models.Player")
                        .WithMany("Quests")
                        .HasForeignKey("PlayerID");

                    b.HasOne("QuestService.Domain.Models.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestID");
                });

            modelBuilder.Entity("PlayerService.Domain.Models.Player", b =>
                {
                    b.HasOne("LocationService.Domain.Models.Location", "CurrentLocation")
                        .WithMany()
                        .HasForeignKey("CurrentLocationID");

                    b.HasOne("WeaponService.Domain.Models.Weapon", "CurrentWeapon")
                        .WithMany()
                        .HasForeignKey("CurrentWeaponID");
                });

            modelBuilder.Entity("QuestCompletionItemService.Domain.Models.QuestCompletionItem", b =>
                {
                    b.HasOne("ItemService.Domain.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID");

                    b.HasOne("QuestService.Domain.Models.Quest")
                        .WithMany("QuestCompletionItems")
                        .HasForeignKey("QuestID");
                });

            modelBuilder.Entity("QuestService.Domain.Models.Quest", b =>
                {
                    b.HasOne("ItemService.Domain.Models.Item", "RewardItem")
                        .WithMany()
                        .HasForeignKey("RewardItemID");
                });

            modelBuilder.Entity("UserService.Domain.Models.User", b =>
                {
                    b.HasOne("PlayerService.Domain.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
