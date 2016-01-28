namespace LINQdIn.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Update
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User OfUser { get; set; }

        public string ContentText { get; set; }
    }
}
