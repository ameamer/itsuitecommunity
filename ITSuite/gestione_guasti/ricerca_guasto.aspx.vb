'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_utenti_ricerca_guasto
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String87") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If

            Case "personale"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If

            Case Else
                Response.Redirect("../logout.aspx")
        End Select

        Dim errmsg As String = Request.QueryString("err")
        If errmsg IsNot String.Empty And errmsg IsNot Nothing And errmsg <> "" Then
            Select Case errmsg
                Case "nonmbr"
                    ErrorMsg.Visible = True
                    ErrorMsg.Text = globals.ResourceHelper.GetString("String252")
                    ScriptLabel.Text = "<script type='text/javascript'>HideLabel();</script>"
            End Select
        End If

    End Sub

End Class
