<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Kasa_Mutfak_User_Control.ascx.cs" Inherits="ProCafe.UserControl.Kasa_Mutfak_User_Control" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<script type="text/javascript">

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;//Will work in Moz in all cases, including clasic dialog
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
        return oWindow;
    }

    function CloseOnReload() {
        RefreshParentPage();
        GetRadWindow().Close();
    }

    function RefreshParentPage() {
        GetRadWindow().BrowserWindow.location = "../Program_Kasa_Islemleri.aspx";
    }

    function RadConfirmTamaminiOde(sender, args) {
        var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
            if (shouldSubmit) {
                this.click();
            }
        });

        var text = "Siparişi kapatmak istediğinize emin misiniz?";
        radconfirm(text, callBackFunction, 300, 160, null, "");
        args.set_cancel(true);
    }

    function RadConfirmSiparisIptal(sender, args) {
        var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
            if (shouldSubmit) {
                this.click();
            }
        });

        var text = "Siparişi iptal etmek istediğinize emin misiniz?";
        radconfirm(text, callBackFunction, 300, 160, null, "");
        args.set_cancel(true);
    }

    function RadConfirmUcretsizKapatma(sender, args) {
        var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
            if (shouldSubmit) {
                this.click();
            }
        });

        var text = "Siparişi ücretsiz kapatmak istediğinize emin misiniz?";
        radconfirm(text, callBackFunction, 300, 160, null, "");
        args.set_cancel(true);
    }

    function YesOrNoClicked(sender, args) {
        var oWnd = $find("<%= confirmWindow.ClientID %>");
        oWnd.close();
        if (sender.get_text() == "Yes") {
            $find("<%= RadButtonTamaminiOdeme.ClientID %>").click();
        }
    }

</script>
<style type="text/css">
    .ImageButtonSize {
        height: 36px;
        width: 36px;
    }
</style>
<div>
    <telerik:RadWindowManager runat="server" ID="RadWindowManagerProgram" EnableShadow="true"
        Behaviors="None" DestroyOnClose="true">
    </telerik:RadWindowManager>
    <telerik:RadWindow ID="confirmWindow" runat="server" VisibleTitlebar="false" VisibleStatusbar="false"
        Modal="true" Behaviors="None" Height="150px" Width="300px" Localization-OK="Evet" Localization-Cancel="Hayır" ReloadOnShow="true" Title=" " >
        <ContentTemplate>
            <div style="float: left; margin-top: 30px;">
                <div style="float: left; padding-left: 15px; width: 60px;">
                    <img src="img/ModalDialogAlert.gif" alt="Confirm Page" />
                </div>
                <div style="float: left; width: 200px;">
                    <asp:Label ID="lblConfirm" Font-Size="14px" Text="İşlemi yapmak istediğnizden emin misiniz?"
                        runat="server"></asp:Label>
                    <br />
                    <br />
                    <telerik:RadButton ID="btnYes" runat="server" Text="Evet" AutoPostBack="false" OnClientClicked=" YesOrNoClicked ">
                        <Icon PrimaryIconCssClass="rbOk"></Icon>
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnNo" runat="server" Text="Hayır" AutoPostBack="false" OnClientClicked=" YesOrNoClicked ">
                        <Icon PrimaryIconCssClass="rbCancel"></Icon>
                    </telerik:RadButton>
                </div>
            </div>
        </ContentTemplate>
    </telerik:RadWindow>
    <table>
        <tr>
            <td style="width: 150px;">
                <asp:RadioButtonList ID="RadioButtonListMutfakSunum" runat="server" RepeatDirection="Horizontal" Visible="False">
                    <asp:ListItem>Hepsi</asp:ListItem>
                    <asp:ListItem Selected="True">Mutfak</asp:ListItem>
                    <asp:ListItem>Sunum</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RadioButtonList ID="RadioButtonListOdenmeler" runat="server" RepeatDirection="Horizontal" Visible="False">
                    <asp:ListItem>Hepsi</asp:ListItem>
                    <asp:ListItem>Ödenenler</asp:ListItem>
                    <asp:ListItem Selected="True">Ödenmeyenler</asp:ListItem>
                    <asp:ListItem>İptaller</asp:ListItem>
                    <asp:ListItem>Ücretsizler</asp:ListItem>
                    <asp:ListItem>Parçalılar</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td style="width: 150px;">&nbsp;</td>
            <td style="width: 150px;">&nbsp;</td>
            <td style="width: 150px;">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
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
                <telerik:RadGrid ID="RadGridHesaplar" runat="server" AutoGenerateColumns="False" Font-Size="14" Font-Bold="True" Height="490" ClientSettings-Scrolling-AllowScroll="True" AllowMultiRowSelection="False" OnItemCommand="RadGridHesaplar_ItemCommand" OnItemDataBound="RadGridHesaplar_ItemDataBound" OnNeedDataSource="RadGridHesaplar_NeedDataSource">
                    <HeaderStyle Font-Size="12" HorizontalAlign="Center"></HeaderStyle>
                    <MasterTableView NoMasterRecordsText="Sipariş edilen ürün bulunamadı." Width="100%" DataKeyNames="SiparisKey">
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" Text="Seç" UniqueName="Select" ImageUrl="../Image/OtherImages/Select.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Deselect" Text="İptal" UniqueName="Deselect" ImageUrl="../Image/OtherImages/Back.png" ButtonType="ImageButton" ButtonCssClass="ImageButtonSize">
                            </telerik:GridButtonColumn>
                            <telerik:GridDateTimeColumn runat="server" HeaderText="Sipariş Tarihi" DataField="SiparisAlindiTarih" DataFormatString="{0:dd.MM.yyyy HH:mm}">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </telerik:GridDateTimeColumn>
                            <telerik:GridBoundColumn runat="server" HeaderText="Sipariş Türü">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn runat="server" HeaderText="Sipariş Durum">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn runat="server" HeaderText="Masa">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn runat="server" HeaderText="Siparişler">
                                <ItemTemplate>
                                    <asp:Repeater ID="RepeaterUrunler" runat="server" OnItemDataBound="RepeaterUrunler_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelSiparis" runat="server"><%# Eval("Urun.UrunAd") %></asp:Label>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="200"></ItemStyle>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn runat="server" HeaderText="Açıklama" DataField="SiparisAciklama">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn runat="server" HeaderText="Toplam Tutar" DataField="SiparisToplam" UniqueName="SiparisToplam">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn runat="server" HeaderText="Ödenen Tutar" DataField="SiparisOdenen" UniqueName="SiparisOdenen">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid></td>
        </tr>
        <tr>
            <td colspan="6">
                <table style="float: right;">
                    <asp:Panel ID="PanelKasa" runat="server" Visible="False">
                        <tr>
                            <td colspan="7" style="text-align: right;">Toplam:  
                                <asp:Label ID="LabelToplam" runat="server"></asp:Label>
                                --&nbsp;&nbsp;--                               
                                <asp:Label ID="LabelIndirimliToplam" runat="server" ForeColor="Red"></asp:Label>
                                <telerik:RadNumericTextBox ID="RadTextBoxGenelToplam" Type="Currency" runat="server" Enabled="False" MaxLength="10">
                                    <NumberFormat AllowRounding="false" DecimalDigits="2" ZeroPattern="n TL" DecimalSeparator="," />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadButton ID="RadButtonMutfakYazdir" runat="server" Text="MutfakYazdır" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonMutfakYazdir_Click"></telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonFisYazdir" runat="server" Text="FişYazdır" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonFisYazdir_Click"></telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonIndirimliOdeme" runat="server" Text="İndirimliÖdeme" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonIndirimliOdeme_Click" OnClientClicking=" RadConfirmTamaminiOde "></telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonTamaminiOdeme" runat="server" Text="TamamınıÖdeme" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonTamaminiOdeme_Click" OnClientClicking=" RadConfirmTamaminiOde "></telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonParcaliOdeme" runat="server" Text="ParçalıÖdeme" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonParcaliOdeme_Click"></telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonSiparisIptali" runat="server" Text="Siparişİptali" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonSiparisIptali_Click" OnClientClicking=" RadConfirmSiparisIptal "></telerik:RadButton>
                            </td>
                            <td>
                                <telerik:RadButton ID="RadButtonUcretsizKapatma" runat="server" Text="ÜcretsizKapatma" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonUcretsizKapatma_Click" OnClientClicking=" RadConfirmUcretsizKapatma "></telerik:RadButton>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelMutfak" runat="server" Visible="False">
                        <tr>
                            <td></td>
                            <td colspan="6">
                                <telerik:RadButton ID="RadButtonMutfakTeslim" runat="server" Text="MutfakTeslim" Width="96" Height="64" ButtonType="LinkButton" Enabled="False" OnClick="RadButtonMutfakTeslim_Click"></telerik:RadButton>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
    </table>
</div>
