'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_cambiaip_dhcp
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ' Imposto variabili pubbliche
    Public Shared wins, connessione As String

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
        wins = Request("wins")
        connessione = Request("connessione")

    End Sub

End Class
