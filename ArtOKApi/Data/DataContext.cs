using ArtOKApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtOKApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<DialogUser> DialogUsers { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PopApp> PopApps { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostPopApp> PostPopApps { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Repost> Reposts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follower>()
                    .HasKey(F => new { F.IDCurrentUser, F.IDFollowedUser});
            modelBuilder.Entity<Follower>()
                    .HasOne(p => p.CUser)
                    .WithMany(pc => pc.Follower)
                    .HasForeignKey(p => p.IDCurrentUser);
            modelBuilder.Entity<Follower>()
                   .HasOne(p => p.FUser)
                   .WithMany(pc => pc.Follower1)
                   .HasForeignKey(p => p.IDFollowedUser);
        }
    }
}
