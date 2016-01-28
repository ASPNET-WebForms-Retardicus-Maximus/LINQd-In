namespace LINQdIn.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Models;
    using Ninject;
    using Services;

    public partial class Skills : System.Web.UI.Page
    {
        [Inject]
        public ISkillsService Service { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Skill> Select()
        {
            return Service.GetAll();
        }

        public void Update(int id)
        {
            var editTextBox = this.gvSkills.Rows[this.gvSkills.EditIndex].Controls[0].Controls[0] as TextBox;

            if (editTextBox == null)
            {
                
            }

            this.Service.Update(id, new Skill {Name = editTextBox.Text});
        }

        public void Delete(int id)
        {
            this.Service.Delete(id);
        }
    }
}