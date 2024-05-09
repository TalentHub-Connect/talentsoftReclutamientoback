using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace talentsoftReclutamiento.Models;

public partial class ProjectarquiContext : DbContext
{
    public ProjectarquiContext()
    {
    }

    public ProjectarquiContext(DbContextOptions<ProjectarquiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=mysql://root:NMpTTtOpvhVJWSowoHxHHnkbTzOqLoPa@monorail.proxy.rlwy.net:58588/payrollDb;database=${MYSQL_DATABASE};User=${MYSQLUSER};Password=${MYSQL_ROOT_PASSWORD};", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("candidate");

            entity.HasIndex(e => e.CurriculumId, "fk_candidate_curriculum1_idx");

            entity.HasIndex(e => e.TalentSoftUserId, "fk_candidate_talentSoftUser1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurriculumId).HasColumnName("curriculum_id");
            entity.Property(e => e.EmploymentExchange)
                .HasMaxLength(45)
                .HasColumnName("employmentExchange");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
            entity.Property(e => e.TalentSoftUserId).HasColumnName("talentSoftUser_id");

        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("offer");

            entity.HasIndex(e => e.CandidateId, "fk_offer_candidate1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.PublishDate).HasColumnName("publishDate");
            entity.Property(e => e.Requeriments)
                .HasMaxLength(45)
                .HasColumnName("requeriments");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TittleOffer)
                .HasMaxLength(45)
                .HasColumnName("tittleOffer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
