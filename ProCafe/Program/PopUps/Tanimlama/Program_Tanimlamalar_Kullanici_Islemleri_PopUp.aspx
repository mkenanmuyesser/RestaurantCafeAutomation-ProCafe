<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Tanimlamalar_Kullanici_Islemleri_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Tanimlama.Program_Tanimlamalar_Kullanici_Islemleri_PopUp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .ImageButtonSize {
            height: 36px;
            width: 36px;
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
                    <telerik:RadTab Text="Kullanıcı Kaydet" Width="300px"></telerik:RadTab>
                    <telerik:RadTab Text="Kullanıcı Düzenle/Sil" Width="300px" Selected="True"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPageTanimlama" SelectedIndex="0">
                <telerik:RadPageView runat="server" ID="RadPageViewKaydet">
                    <div>
                        <br />
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelKullaniciTur" runat="server" Text="Kullanıcı Tipi"></asp:Label></td>
                                <td>
                                    <telerik:RadDropDownList ID="RadDropDownListKullaniciTip" runat="server" DataTextField="KullaniciTurAd" DataValueField="KullaniciTurKey"></telerik:RadDropDownList>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelKullaniciKullaniciAd" runat="server" Text="Takma Ad"></asp:Label></td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBoxKullaniciKullaniciAd" runat="server" MaxLength="20"></telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:Label ID="LabelKullaniciKullaniciParola" runat="server" Text="Parola" MaxLength="20"></asp:Label></td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBoxKullaniciKullaniciParola" runat="server"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelKullaniciAd" runat="server" Text="Ad"></asp:Label></td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBoxKullaniciAd" runat="server" MaxLength="20"></telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:Label ID="LabelKullaniciSoyad" runat="server" Text="Soyad"></asp:Label></td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBoxKullaniciSoyad" runat="server" MaxLength="20"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelKullaniciTcNo" runat="server" Text="Tc No"></asp:Label></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxKullaniciTcNo" runat="server" MaxLength="11" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""></telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:Label ID="LabelKullaniciSgkNo" runat="server" Text="Sgk No"></asp:Label></td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBoxKullaniciSgkNo" runat="server" MaxLength="20"></telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelNotlarHatirlatmalarYetki" runat="server" Text="Notlar Hatırlatmalar Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxNotlarHatirlatmalarYetki" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelKullaniciIseBaslamaTarih" runat="server" Text="İşe Başlama Tarihi"></asp:Label></td>
                                <td>
                                    <telerik:RadDateInput ID="RadDateInputKullaniciIseBaslamaTarihi" runat="server" DisplayDateFormat="dd.MM.yyyy"></telerik:RadDateInput>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelMasaSiparisYetki" runat="server" Text="Masa Sipariş Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxMasaSiparisYetki" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelPaketSiparisYetki" runat="server" Text="Paket Sipariş Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxPaketSiparisYetki" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelRezervasyonYetki" runat="server" Text="Rezervasyon Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxRezervasyonYetki" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelMusterilerYetki" runat="server" Text="Müşteriler Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxMusterilerYetki" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelMutfakYetki" runat="server" Text="Mutfak Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxMutfakYetki" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelKasaIslemleriYetki" runat="server" Text="Kasa İşlemleri Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxKasaIslemleriYetki" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelRaporlarYetki" runat="server" Text="Raporlar Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxRaporlarYetki" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelStokTakibiYetki" runat="server" Text="Stok Takibi Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxStokTakibiYetki" runat="server" Enabled="False" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAyarlarYetki" runat="server" Text="Ayarlar Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxAyarlarYetki" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelTanimlamalarYetki" runat="server" Text="Tanımlamalar Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxTanimlamalarYetki" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelSiparisIptalYetki" runat="server" Text="Sipariş İptal Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxSiparisIptalYetki" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelUcretsizSatisYetki" runat="server" Text="Ücretsiz Satış Yetkisi"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxUcretsizSatisYetki" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                            <br/>
                                            <telerik:RadButton ID="RadButtonKaydet" runat="server" ButtonType="LinkButton" Text="Kaydet"  Width="96" Height="64" OnClick="RadButtonKaydet_Click" ></telerik:RadButton>                                        
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
                        <telerik:RadGrid ID="RadGridKullanici" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="570" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnNeedDataSource="RadGridKullanici_NeedDataSource" OnItemDataBound="RadGridKullanici_ItemDataBound" OnItemCommand="RadGridKullanici_ItemCommand">
                            <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                            <MasterTableView NoMasterRecordsText="Kullanıcı bulunamadı." Width="100%" DataKeyNames="KullaniciKey">
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Delete" Text="Sil" UniqueName="Delete" ImageUrl="../../../Image/OtherImages/Stop.png" ConfirmText="Silmek istediğinizden emin misiniz?" ConfirmDialogType="RadWindow" ConfirmTitle="Sil" ButtonType="ImageButton" ConfirmDialogHeight="25px" ButtonCssClass="ImageButtonSize">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridButtonColumn CommandName="Update" Text="Düzenle" UniqueName="Update" ImageUrl="../../../Image/OtherImages/Upload.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Kullanıcı Tipi">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Takma Ad" DataField="KullaniciKullaniciAd">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Parola">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Ad" DataField="KullaniciAd">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Soyad" DataField="KullaniciSoyad">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Tc No" DataField="KullaniciTcNo">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Sgk No" DataField="KullaniciSgkNo">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="İşe Başlama Tarihi" DataField="KullaniciIseBaslamaTarihi" DataFormatString="{0:dd/MM/yyyy}">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
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
