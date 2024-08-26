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
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User Logged = (User)Session["UserData"];

                if (Logged == null || Logged.UserRole != "Admin" || Request.QueryString["Id"] == null)
                {
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    int id = Convert.ToInt32(Request.QueryString["Id"]);
                    Stationery item = StationeryController.findItem(id);

                    Tb_Name.Text = item.StationeryName;
                    Tb_Price.Text = item.StationeryPrice.ToString();
                }
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string name = Tb_Name.Text;
            string price = Tb_Price.Text;

            int id = Convert.ToInt32(Request.QueryString["Id"]);

            Lbl_Status.Text = StationeryController.UpdateStationery(name, price, id);

            if (Lbl_Status.Text == "Update Success.")
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