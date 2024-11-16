using BECapstoneFitFlex.Models;

namespace BECapstoneFitFlex.Data
{
    public class ExerciseTagData
    {
        public static List<ExerciseTag> ExerciseTag = new()
        {
        new() {Id = 1, ExerciseId = 1, TagId = 1},
        new() {Id = 5, ExerciseId = 1, TagId = 2},
        new() {Id = 2, ExerciseId = 2, TagId = 3},
        new() {Id = 6, ExerciseId = 2, TagId = 4},
        new() {Id = 3, ExerciseId = 3, TagId = 4},
        new() {Id = 7, ExerciseId = 4, TagId = 3},
        new() {Id = 8, ExerciseId = 4, TagId = 7},
        new() {Id = 9, ExerciseId = 5, TagId = 5},
        new() {Id = 10, ExerciseId = 6, TagId = 6},
        new() {Id = 11, ExerciseId = 7, TagId = 7},
        new() {Id = 12, ExerciseId = 8, TagId = 2},
        };
    }
}
