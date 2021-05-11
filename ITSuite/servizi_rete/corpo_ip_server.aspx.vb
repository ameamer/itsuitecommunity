'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_corpo_ip_server
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public Shared hostpc, connessione, ind, submask, gwy, dns1, dns2, wins, utente, password, dhcp, strHost, so As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ttl.Text = globals.ResourceHelper.GetString("String534") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If

        ' Ricavo i dati
        so = Request.QueryString("so")
        Select Case so
            Case "vista"
                Session("soselezionatoserver") = globals.ResourceHelper.GetString("String532")
            Case "xp"
                Session("soselezionatoserver") = globals.ResourceHelper.GetString("String533")
        End Select

        hostpc = Request.Form("hostpc")
        ind = request.form("ip")
        gwy = request.form("gwy")
        submask = request.form("submask")
        dns1 = request.form("dns1")
        dns2 = request.form("dns2")
        wins = request.form("wins")
        connessione = request.form("connessione")
        dhcp = request.form("dhcp")
        utente = request.form("utente")
        password = Request.Form("password")

        strHost = ind
    End Sub

End Class
