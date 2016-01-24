using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQdIn
{
    using Ninject;
    using Services;

    public partial class _Default : Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}