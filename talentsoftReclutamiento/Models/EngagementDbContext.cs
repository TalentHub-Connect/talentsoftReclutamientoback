using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace talentsoftReclutamiento.Models;

public partial class EngagementDbContext : DbContext
{
    public EngagementDbContext()
    {
    }

    public EngagementDbContext(DbContextOptions<EngagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Candidatestatus> Candidatestatuses { get; set; }

    public virtual DbSet<Curriculum> Curricula { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=roundhouse.proxy.rlwy.net;port=19610;user=root;password=FjGiNUdMaIcUCcqHodBHjAbXfxvXqWIx;database=engagementDb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("candidate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Candidatestatusid).HasColumnName("candidatestatusid");
            entity.Property(e => e.CvId).HasColumnName("cv_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.OfferId).HasColumnName("offer_id");
            entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Candidatestatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("candidatestatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Curriculum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("curriculum");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Career)
                .HasMaxLength(45)
                .HasColumnName("career");
            entity.Property(e => e.Certification)
                .HasMaxLength(45)
                .HasColumnName("certification");
            entity.Property(e => e.Educationalhistory)
                .HasMaxLength(45)
                .HasColumnName("educationalhistory");
            entity.Property(e => e.Language)
                .HasMaxLength(45)
                .HasColumnName("language");
            entity.Property(e => e.Personalobjetive)
                .HasMaxLength(45)
                .HasColumnName("personalobjetive");
            entity.Property(e => e.Personalreference)
                .HasMaxLength(45)
                .HasColumnName("personalreference");
            entity.Property(e => e.University)
                .HasMaxLength(45)
                .HasColumnName("university");
            entity.Property(e => e.Workexperience).HasColumnName("workexperience");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("offer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.Publishdate)
                .HasMaxLength(15)
                .HasColumnName("publishdate");
            entity.Property(e => e.Requeriments)
                .HasMaxLength(45)
                .HasColumnName("requeriments");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
            entity.Property(e => e.Tittleoffer)
                .HasMaxLength(45)
                .HasColumnName("tittleoffer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
