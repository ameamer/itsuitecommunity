'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_utenti_gestione_utenti_sistema
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String462") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If

        ' Imposto SQL
        UserSqlSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
        UserSqlSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLSysuserListCommand()

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
