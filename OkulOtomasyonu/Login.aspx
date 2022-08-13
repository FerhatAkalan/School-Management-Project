<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OkulOtomasyonu.Login" %>

<!doctype html>
<html lang="tr">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="LoginDosyası\assets\images\ico-01.png" type="image/x-icon" />
    <link href="LoginDosyası/assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="LoginDosyası/assets/css/font-awesome.min.css" rel="stylesheet">
    <link href="LoginDosyası/assets/css/style.css" rel="stylesheet">

    <title>Okul Otomasyonu</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-family: "Times New Roman";
        }

        <img src="LoginDosyası/assets/images/bg-01.jpg" / >
    </style>
</head>
<body>
    <section class="form-01-main">
        <div class="form-cover">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-sub-main">
                            <div>
                                <h2 class="auto-style1">Okul Bilgi Sistemine Hoşgeldiniz</h2>
                            </div>
                            <div class="_main_head_as">
                                <a href="#">
                                    <img src="LoginDosyası/assets/images/vector.png">
                                </a>
                            </div>
                            <form runat="server" autocomplete="off">

                                <div class="form-group">
                                    <asp:TextBox ID="TxtNumara" runat="server" class="form-control _ge_de_ol" type="text" placeholder="Kullanıcı Adı" required="" aria-required="true"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="TxtSifre" runat="server" type="password" class="form-control" name="password" placeholder="Şifre" required="required" TextMode="Password"></asp:TextBox>
                                    <i toggle="#TxtSifre" class="fa fa-fw fa-eye toggle-password field-icon"></i>
                                </div>

                                <div class="form-group">
                                    <div class="check_box_main">
                                        <a href="#" class="pas-text">Şifremi Unuttum</a>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="btn_uy">
                                        <asp:Button ID="Button2" runat="server" Text="Giriş Yap" CssClass="btn btn-success" Width="383px" OnClick="Button2_Click" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="" Style="color: #CC3300"></asp:Label>
                                </div>
                                <br />
                                <div>
                                    <p>Coded by Ferhat Akalan</p>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</body>
</html>
