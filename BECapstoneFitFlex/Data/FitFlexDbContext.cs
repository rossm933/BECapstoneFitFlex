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

        }
    }
}
