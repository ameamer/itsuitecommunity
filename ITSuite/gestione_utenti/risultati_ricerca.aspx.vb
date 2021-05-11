'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_utenti_risultati_ricerca
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
        Me.Title = globals.ResourceHelper.GetString("String181") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")

            Case "admin"
                terminericerca = Request.Form("schterm").ToString
                tiporicerca = Request.Form("typsearch").ToString

                Select Case tiporicerca
                    Case "only"
                        If Not IsNumeric(terminericerca) Then
                            Response.Redirect("ricerca_utenti.aspx?err=nonmbr")
                            Exit Sub
                        Else
                            IDUserSearchSQL.SelectCommand = "SELECT * FROM [Utenti] WHERE ([ID] = @ID)"
                        End If

                    Case "free"
                        If Not IsNumeric(terminericerca) Then
                            FreeUserSearchSQL.SelectCommand = "SELECT * FROM [Utenti] WHERE (([matricola_utente] LIKE '%' + @matricola_utente + '%') OR ([nomeutente] LIKE '%' + @nomeutente + '%') OR ([tipo_utente] LIKE '%' + @tipo_utente + '%') OR ([dettagli_utente] LIKE '%' + @dettagli_utente + '%') OR ([database_utente] LIKE '%' + @database_utente + '%') OR ([creato_da] LIKE '%' + @creato_da + '%') OR ([ubicazione_utente] LIKE '%' + @ubicazione_utente + '%') OR ([data_creazione_utente] LIKE '%' + @data_creazione_utente + '%') OR ([ora_creazione_utente] LIKE '%' + @ora_creazione_utente + '%') OR ([data_modifica] LIKE '%' + @data_modifica + '%') OR ([note_utente] LIKE '%' + @note_utente + '%') OR ([stato_utente] LIKE '%' + @stato_utente + '%') OR ([autore_modifica] LIKE '%' + @autore_modifica + '%') OR ([ora_modifica] LIKE '%' + @ora_modifica + '%') OR ([FileName] LIKE '%' + @FileName + '%') OR ([cognome] LIKE '%' + @cognome + '%') OR ([nome] LIKE '%' + @nome + '%') OR ([email] LIKE '%' + @email + '%'))"
                        Else
                            FreeUserSearchSQL.SelectCommand = "SELECT * FROM [Utenti] WHERE (([matricola_utente] LIKE '%' + @matricola_utente + '%') OR ([nomeutente] LIKE '%' + @nomeutente + '%') OR ([tipo_utente] LIKE '%' + @tipo_utente + '%') OR ([dettagli_utente] LIKE '%' + @dettagli_utente + '%') OR ([database_utente] LIKE '%' + @database_utente + '%') OR ([creato_da] LIKE '%' + @creato_da + '%') OR ([ubicazione_utente] LIKE '%' + @ubicazione_utente + '%') OR ([data_creazione_utente] LIKE '%' + @data_creazione_utente + '%') OR ([ora_creazione_utente] LIKE '%' + @ora_creazione_utente + '%') OR ([data_modifica] LIKE '%' + @data_modifica + '%') OR ([note_utente] LIKE '%' + @note_utente + '%') OR ([stato_utente] LIKE '%' + @stato_utente + '%') OR ([autore_modifica] LIKE '%' + @autore_modifica + '%') OR ([ora_modifica] LIKE '%' + @ora_modifica + '%') OR ([FileName] LIKE '%' + @FileName + '%') OR ([cognome] LIKE '%' + @cognome + '%') OR ([nome] LIKE '%' + @nome + '%') OR ([email] LIKE '%' + @email + '%') OR ([ID] LIKE '%' + @ID + '%'))"
                        End If
                End Select

                IDUserSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                FreeUserSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()

            Case Else
                Response.Redirect("../logout.aspx")

        End Select
    End Sub


End Class
