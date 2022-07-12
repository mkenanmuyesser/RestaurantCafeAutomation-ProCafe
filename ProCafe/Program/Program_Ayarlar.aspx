<%@ Page Title="" Language="C#" MasterPageFile="~/Program/Program.Master" AutoEventWireup="true" CodeBehind="Program_Ayarlar.aspx.cs" Inherits="ProCafe.Program.Program_Ayarlar" %>

<%@ Import Namespace="ProCafe.Data" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMiddle" runat="server">
    <div>
        <br />
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="LabelGenelSirketAd" runat="server" Text="Şirket Adı"></asp:Label></td>
                <td>
                    <telerik:RadTextBox ID="RadTextBoxGenelSirketAd" runat="server" MaxLength="50"></telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="LabelGenelFaturaBilgi" runat="server" Text="Fatura Bilgisi"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="RadTextBoxGenelFaturaBilgi" runat="server" TextMode="MultiLine" Rows="4" MaxLength="500"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelGenelFaturaMesaj" runat="server" Text="Fatura Mesajı"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="RadTextBoxGenelFaturaMesaj" runat="server" TextMode="MultiLine" Rows="4" MaxLength="500"></telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="LabelGenelSirketLogo" runat="server" Text="Şirket Logosu"></asp:Label>
                </td>
                <td>
                    <telerik:RadAsyncUpload ID="RadAsyncUploadGenelSirketLogo" runat="server" MaxFileInputsCount="1">
                        <Localization Remove="Sil" Select="Seç" Cancel="İptal" DropZone="Sürükle"></Localization>
                        <FileFilters>
                            <telerik:FileFilter Description="Resimler(jpeg;jpg;gif;bmp)" Extensions="jpeg,jpg,gif,bmp" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelGenelMutfakKullanimi" runat="server" Text="Mutfak Kullanımı"></asp:Label></td>
                <td>
                    <asp:CheckBox ID="CheckBoxGenelMutfakKullanimi" runat="server" />
                </td>
                <td>
                    <asp:Label ID="LabelGenelKdvDahil" runat="server" Text="Kdv Dahil"></asp:Label></td>
                <td>
                    <asp:CheckBox ID="CheckBoxGenelKdvDahil" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelIndirimOran" runat="server" Text="İndirim Oranı"></asp:Label></td>
                <td>
                    <telerik:RadNumericTextBox ID="RadTextBoxIndirimOran" Type="Number" runat="server" MaxLength="3" MaxValue="100" MinValue="0">
                        <NumberFormat AllowRounding="false" DecimalDigits="0" ZeroPattern="n" />
                    </telerik:RadNumericTextBox>
                </td>
                <td>

                    <td></td>
            </tr>
            <tr>
                <td colspan="4">
                    <center>
                        <br/>
                        <telerik:RadButton ID="RadButtonKaydet" runat="server" ButtonType="LinkButton" Text="Kaydet"  Width="96" Height="64" OnClick="RadButtonKaydet_Click"></telerik:RadButton>                                    
                        <telerik:RadButton ID="RadButtonİptal" runat="server" ButtonType="LinkButton" Text="İptal"  Width="96" Height="64" OnClick="RadButtonİptal_Click" ></telerik:RadButton>
                    </center>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
