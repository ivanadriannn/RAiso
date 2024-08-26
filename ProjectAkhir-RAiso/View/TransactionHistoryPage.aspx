<%@ Page Title="" Language="C#" MasterPageFile="~/View/General.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.TransactionHistoryPage" %>
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
        .img-item {
            width: auto;
            padding-top: 3vh;
            border: none;
            padding-right: 1vh;
            border-bottom: 2px solid #779ECB;
            box-shadow: rgba(0, 0, 0, 0.15) 2.4px 2.4px 3.2px;
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
        <asp:ImageButton ID="Btn_Back" runat="server" ImageUrl="~/Assets/back.png"  Width="50" OnClick="Btn_Back_Click"/>
    </div>

    <div class="container">
        <h1 class="title">Transaction History</h1>
    </div>

    <div class="container">
        <asp:Label ID="Lbl_Status" runat="server" Text="There is no transaction done" CssClass="title" Visible="true"></asp:Label>
    </div>

    <asp:GridView ID="Gv_TrHeader" runat="server" AutoGenerateColumns="false" BorderStyle="None" CssClass="grid-view" >
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" DataFormatString="{0:dd-MM-yyyy}"/>
            <asp:BoundField DataField="UserName" HeaderText="User" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
            <asp:TemplateField ItemStyle-CssClass="img-item" HeaderStyle-CssClass="grid-header">
                <ItemTemplate>
                    <asp:ImageButton ID="Btn_Detail" runat="server" ImageUrl="~/Assets/detail.png" Width="30" Visible="true" OnClick="Btn_Detail_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
