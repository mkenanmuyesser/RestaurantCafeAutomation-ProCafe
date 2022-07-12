<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Raporlar.aspx.cs" Inherits="ProCafe.Program.Program_Raporlar" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Import Namespace="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <asp:DataList ID="DataListRapor" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="30" CellSpacing="30" OnItemDataBound="DataListRapor_ItemDataBound">
        <ItemTemplate>
            <div style="width: 200px;">
                <table>
                    <tr style="text-align: center;">
                        <td>
                            <asp:Label ID="LabelRaporBaslik" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButtonRapor" runat="server" Width="128" Height="128" OnClick="ImageButtonRapor_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
