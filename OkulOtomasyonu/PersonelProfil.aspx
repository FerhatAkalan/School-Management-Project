<%@ Page Title="" Language="C#" MasterPageFile="~/Personel.Master" AutoEventWireup="true" CodeBehind="PersonelProfil.aspx.cs" Inherits="OkulOtomasyonu.PersonelProfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="form-group col-md-12">

        <div  class="form-group col-md-11">
            <asp:Label for="TextPerID" runat="server">Personel Id</asp:Label>
            <asp:TextBox ID="TextPerID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <br />
        <div class="form-group col-md-11">
            <asp:Label for="TextPerAd" runat="server">Personel Adı</asp:Label>
            <asp:TextBox ID="TextPerAd" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextPerAd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-group col-md-11"">
            <asp:Label for="TextPerSoyad" runat="server">Personel Soyadı</asp:Label>
            <asp:TextBox ID="TextPerSoyad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextPerSoyad" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-group col-md-11"">
            <asp:Label for="TextPerMail" runat="server">Personel Mail</asp:Label>
            <asp:TextBox ID="TextPerMail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextPerMail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-group col-md-11"">
            <asp:Label for="TextPerTelefon" runat="server">Personel Telefon</asp:Label>
            <asp:TextBox ID="TextPerTelefon" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextPerTelefon" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-group col-md-11"">
            <asp:Label for="TextPerKullaniciAdi" runat="server">Personel Kullanıcı Adı</asp:Label>
            <asp:TextBox ID="TextPerKullaniciAdi" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <br />
        <div class="form-group col-md-11">
            <asp:Label for="TextPerSifre" runat="server">Personel Şifre</asp:Label>
            <asp:TextBox ID="TextPerSifre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextPerSifre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-group col-md-11">
            <asp:Button runat="server" Text="Güncelle" CssClass="btn btn-primary" OnClick="Unnamed8_Click" />
            <br />
            <div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>

    </div>




</asp:Content>
