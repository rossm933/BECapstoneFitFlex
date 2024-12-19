using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Data
{
    public class TagData
    {
        public static List<Tag> Tag = new()
        {
            new() { Id = 1, Name = "Chest", UserId = 100 },
            new() { Id = 2, Name = "Triceps", UserId = 100 },
            new() { Id = 3, Name = "Back", UserId = 100 },
            new() { Id = 4, Name = "Legs" },
            new() { Id = 5, Name = "Shoulders" },
            new() { Id = 6, Name = "Core", UserId = 100 },
            new() { Id = 7, Name = "Biceps" },
            new() { Id = 8, Name = "Strength", UserId = 100 },
            new() { Id = 9, Name = "Flexibility", UserId = 100 },
            new() { Id = 10, Name = "Endurance", UserId = 100 },
        };
    }
}
