namespace LINQdIn.Profile
{
    using LINQdIn.Models;
    using LINQdIn.Services;
    using ViewModels;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class ManageSkills : System.Web.UI.Page
    {
        [Inject]
        public ISkillsService SkillsService { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        public IList<Skill> UserSkills { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserSkills = this.UserService.GetById(Page.User.Identity.GetUserId()).Skills.ToList();
        }

        public IQueryable<SkillViewModel> Unnamed_GetData1()
        {
            return this.SkillsService.GetAll().ToList().Select(x => new SkillViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Checked = this.UserSkills.Any(y => y.Name == x.Name)
            }).AsQueryable<SkillViewModel>();
        }

        protected void Unnamed_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            var btn = sender as Button;

            var id = int.Parse(e.CommandArgument as string);

            if(btn.Text == "Add")
            {
                this.UserService.AddSkill(Page.User.Identity.GetUserId(), id);
            }
            else
            {
                this.UserService.RemoveSkill(Page.User.Identity.GetUserId(), id);
            }

            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void Unnamed_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
        {
            var btn = e.Item.Controls[1] as Button;

            bool isChecked = (e.Item.DataItem as SkillViewModel).Checked;
            btn.Text = isChecked ? "Remove" : "Add";
            btn.CssClass = "btn " + (isChecked ? "btn-info" : "btn-danger");
        }
    }
}