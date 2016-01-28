using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQdIn.CustomControls.JoinUsControl
{
    using Data;

    public partial class JoinUs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new ApplicationDbContext();

            var userCount = db.Users.Count();

            this.usersCount.InnerText = userCount.ToString();
        }
    }
}