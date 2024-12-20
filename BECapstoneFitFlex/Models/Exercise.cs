using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BECapstoneFitFlex.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public int? WorkoutId { get; set; }
        public string? ExerciseName { get; set; }
        public string? Description { get; set; }
        public int Repetitions { get; set; }
        public string? ImageUrl { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; }
        public int UserId { get; set; }
        public List<Tag>? Tag { get; set; }
        public List<ExerciseTag>? ExerciseTag { get; set; }

        public List<ExerciseWorkout>? ExerciseWorkout { get; set; }

        public Workout? Workout { get; set; }
    }
}
