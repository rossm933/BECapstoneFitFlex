namespace BECapstoneFitFlex.DTOs
{
    public class CreateWorkoutDTO
    {
        public int UserId { get; set; }
        public string? WorkoutName { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
