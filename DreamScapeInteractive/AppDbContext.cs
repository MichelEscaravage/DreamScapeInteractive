using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DreamScapeInteractive.Data.Classes;
using Windows.Devices.PointOfService.Provider;
using DreamScapeInteractive.Data.Lists;

namespace DreamScapeInteractive
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Magic_Property> MagicProperties { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Trade> Trades { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=;" +
                "database=csd_DreamScapeInteractive",
                ServerVersion.Parse("10.4.17-mariadb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-many relationship between Item and MagicProperty
            modelBuilder.Entity<Item>()
                .HasOne(i => i.MagicProperty)
                .WithMany(mp => mp.Items)
                .HasForeignKey(i => i.MagicPropertyId);

            // Many-to-one relationship between Item and ItemType
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Type)
                .WithMany(it => it.Items)
                .HasForeignKey(i => i.TypeId);

            // One-to-many relationship between User and UserItem
            modelBuilder.Entity<UserItem>()
                .HasKey(ui => ui.UserItemId);

            // One-to-one relationship between Trade and UserItem (User 1)
            modelBuilder.Entity<Trade>()
                .HasOne(t => t.UserItem1)
                .WithMany()
                .HasForeignKey(t => t.UserItem1Id);

            // One-to-one relationship between Trade and UserItem (User 2)
            modelBuilder.Entity<Trade>()
                .HasOne(t => t.UserItem2)
                .WithMany()
                .HasForeignKey(t => t.UserItem2Id);

            // Get your data first
            UserItemList userItemList = new UserItemList();
            ItemList itemList = new ItemList();
            Magic_PropertyList magic_PropertyList = new Magic_PropertyList();
            TradeList tradeList = new TradeList();
            TypeList typeList = new TypeList();
            UserList userList = new UserList();

            List<UserItem> userItems = userItemList.GetUserItemList(); // First, get UserItems
            List<Item> items = itemList.GetItemList();
            List<Magic_Property> magic_Properties = magic_PropertyList.GetMagicPropertyList();
            List<Trade> trades = tradeList.GetTradeList(); // Then, get Trades
            List<ItemType> types = typeList.GetItemTypeList();
            List<User> users = userList.GetUserList();

            // Seed the data in the correct order
            modelBuilder.Entity<UserItem>().HasData(userItems.ToArray()); // Seed UserItems first
            modelBuilder.Entity<Magic_Property>().HasData(magic_Properties.ToArray());
            modelBuilder.Entity<ItemType>().HasData(types.ToArray());
            modelBuilder.Entity<User>().HasData(users.ToArray());

            modelBuilder.Entity<Item>().HasData(items.ToArray());

            // Now, seed the Trades table, which depends on UserItem data
            modelBuilder.Entity<Trade>().HasData(trades.ToArray());
        }
    }

    
}


