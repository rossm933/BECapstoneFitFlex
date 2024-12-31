using BECapstoneFitFlex.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace BECapstoneFitFlex.Data
{
    public class FitFlexDbContext : DbContext
    {
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Tag> Tag { get; set; }    
        public DbSet<User> User { get; set; }
        public DbSet<ExerciseTag> ExerciseTag { get; set; }

        public DbSet<ExerciseWorkout> ExerciseWorkout { get; set; }
        public FitFlexDbContext(DbContextOptions<FitFlexDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>().HasData(WorkoutData.Workout);
            modelBuilder.Entity<Exercise>().HasData(ExerciseData.Exercise);
            modelBuilder.Entity<Tag>().HasData(TagData.Tag);
            modelBuilder.Entity<User>().HasData(UserData.User);
            modelBuilder.Entity<ExerciseTag>().HasData(ExerciseTagData.ExerciseTag);
            modelBuilder.Entity<ExerciseWorkout>().HasData(ExerciseWorkoutData.ExerciseWorkout);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Workout)
                .WithOne(r => r.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercise)
                .WithOne(r => r.Workout)
                .HasForeignKey(w => w.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(u => u.Workout)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.ExerciseTag)
                .WithOne(r => r.Exercise)
                .HasForeignKey(r => r.ExerciseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExerciseTag>()
                .HasOne(r => r.Tag)
                .WithMany(v => v.ExerciseTag)
                .HasForeignKey(r => r.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExerciseWorkout>()
                .HasOne(ew => ew.Exercise)
                .WithMany(e => e.ExerciseWorkout)
                .HasForeignKey(ew => ew.ExerciseId)
                .OnDelete(DeleteBehavior.Cascade); // or DeleteBehavior.Restrict / SetNull based on requirements

            modelBuilder.Entity<Workout>()
                .HasMany(w => w.ExerciseWorkout)
                .WithOne(e => e.Workout)
                .HasForeignKey(ew => ew.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade); // or DeleteBehavior.Restrict / SetNull based on requirements

            modelBuilder.Entity<ExerciseWorkout>()
                .HasKey(ew => ew.Id); // Use a composite key instead if you prefer

            modelBuilder.Entity<ExerciseWorkout>()
                .Property(ew => ew.WorkoutId)
                .IsRequired();

            modelBuilder.Entity<ExerciseWorkout>()
                .Property(ew => ew.ExerciseId)
                .IsRequired();

        }
    }
}
