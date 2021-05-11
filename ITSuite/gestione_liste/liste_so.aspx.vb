'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_liste_liste_so
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String268") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If
    End Sub

    Protected Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs)
        ' Iterate through the values to verify if they are not empty.
        For Each s As DictionaryEntry In e.Values
            If s.Value Is Nothing Then
                ErrorMsg.Text = globals.ResourceHelper.GetString("String286")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                e.Cancel = True
            End If
        Next
    End Sub
End Class
