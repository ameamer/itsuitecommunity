<%--
'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************
--%>

<%@ Page Title="Login | ITSuite by Ame Amer (admin@ameamer.com)" Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="it" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" type="text/css" href="Styles/general.css" />
    <title>ITSuite by Ame Amer</title>
    <script type="text/javascript">
        function AutoFocusOnLoad() {
            document.getElementById("nome_utente").focus();
        }
    </script>
</head>

<body onload="AutoFocusOnLoad();">

    <!-- Container generale -->
    <div class="container">

        <!-- Logo itsuite -->
        <div class="logo-div">
            <img src="img/itsuite_logo.png" style="border: 0px solid black;" />
        </div>

        <form method="post" style="box-sizing: border-box;" runat="server">

            <!-- Lingua -->
            <div class="lang-title">
                <asp:Label ID="LabelIta" runat="server" Visible="false"></asp:Label><asp:LinkButton ID="LinkITA" Visible="false" runat="server" OnClick="LinkITA_Click"></asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="LinkEN" Visible="false" runat="server" OnClick="LinkEN_Click"></asp:LinkButton><asp:Label ID="LabelEn" runat="server" Visible="false"></asp:Label>
            </div>

            <!-- Titolo -->
            <div class="center-title">
                <asp:Label runat="server" ID="LabelTitleLogin"></asp:Label>
            </div>

            <!-- Etichetta per eventuali messaggi di errore -->
            <div class="center-title">
                <asp:Label ForeColor="Red" Font-Size="Medium" Visible="false" runat="server" ID="ErrLabel"></asp:Label>
            </div>

            <!-- Box inserimento dati -->
            <div class="div-login">

                <div>
                    <asp:TextBox runat="server" name="nome_utente" ID="nome_utente" class="inputlogin" />
                </div>

                <div style="margin-top: 10px">
                    <asp:TextBox TextMode="Password" runat="server" name="password" class="inputlogin" ID="pswinput" Style="clear: left;" />
                </div>

                <div style="margin-top: 20px">
                    <asp:Button ID="LoginButton" CssClass="submit-button" runat="server" OnClick="LoginButton_Click" />
                </div>
            </div>

        </form>

        <!-- Logo Footer -->
        <div class="logo-div" style="margin-top: 30px">
            <a href="http://www.ameamer.com" target="_blank">
                <img src="img/logo_scritta_small.png" /></a>
            <br />
            <%=versionString%>
            <br />
            <a href="http://www.ameamer.com/itsuite" target="_blank"><%=editionString%></a> - <a href="https://opensource.org/licenses/bsd-license.php" target="_blank"><%=licenseString%></a>
            <br />
            <%=copyrightString%>&nbsp;<a href="http://www.ameamer.com" target="_blank">Ame Amer</a>
        </div>
    </div>

</body>
</html> 


