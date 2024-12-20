namespace BECapstoneFitFlex.Models
{
    public class ExerciseWorkout
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public Workout? Workout { get; set; }
    }
}
