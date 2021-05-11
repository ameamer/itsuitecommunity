'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_telnet_exec
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public Shared ip_telnet, porta_telnet As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ttl.Text = globals.ResourceHelper.GetString("String571") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If

        ' Ricavo i dati
        ip_telnet = Request.Form("ind")
        porta_telnet = Request.Form("porta")
    End Sub

End Class
