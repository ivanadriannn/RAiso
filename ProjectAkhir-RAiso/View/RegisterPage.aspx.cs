using ProjectAkhir_RAiso.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAkhir_RAiso.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Tb_Password.Attributes["type"] = "password";
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string name = Tb_Name.Text;
            string DOB = Tb_DOB.Text;
            string gender = Rad_Male.Checked ? "Male" : Rad_Female.Checked ? "Female" : "";
            string address = Tb_Address.Text;
            string phone = Tb_Phone.Text;
            string password = Tb_Password.Text;
            Lbl_Status.Text = UserController.RegisterAuth(name, DOB, gender, address, phone, password);

            if (Lbl_Status.Text == "Account has been registered.")
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
                Session["TempData"] = UserController.getUser(name);
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_ShowPassword_Click(object sender, ImageClickEventArgs e)
        {
            string showImageUrl = ResolveUrl("~/Assets/show.png");
            string hideImageUrl = ResolveUrl("~/Assets/hide.png");

            string password = Tb_Password.Text;

            if (Btn_ShowPassword.Attributes["Show"] == "0")
            {
                Btn_ShowPassword.ImageUrl = hideImageUrl;
                Tb_Password.Attributes["type"] = "SingleLine";
                Btn_ShowPassword.Attributes["Show"] = "1";
            }
            else if (Btn_ShowPassword.Attributes["Show"] == "1")
            {
                Btn_ShowPassword.ImageUrl = showImageUrl;
                Tb_Password.Attributes["type"] = "password";
                Btn_ShowPassword.Attributes["Show"] = "0";
            }

            Tb_Password.Text = password;

        }
    }
}