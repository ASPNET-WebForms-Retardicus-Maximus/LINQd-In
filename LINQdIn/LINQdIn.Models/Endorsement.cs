namespace LINQdIn.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Endorsement
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User EndorsedBy { get; set; }

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }
    }
}