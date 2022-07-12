<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Tanimlamalar_Urun_Islemleri_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Tanimlama.Program_Tanimlamalar_Urun_Islemleri_PopUp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .ImageButtonSize {
            height: 36px;
            width: 36px;
        }

        .auto-style1 {
            width: 634px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManagerTanimlama" />
        <telerik:RadWindowManager ID="RadWindowManagerTanimlama" runat="server"></telerik:RadWindowManager>
        <div>
            <telerik:RadTabStrip runat="server" ID="RadTabStripTanimlama" MultiPageID="RadMultiPageTanimlama" SelectedIndex="0" Skin="Silk">
                <Tabs>
                    <telerik:RadTab Text="Ürün Kaydet" Width="300px"></telerik:RadTab>
                    <telerik:RadTab Text="Ürün Düzenle/Sil" Width="300px" Selected="True"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPageTanimlama" SelectedIndex="0">
                <telerik:RadPageView runat="server" ID="RadPageViewKaydet">
                    <div>
                        <br />
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelUrunKategoriTur" runat="server" Text="Kategori"></asp:Label></td>
                                <td class="auto-style1">
                                    <telerik:RadDropDownList ID="RadDropDownListUrunKategoriTip" runat="server" DataTextField="UrunKategoriTurAd" DataValueField="UrunKategoriTurKey"></telerik:RadDropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="LabelUrunAktif" runat="server" Text="Aktif"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxUrunAktif" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelUrunAd" runat="server" Text="Ürün Ad"></asp:Label></td>
                                <td class="auto-style1">
                                    <telerik:RadTextBox ID="RadTextBoxUrunAd" runat="server" MaxLength="20"></telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:Label ID="LabelUrunFiyat" runat="server" Text="Fiyat"></asp:Label></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RadTextBoxUrunFiyat" runat="server" MaxLength="10" MinValue="0">
                                        <NumberFormat AllowRounding="false" DecimalDigits="2" ZeroPattern="n TL" />
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelKullaniciTur" runat="server" Text="Kullanıcı Tipi"></asp:Label></td>
                                <td>
                                    <telerik:RadDropDownList ID="RadDropDownListKullaniciTip" runat="server" DataTextField="KullaniciTurAd" DataValueField="KullaniciTurKey"></telerik:RadDropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="LabelUrunSiralama" runat="server" Text="Sıralama"></asp:Label></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxUrunSiralama" runat="server" Type="Number" MaxLength="10">
                                        <NumberFormat AllowRounding="false" DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelUrunAciklama" runat="server" Text="Açıklama"></asp:Label></td>
                                <td colspan="3">
                                    <telerik:RadTextBox ID="RadTextBoxUrunAciklama" runat="server" TextMode="MultiLine" Rows="4" Width="650" MaxLength="100"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                            <br/>
                                            <telerik:RadButton ID="RadButtonKaydet" runat="server" ButtonType="LinkButton" Text="Kaydet"  Width="96" Height="64" OnClick="RadButtonKaydet_Click"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonTemizle" runat="server" ButtonType="LinkButton" Text="Temizle"  Width="96" Height="64" OnClick="RadButtonTemizle_Click"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonGüncelle" runat="server" ButtonType="LinkButton" Text="Güncelle"  Width="96" Height="64" OnClick="RadButtonGüncelle_Click" Visible="False"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonİptal" runat="server" ButtonType="LinkButton" Text="İptal" Width="96" Height="64" OnClick="RadButtonİptal_Click" Visible="False"></telerik:RadButton>
                                        </center>
                                </td>
                            </tr>
                        </table>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="RadPageViewDüzenleSil">
                    <div>
                        <telerik:RadGrid ID="RadGridUrun" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="570" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnNeedDataSource="RadGridUrun_NeedDataSource" OnItemDataBound="RadGridUrun_ItemDataBound" OnItemCommand="RadGridUrun_ItemCommand">
                            <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                            <MasterTableView NoMasterRecordsText="Ürün bulunamadı." Width="100%" DataKeyNames="UrunKey">
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Delete" Text="Sil" UniqueName="Delete" ImageUrl="../../../Image/OtherImages/Stop.png" ConfirmText="Silmek istediğinizden emin misiniz?" ConfirmDialogType="RadWindow" ConfirmTitle="Sil" ButtonType="ImageButton" ConfirmDialogHeight="25px" ButtonCssClass="ImageButtonSize">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridButtonColumn CommandName="Update" Text="Düzenle" UniqueName="Update" ImageUrl="../../../Image/OtherImages/Upload.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Ürün Ad" DataField="UrunAd">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridCheckBoxColumn runat="server" HeaderText="Aktif" DataField="UrunAktif">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridCheckBoxColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Kategori" DataField="T_Urun_Kategori_Tur.UrunKategoriTurAd">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Kullanıcı Tip" DataField="T_Kullanici_Tur.KullaniciTurAd">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Fiyat" DataField="UrunFiyat">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Sıralama" DataField="UrunSiralama">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Açıklama" DataField="UrunAciklama">
                                        <HeaderStyle Width="200px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </form>
</body>
</html>
