<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="ProjectAkhir_RAiso.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, 'Sans Serif Collection';
            background-image: url('../Assets/BackgroundRAiso.png'); 
            background-size: cover;
            background-repeat: no-repeat;
            background-position: center;
            background-attachment: fixed
        }

        #RegisterForm {
            display: grid;
            justify-content: center;
            padding: 10vh;
        }

        .container {
            display: grid;
            justify-content: center;
            gap: 3vh;
            border: 2px solid #779ECB;
            border-radius: 4vh;
            padding-left: 5vh;
            padding-right: 5vh;
            padding-bottom: 3vh;
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
        
        .subtitle{
            color: #779ECB;
        }

        .btn-submit {
            background-color: #88AED0;
            color: whitesmoke;
            border: none;
            padding: 1vh;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="RegisterForm" runat="server">
        <div class="container">
            <div>
                <h1 class="title">Register</h1>
                <h3 class="subtitle">Already have an account? <asp:HyperLink ID="Hl_Login" runat="server" CssClass="subtitle" NavigateUrl="~/View/LoginPage.aspx">Click Here!</asp:HyperLink></h3>
            </div>
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
                        <asp:RadioButton ID="Rad_Male" runat="server" GroupName="Rad_Gender" Checked="false" />
                        <asp:Label ID="Lbl_Male" runat="server" Text="Male"></asp:Label>
                        <asp:RadioButton ID="Rad_Female" runat="server" GroupName="Rad_Gender" />
                        <asp:Label ID="Lbl_Female" runat="server" Text="Female"></asp:Label>
                    </div>
                </div>
                <div class="sub-container">
                    <asp:Label ID="Lbl_Address" runat="server" Text="Address "></asp:Label>
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
                        <asp:ImageButton ID="Btn_ShowPassword" runat="server" ImageUrl="~/Assets/show.png" Width="20" Height="23" ImageAlign="Top" OnClick="Btn_ShowPassword_Click" Show="0" />
                    </div>
                </div>
            </div>
            <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" OnClick="Btn_Submit_Click" CssClass="btn-submit"/>
        </div>
    </form>
</body>
</html>
