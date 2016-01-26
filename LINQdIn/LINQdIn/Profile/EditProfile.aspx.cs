namespace LINQdIn.Profile
{
    using LINQdIn.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Ninject;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Models;

    public partial class EditProfile : Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Update method to update the selected User item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem()
        {
            var userId = User.Identity.GetUserId();
            var user = UserService.GetById(userId);

            if (user == null)
            {
                // The user wasn't found
                ModelState.AddModelError("", String.Format("User with id {0} was not found", userId));
                return;
            }

            TryUpdateModel(user);

            if (ModelState.IsValid)
            {
                UserService.Update(user);
                Response.Redirect("~/Profile/Private");
            }
        }

        // This is the Select method to selects a single User item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public User GetItem()
        {
            var userId = User.Identity.GetUserId();
            var user = UserService.GetById(userId);

            return user;
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/Profile/Private");
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (ImageFileUpload.HasFile)
            {
                try
                {
                    if (ImageFileUpload.PostedFile.ContentType == "image/jpeg")
                    {
                        if (ImageFileUpload.PostedFile.ContentLength <= 16 * 1000 * 1024)
                        {
                            string username = User.Identity.Name;
                            string id = User.Identity.GetUserId();
                            string directory = Server.MapPath("~/UploadedFiles/ProfileImages/") + id;
                            string filename = Guid.NewGuid().ToString() + ".jpg";
                            string path = directory + "/" + filename;
                            string url = "~/UploadedFiles/ProfileImages/" + id + "/" + filename;

                            if (!Directory.Exists(directory))
                            {
                                Directory.CreateDirectory(directory);
                            }

                            ImageFileUpload.SaveAs(path);
                            UserService.ChangeProfilePhotoUrl(id, url);
                            StatusLabel.Text = "Upload status: File uploaded!";

                            Response.Redirect("~/Profile/Private");
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 16 mb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}