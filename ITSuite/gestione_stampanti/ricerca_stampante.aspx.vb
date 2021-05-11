'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Data.OleDb

Partial Class gestione_stampanti_ricerca_stampante
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String80") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                Diagnostics.Debug.WriteLine("Accesso admin consentito.")

            Case "personale"
                If Session("abilita_utenti_stpers_mod") <> "1" Then
                    Response.Redirect("../logout.aspx")
                    Exit Sub
                End If

            Case Else
                Response.Redirect("../logout.aspx")
                Exit Sub
        End Select
    End Sub

    ''' <summary>
    ''' Avvia strumento di popolazione del selector ordinamento risultati.
    ''' </summary>
    ''' <returns></returns>
    Public Function OrderByResults() As Object
        Response.Write("<option value='id'>" & globals.ResourceHelper.GetString("String137") & "</option>")
        Response.Write("<option value='marca'>" & globals.ResourceHelper.GetString("String138") & "</option>")
        Response.Write("<option value='modello'>" & globals.ResourceHelper.GetString("String139") & "</option>")
        Response.Write("<option value='anno'>" & globals.ResourceHelper.GetString("String140") & "</option>")
        Response.Write("<option value='serie'>" & globals.ResourceHelper.GetString("String141") & "</option>")
        Return 0
    End Function


End Class
