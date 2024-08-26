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
    public partial class EditCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                User Logged = (User)Session["UserData"];
                int ItemID = Convert.ToInt32(Request.QueryString["Id"]);

                if (Logged == null || Logged.UserRole != "Customer" || Request.QueryString["Id"] == null)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Stationery item = StationeryController.findItem(ItemID);
                    Cart cart = CartController.GetCart(Logged.UserID, item.StationeryID);

                    Lbl_ItemName.Text = item.StationeryName;
                    Lbl_Price.Text = item.StationeryPrice.ToString();
                    Tb_Quantity.Text = cart.Quantity.ToString();
                }
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
            if (int.TryParse(Tb_Quantity.Text, out int qty))
            {
                if (qty < 0)
                {
                    Tb_Quantity.Text = "0";
                }
            }
            else
            {
                Tb_Quantity.Text = "0";
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            User Logged = (User)Session["UserData"];
            int ItemID = Convert.ToInt32(Request.QueryString["Id"]);

            int Qty = Convert.ToInt32(Tb_Quantity.Text);

            Lbl_Status.Text = CartController.UpdateCart(Logged.UserID, ItemID, Qty);

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
            Response.Redirect("CartPage.aspx");
        }
    }
}