<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Rezervasyon.aspx.cs" Inherits="ProCafe.Program.Program_Rezervasyon" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Src="../UserControl/Rezervasyon_Not_Hatirlatma_User_Control.ascx" TagName="Rezervasyon_Not_Hatirlatma_User_Control" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <uc1:Rezervasyon_Not_Hatirlatma_User_Control ID="Rezervasyon_Not_Hatirlatma_User_Control1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
