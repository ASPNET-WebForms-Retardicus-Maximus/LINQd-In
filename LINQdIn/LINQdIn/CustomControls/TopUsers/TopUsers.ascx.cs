using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQdIn.CustomControls.TopUsers
{
    using Data;
    using Services;
    using ViewModels;

    public partial class TopUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<TopUserViewModel> Select()
        {
            var topEndorsed = new ApplicationDbContext().Users
                .OrderByDescending(x => x.Endorsements.Count)
                .Take(3)
                .ToList();

            var topUserVM = new List<TopUserViewModel>();

            foreach (var user in topEndorsed)
            {
                topUserVM.Add(new TopUserViewModel { SkillEndorseCount = user.Endorsements.Count, UserId = user.Id, UserImage = user.ProfilePhotoUrl, Username = user.FirstName + " " + user.LastName });
            }

            return topUserVM;
        }
    }
}