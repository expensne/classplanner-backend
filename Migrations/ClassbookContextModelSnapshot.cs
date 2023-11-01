﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Models;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ClassbookContext))]
    partial class ClassbookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("backend.Exam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<float>("MaxScore")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("backend.GradingScale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<float>("APercent")
                        .HasColumnType("REAL");

                    b.Property<float>("BPercent")
                        .HasColumnType("REAL");

                    b.Property<float>("CPercent")
                        .HasColumnType("REAL");

                    b.Property<float>("DPercent")
                        .HasColumnType("REAL");

                    b.Property<float>("EPercent")
                        .HasColumnType("REAL");

                    b.Property<long>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("FPercent")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ExamId")
                        .IsUnique();

                    b.ToTable("GradingScale");
                });

            modelBuilder.Entity("backend.Postscript", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<long>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Postscript");
                });

            modelBuilder.Entity("backend.Score", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<long>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPostscript")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("backend.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("backend.GradingScale", b =>
                {
                    b.HasOne("backend.Exam", null)
                        .WithOne("GradingScale")
                        .HasForeignKey("backend.GradingScale", "ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Postscript", b =>
                {
                    b.HasOne("backend.Exam", null)
                        .WithMany("Postscripts")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Student", null)
                        .WithMany("Postscripts")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Score", b =>
                {
                    b.HasOne("backend.Exam", null)
                        .WithMany("Scores")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Student", null)
                        .WithMany("Scores")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Exam", b =>
                {
                    b.Navigation("GradingScale");

                    b.Navigation("Postscripts");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("backend.Student", b =>
                {
                    b.Navigation("Postscripts");

                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
