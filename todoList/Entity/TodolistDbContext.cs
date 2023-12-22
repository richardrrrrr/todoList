using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todoList.Entity
{
    public class TodolistDbContext:DbContext
    {
        public DbSet<ToDolist> Todolists { get; set; }
        public DbSet<Account> Accounts { get; set; }
        
        public TodolistDbContext(DbContextOptions<TodolistDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  
            modelBuilder.Entity<ToDolist>().ToTable("Todolists ");
            modelBuilder.Entity<Account>().ToTable("Accounts");

            //Seed Data
            base.OnModelCreating(modelBuilder);

            // 讀取並反序列化 account 的 JSON 數據
            string accountJson = System.IO.File.ReadAllText("account.json");
            List<Account> accounts = System.Text.Json.JsonSerializer.Deserialize<List<Account>>(accountJson);

            // 為 account 實體添加種子數據
            foreach (Account account in accounts)
            {
                modelBuilder.Entity<Account>().HasData(account);
            }

            // 讀取並反序列化 todolist 的 JSON 數據
            string todolistJson = System.IO.File.ReadAllText("todolist.json");
            List<ToDolist> todolists = System.Text.Json.JsonSerializer.Deserialize<List<ToDolist>>(todolistJson);

            // 為 todolist 實體添加種子數據
            foreach (ToDolist todolist in todolists)
            {
                modelBuilder.Entity<ToDolist>().HasData(todolist);
            }
        }
    }
}
