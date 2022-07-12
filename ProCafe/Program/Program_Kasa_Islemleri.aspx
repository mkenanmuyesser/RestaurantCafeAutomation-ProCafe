<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Kasa_Islemleri.aspx.cs" Inherits="ProCafe.Program.Program_Kasa_Islemleri" %>
<%@ Import Namespace="ProCafe.Data" %>
<%@ Import Namespace="Telerik.Web.UI" %>

<%@ Register Src="../UserControl/Kasa_Mutfak_User_Control.ascx" TagName="Kasa_Mutfak_User_Control" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <uc1:Kasa_Mutfak_User_Control ID="Kasa_Mutfak_User_ControlProgramKasa" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>