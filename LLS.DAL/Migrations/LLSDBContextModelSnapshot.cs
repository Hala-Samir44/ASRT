﻿// <auto-generated />
using System;
using LLS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LLS.DAL.Migrations
{
    [DbContext(typeof(LLSDBContext))]
    partial class LLSDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("LLS.DAL.Entity.Course", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("fulllName")
                        .HasColumnType("text");

                    b.Property<string>("shortName")
                        .HasColumnType("text");

                    b.Property<string>("startDate")
                        .HasColumnType("text");

                    b.Property<string>("summary")
                        .HasColumnType("text");

                    b.Property<DateTime?>("timeCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("timeModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("LLS.DAL.Entity.CourseExperiments", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("courseId")
                        .HasColumnType("text");

                    b.Property<string>("experimentId")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("courseId");

                    b.HasIndex("experimentId");

                    b.ToTable("CourseExperiments");
                });

            modelBuilder.Entity("LLS.DAL.Entity.CourseUsers", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("courseId")
                        .HasColumnType("text");

                    b.Property<string>("userId")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("courseId");

                    b.HasIndex("userId");

                    b.ToTable("CourseUsers");
                });

            modelBuilder.Entity("LLS.DAL.Entity.Experiment", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("expUrl")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("search")
                        .HasColumnType("text");

                    b.Property<DateTime?>("startDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("version")
                        .HasColumnType("integer");

                    b.Property<bool>("visible")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("Experiment");
                });

            modelBuilder.Entity("LLS.DAL.Entity.Permission", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("title")
                        .IsUnique();

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("LLS.DAL.Entity.Role", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("title")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LLS.DAL.Entity.RolePermissions", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("permissionId")
                        .HasColumnType("text");

                    b.Property<string>("roleId")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("permissionId");

                    b.HasIndex("roleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("LLS.DAL.Entity.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("firstAccess")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("firstname")
                        .HasColumnType("text");

                    b.Property<DateTime?>("lastAccess")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("lastname")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("roleId")
                        .HasColumnType("text");

                    b.Property<string>("timezone")
                        .HasColumnType("text");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("roleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LLS.DAL.Entity.CourseExperiments", b =>
                {
                    b.HasOne("LLS.DAL.Entity.Course", "Course")
                        .WithMany()
                        .HasForeignKey("courseId");

                    b.HasOne("LLS.DAL.Entity.Experiment", "Experiment")
                        .WithMany()
                        .HasForeignKey("experimentId");

                    b.Navigation("Course");

                    b.Navigation("Experiment");
                });

            modelBuilder.Entity("LLS.DAL.Entity.CourseUsers", b =>
                {
                    b.HasOne("LLS.DAL.Entity.Course", "Course")
                        .WithMany()
                        .HasForeignKey("courseId");

                    b.HasOne("LLS.DAL.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LLS.DAL.Entity.RolePermissions", b =>
                {
                    b.HasOne("LLS.DAL.Entity.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("permissionId");

                    b.HasOne("LLS.DAL.Entity.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("roleId");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LLS.DAL.Entity.User", b =>
                {
                    b.HasOne("LLS.DAL.Entity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("roleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LLS.DAL.Entity.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("LLS.DAL.Entity.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
