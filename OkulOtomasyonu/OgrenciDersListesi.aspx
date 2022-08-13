<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.Master" AutoEventWireup="true" CodeBehind="OgrenciDersListesi.aspx.cs" Inherits="OkulOtomasyonu.OgrenciDersListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <table class="table table-bordered table-hover">

        <tr>
            <th scope="col">DERS ID</th>
            <th scope="col">DERS ADI</th>
            <th scope="col">KREDİ</th>
            

        </tr>

        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("DersId")%></td>
                        <td><%#Eval("DersAd")%></td>
                        <td><%#Eval("DersKredi")%></td>


                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </tbody>
    </table>

</asp:Content>
