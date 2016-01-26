namespace LINQdIn.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Skill> skills;
        private ICollection<Endorsement> endorsements;
        private ICollection<Education> education;
        private ICollection<Update> updates;

        public User()
        {
            this.skills = new HashSet<Skill>();  
            this.education = new HashSet<Education>();
            this.updates = new HashSet<Update>();
            this.endorsements = new HashSet<Endorsement>();
        }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(1000)]
        public string Summary { get; set; }

        public string TwitterProfile { get; set; }

        public string GithubProfile { get; set; }

        public string Portfolio { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Skill> Skills { get { return this.skills; } set { this.skills = value; } }

        public virtual ICollection<Endorsement> Endorsements { get { return this.endorsements; } set { this.endorsements = value; } }

        public virtual ICollection<Education> Education { get { return this.education; } set { this.education = value; } }

        public virtual ICollection<Update> Updates { get { return this.updates; } set { this.updates = value; } }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
