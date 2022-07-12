<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Rezervasyon_Not_Hatirlatma_User_Control.ascx.cs" Inherits="ProCafe.UserControl.Rezervasyon_Not_Hatirlatma_User_Control" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<style type="text/css">
    .ImageButtonSize {
        height: 36px;
        width: 36px;
    }
</style>
<div>
    <telerik:RadTabStrip runat="server" ID="RadTabStripTanimlama" MultiPageID="RadMultiPageTanimlama" SelectedIndex="0" Skin="Silk">
        <Tabs>
            <telerik:RadTab Text="Rezervasyon Kaydet" Width="300px"></telerik:RadTab>
            <telerik:RadTab Text="Rezervasyon Düzenle/Sil" Width="300px" Selected="True"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPageTanimlama" SelectedIndex="0">
        <telerik:RadPageView runat="server" ID="RadPageViewKaydet">
            <div>
                <br />
                <table width="500px">
                    <tr>
                        <td>
                            <asp:Label ID="LabelMasa" runat="server" Text="Masa"></asp:Label></td>
                        <td>
                            <telerik:RadDropDownList ID="RadDropDownListMasa" runat="server" DataTextField="MasaNo" DataValueField="MasaKey"></telerik:RadDropDownList>
                        </td>
                        <td>
                            <asp:Label ID="LabelRezervasyonNotHatirlatmaTarihSaat" runat="server" Text="Tarih - Saat"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateInput ID="RadDateInputRezervasyonNotHatirlatmaTarihSaat" runat="server" DisplayDateFormat="dd.MM.yyyy HH:mm"></telerik:RadDateInput>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelRezervasyonNotHatirlatmaAciklama" runat="server" Text="Açıklama"></asp:Label></td>
                        <td colspan="3">
                            <telerik:RadTextBox ID="RadTextBoxRezervasyonNotHatirlatmaAciklama" runat="server" TextMode="MultiLine" Rows="4" Width="670" MaxLength="500"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <br />
                            <center>
                                <telerik:RadButton ID="RadButtonKaydet" runat="server" ButtonType="LinkButton" Width="96" Height="64"  Text="Kaydet" OnClick="RadButtonKaydet_Click"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonTemizle" runat="server" ButtonType="LinkButton" Width="96" Height="64"  Text="Temizle" OnClick="RadButtonTemizle_Click"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonGüncelle" runat="server" ButtonType="LinkButton" Width="96" Height="64"  Text="Güncelle" OnClick="RadButtonGüncelle_Click" Visible="False"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonİptal" runat="server" ButtonType="LinkButton" Width="96" Height="64"  Text="İptal" OnClick="RadButtonİptal_Click" Visible="False"></telerik:RadButton>
                            </center>
                        </td>
                    </tr>
                </table>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageViewDüzenleSil">
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelBaslangic" runat="server" Text="Başlangıç Tarih"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="RadDateTimePickerBaslangicTarih" runat="server">
                            </telerik:RadDateTimePicker>
                        </td>
                        <td>
                            <asp:Label ID="LabelBitis" runat="server" Text="Bitiş Tarih"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="RadDateTimePickerBitisTarih" runat="server">
                            </telerik:RadDateTimePicker>
                        </td>
                        <td></td>
                        <td style="text-align: right;">
                            <telerik:RadButton ID="RadButtonArama" runat="server" ButtonType="LinkButton" Text="Arama" Width="64" Height="32" Font-Bold="true" Font-Size="Large" OnClick="RadButtonArama_Click"></telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <telerik:RadGrid ID="RadGridRezervasyon" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="490" Width="970" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnNeedDataSource="RadGridRezervasyon_NeedDataSource" OnItemCommand="RadGridRezervasyon_ItemCommand">
                                <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                                <MasterTableView NoMasterRecordsText="Rezervasyon bulunamadı." Width="100%" DataKeyNames="RezervasyonNotHatirlatmaKey">
                                    <Columns>
                                        <telerik:GridButtonColumn CommandName="Delete" Text="Sil" UniqueName="Delete" ImageUrl="../Image/OtherImages/Stop.png" ConfirmText="Silmek istediğinizden emin misiniz?" ConfirmDialogType="RadWindow" ConfirmTitle="Sil" ButtonType="ImageButton" ConfirmDialogWidth="500" ConfirmDialogHeight="25px" ButtonCssClass="ImageButtonSize">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn CommandName="Update" Text="Düzenle" UniqueName="Update" ImageUrl="../Image/OtherImages/Upload.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn runat="server" HeaderText="Tarih Saat" DataField="RezervasyonNotHatirlatmaTarihSaat" DataFormatString="{0:dd.MM.yyyy HH:mm}">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn runat="server" HeaderText="Masa" DataField="Masa.MasaNo">
                                            <HeaderStyle Width="200px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn runat="server" HeaderText="Açıklama" DataField="RezervasyonNotHatirlatmaAciklama">
                                            <HeaderStyle Width="400px" />
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
