using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiVentas.Models
{
    public partial class DB_VENTASContext : DbContext
    {
        public DB_VENTASContext()
        {
        }

        public DB_VENTASContext(DbContextOptions<DB_VENTASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestCliente> TestClientes { get; set; }
        public virtual DbSet<TestFactura> TestFacturas { get; set; }
        public virtual DbSet<TestFacturaDetalle> TestFacturaDetalles { get; set; }
        public virtual DbSet<TestProducto> TestProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TestCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__TEST_CLI__D5946642B883BF5E");

                entity.ToTable("TEST_CLIENTE");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Identifiacion).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<TestFactura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__TEST_FAC__50E7BAF19F7C4536");

                entity.ToTable("TEST_FACTURA");

                entity.Property(e => e.IdFactura)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaVenta).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ValorTotal).HasColumnType("numeric(18, 3)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TestFacturas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEST_FACT__Valor__4D94879B");
            });

            modelBuilder.Entity<TestFacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdFacturaDetalle)
                    .HasName("PK__TEST_FAC__3D8E1AB829B93BDE");

                entity.ToTable("TEST_FACTURA_DETALLE");

                entity.Property(e => e.IdFacturaDetalle)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdFactura).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdProducto).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ValorTotal).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ValorUnidad).HasColumnType("numeric(18, 3)");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.TestFacturaDetalles)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEST_FACT__IdFac__5070F446");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.TestFacturaDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TEST_FACT__IdPro__5165187F");
            });

            modelBuilder.Entity<TestProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__TEST_PRO__0988921093E906B2");

                entity.ToTable("TEST_PRODUCTO");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ValorUnidad).HasColumnType("numeric(18, 3)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
