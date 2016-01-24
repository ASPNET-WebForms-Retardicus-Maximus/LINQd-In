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
            if (!IsPostBack)
            {
                this.BindData(0);
            }
        }

        protected void BindData(int page)
        {
            this.GridViewUsers.DataSource = UserService.GetAll().OrderBy(x => x.FirstName + x.LastName).Skip(page * 10).Take(10)
                                                .ToList().Select(x => new
                                                {
                                                    ID = x.Id,
                                                    Name = x.FirstName + " " + x.LastName,
                                                    Skills = string.Join(", ", x.Skills.Select(y => y.Name))
                                                }).ToList();

            this.btnPrevious.Enabled = page > 0;

            this.lblCurrentPage.Text = page.ToString();
            this.GridViewUsers.DataBind();
        }

        protected void ChangePage(object sender, CommandEventArgs e)
        {
            this.BindData(int.Parse(this.lblCurrentPage.Text) + int.Parse((string)e.CommandArgument));
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