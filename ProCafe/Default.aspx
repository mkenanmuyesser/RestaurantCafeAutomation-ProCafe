<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProCafe.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="test" />
    <meta name="keywords" content="test" />
    <meta name="author" content="ProCafe" />
    <link rel="shortcut icon" href="favicon.ico">
    <link rel="stylesheet" type="text/css" href="Style/Css/loginstyle.css" />
    <script src="Script/modernizr.custom.63321.js"> </script>
    <script type="text/javascript">
        if (navigator.userAgent.indexOf('iPhone') != -1 || navigator.userAgent.indexOf('Android') != -1) {
            addEventListener("load", function () {
                setTimeout(hideURLbar, 0);
            }, false);
        }

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
</head>
<body>
    <div class="container">

        <header>
            <div class="support-note">
                <span class="note-ie">Üzgünüm, sadece yeni tarayıcılarla görüntülenebilir.</span>
            </div>
        </header>
        <div style="height: 50px;">
        </div>

        <section class="main">
            <form class="form-1" runat="server" id="form1" style="width: 250px;">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                <p class="field">
                    <center><h1>Pro Cafe </h1>v1.3</center>
                </p>
                <p class="field">
                    <asp:TextBox ID="TextBoxUserName" runat="server" MaxLength="20"></asp:TextBox>
                    <i class="icon-user icon-large"></i>
                </p>
                <p class="field">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                    <i class="icon-lock icon-large"></i>
                </p>
                <p class="field">
                    <asp:DropDownList ID="DropDownListTabletSecim" runat="server" Width="230" Height="26">
                        <asp:ListItem runat="server" Selected="True" Text="Asus"></asp:ListItem>
                        <asp:ListItem runat="server" Text="Casper"></asp:ListItem>
                        <asp:ListItem runat="server" Text="IPod"></asp:ListItem>
                        <asp:ListItem runat="server" Text="PC"></asp:ListItem>
                        <asp:ListItem runat="server" Text="Diğer"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p class="submit">
                    <button id="ButtonGiris" runat="server" type="submit" name="ButtonLogin" onserverclick="ButtonLogin_Click"><i class="icon-arrow-right icon-large"></i></button>
                </p>
            </form>
        </section>
    </div>
</body>
</html>
