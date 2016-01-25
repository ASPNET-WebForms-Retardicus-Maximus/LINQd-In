namespace LINQdIn.Services
{
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllNonAdmin();

        IQueryable<User> GetAllEmployers();

        IQueryable<User> GetAllNonEmployers();

        User GetById(string id);

        void ChangeProfilePhotoUrl(string id, string url);
    }
}
