<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Yazdir_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Program_Yazdir_PopUp" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=8.0.14.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
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
                GetRadWindow().BrowserWindow.location = "../Program_Kasa_Islemleri.aspx";
                GetRadWindow().Close();
            }, 300);
        }

        function Close() {
            GetRadWindow().Close();
        }                 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
        </telerik:RadScriptManager>
        <div>
            <table>
                <tr style="text-align: center; padding: 5px;">
                    <td>
                        <asp:Button ID="ButtonYazdir" runat="server" Width="96" Height="48" Text="Yazdır" OnClientClick="PrintReport(); return false;" /></td>
                    <td>
                        <asp:Button ID="ButtonCikis" runat="server" Width="96" Height="48" BackColor="Red" Text="Çıkış" OnClick="RadButtonCikis_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <telerik:ReportViewer ID="ReportViewerRapor" runat="server" Width="300" Height="400" ShowDocumentMapButton="false" ShowExportGroup="false" ShowHistoryButtons="false" ShowNavigationGroup="false" ShowParametersButton="false" ShowPrintButton="false" ShowPrintPreviewButton="false" ShowRefreshButton="false" ShowZoomSelect="false"></telerik:ReportViewer>
                    </td>
                </tr>
            </table>
            <script type="text/javascript">
                function PrintReport()  
                {  
                    <%=ReportViewerRapor.ClientID %>.PrintReport();  
                }    
            </script>
        </div>
    </form>
</body>
</html>
