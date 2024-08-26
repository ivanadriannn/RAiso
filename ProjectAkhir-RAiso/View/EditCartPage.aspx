<%@ Page Title="" Language="C#" MasterPageFile="~/View/General.Master" AutoEventWireup="true" CodeBehind="EditCartPage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.EditCartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding: 5vh;
            display: grid;
            justify-content: center;
            gap: 2vh;
        }

        .white-container {
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            margin-top: 20px;
        }

        .update-form {
            padding: 2vh;
            border: 2px solid #779ECB;
            display: grid;
            gap: 2vh;
        }

        .title {
            color: #779ECB;
        }

        .sub-form {
            display: grid;
        }

        .sub-title {
            color: #88AED0;
        }

        .add-button {
            background-color: #88AED0;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 1vh;
            cursor: pointer;
        }

        .qty-container {
            display: flex;
            align-items: center;
            gap: 1vh;
        }

        .panel-cart {
            display: grid;
            justify-content: center;
            gap: 1vh;
        }

        .quantity {
            text-align: center;
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
        <h1 class="title">Edit Cart</h1>
        <div class="white-container">
            <div class="update-form">
                <div class="sub-form">
                    <asp:Label ID="Lbl_1" runat="server" Text="Stationery" CssClass="sub-title"></asp:Label>
                    <asp:Label ID="Lbl_ItemName" runat="server" Text=""></asp:Label>
                </div>
                <div class="sub-form">
                    <asp:Label ID="Lbl_2" runat="server" Text="Price" CssClass="sub-title"></asp:Label>
                    <asp:Label ID="Lbl_Price" runat="server" Text=""></asp:Label>
                </div>
                <asp:Panel ID="Pnl_ToCart" runat="server" CssClass="panel-cart">
                    <asp:Label ID="Lbl_3" runat="server" Text="Quantity" CssClass="sub-title"></asp:Label>
                    <div class="qty-container">
                        <asp:ImageButton ID="Btn_Minus" runat="server" ImageUrl="~/Assets/minus.png" Width="20" OnClick="Btn_Minus_Click" />
                        <asp:TextBox ID="Tb_Quantity" runat="server" Text="0" Width="50" OnTextChanged="Tb_Quantity_TextChanged" AutoPostBack="true" CssClass="quantity"></asp:TextBox>
                        <asp:ImageButton ID="Btn_Plus" runat="server" ImageUrl="~/Assets/plus.png" Width="20" OnClick="Btn_Plus_Click" />
                    </div>
                </asp:Panel>
            </div>
        </div>
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
        <asp:Button ID="Btn_Submit" runat="server" Text="Update" OnClick="Btn_Submit_Click" CssClass="add-button" />
    </div>
</asp:Content>
