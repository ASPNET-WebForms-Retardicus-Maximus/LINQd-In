namespace LINQdIn.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Ninject;
    using Services;

    public partial class Public : System.Web.UI.Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public User Select()
        {
            var userId = this.Request.QueryString["userId"];

            if (userId == null)
            {
                Response.Redirect("~/");
            }

            var user = UserService.GetById(userId);

            if (user == null)
            {
                Response.Redirect("~/");
            }

            currentUser = user;

            return user;
        }

        public IEnumerable<Skill> GetSkills()
        {
            return currentUser.Skills;
        }

        public IEnumerable<Endorsement> GetEndorsements()
        {
            return currentUser.Endorsements.OrderByDescending(x => x.Id).Take(5).ToList();
        }
    }
}