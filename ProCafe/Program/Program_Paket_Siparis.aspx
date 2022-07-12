<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Paket_Siparis.aspx.cs" Inherits="ProCafe.Program.Program_Paket_Siparis" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .ImageButtonSize {
            height: 36px;
            width: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <div>
        <telerik:RadTabStrip runat="server" ID="RadTabStripTanimlama" MultiPageID="RadMultiPageTanimlama" SelectedIndex="0" Skin="Silk">
            <Tabs>
                <telerik:RadTab Text="Paket Sipariş Kaydet" Width="300px"></telerik:RadTab>
                <telerik:RadTab Text="Paket Sipariş Düzenle/Sil" Width="300px" Selected="True"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPageTanimlama" SelectedIndex="0">
            <telerik:RadPageView runat="server" ID="RadPageViewKaydet">
                <div>
                    <br />
                    <table style="margin: 10px; width: 500px;">
                        <tr>
                            <td>
                                <asp:Label ID="LabelSiparisAd" runat="server" Text="Ad"></asp:Label></td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBoxSiparisAd" runat="server" MaxLength="50"></telerik:RadTextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelSiparisSoyad" runat="server" Text="Soyad"></asp:Label></td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBoxSiparisSoyad" runat="server" MaxLength="50"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelSiparisTelefon" runat="server" Text="Telefon"></asp:Label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="RadTextBoxSiparisTelefon" runat="server" MaxLength="20"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelSiparisAdres" runat="server" Text="Adres"></asp:Label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="RadTextBoxSiparisAdres" runat="server" TextMode="MultiLine" Rows="4" Width="670" MaxLength="100"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelSiparisAciklama" runat="server" Text="Açıklama"></asp:Label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="RadTextBoxSiparisAciklama" runat="server" TextMode="MultiLine" Rows="4" Width="670" MaxLength="500"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr style="text-align: center;">
                            <td colspan="4">
                                <br />
                                <telerik:RadButton ID="RadButtonKaydet" runat="server" Width="96" Height="64" ButtonType="LinkButton" Text="Kaydet" OnClick="RadButtonKaydet_Click"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonTemizle" runat="server" Width="96" Height="64" ButtonType="LinkButton" Text="Temizle" OnClick="RadButtonTemizle_Click"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonGüncelle" runat="server" Width="96" Height="64" ButtonType="LinkButton" Text="Güncelle" OnClick="RadButtonGüncelle_Click" Visible="False"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonİptal" runat="server" Width="96" Height="64" ButtonType="LinkButton" Text="İptal" OnClick="RadButtonİptal_Click" Visible="False"></telerik:RadButton>
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
                                <asp:Label ID="LabelBaslangicTarih" runat="server" Text="Başlangıç"></asp:Label></td>
                            <td>
                                <telerik:RadDateTimePicker ID="RadDateTimePickerBaslangicTarih" runat="server"></telerik:RadDateTimePicker>
                            </td>
                            <td>
                                <asp:Label ID="LabelBitisTarih" runat="server" Text="Bitiş"></asp:Label></td>
                            <td>
                                <telerik:RadDateTimePicker ID="RadDateTimePickerBitisTarih" runat="server"></telerik:RadDateTimePicker>
                            </td>
                            <td></td>
                            <td style="text-align: right;">
                                <telerik:RadButton ID="RadButtonAra" runat="server" Text="Ara" ButtonType="LinkButton" Width="64" Height="32" OnClick="RadButtonAra_Click"></telerik:RadButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <telerik:RadGrid ID="RadGridSiparis" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="490" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnNeedDataSource="RadGridSiparis_NeedDataSource" OnItemCommand="RadGridSiparis_ItemCommand">
                                    <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                                    <MasterTableView NoMasterRecordsText="Sipariş bulunamadı." Width="100%" DataKeyNames="SiparisKey">
                                        <Columns>
                                            <telerik:GridButtonColumn CommandName="Delete" Text="Sil" UniqueName="Delete" ImageUrl="../Image/OtherImages/Stop.png" ConfirmText="Silmek istediğinizden emin misiniz?" ConfirmDialogType="RadWindow" ConfirmTitle="Sil" ButtonType="ImageButton" ConfirmDialogHeight="25px" ButtonCssClass="ImageButtonSize">
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn CommandName="Update" Text="Düzenle" UniqueName="Update" ImageUrl="../Image/OtherImages/Upload.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn CommandName="OpenPopup" Text="Sipariş Değiştir" UniqueName="OpenPopup" ImageUrl="../Image/OtherImages/Package.ico" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridButtonColumn>
                                            <telerik:GridDateTimeColumn runat="server" HeaderText="Tarih" DataField="SiparisAlindiTarih" DataFormatString="{0:dd.MM.yyyy HH:mm}">
                                                <HeaderStyle Width="150px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Ad" DataField="SiparisAd">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Soyad" DataField="SiparisSoyad">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Telefon" DataField="SiparisTelefon">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Adres" DataField="SiparisAdres">
                                                <HeaderStyle Width="200px" />
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn runat="server" HeaderText="Açıklama" DataField="SiparisAciklama">
                                                <HeaderStyle Width="200px" />
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
