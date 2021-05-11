'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_winfirewall_server_exec
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ' Imposto variabili pubbliche
    Public Shared utente, password, ip_wfw, so, tipofw, tipofwtoshow, disattiva_wfw As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ttl.Text = globals.ResourceHelper.GetString("String587") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If

        ' Valorizzo variabili pubbliche
        utente = Request("utente")
        password = Request("password")
        ip_wfw = Request("ip_remoto")
        tipofw = Request("tipowinfirewall")
        disattiva_wfw = tipofw

        ' Imposto tipo di arresto
        Select Case tipofw
            Case "disattiva"
                tipofwtoshow = globals.ResourceHelper.GetString("String565")
            Case "attiva"
                tipofwtoshow = globals.ResourceHelper.GetString("String566")
            Case "disattiva_fw"
                tipofwtoshow = globals.ResourceHelper.GetString("String563")
            Case "attiva_fw"
                tipofwtoshow = globals.ResourceHelper.GetString("String562")
            Case "reset_fw"
                tipofwtoshow = globals.ResourceHelper.GetString("String564")
        End Select

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
