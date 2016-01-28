namespace LINQdIn.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using ViewModels;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllNonAdmin();

        IQueryable<User> GetAllAdmins();

        IQueryable<User> GetAllEmployers();

        IQueryable<User> GetAllNonEmployers();

        string GetUserRoles(string id);

        User GetById(string id);

        void Update(User user);

        bool EndorseUser(string endorsedUserId, string endorsedById, int skillId);

        void ChangeProfilePhotoUrl(string id, string url);

        bool AddConnection(string user1, string user2);

        bool AreConnected(string user1, string user2);

        List<ConnectionViewModel> GetConnections(string ofUserId);
    }
}
