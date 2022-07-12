<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Tanimlamalar.aspx.cs" Inherits="ProCafe.Program.Program_Tanimlamalar" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Import Namespace="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <asp:DataList ID="DataListTanimlar" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="40" CellSpacing="30" OnItemDataBound="DataListTanimlar_ItemDataBound">
        <ItemTemplate>
            <div style="width: 200px;">
                <table>
                    <tr>
                        <td align="center">
                            <asp:Label ID="LabelBaslik" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButtonResim" runat="server" Width="128" Height="128" OnClick="ImageButtonResim_Click" />
                            <asp:Label ID="LabelUrl" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
