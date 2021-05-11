'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_guasti_gestione_guasti_inattesa
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String20") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If
                Dim t As String = Request.QueryString("t")
                Select Case t
                    Case "myr"
                        GuastiAttesaSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                        GuastiAttesaSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLGuastiAttesaCommandCliente()
                        LabelSubMenu.Text = "<b><a href=""gestione_guasti_inattesa.aspx"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String88") & "</a></b>&nbsp;|&nbsp;<b><a href=""gestione_guasti_inattesa.aspx?t=ges"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String236") & "</a></b>&nbsp;|&nbsp;<b><u>" & globals.ResourceHelper.GetString("String237") & "</u></b>"

                    Case "ges"
                        GuastiAttesaSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                        GuastiAttesaSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLGuastiAttesaCommandPersonale()
                        LabelSubMenu.Text = "<b><a href=""gestione_guasti_inattesa.aspx"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String88") & "</a></b>&nbsp;|&nbsp;<b><u>" & globals.ResourceHelper.GetString("String236") & "</u></b>&nbsp;|&nbsp;<b><a href=""gestione_guasti_inattesa.aspx?t=myr"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String237") & "</a></b>"

                    Case Else
                        GuastiAttesaSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                        GuastiAttesaSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLGuastiAttesaCommandAdmin()
                        LabelSubMenu.Text = "<b><u>" & globals.ResourceHelper.GetString("String88") & "</u></b>&nbsp;|&nbsp;<b><a href=""gestione_guasti_inattesa.aspx?t=ges"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String236") & "</a></b>&nbsp;|&nbsp;<b><a href=""gestione_guasti_inattesa.aspx?t=myr"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String237") & "</a></b>"
                End Select



            Case "personale"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If
                Dim t As String = Request.QueryString("t")
                Select Case t
                    Case "myr"
                        GuastiAttesaSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                        GuastiAttesaSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLGuastiAttesaCommandCliente()
                        LabelSubMenu.Text = "<b><a href=""gestione_guasti_inattesa.aspx"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String88") & "</a></b>&nbsp;|&nbsp;<b><a href=""gestione_guasti_inattesa.aspx?t=ges"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String236") & "</a></b>&nbsp;|&nbsp;<b><u>" & globals.ResourceHelper.GetString("String237") & "</u></b>"

                    Case Else
                        GuastiAttesaSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                        GuastiAttesaSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLGuastiAttesaCommandPersonale()
                        LabelSubMenu.Text = "<b><u>" & globals.ResourceHelper.GetString("String88") & "</u></b>&nbsp;|&nbsp;<b><a href=""gestione_guasti_inattesa.aspx?t=ges"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String236") & "</a></b>&nbsp;|&nbsp;<b><a href=""gestione_guasti_inattesa.aspx?t=myr"" style=""color:gray; text-decoration:underline;"">" & globals.ResourceHelper.GetString("String237") & "</a></b>"

                End Select



            Case "cliente"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If
                GuastiAttesaSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                GuastiAttesaSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLGuastiAttesaCommandCliente()
                LabelSubMenu.Text = "<b><u>" & globals.ResourceHelper.GetString("String237") & "</u></b>"

            Case Else
                Response.Redirect("../logout.aspx")
        End Select
    End Sub

    ''' <summary>
    ''' Autorefresh del pannello.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub AutoRefresh_Tick(sender As Object, e As EventArgs)
        ListViewGuasti.DataBind()
        LastUpdateLabel.Text = globals.ResourceHelper.GetString("String238") & DateTime.Now
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
