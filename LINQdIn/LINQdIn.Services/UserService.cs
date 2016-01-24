namespace LINQdIn.Services
{
    using System.Linq;
    using Data.Repository;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
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
    }
}
