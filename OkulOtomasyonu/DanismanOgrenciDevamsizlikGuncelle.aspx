﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanOgrenciDevamsizlikGuncelle.aspx.cs" Inherits="OkulOtomasyonu.DanismanOgrenciDevamsizlikGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="form-group col-md-12">
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDevId" runat="server">ID</asp:Label>
                <asp:TextBox ID="TextDevId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDevTarihi" runat="server">Devamsızlık Tarihi</asp:Label>
                <asp:TextBox ID="TextDevTarihi" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-11">
                <asp:Label for="TextDevDurum" runat="server">Devamsızlık Durumu</asp:Label>

                <asp:DropDownList ID="TextDevDurum" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Durum Seçiniz</asp:ListItem>
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" ControlToValidate="TextDevDurum" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group col-md-12">
            <div>
                <asp:Button runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="Unnamed4_Click" />
            </div>
            <div class="form-row col-md-12">
                <asp:Label ID="Label1" runat="server" Text="" CssClass="auto-style1"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
