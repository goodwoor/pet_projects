using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Антикварный_магазин.Model;
using Антикварный_магазин.Model.Helpers;

namespace Антикварный_магазин.Pages.Master
{
    public partial class Login : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdminButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Forms/Admin/AdminForm.aspx");
        }

        protected void ClientButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Forms/Client/ClientForm.aspx");
        }
    }
}