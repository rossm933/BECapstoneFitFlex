using BECapstoneFitFlex.Models;

namespace BECapstoneFitFlex.Data
{
    public class ExerciseData
    {
        public static List<Exercise> Exercise = new()
        {
            new() { Id = 1, ExerciseName = "Bench Press", Description = "Chest and triceps workout with a barbell.", Repetitions = 10, ImageUrl = "https://www.shutterstock.com/image-illustration/closegrip-barbell-bench-press-3d-600nw-430936051.jpg", Sets = 3, Weight = 80.5m, UserId = 100 },
            new() { Id = 2, ExerciseName = "Deadlift", Description = "Full-body compound exercise.", Repetitions = 8, ImageUrl = "https://www.evolvefitstudios.com/uploads/1/0/2/9/102951852/deadlifts_orig.jpeg", Sets = 4, Weight = 100m, UserId = 100 },
            new() { Id = 3, ExerciseName = "Squats", Description = "Lower body strength exercise.", Repetitions = 12, ImageUrl = "https://static.strengthlevel.com/images/exercises/squat/squat-800.jpg", Sets = 3, Weight = 60m, UserId = 100 },
            new() { Id = 4, ExerciseName = "Pull-Ups", Description = "Upper body workout targeting back and biceps.", Repetitions = 10, ImageUrl = "https://anabolicaliens.com/cdn/shop/articles/199990_400x.png?v=1645089103", Sets = 3, Weight = 0m, UserId = 100 },
            new() { Id = 5, ExerciseName = "Shoulder Press", Description = "Shoulder strength exercise with a barbell.", Repetitions = 8, ImageUrl = "https://static.strengthlevel.com/images/exercises/shoulder-press/shoulder-press-800.jpg", Sets = 4, Weight = 50m, UserId = 100 },
            new() { Id = 6, ExerciseName = "Plank", Description = "Core stability exercise.", Repetitions = 1, ImageUrl = "https://www.inspireusafoundation.org/wp-content/uploads/2023/07/plank-benefits.png", Sets = 3, Weight = 0m, UserId = 100 },
            new() { Id = 7, ExerciseName = "Bicep Curls", Description = "Isolation exercise for the biceps.", Repetitions = 12, ImageUrl = "https://cdn.shopify.com/s/files/1/2384/0833/files/inner-bicep-curl-benefits.jpg?v=1689192787", Sets = 3, Weight = 15m, UserId = 100 },
            new() { Id = 8, ExerciseName = "Tricep Dips", Description = "Strengthens triceps and shoulders.", Repetitions = 12, ImageUrl = "https://pump-app.s3.eu-west-2.amazonaws.com/exercise-assets/17551101-Weighted-Tricep-Dips_Upper-Arms_small.jpg", Sets = 3, Weight = 0m, UserId = 100 },

        };
    }
}
