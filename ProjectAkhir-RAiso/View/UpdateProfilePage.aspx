<%@ Page Title="" Language="C#" MasterPageFile="~/View/General.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.UpdateProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .UpdateForm {
            display: grid;
            justify-content: center;
            padding-left: 10vh;
            padding-right: 10vh;
            padding-bottom: 10vh;
        }

        .container {
            display: grid;
            justify-content: center;
            gap: 3vh;
            border: 2px solid #779ECB;
            border-radius: 4vh;
            padding: 5vh;
            color: #779ECB;
            background-color: whitesmoke;
        }

        .form-container {
            display: grid;
            justify-content: center;
            gap: 1.5vh;
        }

        .sub-container {
            display: grid;
            gap: 0.5vh;
        }

        .btn-submit {
            background-color: #88AED0;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 5px;
            cursor: pointer;
        }
        .title {
            color: #779ECB;
        }
        .back-button {
            padding-top: 3vh;
            padding-left: 5vh;
        }
        .title-container{
            display: flex; 
            justify-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="back-button">
        <asp:ImageButton ID="Btn_Back" runat="server" ImageUrl="~/Assets/back.png" OnClick="Btn_Back_Click" Width="50" />
    </div>
    <div class="UpdateForm">
        <div class = "title-container">
            <h1 class="title">Edit Profile</h1>
        </div>
        <div class="container">
            <div class="form-container">
                <div class="sub-container">
                    <asp:Label ID="Lbl_Name" runat="server" Text="Name "></asp:Label>
                    <asp:TextBox ID="Tb_Name" runat="server"></asp:TextBox>
                </div>
                <div class="sub-container">
                    <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth "></asp:Label>
                    <asp:TextBox ID="Tb_DOB" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="sub-container">
                    <asp:Label ID="Lbl_Gender" runat="server" Text="Gender "></asp:Label>
                    <div>
                        <asp:RadioButton ID="Rad_Male" runat="server" GroupName="Rad_Gender" Checked="true" />
                        <asp:Label ID="Lbl_Male" runat="server" Text="Male"></asp:Label>
                        <asp:RadioButton ID="Rad_Female" runat="server" GroupName="Rad_Gender" />
                        <asp:Label ID="Lbl_Female" runat="server" Text="Female"></asp:Label>
                    </div>
                </div>
                <div class="sub-container">
                    <asp:Label ID="Lbl_Address" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="Tb_Address" runat="server"></asp:TextBox>
                </div>
                <div class="sub-container">
                    <asp:Label ID="Lbl_Phone" runat="server" Text="Phone "></asp:Label>
                    <asp:TextBox ID="Tb_Phone" runat="server" TextMode="Phone"></asp:TextBox>
                </div>
                <div class="sub-container">
                    <asp:Label ID="Lbl_Password" runat="server" Text="Password "></asp:Label>
                    <div>
                        <asp:TextBox ID="Tb_Password" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="Btn_ShowPassword" runat="server" ImageUrl="~/Assets/hide.png" Width="20" Height="23" ImageAlign="Top" OnClick="Btn_ShowPassword_Click" Show="1" />
                    </div>
                </div>
            </div>
            <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
            <asp:Button ID="Btn_Submit" runat="server" Text="Update" OnClick="Btn_Submit_Click" CssClass="btn-submit" />
        </div>
    </div>
</asp:Content>
