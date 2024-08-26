<%@ Page Title="" Language="C#" MasterPageFile="~/View/General.Master" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.DetailPage" %>
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

        .detail {
            padding: 2vh;
            border: 2px solid #779ECB;
            display: grid;
            gap: 2vh;
        }
        #Lbl_1, #Lbl_2{
            font-size: larger;
        }
        .back-button {
            padding-top: 3vh;
            padding-left: 5vh;
        }
        .qty-container{
            display: flex;
            align-items: center;
            gap: 1vh;
        }
        .panel-cart{
            display: grid;
            justify-content: center;
            gap: 1vh;
        }
        .quantity{
            text-align: center;
        }
        .add-button {
            background-color: #88AED0;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 1vh;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="back-button">
        <asp:ImageButton ID="Btn_Back" runat="server" ImageUrl="~/Assets/back.png" OnClick="Btn_Back_Click" Width="50" />
    </div>
    <div class="container">
        <div class="white-container">
            <div class="detail">
                <div>
                    <asp:Label ID="Lbl_1" runat="server" Text="Stationery: "></asp:Label>
                    <asp:Label ID="Lbl_Name" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Lbl_2" runat="server" Text="Price: $"></asp:Label>
                    <asp:Label ID="Lbl_Price" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
        <asp:Panel ID="Pnl_ToCart" runat="server" CssClass="panel-cart">
            <div class="qty-container">
                <asp:ImageButton ID="Btn_Minus" runat="server" ImageUrl="~/Assets/minus.png" Width="20" OnClick="Btn_Minus_Click"/>
                <asp:TextBox ID="Tb_Quantity" runat="server" Text="0" Width="50" OnTextChanged="Tb_Quantity_TextChanged" AutoPostBack="true" CssClass="quantity"></asp:TextBox>
                <asp:ImageButton ID="Btn_Plus" runat="server" ImageUrl="~/Assets/plus.png" Width="20" OnClick="Btn_Plus_Click"/>
            </div>
            <asp:Button ID="Btn_ToCart" runat="server" Text="Add To Cart" OnClick="Btn_ToCart_Click" CssClass="add-button"/>
        </asp:Panel>
    </div>
</asp:Content>
