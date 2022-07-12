<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Raporlar_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Program_Raporlar_PopUp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=8.0.14.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
        </telerik:RadScriptManager>
        <div>
            <asp:Panel ID="PanelParametre" runat="server" Visible="false">
                <table>
                    <tr>
                        <td>Başlangıç Tarihi : </td>
                        <td style="width: 30%">
                            <telerik:RadDateTimePicker ID="RadDateTimePickerBaslangic" runat="server"></telerik:RadDateTimePicker>
                        </td>
                        <td>Bitiş Tarihi : </td>
                        <td style="width: 30%">
                            <telerik:RadDateTimePicker ID="RadDateTimePickerBitis" runat="server"></telerik:RadDateTimePicker>
                        </td>
                        <td>
                            <div style="float: right; vertical-align: central;">
                                <telerik:RadButton ID="RadButtonAra" runat="server" Text="Ara" OnClick="RadButtonAra_Click" Width="60" Height="30"></telerik:RadButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <telerik:ReportViewer ID="ReportViewerRapor" runat="server" Width="960" Height="580"></telerik:ReportViewer>
        </div>
    </form>
</body>
</html>
