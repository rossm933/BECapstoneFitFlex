﻿namespace BECapstoneFitFlex.Models
{
    public class ExerciseTag
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public Tag? Tag { get; set; }

    }
}
