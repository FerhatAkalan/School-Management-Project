<%@ Page Title="" Language="C#" MasterPageFile="~/Personel.Master" AutoEventWireup="true" CodeBehind="PersonelDanismanListesi.aspx.cs" Inherits="OkulOtomasyonu.PersonelDanismanListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

      <table class="table table-bordered table-hover">

        <tr>
            <th scope="col">ID</th>
            <th scope="col">AD</th>
            <th scope="col">SOYAD</th>
            <th scope="col">E-POSTA</th>
            <th scope="col">TELEFON</th>
            <th scope="col">BÖLÜM</th>
            <th scope="col">KULLANICI ADI</th>
            <th scope="col">ŞİFRE</th>
            <th scope="col">İŞLEMLER</th>
        </tr>

        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("DanismanId")%></td>
                        <td><%#Eval("DanismanAd")%></td>
                        <td><%#Eval("DanismanSoyad")%></td>
                        <td><%#Eval("DanismanMail")%></td>
                        <td><%#Eval("DanismanTelefon")%></td>
                        <td><%#Eval("DanismanBolum")%></td>
                        <td><%#Eval("KullaniciAdi")%></td>
                        <td><%#Eval("Sifre")%></td>
                        

                        <td>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"~/PersonelDanismanSil.aspx?KullaniciAdi="+Eval("KullaniciAdi") %>' runat="server" CssClass="btn btn-danger">SİL</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#"~/PersonelDanismanGuncelle.aspx?DanismanId="+Eval("DanismanId") %>' runat="server" CssClass="btn btn-success">GÜNCELLE</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink3" NavigateUrl='<%#"~/PersonelDanismanOgrenciListesi.aspx?DanismanId="+Eval("DanismanId") %>' runat="server" CssClass="btn btn-info">ÖĞRENCİLER</asp:HyperLink>

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>


</asp:Content>
