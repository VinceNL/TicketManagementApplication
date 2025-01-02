using Domain.Entities;
using Infrastructure.Common;
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

            //seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Constants.ROLE_ADMIN_ID,
                    Name = Constants.ROLE_ADMIN,
                    NormalizedName = Constants.ROLE_ADMIN.ToUpper()
                },
                new IdentityRole
                {
                    Id = Constants.ROLE_USER_ID,
                    Name = Constants.ROLE_USER,
                    NormalizedName = Constants.ROLE_USER.ToUpper()
                }
            );

            // Assign role to user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = Constants.ROLE_ADMIN_ID,
                    UserId = user1
                }
            );

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
                    PriorityName = "Low",
                    ExpectedDays = 10
                },
                new Priority
                {
                    PriorityId = 2,
                    PriorityName = "Medium",
                    ExpectedDays = 5
                },
                new Priority
                {
                    PriorityId = 3,
                    PriorityName = "High",
                    ExpectedDays = 2
                });

            Ticket(modelBuilder);
        }

        private static void Ticket(ModelBuilder modelBuilder)
        {
            var tickets = new[]
            {
                new Ticket { TicketId = 1, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 1", Description = "Description for ticket 1", RaisedDate = new DateTime(2024, 9, 1, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 9, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 2, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 2", Description = "Description for ticket 2", RaisedDate = new DateTime(2024, 9, 3, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 3, 8, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 3, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 3", Description = "Description for ticket 3", RaisedDate = new DateTime(2024, 9, 3, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 8, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 4, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 4", Description = "Description for ticket 4", RaisedDate = new DateTime(2024, 9, 4, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 10, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 5, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 5", Description = "Description for ticket 5", RaisedDate = new DateTime(2024, 9, 5, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 12, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 6, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 6", Description = "Description for ticket 6", RaisedDate = new DateTime(2024, 9, 6, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 13, 8, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 7, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 7", Description = "Description for ticket 7", RaisedDate = new DateTime(2024, 9, 7, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 9, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 8, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 8", Description = "Description for ticket 8", RaisedDate = new DateTime(2024, 9, 8, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 11, 8, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 9, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 9", Description = "Description for ticket 9", RaisedDate = new DateTime(2024, 9, 9, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 16, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 10, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 10", Description = "Description for ticket 10", RaisedDate = new DateTime(2024, 9, 10, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 17, 8, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 11, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 11", Description = "Description for ticket 11", RaisedDate = new DateTime(2024, 9, 11, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 18, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 12, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 12", Description = "Description for ticket 12", RaisedDate = new DateTime(2024, 9, 12, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 19, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 13, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 13", Description = "Description for ticket 13", RaisedDate = new DateTime(2024, 9, 13, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 14, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 14, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 14", Description = "Description for ticket 14", RaisedDate = new DateTime(2024, 9, 14, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 14, 8, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 15, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 15", Description = "Description for ticket 15", RaisedDate = new DateTime(2024, 9, 15, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 16, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 16", Description = "Description for ticket 16", RaisedDate = new DateTime(2024, 9, 16, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 23, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 17, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 17", Description = "Description for ticket 17", RaisedDate = new DateTime(2024, 9, 17, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 24, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 18, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 18", Description = "Description for ticket 18", RaisedDate = new DateTime(2024, 9, 18, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 25, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 19, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 19", Description = "Description for ticket 19", RaisedDate = new DateTime(2024, 9, 19, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 26, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 20, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 20", Description = "Description for ticket 20", RaisedDate = new DateTime(2024, 9, 20, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 27, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 21, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 21", Description = "Description for ticket 21", RaisedDate = new DateTime(2024, 9, 21, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 28, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 22, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 22", Description = "Description for ticket 22", RaisedDate = new DateTime(2024, 9, 22, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 29, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 23, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 23", Description = "Description for ticket 23", RaisedDate = new DateTime(2024, 9, 23, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 30, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 24, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 24", Description = "Description for ticket 24", RaisedDate = new DateTime(2024, 9, 24, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 25, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 25", Description = "Description for ticket 25", RaisedDate = new DateTime(2024, 9, 25, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 2, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 26, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 26", Description = "Description for ticket 26", RaisedDate = new DateTime(2024, 9, 26, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 3, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 27, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 27", Description = "Description for ticket 27", RaisedDate = new DateTime(2024, 9, 27, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 4, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 28, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 28", Description = "Description for ticket 28", RaisedDate = new DateTime(2024, 9, 28, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 5, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 29, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 29", Description = "Description for ticket 29", RaisedDate = new DateTime(2024, 9, 29 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 6, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 30, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 30", Description = "Description for ticket 30", RaisedDate = new DateTime(2024, 9, 30 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 7, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 31, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 31", Description = "Description for ticket 31", RaisedDate = new DateTime(2024, 10, 1 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 8, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 32, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 32", Description = "Description for ticket 32", RaisedDate = new DateTime(2024, 10, 2 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 9, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 33, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 33", Description = "Description for ticket 33", RaisedDate = new DateTime(2024, 10, 3 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 10 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 34, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 34", Description = "Description for ticket 34", RaisedDate = new DateTime(2024, 10, 4 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 11 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 35, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 35", Description = "Description for ticket 35", RaisedDate = new DateTime(2024, 10, 5 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 12 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 36, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 36", Description = "Description for ticket 36", RaisedDate = new DateTime(2024, 10, 6 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 13 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 37, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 37", Description = "Description for ticket 37", RaisedDate = new DateTime(2024, 10, 7 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 14 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 38, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 38", Description = "Description for ticket 38", RaisedDate = new DateTime(2024, 10, 8 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 15 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 39, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 39", Description = "Description for ticket 39", RaisedDate = new DateTime(2024, 10, 9 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 16 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 40, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 40", Description = "Description for ticket 40", RaisedDate = new DateTime(2024, 10, 10 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 17 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 41, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 41", Description = "Description for ticket 41", RaisedDate = new DateTime(2024, 10, 11 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 18 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 42, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 42", Description = "Description for ticket 42", RaisedDate = new DateTime(2024, 10, 12 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 19 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 43, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 43", Description = "Description for ticket 43", RaisedDate = new DateTime(2024, 10, 13 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 20 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 44, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 44", Description = "Description for ticket 44", RaisedDate = new DateTime(2024, 10, 14 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 21 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 45, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 45", Description = "Description for ticket 45", RaisedDate = new DateTime(2024, 10, 15 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 22 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 46, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 46", Description = "Description for ticket 46", RaisedDate = new DateTime(2024, 10, 11 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 18 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 47, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 47", Description = "Description for ticket 47", RaisedDate = new DateTime(2024, 10, 12 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 19 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 48, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 48", Description = "Description for ticket 48", RaisedDate = new DateTime(2024, 10, 13 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 20 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 49, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 49", Description = "Description for ticket 49", RaisedDate = new DateTime(2024, 10, 14 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 21 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 50, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 50", Description = "Description for ticket 50", RaisedDate = new DateTime(2024, 10, 15 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 22 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 51, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 51", Description = "Description for ticket 51", RaisedDate = new DateTime(2024, 10, 16 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 23 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 52, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 52", Description = "Description for ticket 52", RaisedDate = new DateTime(2024, 10, 17 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 24 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 53, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 53", Description = "Description for ticket 53", RaisedDate = new DateTime(2024, 10, 18 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 25 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 54, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 54", Description = "Description for ticket 54", RaisedDate = new DateTime(2024, 10, 19 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 26 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 55, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 55", Description = "Description for ticket 55", RaisedDate = new DateTime(2024, 10, 20 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 27 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 56, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 56", Description = "Description for ticket 56", RaisedDate = new DateTime(2024, 10, 21 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 28 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 57, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 57", Description = "Description for ticket 57", RaisedDate = new DateTime(2024, 10, 22 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 29 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 58, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 2, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 58", Description = "Description for ticket 58", RaisedDate = new DateTime(2024, 10, 23 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 30 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 59, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 1, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 59", Description = "Description for ticket 59", RaisedDate = new DateTime(2024, 10, 24 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 31 , 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 60, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "CLOSED", ClosedBy = "user1", ClosedDate = new DateTime(2024, 12, 10, 0, 0, 0, DateTimeKind.Utc), Summary = "Sample ticket 60", Description = "Description for ticket 60", RaisedDate = new DateTime(2024, 10, 25 , 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 11, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 61, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 61", Description = "Description for ticket 61", RaisedDate = new DateTime(2023, 12, 15, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2023, 12, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 62, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 62", Description = "Description for ticket 62", RaisedDate = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 1, 17, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 63, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 63", Description = "Description for ticket 63", RaisedDate = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 2, 12, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 64, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 64", Description = "Description for ticket 64", RaisedDate = new DateTime(2024, 3, 20, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 3, 27, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 65, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 65", Description = "Description for ticket 65", RaisedDate = new DateTime(2024, 4, 15, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 4, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 66, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 66", Description = "Description for ticket 66", RaisedDate = new DateTime(2024, 5, 10, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 5, 17, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 67, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 67", Description = "Description for ticket 67", RaisedDate = new DateTime(2024, 6, 25, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 7, 2, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 68, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 68", Description = "Description for ticket 68", RaisedDate = new DateTime(2024, 7, 15, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 7, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 69, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 69", Description = "Description for ticket 69", RaisedDate = new DateTime(2024, 8, 5, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 8, 12, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 70, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 2, PriorityId = 1, Status = "OPEN", Summary = "Sample ticket 70", Description = "Description for ticket 70", RaisedDate = new DateTime(2024, 9, 20, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 9, 27, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 71, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 3, PriorityId = 2, Status = "NEW", Summary = "Sample ticket 71", Description = "Description for ticket 71", RaisedDate = new DateTime(2024, 10, 15, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 10, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 72, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 1, PriorityId = 3, Status = "OPEN", Summary = "Sample ticket 72", Description = "Description for ticket 72", RaisedDate = new DateTime(2024, 11, 10, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2024, 11, 17, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 73, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 2, PriorityId = 1, Status = "NEW", Summary = "Sample ticket 73", Description = "Description for ticket 73", RaisedDate = new DateTime(2024, 12, 25, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 74, AssignedToId = user1, RaisedBy = user1, ProductId = 2, CategoryId = 3, PriorityId = 2, Status = "OPEN", Summary = "Sample ticket 74", Description = "Description for ticket 74", RaisedDate = new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2025, 1, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Ticket { TicketId = 75, AssignedToId = user1, RaisedBy = user1, ProductId = 1, CategoryId = 1, PriorityId = 3, Status = "NEW", Summary = "Sample ticket 75", Description = "Description for ticket 75", RaisedDate = new DateTime(2025, 2, 5, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2025, 2, 12, 0, 0, 0, DateTimeKind.Utc) }

            };

            // add tickets to the model builder
            foreach (var ticket in tickets)
            {
                modelBuilder.Entity<Ticket>().HasData(ticket);
            }
        }
    }
}
