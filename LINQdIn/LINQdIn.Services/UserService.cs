namespace LINQdIn.Services
{
    using System;
    using System.Linq;
    using Data.Repository;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Endorsement> endorsements;

        public UserService(IRepository<User> users, IRepository<Endorsement> endorsements)
        {
            this.users = users;
            this.endorsements = endorsements;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<User> GetAllEmployers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var role = roleManager.FindByName("Employer");
            var result = this.users.All().Where(x => x.Roles.Any(r => r.RoleId == role.Id));

            return result;
        }

        public IQueryable<User> GetAllNonAdmin()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var role = roleManager.FindByName("Admin");
            var result = this.users.All().Where(x => x.Roles.All(r => r.RoleId != role.Id));

            return result;
        }

        public IQueryable<User> GetAllNonEmployers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var role = roleManager.FindByName("Employer");
            var result = this.users.All().Where(x => x.Roles.All(r => r.RoleId != role.Id));

            return result;
        }

        public User GetById(string id)
        {
            return this.users.All().FirstOrDefault(x => x.Id == id);
        }

        public void Update(User user)
        {
            this.users.Update(user);
            this.users.SaveChanges();
        }

        public bool EndorseUser(string endorsedUserId, string endorsedById, int skillId)
        {
            var endorsedUser = this.users.All().FirstOrDefault(x => x.Id == endorsedUserId);
            var endorsedBy = this.users.All().FirstOrDefault(x => x.Id == endorsedById);

            var skill = endorsedUser.Skills.FirstOrDefault(x => x.Id == skillId);

            var endorsement = new Endorsement {SkillId = skillId, EndorsedBy = endorsedBy};

            endorsedUser.Updates.Add(new Update
            {
                Content =
                    string.Format("{0} {1} endorsed {2} {3} for their {4} skill.", endorsedBy.FirstName,
                        endorsedBy.LastName, endorsedUser.FirstName, endorsedUser.LastName, skill.Name)
            });

            endorsedUser.Endorsements.Add(endorsement);

            this.users.Update(endorsedUser);
            this.users.SaveChanges();

            return true;
        }

        public void ChangeProfilePhotoUrl(string id, string url)
        {
            var user = this.GetById(id);

            user.ProfilePhotoUrl = url;

            this.users.Update(user);

            this.users.SaveChanges();
        }
    }
}
