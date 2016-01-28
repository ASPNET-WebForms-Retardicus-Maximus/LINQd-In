namespace LINQdIn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using Data;
    using Ninject;
    using Services;
    using ViewModels;

    public partial class _Default : Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}