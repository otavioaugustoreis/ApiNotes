﻿// <auto-generated />
using System;
using ApiNotes.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiNotes.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ApiNotes.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ds_name");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("fk_user");

                    b.Property<string>("password")
                        .HasColumnType("longtext")
                        .HasColumnName("ds_senha");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("ApiNotes.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ds_name");

                    b.Property<int>("PathID")
                        .HasColumnType("int")
                        .HasColumnName("fk_path");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("fk_usuario");

                    b.HasKey("Id");

                    b.HasIndex("PathID");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("ApiNotes.Entities.Path", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("ds_descricao");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ds_name");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("fk_usuario");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("ApiNotes.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pk_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("nr_idade");

                    b.Property<DateTime>("DateOfInclusion")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dh_inclusao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("ds_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ds_name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiNotes.Entities.Login", b =>
                {
                    b.HasOne("ApiNotes.Entities.User", "User")
                        .WithOne("Login")
                        .HasForeignKey("ApiNotes.Entities.Login", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiNotes.Entities.Note", b =>
                {
                    b.HasOne("ApiNotes.Entities.Path", "Path")
                        .WithMany("Notes")
                        .HasForeignKey("PathID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiNotes.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Path");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ApiNotes.Entities.Path", b =>
                {
                    b.HasOne("ApiNotes.Entities.User", "User")
                        .WithMany("Paths")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiNotes.Entities.Path", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("ApiNotes.Entities.User", b =>
                {
                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Paths");
                });
#pragma warning restore 612, 618
        }
    }
}
