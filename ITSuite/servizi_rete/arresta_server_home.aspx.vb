'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_arresta_server_home
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Il sistema operativo selezionato ("vista", "xp").
    ''' </summary>
    Public Shared selectedOs As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String494") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If

        ' Ricavo i dati
        selectedOs = Request.QueryString("so")

        Select Case selectedOs
            Case "vista" ' Windows Vista +
                SubLabel.Text = globals.ResourceHelper.GetString("String495")
            Case "xp" ' Windows XP
                SubLabel.Text = globals.ResourceHelper.GetString("String496")
        End Select

    End Sub

End Class
