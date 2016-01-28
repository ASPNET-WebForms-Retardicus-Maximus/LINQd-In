namespace LINQdIn.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using Models;
    using Ninject;
    using Services;
    using ViewModels;
    // using CustomControls.ErrorSuccessNotifier;

    public partial class Public : Page
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

        protected void OnCommand(object sender, CommandEventArgs e)
        {
            var argument = e.CommandArgument.ToString();

            var targetUser = this.Request.QueryString["userId"];
            var user = UserService.GetById(targetUser);

            var currentUserId = User.Identity.GetUserId();
            var currentUser = UserService.GetById(currentUserId);

            if (currentUserId == targetUser)
            {
                // ErrorSuccessNotifier.ShowAfterRedirect = true;
                // ErrorSuccessNotifier.AddWarningMessage("You should not be trying to endorse yourself.. begone :(");
                return;
            }

            var success = UserService.EndorseUser(targetUser, currentUserId, int.Parse(argument));

            if (success)
            {
                var url = Request.Url.PathAndQuery;

                // ErrorSuccessNotifier.AddInfoMessage("You endorsed the user!");

                Server.TransferRequest(url);
            }
        }

        protected void OnAddConnectionCommand(object sender, CommandEventArgs e)
        {
            var argument = e.CommandArgument.ToString();

            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == argument)
            {
                Response.Redirect("~/Profile/Private");
            }

            UserService.AddConnection(argument, currentUserId);

            var url = Request.Url.PathAndQuery;

            // ErrorSuccessNotifier.AddInfoMessage("You successfully became friends with this user!");

            Server.TransferRequest(url);
        }

        protected void UserFormView_ItemCreated(object sender, EventArgs e)
        {
            var control = UserFormView.Row.FindControl("AddConnectionBtn") as Button;

            if (control != null)
            {
                var targetUser = this.Request.QueryString["userId"];

                var currentUserId = User.Identity.GetUserId();

                if (targetUser != currentUserId)
                {
                    control.Visible = true;
                }

                if (targetUser == currentUserId)
                {
                    return;
                }

                if (!UserService.AreConnected(targetUser, currentUserId))
                {
                    control.Visible = true;
                }
                else
                {
                    control.Visible = false;
                }
            }
        }

        public IEnumerable<ConnectionViewModel> SelectConnections()
        {
            var targetUser = this.Request.QueryString["userId"];

            var targetUserConnections = UserService.GetConnections(targetUser);

            return targetUserConnections;
        }
    }
}