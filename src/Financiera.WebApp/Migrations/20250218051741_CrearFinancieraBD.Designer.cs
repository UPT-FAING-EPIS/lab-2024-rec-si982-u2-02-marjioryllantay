﻿// <auto-generated />
using System;
using Financiera.WebApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Financiera.WebApp.Migrations
{
    [DbContext(typeof(FinancieraContexto))]
    [Migration("20250218051741_CrearFinancieraBD")]
    partial class CrearFinancieraBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Financiera.WebApp.Modelos.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CLIENTE")
                        .HasComment("Identificador unico del cliente");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("NOM_CLIENTE")
                        .HasComment("Nombre del cliente");

                    b.HasKey("IdCliente");

                    b.ToTable("CLIENTES", (string)null);
                });

            modelBuilder.Entity("Financiera.WebApp.Modelos.CuentaAhorro", b =>
                {
                    b.Property<int>("IdCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CUENTA");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaApertura")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int")
                        .HasColumnName("ID_CLIENTE");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("NUM_CUENTA");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Tasa")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("IdCuenta");

                    b.HasIndex("IdPropietario");

                    b.ToTable("CUENTAS_AHORRO", (string)null);
                });

            modelBuilder.Entity("Financiera.WebApp.Modelos.MovimientoCuenta", b =>
                {
                    b.Property<int>("NumeroMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NUM_MOVIMIENTO");

                    b.Property<int?>("CuentaAhorroIdCuenta")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCuenta")
                        .HasColumnType("int")
                        .HasColumnName("ID_CUENTA");

                    b.Property<int>("IdTipoMovimiento")
                        .HasColumnType("int")
                        .HasColumnName("ID_TIPO");

                    b.Property<decimal>("MontoMovimiento")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("MON_MOVIMIENTO");

                    b.HasKey("NumeroMovimiento");

                    b.HasIndex("CuentaAhorroIdCuenta");

                    b.HasIndex("IdCuenta");

                    b.HasIndex("IdTipoMovimiento");

                    b.ToTable("MOVIMIENTOS_CUENTA", (string)null);
                });

            modelBuilder.Entity("Financiera.WebApp.Modelos.TipoMovimiento", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TIPO")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionTipo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DES_TIPO");

                    b.HasKey("IdTipo");

                    b.ToTable("TIPOS_MOVIMIENTO", (string)null);
                });

            modelBuilder.Entity("Financiera.WebApp.Modelos.CuentaAhorro", b =>
                {
                    b.HasOne("Financiera.WebApp.Modelos.Cliente", "Propietario")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("Financiera.WebApp.Modelos.MovimientoCuenta", b =>
                {
                    b.HasOne("Financiera.WebApp.Modelos.CuentaAhorro", null)
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaAhorroIdCuenta");

                    b.HasOne("Financiera.WebApp.Modelos.CuentaAhorro", "Cuenta")
                        .WithMany()
                        .HasForeignKey("IdCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Financiera.WebApp.Modelos.TipoMovimiento", "Tipo")
                        .WithMany()
                        .HasForeignKey("IdTipoMovimiento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Financiera.WebApp.Modelos.CuentaAhorro", b =>
                {
                    b.Navigation("Movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
