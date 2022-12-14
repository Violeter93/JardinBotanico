// <auto-generated />
using System;
using JardinBotanico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JardinBotanico.Migrations
{
    [DbContext(typeof(MiContexto))]
    partial class MiContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JardinBotanico.Models.Centro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCentro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Centros");
                });

            modelBuilder.Entity("JardinBotanico.Models.Jardinero", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CentroId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CentroId");

                    b.ToTable("Jardineros");
                });

            modelBuilder.Entity("JardinBotanico.Models.Planta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("JardineroId")
                        .HasColumnType("bigint");

                    b.Property<string>("NombreCientifico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreComun")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JardineroId");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("JardinBotanico.Models.Jardinero", b =>
                {
                    b.HasOne("JardinBotanico.Models.Centro", "Centro")
                        .WithMany("Jardineros")
                        .HasForeignKey("CentroId");

                    b.Navigation("Centro");
                });

            modelBuilder.Entity("JardinBotanico.Models.Planta", b =>
                {
                    b.HasOne("JardinBotanico.Models.Jardinero", "Jardinero")
                        .WithMany("Plantas")
                        .HasForeignKey("JardineroId");

                    b.Navigation("Jardinero");
                });

            modelBuilder.Entity("JardinBotanico.Models.Centro", b =>
                {
                    b.Navigation("Jardineros");
                });

            modelBuilder.Entity("JardinBotanico.Models.Jardinero", b =>
                {
                    b.Navigation("Plantas");
                });
#pragma warning restore 612, 618
        }
    }
}
