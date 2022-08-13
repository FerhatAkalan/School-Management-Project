<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanProfil.aspx.cs" Inherits="OkulOtomasyonu.DanismanProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-group col-md-12">
        <div  class="form-group col-md-11">
            <asp:Label for="TextDanID" runat="server">Danışman Id</asp:Label>
            <asp:TextBox ID="TextDanID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <div class="form-group col-md-11">
            <asp:Label for="TextDanAd" runat="server">Danışman Adı</asp:Label>
            <asp:TextBox ID="TextDanAd" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextDanAd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextDanSoyad" runat="server">Danışman Soyadı</asp:Label>
            <asp:TextBox ID="TextDanSoyad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextDanSoyad" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextDanMail" runat="server">Danışman Mail</asp:Label>
            <asp:TextBox ID="TextDanMail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextDanMail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextDanTelefon" runat="server">Danışman Telefon</asp:Label>
            <asp:TextBox ID="TextDanTelefon" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextDanTelefon" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextDanKullaniciAdi" runat="server">Danışman Kullanıcı Adı</asp:Label>
            <asp:TextBox ID="TextDanKullaniciAdi" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="form-group col-md-11">
            <asp:Label for="TextDanSifre" runat="server">Danışman Şifre</asp:Label>
            <asp:TextBox ID="TextDanSifre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextDanSifre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11">
            <asp:Button runat="server" Text="Güncelle" CssClass="btn btn-primary" OnClick="Unnamed8_Click"/>
            <br />
            <div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
