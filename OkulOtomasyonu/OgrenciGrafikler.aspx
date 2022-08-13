<%@ Page Title="" Language="C#" MasterPageFile="~/Ogrenci.Master" AutoEventWireup="true" CodeBehind="OgrenciGrafikler.aspx.cs" Inherits="OkulOtomasyonu.OgrenciGrafikler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <table class="nav-justified">
        <tr>
            <td>
                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="400px" Width="500px" Palette="Pastel">
                    <Series>
                        <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Notlar" YValuesPerPoint="6" XValueMember="DersAd" YValueMembers="DersNotu">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisY Title="Ders Not Ortalaması">
                            </AxisY>
                            <Area3DStyle LightStyle="Realistic" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Name="Titles1" Text="Öğrenci Ders Not Ortalamaları Grafiği">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OkulOtomasyonuConnectionString %>" SelectCommand="Select DersAd, DersNotu from Notlar Inner Join Ders ON Ders.DersID=Notlar.DersID Inner Join Ogrenci ON Ogrenci.OgrenciId=Notlar.OgrenciId where Ogrenci.OgrenciNo = @OgrenciNo">
                    <SelectParameters>
                        <asp:SessionParameter Name="OgrenciNo" SessionField="KullaniciAdi" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" Height="400px" Width="500px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie" XValueMember="Bolum" YValueMembers="ÖğrenciSayısı" IsValueShownAsLabel="True" Legend="Legend1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Name="Title1" Text="Bölümlere Göre Öğrenci Dağılım Grafiği">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OkulOtomasyonuConnectionString %>" SelectCommand="Select Bolum,Count(OgrenciID) as ÖğrenciSayısı from Ogrenci Group by Bolum"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <div class="form-group col-md-13">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    </div>


</asp:Content>
