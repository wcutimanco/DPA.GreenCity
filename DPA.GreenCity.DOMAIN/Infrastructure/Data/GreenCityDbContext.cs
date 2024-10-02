using System;
using System.Collections.Generic;
using DPA.GreenCity.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPA.GreenCity.DOMAIN.Infrastructure.Data;

public partial class GreenCityDbContext : DbContext
{
    public GreenCityDbContext()
    {
    }

    public GreenCityDbContext(DbContextOptions<GreenCityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentarios> Comentarios { get; set; }

    public virtual DbSet<EstadosReportes> EstadosReportes { get; set; }

    public virtual DbSet<Informes> Informes { get; set; }

    public virtual DbSet<Reportes> Reportes { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentarios>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__comentar__1BA6C6F48470A7FE");

            entity.ToTable("comentarios");

            entity.Property(e => e.IdComentario).HasColumnName("id_comentario");
            entity.Property(e => e.Comentario)
                .HasColumnType("text")
                .HasColumnName("comentario");
            entity.Property(e => e.FechaComentario)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_comentario");
            entity.Property(e => e.IdReporte).HasColumnName("id_reporte");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdReporteNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdReporte)
                .HasConstraintName("FK__comentari__id_re__4222D4EF");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__comentari__id_us__4316F928");
        });

        modelBuilder.Entity<EstadosReportes>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__estados___86989FB2CBEA55CF");

            entity.ToTable("estados_reportes");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.ComentarioAdm)
                .HasColumnType("text")
                .HasColumnName("comentario_adm");
            entity.Property(e => e.EstadoAnterior)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado_anterior");
            entity.Property(e => e.EstadoNuevo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado_nuevo");
            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_cambio");
            entity.Property(e => e.IdReporte).HasColumnName("id_reporte");

            entity.HasOne(d => d.IdReporteNavigation).WithMany(p => p.EstadosReportes)
                .HasForeignKey(d => d.IdReporte)
                .HasConstraintName("FK__estados_r__id_re__46E78A0C");
        });

        modelBuilder.Entity<Informes>(entity =>
        {
            entity.HasKey(e => e.IdInforme).HasName("PK__informes__ECCCE10F4FA16565");

            entity.ToTable("informes");

            entity.Property(e => e.IdInforme).HasColumnName("id_informe");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.FechaGeneracion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.RutaArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_archivo");
            entity.Property(e => e.TipoInforme)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_informe");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Informes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__informes__id_usu__4CA06362");
        });

        modelBuilder.Entity<Reportes>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__reportes__87E4F5CBD9033475");

            entity.ToTable("reportes");

            entity.Property(e => e.IdReporte).HasColumnName("id_reporte");
            entity.Property(e => e.Categoria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Foto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("foto");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Subcategoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("subcategoria");
            entity.Property(e => e.UbicacionLat).HasColumnName("ubicacion_lat");
            entity.Property(e => e.UbicacionLng).HasColumnName("ubicacion_lng");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__reportes__id_usu__3B75D760");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04ADA463D9DC");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "UQ__usuarios__2A586E0B8C815EAD").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tipo_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
