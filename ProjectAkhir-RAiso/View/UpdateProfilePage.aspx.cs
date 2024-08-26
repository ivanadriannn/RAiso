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
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User Logged = (User)Session["UserData"];

                if (Logged == null)
                {
                    Response.Redirect("HomePage.aspx");
                }

                DateTime UserDOB = (DateTime)Logged.UserDOB;
                string ParsedUserDOB = UserDOB.Year + "-" + UserDOB.Month.ToString("00") + "-" + UserDOB.Day.ToString("00");

                Tb_Name.Text = Logged.UserName;
                Tb_DOB.Text = ParsedUserDOB;
                Tb_Address.Text = Logged.UserAddress;
                Tb_Phone.Text = Logged.UserPhone;
                Tb_Password.Text = Logged.UserPassword;

                if (Logged.UserGender == "Male")
                {
                    Rad_Male.Checked = true;
                }
                else if (Logged.UserGender == "Female")
                {
                    Rad_Female.Checked = true;
                }
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
            User Logged = (User)Session["UserData"];
            int UserID = Logged.UserID;
            string name = Tb_Name.Text;
            string DOB = Tb_DOB.Text;
            string gender = Rad_Male.Checked ? "Male" : "Female";
            string address = Tb_Address.Text;
            string phone = Tb_Phone.Text;
            string password = Tb_Password.Text;
            Lbl_Status.Text = UserController.UpdateUser(UserID, name, DOB, gender, address, phone, password);

            if (Lbl_Status.Text == "Account has been updated.")
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
                Session["UserData"] = UserController.getUser(name);
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}