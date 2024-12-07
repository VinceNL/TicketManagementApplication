﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Infrastructure.Extensions
{
    public static class Seed
    {
        static string user1 = Guid.NewGuid().ToString();
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            string USER_EMAIL = "test@gmail.com";

            //create user
            var appUser = new User
            {
                Id = user1,
                Email = USER_EMAIL,
                NormalizedEmail = USER_EMAIL.ToUpper(),
                UserName = USER_EMAIL,
                NormalizedUserName = USER_EMAIL.ToUpper(),
                EmailConfirmed = true,
            };

            //set user password
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            appUser.PasswordHash = passwordHasher.HashPassword(appUser, "StrongP@ssw0rd!");

            //seed user
            modelBuilder.Entity<User>().HasData(appUser);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Application Bug"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Network Issue"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Feature Request"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Product 1"
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Product 2"
                });

            modelBuilder.Entity<Priority>().HasData(
                new Priority
                {
                    PriorityId = 1,
                    PriorityName = "Low"
                },
                new Priority
                {
                    PriorityId = 2,
                    PriorityName = "Medium"
                },
                new Priority
                {
                    PriorityId = 3,
                    PriorityName = "High"
                });

            Ticket(modelBuilder);
        }

        private static void Ticket(ModelBuilder modelBuilder)
        {
            var tickets = new[]
            {
                new Ticket { TicketId = 1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 1", Description = "Description for ticket 1", RaisedDate = new DateTime(2024, 9, 1), ExpectedDate = new DateTime(2024, 9, 9) }, //8 days 
                new Ticket { TicketId = 2, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 2", Description = "Description for ticket 2", RaisedDate = new DateTime(2024, 9, 3), ExpectedDate = new DateTime(2024, 9, 3, 8, 0, 0) }, //8 hours 
                new Ticket { TicketId = 3, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 3", Description = "Description for ticket 3", RaisedDate = new DateTime(2024, 9, 3), ExpectedDate = new DateTime(2024, 9, 8) }, //5 days
                new Ticket { TicketId = 4, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 4", Description = "Description for ticket 4", RaisedDate = new DateTime(2024, 9, 4), ExpectedDate = new DateTime(2024, 9, 10) },
                new Ticket { TicketId = 5, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 5", Description = "Description for ticket 5", RaisedDate = new DateTime(2024, 9, 5), ExpectedDate = new DateTime(2024, 9, 12) },
                new Ticket { TicketId = 6, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 6", Description = "Description for ticket 6", RaisedDate = new DateTime(2024, 9, 6), ExpectedDate = new DateTime(2024, 9, 13, 8, 0, 0) },
                new Ticket { TicketId = 7, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 7", Description = "Description for ticket 7", RaisedDate = new DateTime(2024, 9, 7), ExpectedDate = new DateTime(2024, 9, 9) },
                new Ticket { TicketId = 8, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 8", Description = "Description for ticket 8", RaisedDate = new DateTime(2024, 9, 8), ExpectedDate = new DateTime(2024, 9, 11, 8, 0, 0) },
                new Ticket { TicketId = 9, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 9", Description = "Description for ticket 9", RaisedDate = new DateTime(2024, 9, 9), ExpectedDate = new DateTime(2024, 9, 16) },
                new Ticket { TicketId = 10, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 10", Description = "Description for ticket 10", RaisedDate = new DateTime(2024, 9, 10), ExpectedDate = new DateTime(2024, 9, 17, 8, 0, 0) },
                new Ticket { TicketId = 11, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 11", Description = "Description for ticket 11", RaisedDate = new DateTime(2024, 9, 11), ExpectedDate = new DateTime(2024, 9, 18) },
                new Ticket { TicketId = 12, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 12", Description = "Description for ticket 12", RaisedDate = new DateTime(2024, 9, 12), ExpectedDate = new DateTime(2024, 9, 19) },
                new Ticket { TicketId = 13, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 13", Description = "Description for ticket 13", RaisedDate = new DateTime(2024, 9, 13), ExpectedDate = new DateTime(2024, 9, 14) },
                new Ticket { TicketId = 14, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 14", Description = "Description for ticket 14", RaisedDate = new DateTime(2024, 9, 14), ExpectedDate = new DateTime(2024, 9, 14, 8, 0, 0) },
                new Ticket { TicketId = 15, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 15", Description = "Description for ticket 15", RaisedDate = new DateTime(2024, 9, 15), ExpectedDate = new DateTime(2024, 9, 22) },
                new Ticket { TicketId = 16, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 16", Description = "Description for ticket 16", RaisedDate = new DateTime(2024, 9, 16), ExpectedDate = new DateTime(2024, 9, 23) },
                new Ticket { TicketId = 17, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 17", Description = "Description for ticket 17", RaisedDate = new DateTime(2024, 9, 17), ExpectedDate = new DateTime(2024, 9, 24) },
                new Ticket { TicketId = 18, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 18", Description = "Description for ticket 18", RaisedDate = new DateTime(2024, 9, 18), ExpectedDate = new DateTime(2024, 9, 25) },
                new Ticket { TicketId = 19, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 19", Description = "Description for ticket 19", RaisedDate = new DateTime(2024, 9, 19), ExpectedDate = new DateTime(2024, 9, 26) },
                new Ticket { TicketId = 20, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 20", Description = "Description for ticket 20", RaisedDate = new DateTime(2024, 9, 20), ExpectedDate = new DateTime(2024, 9, 27) },
                new Ticket { TicketId = 21, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 21", Description = "Description for ticket 21", RaisedDate = new DateTime(2024, 9, 21), ExpectedDate = new DateTime(2024, 9, 28) },
                new Ticket { TicketId = 22, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 22", Description = "Description for ticket 22", RaisedDate = new DateTime(2024, 9, 22), ExpectedDate = new DateTime(2024, 9, 29) },
                new Ticket { TicketId = 23, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 23", Description = "Description for ticket 23", RaisedDate = new DateTime(2024, 9, 23), ExpectedDate = new DateTime(2024, 9, 30) },
                new Ticket { TicketId = 24, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 24", Description = "Description for ticket 24", RaisedDate = new DateTime(2024, 9, 24), ExpectedDate = new DateTime(2024, 10, 1) },
                new Ticket { TicketId = 25, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 25", Description = "Description for ticket 25", RaisedDate = new DateTime(2024, 9, 25), ExpectedDate = new DateTime(2024, 10, 2) },
                new Ticket { TicketId = 26, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 26", Description = "Description for ticket 26", RaisedDate = new DateTime(2024, 9, 26), ExpectedDate = new DateTime(2024, 10, 3) },
                new Ticket { TicketId = 27, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 27", Description = "Description for ticket 27", RaisedDate = new DateTime(2024, 9, 27), ExpectedDate = new DateTime(2024, 10, 4) },
                new Ticket { TicketId = 28, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 28", Description = "Description for ticket 28", RaisedDate = new DateTime(2024, 9, 28), ExpectedDate = new DateTime(2024, 10, 5) },
                new Ticket { TicketId = 29, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 29", Description = "Description for ticket 29", RaisedDate = new DateTime(2024, 9, 29), ExpectedDate = new DateTime(2024, 10, 6) },
                new Ticket { TicketId = 30, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 30", Description = "Description for ticket 30", RaisedDate = new DateTime(2024, 9, 30), ExpectedDate = new DateTime(2024, 10, 7) },
                new Ticket { TicketId = 31, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 31", Description = "Description for ticket 31", RaisedDate = new DateTime(2024, 10, 1), ExpectedDate = new DateTime(2024, 10, 8) },
                new Ticket { TicketId = 32, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 32", Description = "Description for ticket 32", RaisedDate = new DateTime(2024, 10, 2), ExpectedDate = new DateTime(2024, 10, 9) },
                new Ticket { TicketId = 33, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 33", Description = "Description for ticket 33", RaisedDate = new DateTime(2024, 10, 3), ExpectedDate = new DateTime(2024, 10, 10) },
                new Ticket { TicketId = 34, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 34", Description = "Description for ticket 34", RaisedDate = new DateTime(2024, 10, 4), ExpectedDate = new DateTime(2024, 10, 11) },
                new Ticket { TicketId = 35, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 35", Description = "Description for ticket 35", RaisedDate = new DateTime(2024, 10, 5), ExpectedDate = new DateTime(2024, 10, 12) },
                new Ticket { TicketId = 36, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 36", Description = "Description for ticket 36", RaisedDate = new DateTime(2024, 10, 6), ExpectedDate = new DateTime(2024, 10, 13) },
                new Ticket { TicketId = 37, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 37", Description = "Description for ticket 37", RaisedDate = new DateTime(2024, 10, 7), ExpectedDate = new DateTime(2024, 10, 14) },
                new Ticket { TicketId = 38, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 38", Description = "Description for ticket 38", RaisedDate = new DateTime(2024, 10, 8), ExpectedDate = new DateTime(2024, 10, 15) },
                new Ticket { TicketId = 39, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 39", Description = "Description for ticket 39", RaisedDate = new DateTime(2024, 10, 9), ExpectedDate = new DateTime(2024, 10, 16) },
                new Ticket { TicketId = 40, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 40", Description = "Description for ticket 40", RaisedDate = new DateTime(2024, 10, 10), ExpectedDate = new DateTime(2024, 10, 17) },
                new Ticket { TicketId = 41, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 41", Description = "Description for ticket 41", RaisedDate = new DateTime(2024, 10, 11), ExpectedDate = new DateTime(2024, 10, 18) },
                new Ticket { TicketId = 42, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 42", Description = "Description for ticket 42", RaisedDate = new DateTime(2024, 10, 12), ExpectedDate = new DateTime(2024, 10, 19) },
                new Ticket { TicketId = 43, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 43", Description = "Description for ticket 43", RaisedDate = new DateTime(2024, 10, 13), ExpectedDate = new DateTime(2024, 10, 20) },
                new Ticket { TicketId = 44, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 44", Description = "Description for ticket 44", RaisedDate = new DateTime(2024, 10, 14), ExpectedDate = new DateTime(2024, 10, 21) },
                new Ticket { TicketId = 45, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 45", Description = "Description for ticket 45", RaisedDate = new DateTime(2024, 10, 15), ExpectedDate = new DateTime(2024, 10, 22) },
                new Ticket { TicketId = 46, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 46", Description = "Description for ticket 46", RaisedDate = new DateTime(2024, 10, 11), ExpectedDate = new DateTime(2024, 10, 18) },
                new Ticket { TicketId = 47, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 47", Description = "Description for ticket 47", RaisedDate = new DateTime(2024, 10, 12), ExpectedDate = new DateTime(2024, 10, 19) },
                new Ticket { TicketId = 48, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 48", Description = "Description for ticket 48", RaisedDate = new DateTime(2024, 10, 13), ExpectedDate = new DateTime(2024, 10, 20) },
                new Ticket { TicketId = 49, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 49", Description = "Description for ticket 49", RaisedDate = new DateTime(2024, 10, 14), ExpectedDate = new DateTime(2024, 10, 21) },
                new Ticket { TicketId = 50, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 50", Description = "Description for ticket 50", RaisedDate = new DateTime(2024, 10, 15), ExpectedDate = new DateTime(2024, 10, 22) },
                new Ticket { TicketId = 51, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 51", Description = "Description for ticket 51", RaisedDate = new DateTime(2024, 10, 16), ExpectedDate = new DateTime(2024, 10, 23) },
                new Ticket { TicketId = 52, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 52", Description = "Description for ticket 52", RaisedDate = new DateTime(2024, 10, 17), ExpectedDate = new DateTime(2024, 10, 24) },
                new Ticket { TicketId = 53, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 53", Description = "Description for ticket 53", RaisedDate = new DateTime(2024, 10, 18), ExpectedDate = new DateTime(2024, 10, 25) },
                new Ticket { TicketId = 54, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 54", Description = "Description for ticket 54", RaisedDate = new DateTime(2024, 10, 19), ExpectedDate = new DateTime(2024, 10, 26) },
                new Ticket { TicketId = 55, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 55", Description = "Description for ticket 55", RaisedDate = new DateTime(2024, 10, 20), ExpectedDate = new DateTime(2024, 10, 27) },
                new Ticket { TicketId = 56, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 56", Description = "Description for ticket 56", RaisedDate = new DateTime(2024, 10, 21), ExpectedDate = new DateTime(2024, 10, 28) },
                new Ticket { TicketId = 57, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 57", Description = "Description for ticket 57", RaisedDate = new DateTime(2024, 10, 22), ExpectedDate = new DateTime(2024, 10, 29) },
                new Ticket { TicketId = 58, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", Summary = "Sample ticket 58", Description = "Description for ticket 58", RaisedDate = new DateTime(2024, 10, 23), ExpectedDate = new DateTime(2024, 10, 30) },
                new Ticket { TicketId = 59, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", Summary = "Sample ticket 59", Description = "Description for ticket 59", RaisedDate = new DateTime(2024, 10, 24), ExpectedDate = new DateTime(2024, 10, 31) },
                new Ticket { TicketId = 60, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", Summary = "Sample ticket 60", Description = "Description for ticket 60", RaisedDate = new DateTime(2024, 10, 25), ExpectedDate = new DateTime(2024, 11, 1) }
            };

            // add tickets to the model builder
            foreach (var ticket in tickets)
            {
                modelBuilder.Entity<Ticket>().HasData(ticket);
            }
        }
    }
}
