using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class CoteroToDoListContext : DbContext
{
    public CoteroToDoListContext()
    {
    }

    public CoteroToDoListContext(DbContextOptions<CoteroToDoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= COteroToDoList; Trusted_Connection=True; User ID=sa; Password=pass@word1; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Status__B450643A694F82F0");

            entity.ToTable("Status");

            entity.Property(e => e.EstadoStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__EADE909873CFF5D8");

            entity.ToTable("Tarea");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechadeVencimiento).HasColumnType("date");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK__Tarea__IdStatus__1FCDBCEB");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Tarea__IdUsuario__20C1E124");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97F3D99E91");

            entity.ToTable("Usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
