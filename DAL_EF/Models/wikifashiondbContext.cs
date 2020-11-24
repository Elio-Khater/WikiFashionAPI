using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL_EF.Models
{
    public partial class wikifashiondbContext : DbContext
    {
        public wikifashiondbContext()
        {
        }

        public wikifashiondbContext(DbContextOptions<wikifashiondbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Useragency> Useragency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:wikifashion.database.windows.net,1433;Initial Catalog=wikifashiondb;Persist Security Info=False;User ID=wikifashion;Password=@Fashion2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>(entity =>
            {
                entity.ToTable("agency");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bio).HasColumnName("bio");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Birthplace).HasColumnName("birthplace");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Chestcm).HasColumnName("chestcm");

                entity.Property(e => e.Chestinch).HasColumnName("chestinch");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Eyes).HasColumnName("eyes");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Hair).HasColumnName("hair");

                entity.Property(e => e.Heightcm).HasColumnName("heightcm");

                entity.Property(e => e.Heightinch).HasColumnName("heightinch");

                entity.Property(e => e.Hipscm).HasColumnName("hipscm");

                entity.Property(e => e.Hipsinch).HasColumnName("hipsinch");

                entity.Property(e => e.Islogged)
                    .HasColumnName("islogged")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Language).HasColumnName("language");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Shoeeu).HasColumnName("shoeeu");

                entity.Property(e => e.Shoeus).HasColumnName("shoeus");

                entity.Property(e => e.Skin).HasColumnName("skin");

                entity.Property(e => e.Social).HasColumnName("social");

                entity.Property(e => e.Urlfb).HasColumnName("urlfb");

                entity.Property(e => e.Urlinsta).HasColumnName("urlinsta");

                entity.Property(e => e.Urltiktok).HasColumnName("urltiktok");

                entity.Property(e => e.Urltwitter).HasColumnName("urltwitter");

                entity.Property(e => e.Urlyoutube).HasColumnName("urlyoutube");

                entity.Property(e => e.Waistcm).HasColumnName("waistcm");

                entity.Property(e => e.Waistinch).HasColumnName("waistinch");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK_User_Category");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK_user_Country");
            });

            modelBuilder.Entity<Useragency>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Agencyid });

                entity.ToTable("useragency");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Agencyid).HasColumnName("agencyid");

                entity.Property(e => e.IsMotherAgency)
                    .HasColumnName("isMotherAgency")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.Useragency)
                    .HasForeignKey(d => d.Agencyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_useragency_agencies");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Useragency)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_useragency_user");
            });
        }
    }
}
