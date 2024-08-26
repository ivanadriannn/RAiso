using ProjectAkhir_RAiso.Controller;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAkhir_RAiso.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Tb_Password.Attributes["type"] = "password";

            if (Session["TempData"] != null)
            {
                User user = (User)Session["TempData"];
                Tb_Name.Text = user.UserName;
                Tb_Password.Text = user.UserPassword;
            }

            if(Request.Cookies["UserLogged"] != null)
            {
                Response.Redirect("HomePage.aspx");
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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string name = Tb_Name.Text;
            string password = Tb_Password.Text;
            Lbl_Status.Text = UserController.LoginAuth(name, password);

            if (Lbl_Status.Text == "Login Success.")
            {
                if (Cb_Cookies.Checked)
                {
                    HttpCookie cookie = new HttpCookie("UserLogged");
                    cookie.Value = UserController.checkRegisteredUser(name, password).UserName;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
                Session["UserData"] = UserController.checkRegisteredUser(name, password);
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}