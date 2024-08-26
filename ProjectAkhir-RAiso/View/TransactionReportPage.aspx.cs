using ProjectAkhir_RAiso.Controller;
using ProjectAkhir_RAiso.Dataset;
using ProjectAkhir_RAiso.Model;
using ProjectAkhir_RAiso.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAkhir_RAiso.View
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User Logged = (User)Session["UserData"];

            if (Logged == null || Logged.UserRole != "Admin")
            {
                Response.Redirect("Homepage.aspx");
            }

            TransactionReport report = new TransactionReport();
            CR_Viewer.ReportSource = report;

            RaisoDataset data = GetData(TransactionController.GetTransactionHeaders());
            report.SetDataSource(data);
        }

        private RaisoDataset GetData(List<TransactionHeader> transactions)
        {
            RaisoDataset data = new RaisoDataset();

            var TrHeader = data.Transaction;
            var TrDetail = data.TransactionDetails;

            foreach (var tr in transactions)
            {
                var HeaderRow = TrHeader.NewRow();
                HeaderRow["TransactionId"] = tr.TransactionID;
                HeaderRow["UserId"] = tr.UserID;
                HeaderRow["TransactionDate"] = tr.TransactionDate;
                int totalValue = 0;

                foreach (TransactionDetail detail in tr.TransactionDetails)
                {
                    var DetailRow = TrDetail.NewRow();
                    DetailRow["TransactionId"] = detail.TransactionID;
                    DetailRow["StationeryName"] = detail.Stationery.StationeryName;
                    DetailRow["Quantity"] = detail.Quantity;
                    DetailRow["StationeryPrice"] = detail.Stationery.StationeryPrice;
                    DetailRow["SubTotalValue"] = detail.Quantity * detail.Stationery.StationeryPrice;

                    TrDetail.Rows.Add(DetailRow);

                    totalValue = (int)(totalValue + (detail.Quantity * detail.Stationery.StationeryPrice));
                }

                HeaderRow["GrandTotalValue"] = totalValue;

                TrHeader.Rows.Add(HeaderRow);
            }

            return data;
        }

        protected void Btn_Back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}