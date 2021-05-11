'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_info_server_exec
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ' Imposto variabili pubbliche
    Public Shared utente, password, ip_remoto, so As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ttl.Text = globals.ResourceHelper.GetString("String550") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If

        ' Valorizzo variabili pubbliche
        utente = Request("utente")
        password = Request("password")
        ip_remoto = Request("ip_remoto")

        ' Ricavo i dati
        so = Request.QueryString("so")
        Select Case so
            Case "vista"
                Session("soselezionatoserver") = globals.ResourceHelper.GetString("String532")
            Case "xp"
                Session("soselezionatoserver") = globals.ResourceHelper.GetString("String533")
        End Select
    End Sub

End Class
