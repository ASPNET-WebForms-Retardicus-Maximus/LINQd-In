namespace LINQdIn.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Repository;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using ViewModels;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Endorsement> endorsements;
        private readonly IRepository<Connection> connections;

        public UserService(IRepository<User> users, IRepository<Endorsement> endorsements, IRepository<Connection> connections)
        {
            this.users = users;
            this.endorsements = endorsements;
            this.connections = connections;
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

        public IQueryable<User> GetAllAdmins()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var role = roleManager.FindByName("Admin");
            var result = this.users.All().Where(x => x.Roles.Any(r => r.RoleId == role.Id));

            return result;
        }

        public IQueryable<User> GetAllNonEmployers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var role = roleManager.FindByName("Employer");
            var result = this.users.All().Where(x => x.Roles.All(r => r.RoleId != role.Id));

            return result;
        }

        public string GetUserRoles(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var user = this.users.All().FirstOrDefault(x => x.Id == id);
            var regular = roleManager.FindByName("Regular");
            var admin = roleManager.FindByName("Admin");
            var employer = roleManager.FindByName("Employer");

            var userRoles = "";

            if(user.Roles.Any(x => x.RoleId == regular.Id))
            {
                userRoles += "Regular, ";
            }

            if (user.Roles.Any(x => x.RoleId == admin.Id))
            {
                userRoles += "Admin, ";
            }

            if (user.Roles.Any(x => x.RoleId == employer.Id))
            {
                userRoles += "Employer, ";
            }

            return userRoles.TrimEnd(',', ' ');
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

            var endorsement = new Endorsement { SkillId = skillId, EndorsedBy = endorsedBy };

            endorsedUser.Updates.Add(new Update
            {
                ContentText = 
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

        public bool AddConnection(string user1, string user2)
        {
            var connection = new Connection
            {
                User1Id = user1,
                User2Id = user2
            };

            connections.Add(connection);
            connections.SaveChanges();

            return true;
        }

        public bool AreConnected(string user1, string user2)
        {
            return connections.All()
                .Any(c =>
                    (c.User1Id == user1 && c.User2Id == user2)
                || (c.User2Id == user1 && c.User1Id == user2));
        }

        public List<ConnectionViewModel> GetConnections(string ofUserId)
        {
            var connectionsOfUser = connections.All().Where(c => c.User1Id == ofUserId || c.User2Id == ofUserId);

            var result = new List<ConnectionViewModel>();

            foreach (var connection in connectionsOfUser)
            {
                var otherUserId = connection.User1Id != ofUserId ? connection.User1Id : connection.User2Id;

                var otherUser = users.All().FirstOrDefault(u => u.Id == otherUserId);

                result.Add(new ConnectionViewModel { UserId1 = otherUser.Id, UserNames1 = string.Format("{0} {1}", otherUser.FirstName, otherUser.LastName), UserPhoto1 = otherUser.ProfilePhotoUrl});
            }

            return result;
        }
    }
}
