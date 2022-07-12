<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Masa_Paket_Siparis_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Program_Masa_Paket_Siparis_PopUp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../UserControl/Siparis_User_Control.ascx" TagName="Siparis_User_Control" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
            </telerik:RadScriptManager>
            <uc1:Siparis_User_Control ID="Siparis_User_Control1" runat="server" />
        </div>
    </form>
</body>
</html>
