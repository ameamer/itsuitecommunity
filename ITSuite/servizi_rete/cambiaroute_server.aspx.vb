'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_cambiaroute_server
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public Shared ind, gwy, submask, defin_route, utente, password, ip_remoto, so, perm_route As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ttl.Text = globals.ResourceHelper.GetString("String523") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        ind = Request.Form("ip")
        gwy = " " & Request.Form("gwy")
        submask = Request.Form("submask")
        perm_route = Request.Form("perm_route")
        utente = Request.Form("utente")
        password = Request.Form("password")
        ip_remoto = Request.Form("ip_remoto")
    End Sub

End Class
