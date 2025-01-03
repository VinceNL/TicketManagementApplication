﻿using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedDatabase();

            builder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Discussion>()
                .HasOne(d => d.Ticket)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
