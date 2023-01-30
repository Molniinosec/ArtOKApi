using ArtOKApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtOKApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Achievement> Achievement { get; set; }
        public DbSet<Dialog> Dialog { get; set; }
        public DbSet<DialogUser> DialogUser { get; set; }
        public DbSet<Follower> Follower { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<PopApp> PopApp { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostComment> PostComment { get; set; }
        public DbSet<PostPopApp> PostPopApp { get; set; }
        public DbSet<PostTag> PostTag { get; set; }
        public DbSet<Repost> Repost { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAchievement> UserAchievement { get; set; }

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
