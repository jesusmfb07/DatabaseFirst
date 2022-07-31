using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirst.Models
{
    public partial class DBRestauranteContext : DbContext
    {
        public DBRestauranteContext()
        {
        }

        public DBRestauranteContext(DbContextOptions<DBRestauranteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<Cartum> Carta { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Comprobante> Comprobantes { get; set; } = null!;
        public virtual DbSet<Comprobantedetalle> Comprobantedetalles { get; set; } = null!;
        public virtual DbSet<Insumo> Insumos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<ProductoVentum> ProductoVenta { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<Trabajador> Trabajadors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8JC96OU;Database=DBRestaurante;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("cargo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("salario");
            });

            modelBuilder.Entity<Cartum>(entity =>
            {
                entity.ToTable("carta");

                entity.Property(e => e.Descripccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRestaurantNavigation)
                    .WithMany(p => p.Carta)
                    .HasForeignKey(d => d.IdRestaurant)
                    .HasConstraintName("FK__carta__IdRestaur__398D8EEE");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.ToTable("comprobante");

                entity.Property(e => e.Fechas).HasColumnType("date");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.HasOne(d => d.IdTrabajadorNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdTrabajador)
                    .HasConstraintName("FK__comproban__IdTra__3D5E1FD2");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK__comproban__IDCli__3C69FB99");
            });

            modelBuilder.Entity<Comprobantedetalle>(entity =>
            {
                entity.HasKey(e => new { e.IdComprobante, e.IdProductoVenta })
                    .HasName("PK__Comproba__A0F1BAD8E376B9C7");

                entity.ToTable("Comprobantedetalle");

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(21, 2)")
                    .HasComputedColumnSql("([Cantidad]*[Precio])", false);

                entity.HasOne(d => d.IdComprobanteNavigation)
                    .WithMany(p => p.Comprobantedetalles)
                    .HasForeignKey(d => d.IdComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comproban__IdCom__403A8C7D");

                entity.HasOne(d => d.IdProductoVentaNavigation)
                    .WithMany(p => p.Comprobantedetalles)
                    .HasForeignKey(d => d.IdProductoVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comproban__IdPro__412EB0B6");
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.ToTable("Insumo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK__Insumo__IdProvee__32E0915F");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Idrestaurant).HasColumnName("idrestaurant");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idproveedor)
                    .HasConstraintName("FK__pedido__idprovee__35BCFE0A");

                entity.HasOne(d => d.IdrestaurantNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idrestaurant)
                    .HasConstraintName("FK__pedido__idrestau__36B12243");
            });

            modelBuilder.Entity<ProductoVentum>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Receta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("receta");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdrestaurantNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.Idrestaurant)
                    .HasConstraintName("FK__Proveedor__Idres__300424B4");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.ToTable("trabajador");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Edad)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Trabajadors)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK__trabajado__IdCar__2D27B809");

                entity.HasOne(d => d.IdRestaurantNavigation)
                    .WithMany(p => p.Trabajadors)
                    .HasForeignKey(d => d.IdRestaurant)
                    .HasConstraintName("FK__trabajado__IdRes__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
