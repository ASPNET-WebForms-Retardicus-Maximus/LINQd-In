namespace LINQdIn.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Connection
    {
        public int Id { get; set; }

        public string User1Id { get; set; }

        [ForeignKey("User1Id")]
        public virtual User User1 { get; set; }

        public string User2Id { get; set; }

        [ForeignKey("User2Id")]
        public virtual User User2 { get; set; }
    }
}