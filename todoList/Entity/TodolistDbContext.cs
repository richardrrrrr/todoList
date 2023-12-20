using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using todoList.Models;

namespace todoList.Entity
{
    public class TodolistDbContext:DbContext
    {
        public DbSet<todolist> Todolists { get; set; }
        public DbSet<account> Accounts { get; set; }
        
        public TodolistDbContext(DbContextOptions<TodolistDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  
            modelBuilder.Entity<todolist>().ToTable("Todolists ");
            modelBuilder.Entity<account>().ToTable("Accounts");

            //Seed Data
            base.OnModelCreating(modelBuilder);

            // 讀取並反序列化 account 的 JSON 數據
            string accountJson = System.IO.File.ReadAllText("account.json");
            List<account> accounts = System.Text.Json.JsonSerializer.Deserialize<List<account>>(accountJson);

            // 為 account 實體添加種子數據
            foreach (account account in accounts)
            {
                modelBuilder.Entity<account>().HasData(account);
            }

            // 讀取並反序列化 todolist 的 JSON 數據
            string todolistJson = System.IO.File.ReadAllText("todolist.json");
            List<todolist> todolists = System.Text.Json.JsonSerializer.Deserialize<List<todolist>>(todolistJson);

            // 為 todolist 實體添加種子數據
            foreach (todolist todolist in todolists)
            {
                modelBuilder.Entity<todolist>().HasData(todolist);
            }
        }
    }
}
