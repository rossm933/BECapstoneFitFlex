﻿namespace BECapstoneFitFlex.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? UserId { get; set; }
        public List<ExerciseTag>? ExerciseTag { get; set; }

    }
}
