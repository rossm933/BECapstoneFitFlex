using BECapstoneFitFlex.Models;

namespace BECapstoneFitFlex.DTOs
{
    public class WorkoutDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? WorkoutName { get; set; }
        public string? Description { get; set; }

        public int? ExerciseId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Exercise>? Exercise { get; set; }
        public List<ExerciseWorkout>? ExerciseWorkout { get; set; }
    }
}
