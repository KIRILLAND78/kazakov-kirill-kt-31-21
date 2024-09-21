﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using kazakov_kirill_kt_31_21.Data;

#nullable disable

namespace kazakov_kirill_kt_31_21.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    [Migration("20240921090504_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProfessorSubject", b =>
                {
                    b.Property<long>("ProfessorsId")
                        .HasColumnType("int8");

                    b.Property<long>("SubjectsId")
                        .HasColumnType("int8");

                    b.HasKey("ProfessorsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("ProfessorSubject");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Faculty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int8")
                        .HasColumnName("id")
                        .HasComment("Идентификатор кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("LeadProfessorId")
                        .HasColumnType("int8")
                        .HasColumnName("lead_professor_id")
                        .HasComment("Идентификатор заведующего кафедрой, может быть null");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasComment("Название кафедры");

                    b.Property<long?>("lead_professor_id")
                        .HasColumnType("int8");

                    b.HasKey("Id")
                        .HasName("pk_cd_faculty_faculty_id");

                    b.HasIndex("lead_professor_id")
                        .IsUnique();

                    b.ToTable("cd_faculty", null, t =>
                        {
                            t.Property("lead_professor_id")
                                .HasColumnName("lead_professor_id1");
                        });
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int8")
                        .HasColumnName("id")
                        .HasComment("Идентификатор должности");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasComment("Название должности");

                    b.HasKey("Id")
                        .HasName("pk_cd_post_post_id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Professor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int8")
                        .HasColumnName("id")
                        .HasComment("Идентификатор преподавателя");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("FacultyId")
                        .HasColumnType("int8")
                        .HasColumnName("faculty_id")
                        .HasComment("Идентификатор кафедры, в которой находится преподаватель");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasComment("Название кафедры");

                    b.Property<long>("PostId")
                        .HasColumnType("int8")
                        .HasColumnName("post_id")
                        .HasComment("Идентификатор должности преподавателя");

                    b.Property<long>("RankId")
                        .HasColumnType("int8")
                        .HasColumnName("rank_id")
                        .HasComment("Идентификатор ученой степени преподавателя");

                    b.HasKey("Id")
                        .HasName("pk_cd_professor_professor_id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("PostId");

                    b.HasIndex("RankId");

                    b.ToTable("cd_professor", (string)null);
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Rank", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int8")
                        .HasColumnName("id")
                        .HasComment("Идентификатор ученой степени");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasComment("Название ученой степени");

                    b.HasKey("Id")
                        .HasName("pk_cd_rank_rank_id");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Subject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int8")
                        .HasColumnName("id")
                        .HasComment("Идентификатор учебного предмета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasComment("Название учебного предмета");

                    b.Property<long>("WorkloadId")
                        .HasColumnType("int8")
                        .HasColumnName("workload_id")
                        .HasComment("Идентификатор учебной нагрузки");

                    b.HasKey("Id")
                        .HasName("pk_cd_subject_subject_id");

                    b.HasIndex("WorkloadId");

                    b.ToTable("cd_subject", (string)null);
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Workload", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int8")
                        .HasColumnName("id")
                        .HasComment("Идентификатор учебной нагрузки");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Hours")
                        .HasColumnType("int4")
                        .HasColumnName("hours")
                        .HasComment("Часы учебной нагрузки");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasComment("Название учебной нагрузки");

                    b.HasKey("Id")
                        .HasName("pk_cd_workload_workload_id");

                    b.ToTable("Workloads");
                });

            modelBuilder.Entity("ProfessorSubject", b =>
                {
                    b.HasOne("kazakov_kirill_kt_31_21.Models.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kazakov_kirill_kt_31_21.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Faculty", b =>
                {
                    b.HasOne("kazakov_kirill_kt_31_21.Models.Professor", "LeadProfessor")
                        .WithOne("FacultyLead")
                        .HasForeignKey("kazakov_kirill_kt_31_21.Models.Faculty", "lead_professor_id")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_k_lead_professor_id");

                    b.Navigation("LeadProfessor");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Professor", b =>
                {
                    b.HasOne("kazakov_kirill_kt_31_21.Models.Faculty", "Faculty")
                        .WithMany("Professors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_k_faculty_id");

                    b.HasOne("kazakov_kirill_kt_31_21.Models.Post", "Post")
                        .WithMany("Professors")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_k_post_id");

                    b.HasOne("kazakov_kirill_kt_31_21.Models.Rank", "Rank")
                        .WithMany("Professors")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_k_rank_id");

                    b.Navigation("Faculty");

                    b.Navigation("Post");

                    b.Navigation("Rank");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Subject", b =>
                {
                    b.HasOne("kazakov_kirill_kt_31_21.Models.Workload", "Workload")
                        .WithMany("Subjects")
                        .HasForeignKey("WorkloadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_k_workload_id");

                    b.Navigation("Workload");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Faculty", b =>
                {
                    b.Navigation("Professors");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Post", b =>
                {
                    b.Navigation("Professors");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Professor", b =>
                {
                    b.Navigation("FacultyLead");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Rank", b =>
                {
                    b.Navigation("Professors");
                });

            modelBuilder.Entity("kazakov_kirill_kt_31_21.Models.Workload", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
