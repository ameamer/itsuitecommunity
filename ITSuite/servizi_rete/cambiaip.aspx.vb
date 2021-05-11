'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_cambiaip
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ' Imposto variabili pubbliche
    Public Shared ind, gwy, submask, dns1, dns2, wins, connessione, dhcp As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ttl.Text = globals.ResourceHelper.GetString("String502") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If

        ' Valorizzo variabili pubbliche
        ind = Request.Form("ip")
        gwy = Request.Form("gwy")
        submask = Request.Form("submask")
        dns1 = Request.Form("dns1")
        dns2 = Request.Form("dns2")
        wins = Request.Form("wins")
        connessione = Request.Form("connessione")
        dhcp = Request.Form("dhcp")
    End Sub

End Class
