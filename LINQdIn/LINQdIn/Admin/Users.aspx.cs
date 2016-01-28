namespace LINQdIn.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Models;
    using Ninject;
    using Services;

    public partial class Users : System.Web.UI.Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> Select()
        {
            return UserService.GetAllNonEmployers();
        }

        public IQueryable<User> SelectEmployers()
        {
            return UserService.GetAllEmployers();
        }

        public IQueryable<User> SelectAdmins()
        {
            return UserService.GetAllAdmins();
        }

        protected void gvUsers_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected string GetRoles(string id)
        {
            return UserService.GetUserRoles(id);
        }
    }
}