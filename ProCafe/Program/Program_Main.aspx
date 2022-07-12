<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Main.aspx.cs" Inherits="ProCafe.Program.Program_Main" %>

<%@ Import Namespace="ProCafe.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <asp:DataList ID="DataListMenu" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="10" OnItemDataBound="DataListMenu_ItemDataBound">
        <ItemTemplate>
            <div style="width: 225px;">
                <table>
                    <tr style="text-align: center;">
                        <td>
                            <asp:Label ID="LabelBaslik" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButtonResim" runat="server" Width="128" Height="128" OnClick="ImageButtonResim_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
