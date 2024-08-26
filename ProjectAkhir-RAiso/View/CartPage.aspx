<%@ Page Title="" Language="C#" MasterPageFile="~/View/General.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
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
        .modal-delete{
            border: 2px solid red;
            border-radius: 1vh;
            position: fixed;
            z-index: 1;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: whitesmoke;
            padding: 2vh;
            display: grid;
            gap: 2vh;
            box-shadow: rgba(0, 0, 0, 0.56) 0px 22px 70px 4px;
        }
        .modal-checkout {
            border: 2px solid green;
            border-radius: 1vh;
            position: fixed;
            z-index: 1;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: whitesmoke;
            padding: 2vh;
            display: grid;
            gap: 2vh;
            box-shadow: rgba(0, 0, 0, 0.56) 0px 22px 70px 4px;
        }
        .confirm-delete-button {
            background-color: red;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 1vh;
            cursor: pointer;
        }
        .confirm-checkout-button {
            background-color: green;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 1vh;
            cursor: pointer;
        }

        .cancel-button {
            background-color: #88AED0;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 1vh;
            cursor: pointer;
        }

        .sub-modal {
            display: flex;
            justify-content: center;
            gap: 3vh;
        }

        .back-button {
            padding-top: 3vh;
            padding-left: 5vh;
        }
        .container{
            display: flex;
            justify-content: center;
        }
        .title {
            color: #779ECB;
        }
        .checkout-button {
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
        <h1 class="title">Your Cart</h1>
    </div>

    <div class="container">
        <asp:Label ID="Lbl_Status" runat="server" Text="Your cart is empty" CssClass="title" Visible="true"></asp:Label>
    </div>

    <asp:GridView ID="Gv_Cart" runat="server" AutoGenerateColumns="false" BorderStyle="None" CssClass="container">
        <Columns>
            <asp:BoundField DataField="StationeryName" HeaderText="Stationery" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
            <asp:BoundField DataField="StationeryPrice" HeaderText="Price" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-CssClass="grid-item" HeaderStyle-CssClass="grid-header" />
            <asp:TemplateField ItemStyle-CssClass="img-item" HeaderStyle-CssClass="grid-header">
                <ItemTemplate>
                    <asp:ImageButton ID="Btn_Edit" runat="server" ImageUrl="~/Assets/edit.png" Width="30" Visible="true" OnClick="Btn_Edit_Click" />
                    <asp:ImageButton ID="Btn_Delete" runat="server" ImageUrl="~/Assets/delete.png" Width="30" Visible="true" OnClick="Btn_Delete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="container">
        <asp:Button ID="Btn_CheckOut" runat="server" Text="Checkout" OnClick="Btn_CheckOut_Click" CssClass="checkout-button" Visible="false"/>
    </div>

    <asp:Panel ID="Mdl_Checkout" runat="server" Visible="false" CssClass="modal-checkout">
        <div>
            <asp:Label ID="Label3" runat="server" Text="Are you sure want to checkout?"></asp:Label>
        </div>
        <div class="sub-modal">
            <asp:Button ID="Btn_Conf_Checkout" runat="server" Text="Confirm" OnClick="Btn_Conf_Checkout_Click" CssClass="confirm-checkout-button"/>
            <asp:Button ID="Btn_Canc_Checkout" runat="server" Text="Cancel" OnClick="Btn_Canc_Checkout_Click" CssClass="cancel-button"/>
        </div>
    </asp:Panel>

    <asp:Panel ID="Mdl_Delete" runat="server" Visible="false" CssClass="modal-delete">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Are you sure want to delete "></asp:Label>
            <asp:Label ID="Lbl_Item" runat="server" Text="" Font-Bold="true"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text=" from your cart?"></asp:Label>
        </div>
        <div class="sub-modal">
            <asp:Button ID="Btn_Confirm" runat="server" Text="Delete" OnClick="Btn_Confirm_Click" CssClass="confirm-delete-button"/>
            <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" OnClick="Btn_Cancel_Click" CssClass="cancel-button"/>
        </div>
    </asp:Panel>
</asp:Content>
