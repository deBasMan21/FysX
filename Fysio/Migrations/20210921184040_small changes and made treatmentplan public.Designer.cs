﻿// <auto-generated />
using System;
using DomainServices.Interfaces;
using EFInfrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fysio.Migrations
{
    [DbContext(typeof(FysioDbContext))]
    [Migration("20210921184040_small changes and made treatmentplan public")]
    partial class smallchangesandmadetreatmentplanpublic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Account", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.HasIndex("PatientId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Domain.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("TreatorEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("TreatorEmail");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Domain.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FREndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FRStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MOEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MOStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("THEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("THStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TUEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TUStartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatorEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("WEEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WEStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TreatorEmail");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientFileId")
                        .HasColumnType("int");

                    b.Property<bool>("VisibleForPatient")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CreatorEmail");

                    b.HasIndex("PatientFileId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistrationNumber")
                        .HasColumnType("int");

                    b.Property<bool>("Student")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.PatientFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Complaints")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosisCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosisDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IntakerEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MainTreatorEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SupervisingTreatorEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TreatmentPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IntakerEmail");

                    b.HasIndex("MainTreatorEmail");

                    b.HasIndex("PatientId");

                    b.HasIndex("SupervisingTreatorEmail");

                    b.HasIndex("TreatmentPlanId");

                    b.ToTable("PatientFiles");
                });

            modelBuilder.Entity("Domain.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Particularities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientFileId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TreatmentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatorEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientFileId");

                    b.HasIndex("PatientId");

                    b.HasIndex("TreatorEmail");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("Domain.TreatmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MinutesPerSession")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentsPerWeek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TreatmentPlans");
                });

            modelBuilder.Entity("Domain.Treator", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Treators");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Treator");
                });

            modelBuilder.Entity("Domain.FysioTherapist", b =>
                {
                    b.HasBaseType("Domain.Treator");

                    b.Property<int>("BIGNumber")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherNumber")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("FysioTherapist");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasBaseType("Domain.Treator");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Email = "bbuijsen@gmail.com",
                            Name = "Bas Buijsen",
                            StudentNumber = 2170769
                        });
                });

            modelBuilder.Entity("Domain.Account", b =>
                {
                    b.HasOne("Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Appointment", b =>
                {
                    b.HasOne("Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Domain.Treator", "Treator")
                        .WithMany()
                        .HasForeignKey("TreatorEmail");

                    b.Navigation("Patient");

                    b.Navigation("Treator");
                });

            modelBuilder.Entity("Domain.Availability", b =>
                {
                    b.HasOne("Domain.Treator", "Treator")
                        .WithMany()
                        .HasForeignKey("TreatorEmail");

                    b.Navigation("Treator");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.Treator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorEmail");

                    b.HasOne("Domain.PatientFile", null)
                        .WithMany("Comments")
                        .HasForeignKey("PatientFileId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Domain.PatientFile", b =>
                {
                    b.HasOne("Domain.Treator", "Intaker")
                        .WithMany()
                        .HasForeignKey("IntakerEmail");

                    b.HasOne("Domain.Treator", "MainTreator")
                        .WithMany()
                        .HasForeignKey("MainTreatorEmail");

                    b.HasOne("Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Domain.Treator", "SupervisingTreator")
                        .WithMany()
                        .HasForeignKey("SupervisingTreatorEmail");

                    b.HasOne("Domain.TreatmentPlan", "TreatmentPlan")
                        .WithMany()
                        .HasForeignKey("TreatmentPlanId");

                    b.Navigation("Intaker");

                    b.Navigation("MainTreator");

                    b.Navigation("Patient");

                    b.Navigation("SupervisingTreator");

                    b.Navigation("TreatmentPlan");
                });

            modelBuilder.Entity("Domain.Treatment", b =>
                {
                    b.HasOne("Domain.PatientFile", null)
                        .WithMany("Treatments")
                        .HasForeignKey("PatientFileId");

                    b.HasOne("Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Domain.Treator", "Treator")
                        .WithMany()
                        .HasForeignKey("TreatorEmail");

                    b.Navigation("Patient");

                    b.Navigation("Treator");
                });

            modelBuilder.Entity("Domain.PatientFile", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Treatments");
                });
#pragma warning restore 612, 618
        }
    }
}
