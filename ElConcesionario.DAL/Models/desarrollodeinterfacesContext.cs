using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElConcesionario.DAL.Models
{
    public partial class desarrollodeinterfacesContext : DbContext
    {
        public desarrollodeinterfacesContext()
        {
        }

        public desarrollodeinterfacesContext(DbContextOptions<desarrollodeinterfacesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Mecánico> Mecánico { get; set; }
        public virtual DbSet<Propuestas> Propuestas { get; set; }
        public virtual DbSet<Reparación> Reparación { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehículo> Vehículo { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=desarrollodeinterfaces");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.DniCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.DniCliente)
                    .HasColumnName("DNI_Cliente")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Teléfono).HasColumnType("int(9)");
            });

            modelBuilder.Entity<Mecánico>(entity =>
            {
                entity.HasKey(e => e.DniUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("mecánico");

                entity.Property(e => e.DniUsuario)
                    .HasColumnName("DNI_Usuario")
                    .HasMaxLength(15);

                entity.Property(e => e.EsJefe)
                    .HasColumnName("Es_Jefe")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DniUsuarioNavigation)
                    .WithOne(p => p.Mecánico)
                    .HasForeignKey<Mecánico>(d => d.DniUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DNI_Usuario");
            });

            modelBuilder.Entity<Propuestas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("propuestas");

                entity.Property(e => e.DniCliente)
                    .IsRequired()
                    .HasColumnName("DNI_Cliente")
                    .HasMaxLength(15);

                entity.Property(e => e.FechaEntrada)
                    .IsRequired()
                    .HasColumnName("Fecha_Entrada")
                    .HasMaxLength(45);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Reparación>(entity =>
            {
                entity.HasKey(e => e.NumIncidencia)
                    .HasName("PRIMARY");

                entity.ToTable("reparación");

                entity.HasIndex(e => e.DniCliente)
                    .HasName("DNI_Cliente3");

                entity.HasIndex(e => e.DniUsuario)
                    .HasName("DNI_Usuario3");

                entity.Property(e => e.NumIncidencia).HasColumnType("int(11)");

                entity.Property(e => e.Coste)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DniCliente)
                    .IsRequired()
                    .HasColumnName("DNI_Cliente")
                    .HasMaxLength(15);

                entity.Property(e => e.DniUsuario)
                    .HasColumnName("DNI_Usuario")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Piezas)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Problema)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Teléfono)
                    .HasMaxLength(9)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TiempoEstimado)
                    .IsRequired()
                    .HasColumnName("Tiempo_Estimado")
                    .HasMaxLength(45);

                entity.HasOne(d => d.DniClienteNavigation)
                    .WithMany(p => p.Reparación)
                    .HasForeignKey(d => d.DniCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DNI_Cliente3");

                entity.HasOne(d => d.DniUsuarioNavigation)
                    .WithMany(p => p.Reparación)
                    .HasForeignKey(d => d.DniUsuario)
                    .HasConstraintName("DNI_Usuario3");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.DniUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Correo)
                    .HasName("Correo_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Nuss)
                    .HasName("NUSS_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Usuario1)
                    .HasName("Usuario_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DniUsuario)
                    .HasColumnName("DNI_Usuario")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nuss)
                    .IsRequired()
                    .HasColumnName("NUSS")
                    .HasMaxLength(45);

                entity.Property(e => e.Profesión)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.SueldoBase).HasColumnType("int(11)");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Vehículo>(entity =>
            {
                entity.HasKey(e => e.NumSerial)
                    .HasName("PRIMARY");

                entity.ToTable("vehículo");

                entity.Property(e => e.NumSerial)
                    .HasColumnName("Num_Serial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Anyo).HasColumnType("int(4)");

                entity.Property(e => e.Combustible)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.FechaEntrada)
                    .IsRequired()
                    .HasColumnName("Fecha_Entrada")
                    .HasMaxLength(10);

                entity.Property(e => e.InfAdicional)
                    .HasColumnName("Inf_Adicional")
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Kilometros).HasColumnType("int(10)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Precio).HasColumnType("int(11)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => new { e.NumSerial, e.DniCliente, e.DniUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("venta");

                entity.HasIndex(e => e.DniCliente)
                    .HasName("DNI_Cliente_idx");

                entity.HasIndex(e => e.DniUsuario)
                    .HasName("DNI_Usuario_idx");

                entity.Property(e => e.NumSerial)
                    .HasColumnName("Num_Serial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DniCliente)
                    .HasColumnName("DNI_Cliente")
                    .HasMaxLength(15);

                entity.Property(e => e.DniUsuario)
                    .HasColumnName("DNI_Usuario")
                    .HasMaxLength(15);

                entity.Property(e => e.Beneficios).HasColumnType("int(11)");

                entity.Property(e => e.Plazo)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.DniClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.DniCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DNI_Cliente2");

                entity.HasOne(d => d.DniUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.DniUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DNI_Usuario2");

                entity.HasOne(d => d.NumSerialNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.NumSerial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Num_Serial");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
