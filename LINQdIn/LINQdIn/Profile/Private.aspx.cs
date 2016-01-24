namespace LINQdIn.Profile
{
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using DbUser = Models.User;
    using Ninject;
    using Services;

    public partial class Private : System.Web.UI.Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected new DbUser DbUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = User.Identity.GetUserId();
            var user = UserService.GetById(userId);

            DbUser = user;
            this.DataBind();
        }
    }
}