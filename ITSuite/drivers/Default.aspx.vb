'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class drivers_Default
    Inherits System.Web.UI.Page

    Public Shared PathGen As String
    Public Shared devmodel As String
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String765") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        PathGen = Request("path")
        devmodel = Request("dev")

        Dim lbl As New Label
        lbl.Text = ""

        Try
            Dim files() As String = IO.Directory.GetFiles(HttpContext.Current.Request.PhysicalApplicationPath & "drivers\" & PathGen)
            For Each file As String In files
                Dim info As New System.IO.FileInfo(file)
                lbl.Text = lbl.Text & "<a href='" & HttpContext.Current.Request.Path & "..\..\..\drivers\" & PathGen & "\" & info.Name & "'>" & info.Name & "<br />"
            Next
        Catch ex As Exception
            lbl.Text = globals.ResourceHelper.GetString("String768") & "<b>" & PathGen & "</b>" & globals.ResourceHelper.GetString("String769")
        End Try

        GeneralPanel.Controls.Add(lbl)
    End Sub

End Class
