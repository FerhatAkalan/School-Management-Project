<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanOgrenciNotGirisi.aspx.cs" Inherits="OkulOtomasyonu.DanismanOgrenciNotGirisi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="form-group col-md-12">
        <table class="table table-bordered table-hover">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">DERS ID</th>
                    <th scope="col">ID</th>
                    <th scope="col">NUMARA</th>
                    <th scope="col">SINIF</th>
                    <th scope="col">AD</th>
                    <th scope="col">SOYAD</th>
                    <th scope="col">BÖLÜM</th>
                    <th scope="col">VİZE</th>
                    <th scope="col">FİNAL</th>
                    <th scope="col">NOT EKLE</th>


                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("DersID")%> </td>
                            <td><%#Eval("OgrenciID")%></td>
                            <td><%#Eval("OgrenciNo")%></td>
                            <td><%#Eval("Sinif")%></td>
                            <td><%#Eval("OgrenciAd")%></td>
                            <td><%#Eval("OgrenciSoyad")%></td>
                            <td><%#Eval("Bolum")%></td>
                            <td><%#Eval("DersVize")%></td>
                            <td><%#Eval("DersFinal")%></td>
                            <td>
                                <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# string.Format("~/DanismanOgrenciNotEkle.aspx?OgrenciID={0}&DersID={1}", HttpUtility.UrlEncode(Eval("OgrenciID").ToString()), HttpUtility.UrlEncode(Eval("DersID").ToString())) %>' runat="server" CssClass="btn btn-info">NOT EKLE</asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

</asp:Content>
