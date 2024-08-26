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
    public partial class DetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);

                if(Request.QueryString["Id"] == null)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Stationery item = StationeryController.findItem(id);

                    Lbl_Name.Text = item.StationeryName;
                    Lbl_Price.Text = item.StationeryPrice.ToString();
                }

                User Logged = (User)Session["UserData"];

                if (Logged == null || Logged.UserRole != "Customer")
                {
                    Pnl_ToCart.Visible = false;
                }
            }
        }

        protected void Btn_Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Btn_ToCart_Click(object sender, EventArgs e)
        {
            User user = (User)Session["UserData"];
            if (user == null) return;

            int userID = user.UserID;
            int itemID = Convert.ToInt32(Request.QueryString["Id"]);
            int qty = Convert.ToInt32(Tb_Quantity.Text);

            Lbl_Status.Text = CartController.AddItemToCart(qty, userID, itemID);

            if (Lbl_Status.Text == "Successfully added to cart.")
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void Btn_Minus_Click(object sender, ImageClickEventArgs e)
        {
            if (int.TryParse(Tb_Quantity.Text, out int qty))
            {
                if (qty == 0) return;

                Tb_Quantity.Text = (qty - 1).ToString();
            }
        }

        protected void Btn_Plus_Click(object sender, ImageClickEventArgs e)
        {
            if (int.TryParse(Tb_Quantity.Text, out int qty))
            {
                Tb_Quantity.Text = (qty + 1).ToString();
            }
        }

        protected void Tb_Quantity_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(Tb_Quantity.Text, out int qty)){
                if(qty < 0)
                {
                    Tb_Quantity.Text = "0";
                }
            }
            else
            {
                Tb_Quantity.Text = "0";
            }
        }
    }
}