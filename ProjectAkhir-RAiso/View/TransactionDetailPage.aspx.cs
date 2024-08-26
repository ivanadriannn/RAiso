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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User Logged = (User)Session["UserData"];
                int TrID = Convert.ToInt32(Request.QueryString["Id"]);

                if (Logged == null || Logged.UserRole != "Customer" || Request.QueryString["Id"] == null)
                {
                    Response.Redirect("HomePage.aspx");
                }

                List<dynamic> details = TransactionController.GetTransactionDetail(TrID);

                Gv_TrDetail.DataSource = details;
                Gv_TrDetail.DataBind();
            }
        }

        protected void Btn_Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("TransactionHistoryPage.aspx");
        }
    }
}