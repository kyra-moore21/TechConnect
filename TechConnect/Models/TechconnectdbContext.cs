using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TechConnect.Models;

public partial class TechconnectdbContext : DbContext
{
    public TechconnectdbContext()
    {
    }

    public TechconnectdbContext(DbContextOptions<TechconnectdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userprofile> Userprofiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=TECHCONNECTDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__APPLICAT__3214EC279451E610");

            entity.ToTable("APPLICATIONS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany(p => p.Applications)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__APPLICATI__PostI__628FA481");

            entity.HasOne(d => d.User).WithMany(p => p.Applications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__APPLICATI__UserI__6383C8BA");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__POSTS__3214EC27552369F8");

            entity.ToTable("POSTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__POSTS__UserID__4F7CD00D");

            entity.HasMany(d => d.Skills).WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__POST_SKIL__Skill__5BE2A6F2"),
                    l => l.HasOne<Post>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__POST_SKIL__PostI__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("PostId", "SkillId").HasName("PK__POST_SKI__C7E869266BC4AAF4");
                        j.ToTable("POST_SKILLS");
                        j.IndexerProperty<int>("PostId").HasColumnName("PostID");
                        j.IndexerProperty<int>("SkillId").HasColumnName("SkillID");
                    });
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SKILLS__3214EC27B24E360B");

            entity.ToTable("SKILLS");

            entity.HasIndex(e => e.SkillName, "UQ__SKILLS__B63C65714C617360").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SkillName).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS__3214EC27807E30F9");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.Email, "UQ_Email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirebaseId)
                .HasMaxLength(255)
                .HasColumnName("FirebaseID");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasMany(d => d.Skills).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Userskill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__USERSKILL__Skill__5812160E"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__USERSKILL__UserI__571DF1D5"),
                    j =>
                    {
                        j.HasKey("UserId", "SkillId").HasName("PK__USERSKIL__7A72C5B2013DF015");
                        j.ToTable("USERSKILLS");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("SkillId").HasColumnName("SkillID");
                    });
        });

        modelBuilder.Entity<Userprofile>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__USERPROF__7B9E7F35ED4965AE");

            entity.ToTable("USERPROFILES");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("USERID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProfilePicture).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithOne(p => p.Userprofile)
                .HasForeignKey<Userprofile>(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USERPROFI__USERI__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
