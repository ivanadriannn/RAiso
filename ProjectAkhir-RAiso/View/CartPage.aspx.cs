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
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User Logged = (User)Session["UserData"];

                if (Logged == null || Logged.UserRole != "Customer")
                {
                    Response.Redirect("HomePage.aspx");
                }

                List<dynamic> carts = CartController.GetCartInformation(Logged.UserID);

                if(carts.Count() > 0)
                {
                    Lbl_Status.Visible = false;
                    Btn_CheckOut.Visible = true;

                    Gv_Cart.DataSource = carts;
                    Gv_Cart.DataBind();
                }
            }
        }

        protected void Btn_Edit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Btn = (ImageButton)sender;

            GridViewRow row = (GridViewRow)Btn.NamingContainer;

            string StationeryName = row.Cells[0].Text;

            int id = StationeryController.findIDbyName(StationeryName);

            Response.Redirect("EditCartPage.aspx?Id=" + id);
        }

        protected void Btn_Delete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Btn = (ImageButton)sender;

            GridViewRow row = (GridViewRow)Btn.NamingContainer;

            string StationeryName = row.Cells[0].Text;

            Lbl_Item.Text = StationeryName;
            Mdl_Delete.Visible = true;
        }
        protected void Btn_Confirm_Click(object sender, EventArgs e)
        {
            User Logged = (User)Session["UserData"];

            string ItemName = Lbl_Item.Text;
            CartController.DeleteItemFromCart(Logged.UserID, ItemName);

            List<dynamic> carts = CartController.GetCartInformation(Logged.UserID);

            if (carts.Count() == 0)
            {
                Lbl_Status.Visible = true;
                Btn_CheckOut.Visible = false;
            }

            Gv_Cart.DataSource = carts;
            Gv_Cart.DataBind();

            Mdl_Delete.Visible = false;
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Mdl_Delete.Visible = false;
        }

        protected void Btn_Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Btn_CheckOut_Click(object sender, EventArgs e)
        {
            Mdl_Checkout.Visible = true;
        }

        protected void Btn_Conf_Checkout_Click(object sender, EventArgs e)
        {
            User Logged = (User)Session["UserData"];

            TransactionController.Checkout(Logged.UserID);

            List<dynamic> carts = CartController.GetCartInformation(Logged.UserID);

            if (carts.Count() == 0)
            {
                Lbl_Status.Visible = true;
                Btn_CheckOut.Visible = false;
            }

            Gv_Cart.DataSource = carts;
            Gv_Cart.DataBind();

            Mdl_Checkout.Visible = false;

            Response.Redirect("HomePage.aspx");
        }

        protected void Btn_Canc_Checkout_Click(object sender, EventArgs e)
        {
            Mdl_Checkout.Visible = false;
        }
    }
}