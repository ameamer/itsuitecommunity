'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class assistenza_prodotti_nuova_assistenza
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()
    Public tipo As String
    Public pc As String
    Public stmp As String
    Public altrohw As String
    Public body As String
    Public intest As String
    Public isempty As Boolean = False

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String757") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                    Exit Sub
                End If

            Case "personale"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                    Exit Sub
                Else
                    If Session("abilita_utenti_stpers_ass") <> "1" Then
                        Response.Redirect("../logout.aspx")
                        Exit Sub
                    End If
                End If

            Case Else
                Response.Redirect("../logout.aspx")
                Exit Sub
        End Select

        Dim qry As String = Request.QueryString("err")
        tipo = ""
        pc = ""
        stmp = ""
        altrohw = ""
        intest = ""

        Select Case qry
            Case "emptyfields"
                isempty = True
                ErrorMsg.Text = globals.ResourceHelper.GetString("String163")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                intest = Request.Form("intest")
                body = Request.Form("body")
            Case "notype"
                isempty = True
                ErrorMsg.Text = globals.ResourceHelper.GetString("String758")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                intest = Request.Form("intest")
                body = Request.Form("body")
        End Select

    End Sub

End Class
