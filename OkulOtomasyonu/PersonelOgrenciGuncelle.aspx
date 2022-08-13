<%@ Page Title="" Language="C#" MasterPageFile="~/Personel.Master" AutoEventWireup="true" CodeBehind="PersonelOgrenciGuncelle.aspx.cs" Inherits="OkulOtomasyonu.Sidebar.PersonelOgrenciGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-group col-md-12">
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextOgrenciNo" runat="server">Öğrenci Numara</asp:Label>
                <asp:TextBox ID="TextOgrenciNo" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-5">
                <asp:Label for="TextOgrenciAd" runat="server">Öğrenci Adı</asp:Label>
                <asp:TextBox ID="TextOgrenciAd" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextOgrenciAd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-5">
                <asp:Label for="TextOgrenciSoyad" runat="server">Öğrenci Soyadı</asp:Label>
                <asp:TextBox ID="TextOgrenciSoyad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextOgrenciSoyad" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <br />
        <div>
            <div class="form-group col-md-11">
                <asp:Label for="TextOgrenciBolum" runat="server">Öğrenci Bölümü</asp:Label>
                <asp:DropDownList ID="TextOgrenciBolum" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Bölüm Seçiniz</asp:ListItem>
                    <asp:ListItem>Bilgisayar Mühendisliği</asp:ListItem>
                    <asp:ListItem>Yazılım Mühendisliği</asp:ListItem>
                    <asp:ListItem>Makine Mühendisliği</asp:ListItem>
                    <asp:ListItem>İnşaat Mühendisliği</asp:ListItem>
                    <asp:ListItem>Endüstri Mühendisliği</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" ControlToValidate="TextOgrenciBolum" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-5">
                <asp:Label for="TextOgrenciTelefon" runat="server">Öğrenci Telefon</asp:Label>
                <asp:TextBox ID="TextOgrenciTelefon" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextOgrenciTelefon" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-5">
                <asp:Label for="TextOgrenciMail" runat="server">Öğrenci Mail</asp:Label>
                <asp:TextBox ID="TextOgrenciMail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextOgrenciMail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-5">
                <asp:Label for="TextOgrenciSinif" runat="server">Öğrenci Sınıf</asp:Label>
                <asp:DropDownList ID="TextOgrenciSinif" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Sınıf Seçiniz</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="0" ControlToValidate="TextOgrenciSinif" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-5">
                <asp:Label for="TextOgrenciDanisman" runat="server">Öğrenci Danışman</asp:Label>
                <asp:DropDownList ID="drpDanisman" runat="server" DataSourceID="SqlDataSource1" DataTextField="DanismanAdSoyad" DataValueField="DanismanId" CssClass="form-control"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OkulOtomasyonuConnectionString %>" SelectCommand="SELECT *, DanismanAd + ' ' + DanismanSoyad + ' - ' + DanismanBolum as DanismanAdSoyad FROM [Danisman]"></asp:SqlDataSource>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpDanisman" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextOgrenciSifre" runat="server">Öğrenci Şifre</asp:Label>
                <asp:TextBox ID="TextOgrenciSifre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextOgrenciSifre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div  class="form-group col-md-12">
            <div>
                <asp:Button runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="Unnamed10_Click" />
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="" CssClass="auto-style1"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
