<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.Master" AutoEventWireup="true" CodeBehind="OgrenciDevamsizlikBilgisi.aspx.cs" Inherits="OkulOtomasyonu.OgrenciDevamsizlikBilgisi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table class="table table-bordered table-hover">

        <tr>
            <th scope="col">Devamsızlık Tarihi</th>
        </tr>

        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("DevamsizlikTarihi")%></td>
                       
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </tbody>
    </table>

</asp:Content>
