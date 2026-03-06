using Microsoft.EntityFrameworkCore;
using nexus2.Models;

namespace nexus2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower).WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Following).WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}