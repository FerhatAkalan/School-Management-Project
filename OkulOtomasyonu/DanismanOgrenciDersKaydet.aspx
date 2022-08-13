<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanOgrenciDersKaydet.aspx.cs" Inherits="OkulOtomasyonu.DanismanOgrenciDersKaydet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-group">
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDersAd" runat="server">Ders Adı</asp:Label>
                <asp:TextBox ID="TextDersAd" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextOgrenciNo" runat="server">Öğrenci Numara</asp:Label>
                <asp:DropDownList ID="drpOgrenciNo" runat="server"  CssClass="form-control"></asp:DropDownList>
                

            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpOgrenciNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

    </div>

    <div class="form-group col-md-12">
        <div>
            <asp:Button runat="server" Text="Kaydet" CssClass="btn btn-info" OnClick="Unnamed3_Click" />
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>


</asp:Content>
