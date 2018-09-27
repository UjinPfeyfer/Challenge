using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Challenge24.Models;
using Challenge24.Models.ChallengeModels;

namespace Challenge24.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Challenge> Challenges { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ChallengeUser>()
                .HasKey(cu => new { cu.UserId, cu.ChallengeId });

            builder.Entity<ChallengeUser>()
                .HasOne(cu => cu.ApplicationUser)
                .WithMany(u => u.ChallengeUsers)
                .HasForeignKey(cu => cu.UserId);

            builder.Entity<ChallengeUser>()
                .HasOne(cu => cu.Challenge)
                .WithMany(c => c.ChallengeUsers)
                .HasForeignKey(cu => cu.ChallengeId);
        }
    }
}
