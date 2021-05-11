'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_cambiarotte
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String516") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub

End Class
