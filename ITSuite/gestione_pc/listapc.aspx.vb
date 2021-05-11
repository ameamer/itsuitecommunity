'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_pc_listapc
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String74") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                SQLListaPC.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True"
                SQLListaPC.SelectCommand = "SELECT [Id], [marca_pc], [modello_pc], [serie_pc], [inventario_pc] FROM [datapc] ORDER BY [Id] DESC"
                Diagnostics.Debug.WriteLine("Accesso admin consentito.")

            Case "personale"
                If Session("abilita_utenti_stpers_mod") <> "1" Then
                    Response.Redirect("../logout.aspx")
                    Exit Sub
                Else
                    SQLListaPC.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True"
                    SQLListaPC.SelectCommand = "SELECT [Id], [marca_pc], [modello_pc], [serie_pc], [inventario_pc] FROM [datapc] ORDER BY [Id] DESC"
                End If

            Case Else
                Response.Redirect("../logout.aspx")
                Exit Sub
        End Select

        Dim t As String = Request.QueryString("t")
        Select Case t
            Case "del_ok"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String408")
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
