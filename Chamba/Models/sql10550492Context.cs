using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Chamba.Models
{
    public partial class sql10550492Context : DbContext
    {
        public sql10550492Context()
        {
        }

        public sql10550492Context(DbContextOptions<sql10550492Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Postulacion> Postulacions { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=sql10.freesqldatabase.com;database=sql10550492;uid=sql10550492;pwd=UHGIpqBHSe", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.62-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_empresa");

                entity.Property(e => e.ApodoEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("apodo_empresa");

                entity.Property(e => e.BiografiaEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("biografia_empresa");

                entity.Property(e => e.CorreoEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("correo_empresa");

                entity.Property(e => e.DireccionEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("direccion_empresa");

                entity.Property(e => e.FFundacion).HasColumnName("f_fundacion");

                entity.Property(e => e.FotoPerfilEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("foto_perfil_empresa");

                entity.Property(e => e.NombreEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("nombre_empresa");

                entity.Property(e => e.RubroEmpresa)
                    .HasColumnType("text")
                    .HasColumnName("rubro_empresa");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PRIMARY");

                entity.ToTable("login");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdLogin)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_login");

                entity.Property(e => e.Contraseña)
                    .HasColumnType("text")
                    .HasColumnName("contraseña");

                entity.Property(e => e.Correo)
                    .HasColumnType("text")
                    .HasColumnName("correo");

                entity.Property(e => e.Rol)
                    .HasColumnType("text")
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<Postulacion>(entity =>
            {
                entity.HasKey(e => e.IdPostulacion)
                    .HasName("PRIMARY");

                entity.ToTable("postulacion");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Puesto, "puesto_postulacion");

                entity.HasIndex(e => e.Postulante, "usuario_postulacion");

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
                    .HasColumnType("text")
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

                entity.HasOne(d => d.PostulanteNavigation)
                    .WithMany(p => p.Postulacions)
                    .HasForeignKey(d => d.Postulante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_postulacion");

                entity.HasOne(d => d.PuestoNavigation)
                    .WithMany(p => p.Postulacions)
                    .HasForeignKey(d => d.Puesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("puesto_postulacion");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PRIMARY");

                entity.ToTable("puesto");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Empresa, "puesto_empresa");

                entity.Property(e => e.IdPuesto)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_puesto");

                entity.Property(e => e.DescripcionPuesto)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_puesto");

                entity.Property(e => e.Empresa)
                    .HasColumnType("int(11)")
                    .HasColumnName("empresa");

                entity.Property(e => e.FotoPuesto)
                    .HasColumnType("text")
                    .HasColumnName("foto_puesto");

                entity.Property(e => e.LugarPuesto)
                    .HasColumnType("text")
                    .HasColumnName("lugar_puesto");

                entity.Property(e => e.NombrePuesto)
                    .HasColumnType("text")
                    .HasColumnName("nombre_puesto");

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.Property(e => e.TipoPuesto)
                    .HasColumnType("text")
                    .HasColumnName("tipo_puesto");

                entity.Property(e => e.VacantesPuesto)
                    .HasColumnType("int(11)")
                    .HasColumnName("vacantes_puesto");

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("puesto_empresa");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

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

                entity.Property(e => e.CorreoUsuario)
                    .HasColumnType("text")
                    .HasColumnName("correo_usuario");

                entity.Property(e => e.EstudiosUsuario)
                    .HasColumnType("text")
                    .HasColumnName("estudios_usuario");

                entity.Property(e => e.FNacUsuario).HasColumnName("f_nac_usuario");

                entity.Property(e => e.FotoPerfilUsuario)
                    .HasColumnType("text")
                    .HasColumnName("foto_perfil_usuario");

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
