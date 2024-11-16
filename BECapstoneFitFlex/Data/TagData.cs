using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Data
{
    public class TagData
    {
        public static List<Tag> Tag = new()
        {
            new() { Id = 1, Name = "Chest" },
            new() { Id = 2, Name = "Triceps" },
            new() { Id = 3, Name = "Back" },
            new() { Id = 4, Name = "Legs" },
            new() { Id = 5, Name = "Shoulders" },
            new() { Id = 6, Name = "Core" },
            new() { Id = 7, Name = "Biceps" },
            new() { Id = 8, Name = "Strength" },
            new() { Id = 9, Name = "Flexibility" },
            new() { Id = 10, Name = "Endurance" },
        };
    }
}
