<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Masa_Siparis.aspx.cs" Inherits="ProCafe.Program.Program_Masa_Siparis" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Import Namespace="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UserControl/Masa_User_Control.ascx" TagName="Masa_User_Control" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
    <div style="float: right">
        <telerik:RadButton ID="RadButtonHesapAktar" runat="server" Text="HesapAktar" ButtonType="LinkButton" Width="64" Height="32" Font-Bold="true" OnClick="RadButtonHesapAktar_Click"></telerik:RadButton>
        <telerik:RadButton ID="RadButtonYenile" runat="server" Text="Yenile" ButtonType="LinkButton" Width="64" Height="32" Font-Bold="true" OnClick="RadButtonYenile_Click"></telerik:RadButton>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <div>
        <uc1:Masa_User_Control ID="Masa_User_Control1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
