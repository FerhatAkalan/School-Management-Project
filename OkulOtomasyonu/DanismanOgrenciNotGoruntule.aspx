<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanOgrenciNotGoruntule.aspx.cs" Inherits="OkulOtomasyonu.DanismanOgrenciNotGoruntule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <table class="table table-bordered table-hover">
        <thead class="thead-dark">
            <tr>
                <th scope="col">DERS ID</th>
                <th scope="col">DERS AD</th>
                <th scope="col">DERS KREDİ</th>
                <th scope="col">DERS VİZE</th>
                <th scope="col">DERS FİNAL</th>
                <th scope="col">DERS NOTU</th>
                <th scope="col">DURUM</th>
                <th scope="col">İŞLEM</th>



            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("DersID")%></td>
                        <td><%#Eval("DersAd")%></td>
                        <td><%#Eval("DersKredi")%></td>
                        <td><%#Eval("DersVize")%></td>
                        <td><%#Eval("DersFinal")%></td>
                        <td><%#Eval("DersNotu")%></td>
                        <td><%#Eval("Durum")%></td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#"~/DanismanOgrenciNotGuncelle.aspx?NotId="+Eval("NotId") %>' runat="server" CssClass="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <td colspan="8">
                        <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </td>
                </FooterTemplate>
            </asp:Repeater>


        </tbody>
    </table>

</asp:Content>
