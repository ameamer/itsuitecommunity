'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_utenti_ricerca_utenti
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String98") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                Diagnostics.Debug.Write("Accesso admin consentito.")

                Dim errmsg As String = Request.QueryString("err")
                If errmsg IsNot String.Empty And errmsg IsNot Nothing And errmsg <> "" Then
                    Select Case errmsg
                        Case "nonmbr"
                            ErrorMsg.Visible = True
                            ErrorMsg.Text = globals.ResourceHelper.GetString("String483")
                            ScriptLabel.Text = "<script type='text/javascript'>HideLabel();</script>"
                    End Select
                End If

            Case Else
                Response.Redirect("../logout.aspx")
        End Select
    End Sub

End Class
