namespace LINQdIn.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Models;
    using Ninject;
    using Services;
    using CustomControls.ErrorSuccessNotifier;

    public partial class Skills : System.Web.UI.Page
    {
        [Inject]
        public ISkillsService Service { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Skill> Select()
        {
            return this.Service.GetAll();
        }

        public void Update(int id)
        {
            var editTextBox = this.gvSkills.Rows[this.gvSkills.EditIndex].Controls[0].Controls[0] as TextBox;

            if (editTextBox == null)
            {
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                ErrorSuccessNotifier.AddErrorMessage("Something happened while updating the skill entry! :(");
            }

            this.Service.Update(id, new Skill {Name = editTextBox.Text});

            ErrorSuccessNotifier.AddSuccessMessage("Successfully updated the skill entry!");
        }

        public void Delete(int id)
        {
            var skill = this.Service.Delete(id);

            ErrorSuccessNotifier.AddInfoMessage("You successfully removed entry: " + skill.Name);
        }
    }
}