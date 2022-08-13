<%@ Page Title="" Language="C#" MasterPageFile="~/Personel.Master" AutoEventWireup="true" CodeBehind="PersonelDanismanEkle.aspx.cs" Inherits="OkulOtomasyonu.PersonelDanismanEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-group col-md-12">
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDanismanId" runat="server">Danışman Numara</asp:Label>
                <asp:TextBox ID="TextDanismanId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-5">
                <asp:Label for="TextDanismanAd" runat="server">Danışman Ad</asp:Label>
                <asp:TextBox ID="TextDanismanAd" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextDanismanAd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-5">
                <asp:Label for="TextDanismanSoyad" runat="server">Danışman Soyad</asp:Label>
                <asp:TextBox ID="TextDanismanSoyad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextDanismanSoyad" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <br />
        <div>
            <div class="form-group col-md-11">
                <asp:Label for="TextDanismanBolum" runat="server">Danışman Bölüm</asp:Label>
                <asp:DropDownList ID="TextDanismanBolum" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Bölüm Seçiniz</asp:ListItem>
                    <asp:ListItem>Bilgisayar Mühendisliği</asp:ListItem>
                    <asp:ListItem>Yazılım Mühendisliği</asp:ListItem>
                    <asp:ListItem>Makine Mühendisliği</asp:ListItem>
                    <asp:ListItem>İnşaat Mühendisliği</asp:ListItem>
                    <asp:ListItem>Endüstri Mühendisliği</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" ControlToValidate="TextDanismanBolum" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-5">
                <asp:Label for="TextDanismanTelefon" runat="server">Danışman Telefon</asp:Label>
                <asp:TextBox ID="TextDanismanTelefon" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextDanismanTelefon" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-5">
                <asp:Label for="TextDanismanMail" runat="server">Danışman Mail</asp:Label>
                <asp:TextBox ID="TextDanismanMail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextDanismanMail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDanismanSifre" runat="server">Danışman Şifre</asp:Label>
                <asp:TextBox ID="TextDanismanSifre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextDanismanSifre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-group col-md-12">
            <div>
                <asp:Button runat="server" Text="Kaydet" CssClass="btn btn-info" OnClick="Unnamed8_Click" />
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
