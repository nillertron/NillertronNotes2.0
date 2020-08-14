using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NillertronNotes.Models
{
    public partial class nillertron_com_dbContext : DbContext
    {
        public nillertron_com_dbContext()
        {
        }

        public nillertron_com_dbContext(DbContextOptions<nillertron_com_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bruger> Bruger { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Fag> Fag { get; set; }
        public virtual DbSet<FagFiler> FagFiler { get; set; }
        public virtual DbSet<FagSubChoise> FagSubChoise { get; set; }
        public virtual DbSet<LoginCookie> LoginCookie { get; set; }
        public virtual DbSet<Noter> Noter { get; set; }
        public virtual DbSet<Nyheder> Nyheder { get; set; }
        public virtual DbSet<Pic> Pic { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<Visits> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bruger>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rank).HasColumnType("tinyint(4)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fag>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Fag1)
                    .IsRequired()
                    .HasColumnName("Fag")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FagFiler>(entity =>
            {
                entity.HasIndex(e => e.BrugerId)
                    .HasName("Foreign1");

                entity.HasIndex(e => e.FagId)
                    .HasName("Foreign");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Beskrivelse).IsRequired();

                entity.Property(e => e.BrugerId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FagId).HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bruger)
                    .WithMany(p => p.FagFiler)
                    .HasForeignKey(d => d.BrugerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FagFiler_ibfk_2");

                entity.HasOne(d => d.Fag)
                    .WithMany(p => p.FagFiler)
                    .HasForeignKey(d => d.FagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FagFiler_ibfk_1");
            });

            modelBuilder.Entity<FagSubChoise>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.SubChoise)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginCookie>(entity =>
            {
                entity.HasIndex(e => e.BrugerId)
                    .HasName("FK");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Aktiv).HasColumnType("tinyint(1)");

                entity.Property(e => e.BrugerId).HasColumnType("int(11)");

                entity.Property(e => e.Cookie)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Noter>(entity =>
            {
                entity.HasIndex(e => e.BrugerId)
                    .HasName("Foreign");

                entity.HasIndex(e => e.FagId)
                    .HasName("Foreign1");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.BrugerId).HasColumnType("int(11)");

                entity.Property(e => e.FagId).HasColumnType("int(11)");

                entity.Property(e => e.NoteText).IsRequired();

                entity.Property(e => e.Overskrift)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bruger)
                    .WithMany(p => p.Noter)
                    .HasForeignKey(d => d.BrugerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Noter_ibfk_2");

                entity.HasOne(d => d.Fag)
                    .WithMany(p => p.Noter)
                    .HasForeignKey(d => d.FagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Noter_ibfk_1");
            });

            modelBuilder.Entity<Nyheder>(entity =>
            {
                entity.HasIndex(e => e.BrugerId)
                    .HasName("Foreign");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.BilledeUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BrugerId)
                    .HasColumnName("BrugerID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Overskrift)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Bruger)
                    .WithMany(p => p.Nyheder)
                    .HasForeignKey(d => d.BrugerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Nyheder_ibfk_1");
            });

            modelBuilder.Entity<Pic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasIndex(e => e.PortfolioId)
                    .HasName("Foreign");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PortfolioId).HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Portfolio)
                    .WithMany(p => p.Picture)
                    .HasForeignKey(d => d.PortfolioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Picture_ibfk_1");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Beskrivelse).IsRequired();

                entity.Property(e => e.Navn)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Published).HasColumnType("date");
            });

            modelBuilder.Entity<Visits>(entity =>
            {
                entity.HasIndex(e => e.BrugerId)
                    .HasName("FK");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.BrugerId).HasColumnType("int(11)");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
