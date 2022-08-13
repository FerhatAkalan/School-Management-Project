<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanOgrenciDevamsizlikGoruntule.aspx.cs" Inherits="OkulOtomasyonu.DanismanOgrenciDevamsizlikGoruntule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <table class="table table-bordered table-hover">

        <tr>
            <th scope="col">ID</th>
            <th scope="col">DEVAMSIZLIK TARİHİ</th>
            <th scope="col">DEVAMSIZLIK DURUMU</th>
            <th scope="col">İŞLEMLER</th>
            
            

        </tr>

        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("DevamsizId")%></td>
                        <td><%#Eval("DevamsizlikTarihi")%></td>
                        <td><%#Eval("DevamsizlikDurumu")%></td>
                        <td>
                            <asp:HyperLink ID="HyperLink3" NavigateUrl='<%#"~/DanismanOgrenciDevamsizlikGuncelle.aspx?DevamsizId="+Eval("DevamsizId") %>' runat="server" CssClass="btn btn-success">GÜNCELLE</asp:HyperLink>
                        </td>


                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </tbody>
    </table>


</asp:Content>
