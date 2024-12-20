namespace BECapstoneFitFlex.DTOs
{
    public class UpdateWorkoutDTO
    {
        public string? WorkoutName { get; set; }
        public string? Description { get; set; }

        public List<int>? ExerciseIds { get; set; }
        public int UserId { get; set; }
    }
}
