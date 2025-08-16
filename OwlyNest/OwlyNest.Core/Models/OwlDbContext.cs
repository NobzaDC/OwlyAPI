using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OwlyNest.Core.Models;

public partial class OwlDbContext : DbContext
{
    public OwlDbContext()
    {
    }

    public OwlDbContext(DbContextOptions<OwlDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Click> Clicks { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Url> Urls { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Click>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClickedAt)
                .HasColumnType("datetime")
                .HasColumnName("clicked_at");
            entity.Property(e => e.Contry)
                .HasMaxLength(100)
                .HasColumnName("contry");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.Referrer)
                .HasColumnType("text")
                .HasColumnName("referrer");
            entity.Property(e => e.UrlId).HasColumnName("url_id");
            entity.Property(e => e.UserAgent)
                .HasColumnType("text")
                .HasColumnName("user_agent");

            entity.HasOne(d => d.Url).WithMany(p => p.Clicks)
                .HasForeignKey(d => d.UrlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clicks_Urls");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomDomains).HasColumnName("custom_domains");
            entity.Property(e => e.MaxClicks).HasColumnName("max_clicks");
            entity.Property(e => e.MaxUrls).HasColumnName("max_urls");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PriceUsd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_usd");
            entity.Property(e => e.PriceYearlyUsd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_yearly_usd");
            entity.Property(e => e.SupportLevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("E = email, C = chat, D =dedicado")
                .HasColumnName("support_level");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Url>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClickCount).HasColumnName("click_count");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiredAt)
                .HasColumnType("datetime")
                .HasColumnName("expired_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.OriginalUrl)
                .HasColumnType("text")
                .HasColumnName("original_url");
            entity.Property(e => e.ShortCode)
                .HasMaxLength(20)
                .HasColumnName("short_code");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Urls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Urls_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Plan).WithMany(p => p.Users)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Plans");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
