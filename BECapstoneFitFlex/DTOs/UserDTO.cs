using BECapstoneFitFlex.Models;

namespace BECapstoneFitFlex.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImageUrl { get; set; }

        public List<Workout>? Workout { get; set; }
    }
}
