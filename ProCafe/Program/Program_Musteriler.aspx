<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Musteriler.aspx.cs" Inherits="ProCafe.Program.Program_Musteriler" %>

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
    <telerik:RadWindowManager ID="RadWindowManagerTanimlama" runat="server"></telerik:RadWindowManager>
    <div>
        <telerik:RadTabStrip runat="server" ID="RadTabStripTanimlama" MultiPageID="RadMultiPageTanimlama" SelectedIndex="0" Skin="Silk">
            <Tabs>
                <telerik:RadTab Text="Müşteri Kaydet" Width="300px"></telerik:RadTab>
                <telerik:RadTab Text="Müşteri Düzenle/Sil" Width="300px" Selected="True"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPageTanimlama" SelectedIndex="0">
            <telerik:RadPageView runat="server" ID="RadPageViewKaydet">
                <div>
                    <br />
                    <table style="width: 500px;">
                        <tr>
                            <td>
                                <asp:Label ID="LabelMusteriAd" runat="server" Text="Ad"></asp:Label></td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBoxMusteriAd" runat="server" MaxLength="50"></telerik:RadTextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelMusteriSoyad" runat="server" Text="Soyad"></asp:Label></td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBoxMusteriSoyad" runat="server" MaxLength="50"></telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelMusteriUnvan" runat="server" Text="Ünvan"></asp:Label></td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBoxMusteriUnvan" runat="server" MaxLength="50"></telerik:RadTextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabelMusteriTarih" runat="server" Text="Tarih"></asp:Label></td>
                            <td>
                                <telerik:RadDateInput ID="RadTextBoxMusteriTarih" runat="server" DisplayDateFormat="dd.MM.yyyy"></telerik:RadDateInput>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelMusteriTelefon" runat="server" Text="Telefon"></asp:Label></td>
                            <td>
                                <telerik:RadTextBox ID="RadTextBoxMusteriTelefon" runat="server" MaxLength="20"></telerik:RadTextBox>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelMusteriAciklama" runat="server" Text="Açıklama"></asp:Label></td>
                            <td colspan="3">
                                <telerik:RadTextBox ID="RadTextBoxMusteriAciklama" runat="server" TextMode="MultiLine" Rows="4" Width="670" MaxLength="500"></telerik:RadTextBox>
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
                    <telerik:RadGrid ID="RadGridMusteri" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="500" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnNeedDataSource="RadGridMusteri_NeedDataSource" OnItemCommand="RadGridMusteri_ItemCommand">
                        <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                        <MasterTableView NoMasterRecordsText="Müşteri bulunamadı." Width="100%" DataKeyNames="MusteriKey">
                            <Columns>

                                <telerik:GridButtonColumn CommandName="Delete" Text="Sil" UniqueName="Delete" ImageUrl="../Image/OtherImages/Stop.png" ConfirmText="Silmek istediğinizden emin misiniz?" ConfirmDialogType="RadWindow" ConfirmTitle="Sil" ButtonType="ImageButton" ConfirmDialogHeight="25px" ButtonCssClass="ImageButtonSize">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="Update" Text="Düzenle" UniqueName="Update" ImageUrl="../Image/OtherImages/Upload.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridButtonColumn>
                                <telerik:GridDateTimeColumn runat="server" HeaderText="Tarih" DataField="MusteriTarih" DataFormatString="{0:dd.MM.yyyy}">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridDateTimeColumn>
                                <telerik:GridBoundColumn runat="server" HeaderText="Ünvan" DataField="MusteriUnvan">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn runat="server" HeaderText="Ad" DataField="MusteriAd">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn runat="server" HeaderText="Soyad" DataField="MusteriSoyad">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn runat="server" HeaderText="Telefon" DataField="MusteriTelefon">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn runat="server" HeaderText="Açıklama" DataField="MusteriAciklama">
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
