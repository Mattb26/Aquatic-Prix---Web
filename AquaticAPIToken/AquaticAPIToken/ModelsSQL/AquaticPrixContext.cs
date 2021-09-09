using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AquaticAPIToken.ModelsSQL
{
    public partial class AquaticPrixContext : IdentityDbContext
    {
        public AquaticPrixContext()
        {
        }

        public AquaticPrixContext(DbContextOptions<AquaticPrixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Estadistica> Estadisticas { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<PersonaUsuario> PersonaUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioEstadistica> UsuarioEstadisticas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIND_10_BPO; Database=AquaticPrix; User id=sa; Password=Bostero10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto);

                entity.ToTable("Contacto");

                entity.Property(e => e.IdContacto).HasColumnName("idContacto");

                entity.Property(e => e.Asunto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("asunto");

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mensaje");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estadistica>(entity =>
            {
                entity.HasKey(e => e.IdEstadistica);

                entity.Property(e => e.IdEstadistica).HasColumnName("idEstadistica");

                entity.Property(e => e.Bajas).HasColumnName("bajas");

                entity.Property(e => e.Caidas).HasColumnName("caidas");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Perdido).HasColumnName("perdido");

                entity.Property(e => e.Posicion).HasColumnName("posicion");

                entity.Property(e => e.PromedioCaidas).HasColumnName("promedioCaidas");

                entity.Property(e => e.PromedioPartidas).HasColumnName("promedioPartidas");

                entity.Property(e => e.Promediobaja).HasColumnName("promediobaja");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.CorreoElectronico);

                entity.ToTable("Persona");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAlta");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaBaja");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<PersonaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioPersona);

                entity.ToTable("PersonaUsuario");

                entity.Property(e => e.IdUsuarioPersona).HasColumnName("idUsuarioPersona");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAlta");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaBaja");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");
            });

            modelBuilder.Entity<UsuarioEstadistica>(entity =>
            {
                entity.ToTable("usuarioEstadistica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fechaalta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaalta");

                entity.Property(e => e.Idestadistica).HasColumnName("idestadistica");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
