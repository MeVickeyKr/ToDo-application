using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TODOList.Models;

public partial class TodoListDatabaseContext : DbContext
{
    public TodoListDatabaseContext()
    {
    }

    public TodoListDatabaseContext(DbContextOptions<TodoListDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoList> TodoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = DESKTOP-5GG7H1O\\SQLEXPRESS; Database =TodoListDatabase; Trusted_connection = true; TrustServerCertificate = true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.ToTable("TodoList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("createdDateTime");
            entity.Property(e => e.CreatedUserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdUserId");
            entity.Property(e => e.Iscompleted).HasColumnName("iscompleted");
            entity.Property(e => e.ModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("modifiedDateTime");
            entity.Property(e => e.ModifieduserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modifieduserId");
            entity.Property(e => e.Task)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
