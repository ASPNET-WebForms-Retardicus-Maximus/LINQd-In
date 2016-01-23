namespace LINQdIn.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Endorsement
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string EndorsedBy { get; set; }
    }
}