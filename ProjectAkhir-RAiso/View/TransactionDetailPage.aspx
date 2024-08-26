<%@ Page Title="" Language="C#" MasterPageFile="~/View/General.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .grid-view {
            display: flex;
            justify-content: center;
            padding: 2vh;
        }

        .grid-header {
            border: none;
            padding-right: 10vh;
            padding-bottom: 3vh;
            font-weight: normal;
            font-size: larger;
            color: #779ECB;
        }

        .grid-item {
            border: none;
            padding-top: 3vh;
            padding-right: 10vh;
            border-bottom: 2px solid #779ECB;
        }

        .back-button {
            padding-top: 3vh;
            padding-left: 5vh;
        }

        .container {
            display: flex;
            justify-content: center;
        }

        .title {
            color: #779ECB;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="back-button">
        <asp:ImageButton ID="Btn_Back" runat="server" ImageUrl="~/Assets/back.png" Width="50" OnClick="Btn_Back_Click" />
    </div>

    <div class="container">
        <h1 class="title">Detail Transaction</h1>
    </div>

    <asp:GridView ID="Gv_TrDetail" runat="server" AutoGenerateColumns="false" BorderStyle="None" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="StationeryName" HeaderText="Stationery" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
            <asp:BoundField DataField="StationeryPrice" HeaderText="Price" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
        </Columns>
    </asp:GridView>
</asp:Content>
