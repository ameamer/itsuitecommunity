'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class assistenza_prodotti_risultati_ricerca
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public Shared terminericerca As String
    Public Shared tiporicerca As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String181") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        terminericerca = Request.Form("schterm").ToString
        tiporicerca = Request.Form("typsearch").ToString

        Select Case tiporicerca
            Case "only"
                If Not IsNumeric(terminericerca) Then
                    Response.Redirect("ricerca_assistenze.aspx?err=nonmbr")
                    Exit Sub
                Else
                    AssSearchSQL.SelectCommand = "SELECT [ID], [data_apertura], [ora_apertura], [autore_apertura], [intestazione_apertura], [stato] FROM [assistenzaprodotti] WHERE ([ID] = @ID)"
                End If

            Case "free"
                If Not IsNumeric(terminericerca) Then
                    AssFreeSearchSQL.SelectCommand = "SELECT * FROM [assistenzaprodotti] WHERE (([altra_ass] LIKE '%' + @altra_ass + '%') OR ([autore_apertura] LIKE '%' + @autore_apertura + '%') OR ([autore_chiusura] LIKE '%' + @autore_chiusura + '%') OR ([autore_dettagli1] LIKE '%' + @autore_dettagli1 + '%') OR ([data_apertura] LIKE '%' + @data_apertura + '%') OR ([data_chiusura] LIKE '%' + @data_chiusura + '%') OR ([dettagli_apertura] LIKE '%' + @dettagli_apertura + '%') OR ([dettagli_chiusura] LIKE '%' + @dettagli_chiusura + '%') OR ([dettagli1] LIKE '%' + @dettagli1 + '%') OR ([idaltrohw] LIKE '%' + @idaltrohw + '%') OR ([idpc] LIKE '%' + @idpc + '%') OR ([idstamp] LIKE '%' + @idstamp + '%') OR ([intestazione_apertura] LIKE '%' + @intestazione_apertura + '%') OR ([ora_apertura] LIKE '%' + @ora_apertura + '%') OR ([stato] LIKE '%' + @stato + '%'))"
                Else
                    AssFreeSearchSQL.SelectCommand = "SELECT * FROM [assistenzaprodotti] WHERE (([altra_ass] LIKE '%' + @altra_ass + '%') OR ([autore_apertura] LIKE '%' + @autore_apertura + '%') OR ([autore_chiusura] LIKE '%' + @autore_chiusura + '%') OR ([autore_dettagli1] LIKE '%' + @autore_dettagli1 + '%') OR ([data_apertura] LIKE '%' + @data_apertura + '%') OR ([data_chiusura] LIKE '%' + @data_chiusura + '%') OR ([dettagli_apertura] LIKE '%' + @dettagli_apertura + '%') OR ([dettagli_chiusura] LIKE '%' + @dettagli_chiusura + '%') OR ([dettagli1] LIKE '%' + @dettagli1 + '%') OR ([idaltrohw] LIKE '%' + @idaltrohw + '%') OR ([idpc] LIKE '%' + @idpc + '%') OR ([idstamp] LIKE '%' + @idstamp + '%') OR ([intestazione_apertura] LIKE '%' + @intestazione_apertura + '%') OR ([ora_apertura] LIKE '%' + @ora_apertura + '%') OR ([stato] LIKE '%' + @stato + '%') OR ([ID] LIKE '%' + @ID + '%'))"
                End If
        End Select

        AssSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
        AssFreeSearchSQL.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()

    End Sub

End Class
