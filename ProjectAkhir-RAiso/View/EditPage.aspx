<%@ Page Title="" Language="C#" MasterPageFile="~/View/General.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding: 5vh;
            display: grid;
            justify-content: center;
            gap: 2vh;
        }

        .update-form {
            padding: 2vh;
            border: 2px solid #779ECB;
            display: grid;
            gap: 2vh;
        }
        .title{
            color: #779ECB;
        }
        .sub-form{
            display: grid;
        }
        #<%=Btn_Submit.ClientID %>{
            background-color: #88AED0;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 5px;
            cursor: pointer;
        }
        .back-button {
            padding-top: 3vh;
            padding-left: 5vh;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="back-button">
        <asp:ImageButton ID="Btn_Back" runat="server" ImageUrl="~/Assets/back.png" OnClick="Btn_Back_Click" Width="50" />
    </div>
    <div class="container">
        <h1 class="title">Edit Stationery</h1>
        <div class="update-form">
            <div class="sub-form">
                <asp:Label ID="Lbl_1" runat="server" Text="Stationery"></asp:Label>
                <asp:TextBox ID="Tb_Name" runat="server" Text=""></asp:TextBox>
            </div>
            <div class="sub-form">
                <asp:Label ID="Lbl_2" runat="server" Text="Price"></asp:Label>
                <asp:TextBox ID="Tb_Price" runat="server" Text=""></asp:TextBox>
            </div>
        </div>
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
        <asp:Button ID="Btn_Submit" runat="server" Text="Update" OnClick="Btn_Submit_Click" />
    </div>
</asp:Content>
