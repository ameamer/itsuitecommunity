'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_stampanti_gestione_stampanti_lista
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String79") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        ' Imposto SQL
        SqlListaStampanti.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
        SqlListaStampanti.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLListaStampCommand()

        Dim t As String = Request.QueryString("t")
        Select Case t
            Case "del_ok"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String435")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                Exit Select
        End Select

    End Sub

    ''' <summary>
    ''' Si verifica all'inizializzazione del gestore delle impaginazioni.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DataPager1_Init(sender As Object, e As EventArgs)
        Dim pg As DataPager = DirectCast(sender, DataPager)
        pg.PageSize = Session("risultati_pag")
    End Sub

End Class
