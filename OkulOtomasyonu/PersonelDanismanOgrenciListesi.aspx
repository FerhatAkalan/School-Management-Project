<%@ Page Title="" Language="C#" MasterPageFile="~/Personel.Master" AutoEventWireup="true" CodeBehind="PersonelDanismanOgrenciListesi.aspx.cs" Inherits="OkulOtomasyonu.PersonelDanismanOgrenciListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <table class="table table-bordered table-hover">
        <thead class="thead-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">NUMARA</th>
                <th scope="col">AD</th>
                <th scope="col">SOYAD</th>
                <th scope="col">E-POSTA</th>
                <th scope="col">TELEFON</th>
                <th scope="col">BÖLÜM</th>
                <th scope="col">SINIF</th>
    
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("OgrenciID")%></td>
                        <td><%#Eval("OgrenciNo")%></td>
                        <td><%#Eval("OgrenciAd")%></td>
                        <td><%#Eval("OgrenciSoyad")%></td>
                        <td><%#Eval("OgrenciMail")%></td>
                        <td><%#Eval("OgrenciTel")%></td>
                        <td><%#Eval("Bolum")%></td>
                 
                        <td><%#Eval("Sinif")%></td>

                       
                    </tr>
                </ItemTemplate>
            </asp:Repeater>


        </tbody>
    </table>

</asp:Content>
