using ProjectAkhir_RAiso.Controller;
using ProjectAkhir_RAiso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAkhir_RAiso.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Gv_Stationeries.DataSource = StationeryController.GetStationeryList();
                Gv_Stationeries.DataBind();

                if (Request.Cookies["UserLogged"] != null)
                {
                    Session["UserData"] = UserController.getUser(Request.Cookies["UserLogged"].Value);
                }

                User Logged = (User)Session["UserData"];

                if (Logged == null || Logged.UserRole != "Admin")
                {
                    Btn_Insert.Visible = false;

                    foreach (GridViewRow row in Gv_Stationeries.Rows)
                    {
                        ImageButton btnDelete = row.FindControl("Btn_Delete") as ImageButton;
                        ImageButton btnEdit = row.FindControl("Btn_Edit") as ImageButton;

                        if (btnDelete != null || btnEdit != null)
                        {
                            btnDelete.Visible = false;
                            btnEdit.Visible = false;
                        }
                    }
                }
            }
        }

        protected void Btn_Detail_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Btn = (ImageButton)sender;

            GridViewRow row = (GridViewRow)Btn.NamingContainer;

            string StationeryName = row.Cells[0].Text;

            int id = StationeryController.findIDbyName(StationeryName);

            Response.Redirect("DetailPage.aspx?Id=" + id);
        }

        protected void Btn_Edit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Btn = (ImageButton)sender;

            GridViewRow row = (GridViewRow)Btn.NamingContainer;

            string StationeryName = row.Cells[0].Text;

            int id = StationeryController.findIDbyName(StationeryName);

            Response.Redirect("EditPage.aspx?Id=" + id);
        }

        protected void Btn_Delete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Btn = (ImageButton)sender;

            GridViewRow row = (GridViewRow)Btn.NamingContainer;

            string StationeryName = row.Cells[0].Text;

            Lbl_Item.Text = StationeryName;
            Mdl_Delete.Visible = true;
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPage.aspx");
        }

        protected void Btn_Confirm_Click(object sender, EventArgs e)
        {
            string name = Lbl_Item.Text;
            Lbl_Status.Text = StationeryController.DeleteStationery(name);
            Mdl_Error.Visible = true;

            if(Lbl_Status.Text == "Delete Success")
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Green;
                Gv_Stationeries.DataSource = StationeryController.GetStationeryList();
                Gv_Stationeries.DataBind();
            }
            else
            {
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }
            

            Mdl_Delete.Visible = false;
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Mdl_Delete.Visible = false;
        }

        protected void Btn_Continue_Click(object sender, EventArgs e)
        {
            Mdl_Error.Visible = false;
        }
    }
}