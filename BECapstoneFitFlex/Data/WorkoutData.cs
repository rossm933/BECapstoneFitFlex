using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Data
{
    public class WorkoutData
    {
        public static List<Workout> Workout = new()
        {
            new() { Id = 1, UserId = 100, WorkoutName = "Strength Training", Description = "Focus on building upper body strength with weights.", DateCreated = new DateTime (2024-11-14)},
            new() { Id = 2, UserId = 100, WorkoutName = "Leg Day", Description = "Focus on lower body strength with weights.", DateCreated = new DateTime (2024-11-19)},
        };
    }
}
