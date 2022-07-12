<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mobile_Masa.aspx.cs" Inherits="ProCafe.Program.Mobile.Mobile_Masa" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pro Cafe</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no;width:450;">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <style type="text/css">
        html, body, #mobileContainer {
            height: 100%;
        }

        body {
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript">
        function hideURLbar() {
            window.scrollTo(0, 1);
        }

        if (navigator.userAgent.indexOf('iPhone') != -1 || navigator.userAgent.indexOf('Android') != -1) {
            addEventListener("load", function () {
                setTimeout(hideURLbar, 0);
            }, false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
        </telerik:RadScriptManager>
        <div style="width: 320px; height: auto;">
            <table>
                <tr>
                    <td>
                        <center><h3>Masalar</h3></center>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;
 <telerik:RadButton ID="RadButtonYenile" runat="server" Text="Yenile" ButtonType="LinkButton" Bold="True" Font-Size="Large" Width="100" OnClick="RadButtonYenile_Click"></telerik:RadButton>
                        <telerik:RadButton ID="RadButtonCikis" runat="server" Text="Çıkış" ButtonType="LinkButton" Bold="True" Width="100" Font-Size="Large" OnClick="RadButtonCikis_Click"></telerik:RadButton>
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <center>
                <asp:DataList ID="DataListMasa" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="2" CellSpacing="0" OnItemDataBound="DataListMasa_ItemDataBound">
                    <ItemTemplate>
                        <div style="width: 90px;">
                            <table>
                                <tr style="text-align: center">
                                    <td>
                                        <asp:Label ID="LabelMasaNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButtonMasa" runat="server" Width="72" Height="72" OnClick="ImageButtonMasa_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                    </center>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
"