<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Masa_Aktarma_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Program_Masa_Aktarma_PopUp" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;//Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
            return oWindow;
        }
        function CloseOnReload() {
            setTimeout(function () {
                RefreshParentPage();
                GetRadWindow().Close();
            }, 300);
        }
        function RefreshParentPage() {
            GetRadWindow().BrowserWindow.location = "../Program_Masa_Siparis.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
        </telerik:RadScriptManager>
        <div>
            <table style="width: 480px;">
                <tr style="text-align: center;">
                    <td>Açık Masalar</td>
                    <td>Kapalı Masalar</td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadListBox ID="RadListBoxAcik" runat="server" Width="200" Height="370" DataTextField="MasaNo" DataValueField="MasaKey"></telerik:RadListBox>
                    </td>
                    <td>
                        <telerik:RadListBox ID="RadListBoxKapali" runat="server" Width="200" Height="370" DataTextField="MasaNo" DataValueField="MasaKey"></telerik:RadListBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;">
                        <telerik:RadButton ID="RadButtonAktar" runat="server" ButtonType="LinkButton" Text="Aktar" Width="96" Height="64" OnClick="RadButtonAktar_Click"></telerik:RadButton>
                    </td>
                    <td style="text-align: center;">
                        <telerik:RadButton ID="RadButtonCikis" runat="server" ButtonType="LinkButton" Text="Çıkış" BackColor="Red" Width="96" Height="64" OnClick="RadButtonCikis_Click"></telerik:RadButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
