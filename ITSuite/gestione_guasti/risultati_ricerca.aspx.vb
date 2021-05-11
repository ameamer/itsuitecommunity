'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_guasti_risultati_ricerca
    Inherits System.Web.UI.Page

    Public terminericerca As String
    Public tiporicerca As String
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String253") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        terminericerca = Request.Form("schterm").ToString
        tiporicerca = Request.Form("typsearch").ToString

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If

                Select Case tiporicerca
                    Case "only"
                        If Not IsNumeric(terminericerca) Then
                            Response.Redirect("ricerca_guasto.aspx?err=nonmbr")
                            Exit Sub
                        Else
                            TicketSearchSQL.SelectCommand = "SELECT [ID], [data], [ora], [intestazione], [autore_apertura], [autore_dettagli1], [dettagli1], [stato] FROM [guasti] WHERE ([ID] = @ID)"
                        End If

                    Case "free"
                        If Not IsNumeric(terminericerca) Then
                            FreeSearchSQL.SelectCommand = "SELECT * FROM [guasti] WHERE (([autore_apertura] LIKE '%' + @autore_apertura + '%') OR ([utente] LIKE '%' + @utente + '%') OR ([autore_dettagli1] LIKE '%' + @autore_dettagli1 + '%') OR ([autore_dettagli2] LIKE '%' + @autore_dettagli2 + '%') OR ([autore_dettagli3] LIKE '%' + @autore_dettagli3 + '%') OR ([autore_dettagli4] LIKE '%' + @autore_dettagli4 + '%') OR ([autore_dettagli5] LIKE '%' + @autore_dettagli5 + '%') OR ([autorechiusura] LIKE '%' + @autorechiusura + '%') OR ([corpo] LIKE '%' + @corpo + '%') OR ([data] LIKE '%' + @data + '%') OR ([datachiusura] LIKE '%' + @datachiusura + '%') OR ([dettagli1] LIKE '%' + @dettagli1 + '%') OR ([dettagli2] LIKE '%' + @dettagli2 + '%') OR ([dettagli3] LIKE '%' + @dettagli3 + '%') OR ([dettagli4] LIKE '%' + @dettagli4 + '%') OR ([dettagli5] LIKE '%' + @dettagli5 + '%') OR ([intestazione] LIKE '%' + @intestazione + '%') OR ([motivo] LIKE '%' + @motivo + '%') OR ([motivoattesa] LIKE '%' + @motivoattesa + '%') OR ([ora] LIKE '%' + @ora + '%') OR ([padiglione] LIKE '%' + @padiglione + '%') OR ([presidio] LIKE '%' + @presidio + '%') OR ([reparto] LIKE '%' + @reparto + '%') OR ([stato] LIKE '%' + @stato + '%') OR ([ubicazione_guasto] LIKE '%' + @ubicazione_guasto + '%'))"
                        Else
                            FreeSearchSQL.SelectCommand = "SELECT * FROM [guasti] WHERE (([autore_apertura] LIKE '%' + @autore_apertura + '%') OR  ([utente] LIKE '%' + @utente + '%') OR ([autore_dettagli1] LIKE '%' + @autore_dettagli1 + '%') OR ([autore_dettagli2] LIKE '%' + @autore_dettagli2 + '%') OR ([autore_dettagli3] LIKE '%' + @autore_dettagli3 + '%') OR ([autore_dettagli4] LIKE '%' + @autore_dettagli4 + '%') OR ([autore_dettagli5] LIKE '%' + @autore_dettagli5 + '%') OR ([autorechiusura] LIKE '%' + @autorechiusura + '%') OR ([corpo] LIKE '%' + @corpo + '%') OR ([data] LIKE '%' + @data + '%') OR ([datachiusura] LIKE '%' + @datachiusura + '%') OR ([dettagli1] LIKE '%' + @dettagli1 + '%') OR ([dettagli2] LIKE '%' + @dettagli2 + '%') OR ([dettagli3] LIKE '%' + @dettagli3 + '%') OR ([dettagli4] LIKE '%' + @dettagli4 + '%') OR ([dettagli5] LIKE '%' + @dettagli5 + '%') OR ([intestazione] LIKE '%' + @intestazione + '%') OR ([motivo] LIKE '%' + @motivo + '%') OR ([motivoattesa] LIKE '%' + @motivoattesa + '%') OR ([ora] LIKE '%' + @ora + '%') OR ([padiglione] LIKE '%' + @padiglione + '%') OR ([presidio] LIKE '%' + @presidio + '%') OR ([reparto] LIKE '%' + @reparto + '%') OR ([stato] LIKE '%' + @stato + '%') OR ([ubicazione_guasto] LIKE '%' + @ubicazione_guasto + '%') OR ([ID] LIKE '%' + @ID + '%'))"
                        End If
                End Select

                FreeSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                TicketSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()

            Case "personale"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If
                FreeSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                TicketSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                FreeSearchSQL.SelectCommand = "SELECT * FROM [guasti] WHERE (([autore_apertura] LIKE '%' + @autore_apertura + '%') OR ([utente] LIKE '%' + @utente + '%') OR ([autore_dettagli1] LIKE '%' + @autore_dettagli1 + '%') OR ([autore_dettagli2] LIKE '%' + @autore_dettagli2 + '%') OR ([autore_dettagli3] LIKE '%' + @autore_dettagli3 + '%') OR ([autore_dettagli4] LIKE '%' + @autore_dettagli4 + '%') OR ([autore_dettagli5] LIKE '%' + @autore_dettagli5 + '%') OR ([autorechiusura] LIKE '%' + @autorechiusura + '%') OR ([corpo] LIKE '%' + @corpo + '%') OR ([data] LIKE '%' + @data + '%') OR ([datachiusura] LIKE '%' + @datachiusura + '%') OR ([dettagli1] LIKE '%' + @dettagli1 + '%') OR ([dettagli2] LIKE '%' + @dettagli2 + '%') OR ([dettagli3] LIKE '%' + @dettagli3 + '%') OR ([dettagli4] LIKE '%' + @dettagli4 + '%') OR ([dettagli5] LIKE '%' + @dettagli5 + '%') OR ([intestazione] LIKE '%' + @intestazione + '%') OR ([motivo] LIKE '%' + @motivo + '%') OR ([motivoattesa] LIKE '%' + @motivoattesa + '%') OR ([ora] LIKE '%' + @ora + '%') OR ([padiglione] LIKE '%' + @padiglione + '%') OR ([presidio] LIKE '%' + @presidio + '%') OR ([reparto] LIKE '%' + @reparto + '%') OR ([stato] LIKE '%' + @stato + '%') OR ([ubicazione_guasto] LIKE '%' + @ubicazione_guasto + '%') OR ([ID] LIKE '%' + @ID + '%')) AND ([dettagli1] ='" & Session("username") & "')"
                TicketSearchSQL.SelectCommand = "SELECT [ID], [data], [ora], [intestazione], [autore_apertura], [autore_dettagli1], [dettagli1], [stato] FROM [guasti] WHERE ([ID] = @ID) AND ([dettagli1]='" & Session("username") & "')"

            Case Else
                Response.Redirect("../logout.aspx")
        End Select

    End Sub

End Class