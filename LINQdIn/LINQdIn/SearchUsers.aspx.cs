using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace LINQdIn
{
    using Ninject;
    using Services;

    public partial class SearchUsers : System.Web.UI.Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.GridViewUsers.DataSource = UserService.GetAllNonAdmin()
                                                .ToList().Select(x => new
                                                {
                                                    ID= x.Id,
                                                    Name = x.FirstName + " " + x.LastName,
                                                    Skills = string.Join(", ", x.Skills.Select(y => y.Name))
                                                }).ToList();
            this.GridViewUsers.DataBind();
        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}