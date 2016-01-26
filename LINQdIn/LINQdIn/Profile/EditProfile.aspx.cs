namespace LINQdIn.Profile
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using Models;
    using Ninject;
    using Services;

    public partial class EditProfile : Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Update method to update the selected User item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem()
        {
            var userId = User.Identity.GetUserId();
            var user = UserService.GetById(userId);

            if (user == null)
            {
                // The user wasn't found
                ModelState.AddModelError("", String.Format("User with id {0} was not found", userId));
                return;
            }

            TryUpdateModel(user);

            if (ModelState.IsValid)
            {
                UserService.Update(user);
                Response.Redirect("~/Profile/Private");
            }
        }

        // This is the Select method to selects a single User item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public User GetItem()
        {
            var userId = User.Identity.GetUserId();
            var user = UserService.GetById(userId);

            return user;
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/Profile/Private");
            }
        }
    }
}