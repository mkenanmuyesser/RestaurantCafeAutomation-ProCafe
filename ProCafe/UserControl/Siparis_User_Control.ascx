<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Siparis_User_Control.ascx.cs" Inherits="ProCafe.UserControl.Siparis_User_Control" %>
<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=8.0.14.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<style type="text/css">
    .DivMargin {
        margin: 5px;
    }

    .ImageButtonSize {
        height: 36px;
        width: 36px;
    }
</style>
<script type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;//Will work in Moz in all cases, including clasic dialog
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
        return oWindow;
    }

    function CloseOnReload1() {

        setTimeout(function () {
            RefreshParentPage1();
            GetRadWindow().Close();
        }, 300);
    }

    function CloseOnReload2() {

        setTimeout(function () {
            RefreshParentPage2();
            GetRadWindow().Close();
        }, 300);

    }

    function RefreshParentPage1() {
        GetRadWindow().BrowserWindow.location = "../Program_Masa_Siparis.aspx";
    }

    function RefreshParentPage2() {
        GetRadWindow().BrowserWindow.location = "../Program_Paket_Siparis.aspx";
    }
</script>
<div>
    <table>
        <tr>
            <td colspan="2">
                <asp:Panel ID="PanelKategori" runat="server" Width="960" Height="110" ScrollBars="Horizontal">
                    <table>
                        <tr>
                            <asp:Repeater ID="RepeaterKategori" runat="server" OnItemDataBound="RepeaterKategori_ItemDataBound">
                                <ItemTemplate>
                                    <td>

                                        <asp:LinkButton ID="LinkButtonKategori" runat="server" OnClick="LinkButtonKategori_Click" CssClass="DivMargin">
                                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImageKategori" ImageUrl="../Image/OtherImages/catalbicak.png"
                                                AutoAdjustImageControlSize="false" Width="72" Height="72" />
                                        </asp:LinkButton>
                                    </td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr valign="top">
            <td>
                <div style="float: left; height: 490px; overflow: auto; width: 550px;">
                    <asp:DataList ID="DataListUrun" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" OnItemDataBound="DataListUrun_ItemDataBound" Width="510px">
                        <ItemTemplate>
                            <div style="margin: 5px;">
                                <table>
                                    <tr style="text-align: center;">
                                        <td>
                                            <asp:Label ID="LabelUrunAd" runat="server"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LinkButtonUrun" runat="server" OnClick="LinkButtonUrun_Click" CssClass="DivMargin">
                                                <telerik:RadBinaryImage runat="server" ID="RadBinaryImageUrun"
                                                    AutoAdjustImageControlSize="false" Width="72" Height="72" ImageUrl="../Image/OtherImages/catalbicak.png" />
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:Label ID="LabelUrunFiyat" runat="server"></asp:Label>
                                            <hr />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </td>
            <td>
                <div style="float: left; width: 400px;">
                    <table>
                        <tr>
                            <td style="width: 300px;">
                                <asp:Panel ID="PanelMasaSiparis" runat="server">
                                    Masa No:                              
                                    <asp:Label ID="LabelMasaNo" runat="server"></asp:Label><br />
                                    Garson: 
                                    <asp:Label ID="LabelSiparisiKimAldi" runat="server"></asp:Label>
                                    <br />
                                </asp:Panel>
                                Sipariş Zamanı:
                                <asp:Label ID="LabelSiparisAcilisZamani" runat="server"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonEkranKapat1" runat="server" Text="Çıkış" Font-Bold="true" Font-Size="Large" Width="96" Height="64" ButtonType="LinkButton" OnClick="RadButtonEkranKapat_Click" BackColor="Red" ForeColor="White" Visible="False"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonEkranKapat2" runat="server" Text="Çıkış" Font-Bold="true" Font-Size="Large" Width="96" Height="64" ButtonType="LinkButton" OnClick="RadButtonEkranKapat_Click" BackColor="Red" ForeColor="White" Visible="False"></telerik:RadButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadGrid ID="RadGridSiparisUrun" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Width="400" Height="320" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnItemCommand="RadGridSiparisUrun_ItemCommand" OnItemDataBound="RadGridSiparisUrun_ItemDataBound" OnNeedDataSource="RadGridSiparisUrun_NeedDataSource">
                                    <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                                    <MasterTableView NoMasterRecordsText="Sipariş edilen ürün bulunamadı." DataKeyNames="UrunKey,SiparisUrunKey">
                                        <Columns>
                                            <telerik:GridButtonColumn CommandName="Select" Text="Seç" UniqueName="Select" ImageUrl="../Image/OtherImages/Select.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn CommandName="Deselect" Text="İptal" UniqueName="Deselect" ImageUrl="../Image/OtherImages/Back.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Ürün">
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Birim Fiyat">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                <div>
                                    <div style="float: left;">
                                        <asp:Label ID="LabelGenelToplam" runat="server" Text="Genel Toplam :"></asp:Label>
                                        <telerik:RadNumericTextBox ID="RadNumericTextBoxGenelToplam" Type="Currency" runat="server" MaxLength="8" Enabled="False">
                                            <NumberFormat AllowRounding="false" DecimalDigits="2" ZeroPattern="n TL" />
                                        </telerik:RadNumericTextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:Label ID="LabelToplam" runat="server" Text="Genel Toplam :"></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;" colspan="2">
                                <telerik:RadComboBox ID="RadComboBoxUrunSayisi" runat="server" Width="40" AllowCustomText="false" EnableTextSelection="false"></telerik:RadComboBox>
                                &nbsp;&nbsp;&nbsp;
                                <telerik:RadButton ID="RadButtonUrunArttir" runat="server" Text="ÜrünEkle" Width="96" Height="64" Font-Bold="true" Font-Size="Large" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonUrunEkle_Click"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonUrunEksilt" runat="server" Text="ÜrünEksilt" Width="96" Height="64" Font-Bold="true" Font-Size="Large" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonUrunEksilt_Click"></telerik:RadButton>

                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>
