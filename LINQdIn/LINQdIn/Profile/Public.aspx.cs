namespace LINQdIn.Profile
{
    using System;
    using Models;
    using Ninject;
    using Services;

    public partial class Public : System.Web.UI.Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public User Select()
        {
            var userId = this.Request.QueryString["userId"];
            var user = UserService.GetById(userId);

            return user;
        }
    }
}