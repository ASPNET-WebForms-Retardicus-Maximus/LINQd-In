namespace LINQdIn.Services
{
    using System.Linq;
    using Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllNonAdmin();

        IQueryable<User> GetAllEmployers();

        IQueryable<User> GetAllNonEmployers();

        User GetById(string id);

        void Update(User user);

        bool EndorseUser(string endorsedUserId, string endorsedById, int skillId);
    }
}
