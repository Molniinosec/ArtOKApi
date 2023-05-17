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
        public DbSet<Messages> Message { get; set; }
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

            modelBuilder.Entity<PostTag>()
                .HasKey(PT => new { PT.IDTag, PT.IDPost });
            modelBuilder.Entity<PostTag>()
                .HasOne(p => p.Tag)
                .WithMany(pc => pc.PostTag)
                .HasForeignKey(p => p.IDTag);
            modelBuilder.Entity<PostTag>()
               .HasOne(p => p.Post)
               .WithMany(pc => pc.PostTag)
               .HasForeignKey(p => p.IDPost);

            modelBuilder.Entity<Like>()
                .HasKey(L => new { L.IDPost, L.IDUser });
            modelBuilder.Entity<Like>()
                .HasOne(p => p.Post)
                .WithMany(pc => pc.Like)
                .HasForeignKey(p => p.IDPost);
            modelBuilder.Entity<Like>()
               .HasOne(p => p.User)
               .WithMany(pc => pc.Like)
               .HasForeignKey(p => p.IDUser);

            modelBuilder.Entity<PostComment>()
                .HasKey(PC => new { PC.IDPost, PC.IDUser });
            modelBuilder.Entity<PostComment>()
                .HasOne(p => p.Post)
                .WithMany(pc => pc.PostComment)
                .HasForeignKey(p => p.IDPost);
            modelBuilder.Entity<PostComment>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.PostComment)
                .HasForeignKey(p => p.IDUser);

            modelBuilder.Entity<Repost>()
               .HasKey(PT => new { PT.IDUser, PT.IDRepostedPost });
            modelBuilder.Entity<Repost>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.Repost)
                .HasForeignKey(p => p.IDUser);
            modelBuilder.Entity<Repost>()
               .HasOne(p => p.Post)
               .WithMany(pc => pc.Repost)
               .HasForeignKey(p => p.IDRepostedPost);

            modelBuilder.Entity<PostPopApp>()
               .HasKey(PC => new { PC.IDPost, PC.IDPopApp });
            modelBuilder.Entity<PostPopApp>()
                .HasOne(p => p.Post)
                .WithMany(pc => pc.PostPopApp)
                .HasForeignKey(p => p.IDPost);
            modelBuilder.Entity<PostPopApp>()
                .HasOne(p => p.PopApp)
                .WithMany(pc => pc.PostPopApp)
                .HasForeignKey(p => p.IDPopApp);

            modelBuilder.Entity<DialogUser>()
              .HasKey(PC => new { PC.IDUser, PC.IDDialog });
            modelBuilder.Entity<DialogUser>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.DialogUser)
                .HasForeignKey(p => p.IDUser);
            modelBuilder.Entity<DialogUser>()
                .HasOne(p => p.Dialog)
                .WithMany(pc => pc.DialogUser)
                .HasForeignKey(p => p.IDDialog);


            modelBuilder.Entity<DialogUser>()
             .HasKey(PC => new { PC.ID });
            modelBuilder.Entity<DialogUser>()
                .HasMany(p => p.Message)
                .WithOne(pc => pc.DialogUser)
                .HasForeignKey(p => p.IDUserDialog);

        }

    }
}
