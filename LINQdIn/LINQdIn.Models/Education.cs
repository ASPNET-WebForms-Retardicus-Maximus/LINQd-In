namespace LINQdIn.Models
{
    using System;

    public class Education
    {
        public int Id { get; set; }

        public string School { get; set; }

        public string FieldOfStudy { get; set; }

        public string Degree { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
