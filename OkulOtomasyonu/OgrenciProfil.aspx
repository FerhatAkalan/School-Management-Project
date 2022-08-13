<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.Master" AutoEventWireup="true" CodeBehind="OgrenciProfil.aspx.cs" Inherits="OkulOtomasyonu.OgrenciProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <div class="form-group">
        <div class="form-group">
            <div class="form-row">
                <div class="form-group col-md-5">
                    <asp:Label for="TextOgrID" runat="server">Öğrenci Id</asp:Label>
                    <asp:TextBox ID="TextOgrID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label for="TextOgrDanisman" runat="server">Öğrenci Danışman</asp:Label>
                    <asp:TextBox ID="TextOgrDanisman" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div> 
            </div> 
         </div>
        
        <div class="form-group col-md-11">
            <asp:Label for="TextOgrAd" runat="server">Öğrenci Adı</asp:Label>
            <asp:TextBox ID="TextOgrAd" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextOgrAd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextOgrSoyad" runat="server">Öğrenci Soyadı</asp:Label>
            <asp:TextBox ID="TextOgrSoyad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextOgrSoyad" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextOgrMail" runat="server">Öğrenci Mail</asp:Label>
            <asp:TextBox ID="TextOgrMail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextOgrMail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextOgrTelefon" runat="server">Öğrenci Telefon</asp:Label>
            <asp:TextBox ID="TextOgrTelefon" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextOgrTelefon" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group col-md-11"">
            <asp:Label for="TextOgrKullaniciAdi" runat="server">Öğrenci Kullanıcı Adı</asp:Label>
            <asp:TextBox ID="TextOgrKullaniciAdi" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="form-group col-md-11">
            <asp:Label for="TextOgrSifre" runat="server">Öğrenci Şifre</asp:Label>
            <asp:TextBox ID="TextOgrSifre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextOgrSifre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
