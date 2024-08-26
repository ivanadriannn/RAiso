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
    public partial class TransactionHistoryPage : System.Web.UI.Page
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

                List<dynamic> transaction = TransactionController.GetTransactionInformation(Logged.UserID);

                if(transaction == null)
                {
                    Lbl_Status.Visible = true;
                    return;
                }

                if (transaction.Count() > 0)
                {
                    Lbl_Status.Visible = false;

                    Gv_TrHeader.DataSource = transaction;
                    Gv_TrHeader.DataBind();
                }
            }
        }

        protected void Btn_Detail_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Btn = (ImageButton)sender;

            GridViewRow row = (GridViewRow)Btn.NamingContainer;

            int TrID = Convert.ToInt32(row.Cells[0].Text);

            Response.Redirect("TransactionDetailPage.aspx?Id=" + TrID);
        }

        protected void Btn_Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}