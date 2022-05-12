using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab11
{
    public partial class AgregatoContext : DbContext
    {
        public AgregatoContext()
        {
        }

        public AgregatoContext(DbContextOptions<AgregatoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developer> Developers { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Agregato;Encrypt=False;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>(entity =>
            {
                entity.Property(e => e.DeveloperId).HasColumnName("DeveloperID");

                entity.Property(e => e.DeveloperCountry).HasMaxLength(50);

                entity.Property(e => e.DeveloperName).HasMaxLength(50);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.BuyUrl)
                    .HasMaxLength(96)
                    .HasColumnName("BuyURL");

                entity.Property(e => e.DeveloperId).HasColumnName("DeveloperID");

                entity.Property(e => e.GameName).HasMaxLength(64);

                entity.Property(e => e.Genre).HasMaxLength(32);

                entity.Property(e => e.Platform).HasMaxLength(32);

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.DeveloperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Games_Developers");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Games_Publishers");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.PublisherCountry).HasMaxLength(50);

                entity.Property(e => e.PublisherName).HasMaxLength(50);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UploadDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Games");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Reviews_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Nickname, "UQ_Nickname")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(96);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(24);

                entity.Property(e => e.Password).HasMaxLength(32);

                entity.Property(e => e.PhoneNumber).HasMaxLength(16);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
