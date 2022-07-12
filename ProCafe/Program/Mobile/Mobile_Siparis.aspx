<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mobile_Siparis.aspx.cs" Inherits="ProCafe.Program.Mobile.Mobile_Siparis" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pro Cafe</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no;width:450;">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <style type="text/css">
        html, body, #mobileContainer {
            height: 100%;
        }

        ul {
            list-style: none;
        }

        body {
            margin: 0;
            padding: 0;
        }

        .ImageButtonSize {
            height: 28px;
            width: 28px;
        }
    </style>
    <script type="text/javascript">
        function hideURLbar() {
            window.scrollTo(0, 1);
        }

        if (navigator.userAgent.indexOf('iPhone') != -1 || navigator.userAgent.indexOf('Android') != -1) {
            addEventListener("load", function () {
                setTimeout(hideURLbar, 0);
            }, false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <span id="dummyspan"></span>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
        </telerik:RadScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="width: 320px; height: auto;">
                    <table>
                        <tr>
                            <td colspan="2">
                                <center>    <h3>Siparişler</h3></center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp; &nbsp;
                    <telerik:RadButton ID="RadButtonYenile" runat="server" Text="Yenile" ButtonType="LinkButton" Bold="True" Font-Size="Large" Width="100" OnClick="RadButtonYenile_Click"></telerik:RadButton>

                                <telerik:RadButton ID="RadButtonMasa" runat="server" Text="Masa Seçim" ButtonType="LinkButton" Bold="True" Font-Size="Large" Width="100" OnClick="RadButtonMasa_Click"></telerik:RadButton>
                                &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
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
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;" colspan="2">
                                            <telerik:RadComboBox ID="RadComboBoxUrunSayisi" runat="server" Width="40" AllowCustomText="false" EnableTextSelection="false"></telerik:RadComboBox>
                                            &nbsp;&nbsp;&nbsp;
                                            <telerik:RadButton ID="RadButtonUrunArttir" runat="server" Text="Ürün Arttır" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonUrunEkle_Click"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonUrunEksilt" runat="server" Text="Ürün Eksilt" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonUrunEksilt_Click"></telerik:RadButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <div>
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <telerik:RadGrid ID="RadGridSiparisUrun" runat="server" AutoGenerateColumns="False" Height="230" Font-Size="10" Font-Bold="True" Width="300" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnItemCommand="RadGridSiparisUrun_ItemCommand" OnItemDataBound="RadGridSiparisUrun_ItemDataBound" OnNeedDataSource="RadGridSiparisUrun_NeedDataSource">
                                    <HeaderStyle Font-Size="10" HorizontalAlign="Center"></HeaderStyle>
                                    <MasterTableView NoMasterRecordsText="Sipariş edilen ürün bulunamadı." DataKeyNames="UrunKey,SiparisUrunKey">
                                        <Columns>
                                            <telerik:GridButtonColumn CommandName="Select" Text="Seç" UniqueName="Select" ImageUrl="../../Image/OtherImages/Select.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn CommandName="Deselect" Text="İptal" UniqueName="Deselect" ImageUrl="../../Image/OtherImages/Back.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Ürün">
                                                <HeaderStyle Width="120px" />
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Birim Fiyat">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 60px; margin: 0px;" valign="top">
                                <asp:Repeater ID="RepeaterKategori" runat="server" OnItemDataBound="RepeaterKategori_ItemDataBound">
                                    <ItemTemplate>
                                        <div>
                                            <telerik:RadButton ID="LinkButtonKategori" runat="server" Text="RadButton" BorderColor="Transparent" BackColor="Transparent" ButtonType="LinkButton" Width="72" Height="72" OnClick="LinkButtonKategori_Click">
                                                <ContentTemplate>
                                                    <telerik:RadBinaryImage runat="server" ID="RadBinaryImageKategori"
                                                        AutoAdjustImageControlSize="false" Width="72" Height="72" ImageUrl="../../Image/OtherImages/catalbicak.png" />
                                                </ContentTemplate>
                                            </telerik:RadButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                            <td valign="top">
                                <asp:DataList ID="DataListUrun" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" OnItemDataBound="DataListUrun_ItemDataBound" Width="200">
                                    <ItemTemplate>
                                        <div>
                                            <table>
                                                <tr style="text-align: center;">
                                                    <td>
                                                        <asp:Label ID="LabelUrunAd" runat="server" Width="56"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButtonUrun" runat="server" OnClick="LinkButtonUrun_Click" CssClass="DivMargin">
                                                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImageUrun" ImageUrl="../../Image/OtherImages/catalbicak.png"
                                                                AutoAdjustImageControlSize="false" Width="56" Height="56" />
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
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
