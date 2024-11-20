﻿// <auto-generated />
using System;
using BECapstoneFitFlex.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BECapstoneFitFlex.Migrations
{
    [DbContext(typeof(FitFlexDbContext))]
    partial class FitFlexDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BECapstoneFitFlex.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ExerciseName")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<int>("Repetitions")
                        .HasColumnType("integer");

                    b.Property<int>("Sets")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Chest and triceps workout with a barbell.",
                            ExerciseName = "Bench Press",
                            ImageUrl = "https://www.shutterstock.com/image-illustration/closegrip-barbell-bench-press-3d-600nw-430936051.jpg",
                            Repetitions = 10,
                            Sets = 3,
                            UserId = 100,
                            Weight = 80.5m,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Full-body compound exercise.",
                            ExerciseName = "Deadlift",
                            ImageUrl = "https://www.evolvefitstudios.com/uploads/1/0/2/9/102951852/deadlifts_orig.jpeg",
                            Repetitions = 8,
                            Sets = 4,
                            UserId = 100,
                            Weight = 100m,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lower body strength exercise.",
                            ExerciseName = "Squats",
                            ImageUrl = "https://static.strengthlevel.com/images/exercises/squat/squat-800.jpg",
                            Repetitions = 12,
                            Sets = 3,
                            UserId = 100,
                            Weight = 60m,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Upper body workout targeting back and biceps.",
                            ExerciseName = "Pull-Ups",
                            ImageUrl = "https://anabolicaliens.com/cdn/shop/articles/199990_400x.png?v=1645089103",
                            Repetitions = 10,
                            Sets = 3,
                            UserId = 100,
                            Weight = 0m,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Shoulder strength exercise with a barbell.",
                            ExerciseName = "Shoulder Press",
                            ImageUrl = "https://static.strengthlevel.com/images/exercises/shoulder-press/shoulder-press-800.jpg",
                            Repetitions = 8,
                            Sets = 4,
                            UserId = 100,
                            Weight = 50m,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Core stability exercise.",
                            ExerciseName = "Plank",
                            ImageUrl = "https://www.inspireusafoundation.org/wp-content/uploads/2023/07/plank-benefits.png",
                            Repetitions = 1,
                            Sets = 3,
                            UserId = 100,
                            Weight = 0m,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "Isolation exercise for the biceps.",
                            ExerciseName = "Bicep Curls",
                            ImageUrl = "https://cdn.shopify.com/s/files/1/2384/0833/files/inner-bicep-curl-benefits.jpg?v=1689192787",
                            Repetitions = 12,
                            Sets = 3,
                            UserId = 100,
                            Weight = 15m,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 8,
                            Description = "Strengthens triceps and shoulders.",
                            ExerciseName = "Tricep Dips",
                            ImageUrl = "https://pump-app.s3.eu-west-2.amazonaws.com/exercise-assets/17551101-Weighted-Tricep-Dips_Upper-Arms_small.jpg",
                            Repetitions = 12,
                            Sets = 3,
                            UserId = 100,
                            Weight = 0m,
                            WorkoutId = 1
                        });
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.ExerciseTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TagId");

                    b.ToTable("ExerciseTag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            TagId = 1
                        },
                        new
                        {
                            Id = 5,
                            ExerciseId = 1,
                            TagId = 2
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 2,
                            TagId = 3
                        },
                        new
                        {
                            Id = 6,
                            ExerciseId = 2,
                            TagId = 4
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 3,
                            TagId = 4
                        },
                        new
                        {
                            Id = 7,
                            ExerciseId = 4,
                            TagId = 3
                        },
                        new
                        {
                            Id = 8,
                            ExerciseId = 4,
                            TagId = 7
                        },
                        new
                        {
                            Id = 9,
                            ExerciseId = 5,
                            TagId = 5
                        },
                        new
                        {
                            Id = 10,
                            ExerciseId = 6,
                            TagId = 6
                        },
                        new
                        {
                            Id = 11,
                            ExerciseId = 7,
                            TagId = 7
                        },
                        new
                        {
                            Id = 12,
                            ExerciseId = 8,
                            TagId = 2
                        });
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chest"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Triceps"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Back"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Legs"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Shoulders"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Core"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Biceps"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Strength"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Flexibility"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Endurance"
                        });
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            Email = "ross.morgan933@gmail.com",
                            ImageUrl = "https://avatars.githubusercontent.com/u/148557558?v=4",
                            Name = "Ross Morgan",
                            Password = "password123"
                        },
                        new
                        {
                            Id = 101,
                            Email = "janesmith@example.com",
                            ImageUrl = "https://example.com/images/jane_smith.jpg",
                            Name = "Jane Smith",
                            Password = "securepass456"
                        });
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("WorkoutName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workout");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1999),
                            Description = "Focus on building upper body strength with weights.",
                            UserId = 100,
                            WorkoutName = "Strength Training"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1994),
                            Description = "Focus on lower body strength with weights.",
                            UserId = 100,
                            WorkoutName = "Leg Day"
                        });
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Exercise", b =>
                {
                    b.HasOne("BECapstoneFitFlex.Models.User", null)
                        .WithMany("Exercise")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BECapstoneFitFlex.Models.Workout", "Workout")
                        .WithMany("Exercise")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.ExerciseTag", b =>
                {
                    b.HasOne("BECapstoneFitFlex.Models.Exercise", "Exercise")
                        .WithMany("ExerciseTag")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BECapstoneFitFlex.Models.Tag", "Tag")
                        .WithMany("ExerciseTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Tag", b =>
                {
                    b.HasOne("BECapstoneFitFlex.Models.Exercise", null)
                        .WithMany("Tag")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Workout", b =>
                {
                    b.HasOne("BECapstoneFitFlex.Models.User", "User")
                        .WithMany("Workout")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Exercise", b =>
                {
                    b.Navigation("ExerciseTag");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Tag", b =>
                {
                    b.Navigation("ExerciseTag");
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.User", b =>
                {
                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("BECapstoneFitFlex.Models.Workout", b =>
                {
                    b.Navigation("Exercise");
                });
#pragma warning restore 612, 618
        }
    }
}
