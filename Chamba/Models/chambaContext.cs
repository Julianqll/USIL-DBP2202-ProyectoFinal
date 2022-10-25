using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Chamba.Models
{
    public partial class chambaContext : DbContext
    {
        public chambaContext()
        {
        }

        public chambaContext(DbContextOptions<chambaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Postulacion> Postulacions { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_empresa");

                entity.Property(e => e.ApodoEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("apodo_empresa");

                entity.Property(e => e.AñoFundacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("año_fundacion");

                entity.Property(e => e.BiografiaEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("biografia_empresa");

                entity.Property(e => e.ContrasenaEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("contrasena_empresa");

                entity.Property(e => e.CorreoEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("correo_empresa");

                entity.Property(e => e.DireccionEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("direccion_empresa");

                entity.Property(e => e.NombreEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("nombre_empresa");

                entity.Property(e => e.RubroEmpresa)
                    .HasColumnType("int(11)")
                    .HasColumnName("rubro_empresa");
            });

            modelBuilder.Entity<Postulacion>(entity =>
            {
                entity.HasKey(e => e.IdPostulacion)
                    .HasName("PRIMARY");

                entity.ToTable("postulacion");

                entity.Property(e => e.IdPostulacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_postulacion");

                entity.Property(e => e.ComentarioPostulante)
                    .HasColumnType("text")
                    .HasColumnName("comentario_postulante");

                entity.Property(e => e.CvPostulante)
                    .HasColumnType("text")
                    .HasColumnName("cv_postulante");

                entity.Property(e => e.EstadoPostulacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado_postulacion");

                entity.Property(e => e.Observacion)
                    .HasColumnType("text")
                    .HasColumnName("observacion");

                entity.Property(e => e.Postulante)
                    .HasColumnType("int(11)")
                    .HasColumnName("postulante");

                entity.Property(e => e.Puesto)
                    .HasColumnType("int(11)")
                    .HasColumnName("puesto");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PRIMARY");

                entity.ToTable("puesto");

                entity.Property(e => e.IdPuesto)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_puesto");

                entity.Property(e => e.DescripcionPuesto)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_puesto");

                entity.Property(e => e.EmpresaPuesto)
                    .HasColumnType("int(11)")
                    .HasColumnName("empresa_puesto");

                entity.Property(e => e.LugarPuesto)
                    .HasColumnType("text")
                    .HasColumnName("lugar_puesto");

                entity.Property(e => e.NombrePuesto)
                    .HasColumnType("text")
                    .HasColumnName("nombre_puesto");

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.Property(e => e.TipoPuesto)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo_puesto");

                entity.Property(e => e.VacantesPuesto)
                    .HasColumnType("int(11)")
                    .HasColumnName("vacantes_puesto");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_usuario");

                entity.Property(e => e.ApellidosUsuario)
                    .HasColumnType("text")
                    .HasColumnName("apellidos_usuario");

                entity.Property(e => e.ApodoUsuario)
                    .HasColumnType("text")
                    .HasColumnName("apodo_usuario");

                entity.Property(e => e.BiografiaUsuario)
                    .HasColumnType("text")
                    .HasColumnName("biografia_usuario");

                entity.Property(e => e.ContrasenaUsuario)
                    .HasColumnType("text")
                    .HasColumnName("contrasena_usuario");

                entity.Property(e => e.CorreoUsuario)
                    .HasColumnType("text")
                    .HasColumnName("correo_usuario");

                entity.Property(e => e.EdadUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("edad_usuario");

                entity.Property(e => e.EstudiosUsuario)
                    .HasColumnType("text")
                    .HasColumnName("estudios_usuario");

                entity.Property(e => e.NombresUsuario)
                    .HasColumnType("text")
                    .HasColumnName("nombres_usuario");

                entity.Property(e => e.SexoUsuario)
                    .HasMaxLength(1)
                    .HasColumnName("sexo_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
