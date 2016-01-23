namespace LINQdIn.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Skill> Skills { get; set; }

        public IDbSet<Education> Education { get; set; }

        public IDbSet<Endorsement> Endorsements { get; set; }

        public IDbSet<Update> Updates { get; set; } 

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
