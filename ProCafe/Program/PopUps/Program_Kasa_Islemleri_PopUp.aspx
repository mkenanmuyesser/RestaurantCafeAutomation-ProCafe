<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Kasa_Islemleri_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Program_Kasa_Islemleri_PopUp" %>

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
            RefreshParentPage();
            GetRadWindow().Close();
        }

        function RefreshParentPage() {
            GetRadWindow().BrowserWindow.location = "../Program_Kasa_Islemleri.aspx";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
        </telerik:RadScriptManager>
        <div>
            <table style="width: 480px;">
                <tr style="text-align: left;">
                    <td style="text-align: left;">
                        <asp:Label ID="LabelOdenmemisSiparisler" runat="server" Text="Ödenmemiş</br> Siparişler"></asp:Label></td>
                    <td>
                        <asp:Label ID="LabelOdenmisSiparisler" runat="server" Text="Ödenmiş Siparişler"></asp:Label>
                    </td>
                    <td style="text-align: right;">
                        <telerik:RadButton ID="RadButtonCikis" runat="server" ButtonType="LinkButton" Text="Çıkış" Width="96" Height="64" BackColor="Red" OnClick="RadButtonCikis_Click"></telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadListBox ID="RadListBoxAlinanSiparisler" runat="server" Width="235" Height="300" DataValueField="SiparisUrunKey"></telerik:RadListBox>
                    </td>
                    <td colspan="2">
                        <telerik:RadListBox ID="RadListBoxOdenenSiparisler" runat="server" Width="235" Height="300" DataValueField="SiparisUrunKey"></telerik:RadListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadNumericTextBox ID="RadTextBoxAlinanSiparislerToplam" Type="Currency" runat="server" Enabled="False" Width="235">
                            <NumberFormat AllowRounding="false" DecimalDigits="2" ZeroPattern="n TL" />
                        </telerik:RadNumericTextBox></td>
                    <td colspan="2">
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxOdenenSiparislerToplam" Type="Currency" runat="server" Enabled="False" Width="235">
                            <NumberFormat AllowRounding="false" DecimalDigits="2" ZeroPattern="n TL" />
                        </telerik:RadNumericTextBox></td>
                </tr>
                <tr style="text-align: center;">
                    <td>
                        <telerik:RadButton ID="RadButtonEkle" runat="server" ButtonType="LinkButton" Text="ListeyeEkle" Width="96" Height="64" OnClick="RadButtonEkle_Click"></telerik:RadButton>
                        <telerik:RadButton ID="RadButtonKaldir" runat="server" ButtonType="LinkButton" Text="ListedenKaldır" Width="96" Height="64" OnClick="RadButtonKaldir_Click"></telerik:RadButton>
                    </td>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td>
                                    <telerik:RadButton ID="RadButtonTemizle" runat="server" ButtonType="LinkButton" Text="ListeyiSıfırla" Width="96" Height="64" OnClick="RadButtonSifirla_Click"></telerik:RadButton>
                                </td>
                                <td rowspan="2">
                                    <telerik:RadButton ID="RadButtonOde" runat="server" ButtonType="LinkButton" Text="Ödeme" Width="96" Height="32" BackColor="Red" OnClick="RadButtonOde_Click"></telerik:RadButton>
                                    <telerik:RadButton ID="RadButtonIndirimliOde" runat="server" ButtonType="LinkButton" Text="IndirimliÖdeme" Width="96" Height="32" BackColor="Red" OnClick="RadButtonIndirimliOde_Click"></telerik:RadButton>
                                </td>
                            </tr>

                        </table>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
