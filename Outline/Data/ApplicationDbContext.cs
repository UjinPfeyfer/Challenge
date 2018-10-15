using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Challenge24.Models;
using Challenge24.Models.ChallengeModels;
using Microsoft.AspNetCore.Identity;

namespace Challenge24.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Outline> Outlines { get; set; }
        public DbSet<Commen> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OutlineUser>()
                .HasKey(cu => new { cu.UserId, cu.OutlineId });

            builder.Entity<OutlineUser>()
                .HasOne(cu => cu.ApplicationUser)
                .WithMany(u => u.OutlineUsers)
                .HasForeignKey(cu => cu.UserId);

            builder.Entity<OutlineUser>()
                .HasOne(cu => cu.Outline)
                .WithMany(c => c.OutlineUsers)
                .HasForeignKey(cu => cu.OutlineId);
        }
    }
}
