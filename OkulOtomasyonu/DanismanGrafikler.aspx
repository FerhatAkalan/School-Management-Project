<%@ Page Title="" Language="C#" MasterPageFile="~/Danisman.Master" AutoEventWireup="true" CodeBehind="DanismanGrafikler.aspx.cs" Inherits="OkulOtomasyonu.DanismanGrafikler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <table class="table table-striped table-hover">
        <tr>
            <td>
                <asp:Chart ID="Chart1" runat="server" Height="400px" Width="500px" Palette="Pastel">
                    <Titles>
                        <asp:Title Text="Bölümlere Kayıtlı Öğrenci Sayısı"></asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Bölümler" ChartArea="ChartArea1" Legend="Bölümler">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX Title=""></AxisX>
                            <AxisY Title="Öğrenci Sayısı"></AxisY>
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Bölümler">
                        </asp:Legend>
                    </Legends>
                </asp:Chart>
            </td>
            <td>
                <asp:Chart ID="Chart2" runat="server" Height="400px" Width="500px">
                    <Titles>
                        <asp:Title Text="Öğrenci Cinsiyet Dağılımı"></asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Cinsiyet" ChartArea="ChartArea1" ChartType="Pie" Legend="Erkek" IsValueShownAsLabel="True">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Erkek">
                        </asp:Legend>
                        <asp:Legend Name="Kız">
                        </asp:Legend>
                    </Legends>
                </asp:Chart>
            </td>
        </tr>
    </table>
    <div class="form-group col-md-13">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    </div>
</asp:Content>


