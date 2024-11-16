namespace BECapstoneFitFlex.DTOs
{
    public class UpdateExerciseDTO
    {
        public string? ExerciseName { get; set; }
        public string? Description { get; set; }
        public int Repetitions { get; set; }
        public string? ImageUrl { get; set; }
        public int Sets { get; set; }
        public decimal Weight { get; set; }

        public List<int>? TagIds { get; set; } = new List<int>();
    }
}
