using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mod7ScaffoldDemo;

public partial class BlogDbContext : DbContext
{
    public BlogDbContext()
    {
    }

    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BlogMaster> BlogMasters { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-EA8DDSO;Database=BlogDB;Trusted_Connection=True;Integrated Security=True;trustservercertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogMaster>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__BlogMast__54379E303B5E5B76");

            entity.ToTable("BlogMaster");

            entity.Property(e => e.AuthorName).HasMaxLength(100);
            entity.Property(e => e.BlogName).HasMaxLength(100);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__AA1260186CFFF5DB");

            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Blog).WithMany(p => p.Posts)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Posts_BlogMaster");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
