﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanNotListesi.aspx.cs" Inherits="OkulOtomasyonu.DanismanNotListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    
     <table class="table table-bordered table-hover">

        <tr>
            <th scope="col">DERS ID</th>
            <th scope="col">DERS ADI</th>
            <th scope="col">KREDİ</th>
            <th scope="col">İŞLEMLER</th>   

        </tr>

        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("DersId")%></td>
                        <td><%#Eval("DersAd")%></td>
                        <td><%#Eval("DersKredi")%></td>


                        <td class="col-md-4">
                            <asp:HyperLink NavigateUrl='<%#"DanismanOgrenciNotGirisi.Aspx?DersId="+Eval("DersId") %>' ID="HyperLink2" runat="server" CssClass="btn btn-success">NOT GİRİŞİ</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </tbody>
    </table>
    
</asp:Content>
