using BECapstoneFitFlex.Models;
namespace BECapstoneFitFlex.Data
{
    public class UserData
    {
        public static List<User> User = new()
        {
            new() { Id = 100, Name = "Ross Morgan", Email = "ross.morgan933@gmail.com", Password = "password123", ImageUrl = "https://avatars.githubusercontent.com/u/148557558?v=4", Uid = "qvds941JGQYhQ4DvLi0mxSE0juM2" },
            new() { Id = 101, Name = "Jane Smith", Email = "janesmith@example.com", Password = "securepass456", ImageUrl = "https://example.com/images/jane_smith.jpg" },
        };
    }
}
