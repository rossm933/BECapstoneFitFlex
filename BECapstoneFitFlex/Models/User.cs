namespace BECapstoneFitFlex.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImageUrl { get; set; }
        public string? Uid { get; set; }
        public List<Workout>? Workout { get; set; }
        public List<Exercise>? Exercise { get; set; }

    }
}
