<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Tanimlamalar_Masa_Islemleri_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Tanimlama.Program_Tanimlamalar_Masa_Islemleri_PopUp" %>

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
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <telerik:RadScriptManager runat="server" ID="RadScriptManagerTanimlama" />
            <telerik:RadWindowManager ID="RadWindowManagerTanimlama" runat="server"></telerik:RadWindowManager>
            <div>
                <telerik:RadTabStrip runat="server" ID="RadTabStripTanimlama" MultiPageID="RadMultiPageTanimlama" SelectedIndex="0" Skin="Silk">
                    <Tabs>
                        <telerik:RadTab Text="Masa Kaydet" Width="300px"></telerik:RadTab>
                        <telerik:RadTab Text="Masa Düzenle/Sil" Width="300px" Selected="True"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPageTanimlama" SelectedIndex="0">
                    <telerik:RadPageView runat="server" ID="RadPageViewKaydet">
                        <div>
                            <br />
                            <table width="500px">
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelMasaKatBolgeTur" runat="server" Text="Kat Bölge"></asp:Label></td>
                                    <td>
                                        <telerik:RadDropDownList ID="RadDropDownListKatBolgeTip" runat="server" DataTextField="MasaKatBolgeAd" DataValueField="MasaKatBolgeKey"></telerik:RadDropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelMasaAktif" runat="server" Text="Aktif"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxMasaAktif" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelMasaNo" runat="server" Text="Masa No"></asp:Label></td>
                                    <td>
                                        <telerik:RadTextBox ID="RadTextBoxMasaNo" runat="server" MaxLength="10"></telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelMasaKisi" runat="server" Text="Kişi Sayısı"></asp:Label></td>
                                    <td>
                                        <telerik:RadNumericTextBox runat="server" ID="RadNumericTextBoxMasaKisi" Type="Number" MaxLength="8" ></telerik:RadNumericTextBox>                                       
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label ID="LabelMasaSıraNo" runat="server" Text="Masa Sıra No"></asp:Label></td>
                                    <td>
                                        <telerik:RadNumericTextBox runat="server" ID="RadNumericTextBoxMasaSiraNo" Type="Number" MaxLength="2" ></telerik:RadNumericTextBox>                                       
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelMasaAciklama" runat="server" Text="Açıklama"></asp:Label></td>
                                    <td>
                                        <telerik:RadTextBox ID="RadTextBoxMasaAciklama" runat="server" TextMode="MultiLine" Rows="4" MaxLength="100"></telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <br/>
                                            <telerik:RadButton ID="RadButtonKaydet" runat="server" ButtonType="LinkButton" Text="Kaydet"  Width="96" Height="64" OnClick="RadButtonKaydet_Click"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonTemizle" runat="server" ButtonType="LinkButton" Text="Temizle"  Width="96" Height="64" OnClick="RadButtonTemizle_Click"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonGüncelle" runat="server" ButtonType="LinkButton" Text="Güncelle" Width="96" Height="64" OnClick="RadButtonGüncelle_Click" Visible="False"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonİptal" runat="server" ButtonType="LinkButton" Text="İptal"  Width="96" Height="64" OnClick="RadButtonİptal_Click" Visible="False"></telerik:RadButton>
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewDüzenleSil">
                        <div>
                            <telerik:RadGrid ID="RadGridMasa" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="570" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnNeedDataSource="RadGridMasa_NeedDataSource" OnItemDataBound="RadGridMasa_ItemDataBound" OnItemCommand="RadGridMasa_ItemCommand">
                                <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                                <MasterTableView NoMasterRecordsText="Masa bulunamadı." Width="100%" DataKeyNames="MasaKey">
                                    <Columns>
                                        <telerik:GridButtonColumn CommandName="Delete" Text="Sil" UniqueName="Delete" ImageUrl="../../../Image/OtherImages/Stop.png" ConfirmText="Silmek istediğinizden emin misiniz?" ConfirmDialogType="RadWindow" ConfirmTitle="Sil" ButtonType="ImageButton" ConfirmDialogHeight="25px" ButtonCssClass="ImageButtonSize">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn CommandName="Update" Text="Düzenle" UniqueName="Update" ImageUrl="../../../Image/OtherImages/Upload.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                        <telerik:GridCheckBoxColumn runat="server" HeaderText="Aktif" DataField="MasaAktif">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridCheckBoxColumn>
                                        <telerik:GridBoundColumn runat="server" HeaderText="Masa No" DataField="MasaNo">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn runat="server" HeaderText="Kat Bölge" DataField="T_Masa_Kat_Bolge_Tur.MasaKatBolgeAd">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn runat="server" HeaderText="Kişi Sayısı" DataField="MasaKisi">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                          <telerik:GridBoundColumn runat="server" HeaderText="Masa Sırası" DataField="MasaSira">
                                            <HeaderStyle Width="100px" />
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn runat="server" HeaderText="Açıklama" DataField="MasaAciklama">
                                            <HeaderStyle Width="400px" />
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