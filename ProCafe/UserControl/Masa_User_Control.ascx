<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Masa_User_Control.ascx.cs" Inherits="ProCafe.UserControl.Masa_User_Control" %>

<asp:DataList ID="DataListMasa" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="10" OnItemDataBound="DataListMasa_ItemDataBound">
    <ItemTemplate>
        <div style="width: 170px;">
            <table>
                <tr style="text-align: center">
                    <td>
                        <asp:Label ID="LabelMasaNo" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButtonMasa" runat="server" Width="128" Height="128" OnClick="ImageButtonMasa_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </ItemTemplate>
</asp:DataList>