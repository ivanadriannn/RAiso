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
    public partial class InsertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User Logged = (User)Session["UserData"];

                if (Logged == null || Logged.UserRole != "Admin")
                {
                    Response.Redirect("Homepage.aspx");
                }
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string name = Tb_Name.Text;
            string price = Tb_Price.Text;
            Lbl_Status.Text = StationeryController.InsertNewStationery(name, price);

            if (Lbl_Status.Text == "Insert Success.")
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
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