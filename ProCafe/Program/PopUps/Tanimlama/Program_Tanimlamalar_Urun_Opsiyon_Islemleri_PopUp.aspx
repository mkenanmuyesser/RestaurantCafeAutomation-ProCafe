<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program_Tanimlamalar_Urun_Opsiyon_Islemleri_PopUp.aspx.cs" Inherits="ProCafe.Program.PopUps.Tanimlama.Program_Tanimlamalar_Urun_Opsiyon_Islemleri_PopUp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManagerTanimlama" />
        <telerik:RadWindowManager ID="RadWindowManagerTanimlama" runat="server"></telerik:RadWindowManager>
        <div>
            <telerik:RadTabStrip runat="server" ID="RadTabStripTanimlama" MultiPageID="RadMultiPageTanimlama" SelectedIndex="0" Skin="Silk">
                <Tabs>
                    <telerik:RadTab Text="Ürün Opsiyon Kaydet" Width="300px"></telerik:RadTab>
                    <telerik:RadTab Text="Ürün Opsiyon Düzenle/Sil" Width="300px" Selected="True"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPageTanimlama" SelectedIndex="0">
                <telerik:RadPageView runat="server" ID="RadPageViewKaydet">
                    <div>
                        <br />
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelUrunOpsiyonAd" runat="server" Text="Opsiyon Ad"></asp:Label></td>
                                <td>
                                    <telerik:RadTextBox ID="RadTextBoxUrunOpsiyonAd" runat="server" MaxLength="20"></telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                            <telerik:RadButton ID="RadButtonKaydet" runat="server" ButtonType="LinkButton" Text="Kaydet"  Width="96" Height="64" OnClick="RadButtonKaydet_Click"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonTemizle" runat="server" ButtonType="LinkButton" Text="Temizle"  Width="96" Height="64" OnClick="RadButtonTemizle_Click"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonGüncelle" runat="server" ButtonType="LinkButton" Text="Güncelle"  Width="96" Height="64" OnClick="RadButtonGüncelle_Click" Visible="False"></telerik:RadButton>
                                            <telerik:RadButton ID="RadButtonİptal" runat="server" ButtonType="LinkButton" Text="İptal"  Width="96" Height="64" OnClick="RadButtonİptal_Click" Visible="False"></telerik:RadButton>
                                        </center>
                                </td>
                            </tr>
                        </table>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="RadPageViewDüzenleSil">
                    <div>
                        <telerik:RadGrid ID="RadGridKullanici" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="570" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnNeedDataSource="RadGridKullanici_NeedDataSource" OnItemCommand="RadGridKullanici_ItemCommand">
                            <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                            <MasterTableView NoMasterRecordsText="Kullanıcı bulunamadı." Width="100%" DataKeyNames="UrunOpsiyonTurKey">
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Delete" Text="Sil" UniqueName="Delete" ImageUrl="../../../Image/OtherImages/Stop.png" ConfirmText="Silmek istediğinizden emin misiniz?" ConfirmDialogType="RadWindow" ConfirmTitle="Sil" ButtonType="ImageButton" ConfirmDialogHeight="25px">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridButtonColumn CommandName="Update" Text="Düzenle" UniqueName="Update" ImageUrl="../../../Image/OtherImages/Upload.png" ButtonType="ImageButton">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn runat="server" HeaderText="Opsiyon" DataField="UrunOpsiyonAd">
                                        <HeaderStyle Width="800px" />
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
