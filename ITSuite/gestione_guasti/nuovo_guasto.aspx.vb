'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_guasti_nuovo_guasto
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public intest As String
    Public body As String
    Public reparto As String
    Public padiglione As String
    Public presidio As String
    Public ubicazione As String
    Public assegnazione_utente As String
    Public isempty As Boolean

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String22") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "1" Then
                    Diagnostics.Debug.WriteLine("Accesso admin")
                Else
                    Response.Redirect("../logout.aspx")
                End If
            Case "personale"
                If Session("abilita_gestione_guasti") = "1" Then
                    Diagnostics.Debug.WriteLine("Accesso tecnico ticketing")

                Else
                    Response.Redirect("../logout.aspx")
                End If
            Case "cliente"
                If Session("abilita_gestione_guasti") = "1" Then
                    Diagnostics.Debug.WriteLine("Accesso cliente")

                Else
                    Response.Redirect("../logout.aspx")
                End If
            Case Else
                Response.Redirect("../logout.aspx")
        End Select

        Dim qry As String = Request.QueryString("err")
        isempty = False

        Select Case qry
            Case "emptyfields"
                isempty = True
                ErrorMsg.Text = globals.ResourceHelper.GetString("String259")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                intest = Request.Form("intest")
                body = Request.Form("body")
                reparto = Request.Form("reparto")
                padiglione = Request.Form("padiglione")
                presidio = Request.Form("presidio")
                ubicazione = Request.Form("ubicazione")
                assegnazione_utente = Request.Form("assegnazione_utente")

            Case "requsrerr"
                isempty = True
                ErrorMsg.Text = globals.ResourceHelper.GetString("String260")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                intest = Request.Form("intest")
                body = Request.Form("body")
                reparto = Request.Form("reparto")
                padiglione = Request.Form("padiglione")
                presidio = Request.Form("presidio")
                ubicazione = Request.Form("ubicazione")
                assegnazione_utente = Request.Form("assegnazione_utente")

        End Select

    End Sub

End Class
