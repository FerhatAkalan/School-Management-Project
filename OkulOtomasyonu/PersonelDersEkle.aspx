﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Personel.Master" AutoEventWireup="true" CodeBehind="PersonelDersEkle.aspx.cs" Inherits="OkulOtomasyonu.PersonelDersEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-group col-md-12">
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDersId" runat="server">Ders ID</asp:Label>
                <asp:TextBox ID="TextDersId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDersAd" runat="server">Ders Ad</asp:Label>
                <asp:TextBox ID="TextDersAd" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextDersAd" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />

        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDersKredi" runat="server">Ders Kredisi</asp:Label>
                <asp:TextBox ID="TextDersKredi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextDersKredi" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div>
            <div class="form-group col-md-6">
                <asp:Button runat="server" Text="Kaydet" CssClass="btn btn-info" OnClick="Unnamed4_Click" />
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>


</asp:Content>
