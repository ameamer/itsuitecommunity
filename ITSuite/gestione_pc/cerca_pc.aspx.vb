'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Data.SqlClient

Partial Class gestione_pc_cerca_pc
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public strSQL, ordina_per, ordina_per_visualizzato, id_pc, inserito_da, arca_pc, modello_pc, serie_pc, processore_pc, stato_pc,
        tipo_pc, nome_dominio_pc, inventario_pc, reparto_pc, stanza_pc, padiglione_pc, piano_pc, presidio_pc, so_pc, ram_pc,
        indirizzo_ip_pc, dominio_pc, marca_pc, swprivate_pc, data_ins_pc, ora_ins_pc, note_pc, anno_pc, selezione_video_pc, marca_video_pc,
        modello_video_pc, inventario_video_pc, serie_video_pc, anno_video_pc, stato_video_pc, totale, cartella_pc, pag, pagecount, id_report As String

    Public conteggio As Integer

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String363") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        ' Ordina_per
        ordina_per = Request("ordina_per")
        If ordina_per = "" Then ordina_per = Request.QueryString("ordina_per")
        If ordina_per = "id" Then ordina_per = "ID"
        If ordina_per = "inv" Then ordina_per = "inventario_pc"
        If ordina_per = "anno" Then ordina_per = "anno_pc"
        If ordina_per = "nom_pc" Then ordina_per = "nome_dominio_pc"
        If ordina_per = "ip" Then ordina_per = "indirizzo_ip_pc"
        Select Case ordina_per
            Case "id", "ID"
                ordina_per_visualizzato = "ID"
            Case "inventario_pc"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String124").ToLower()
            Case "anno_pc"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String131").ToLower()
            Case "nome_dominio_pc"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String366").ToLower()
            Case "indirizzo_ip_pc"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String130").ToLower()
        End Select

        ' Recupero dati immessi nel form (pc)
        marca_pc = Request("marca_pc")
        modello_pc = Request("modello_pc")
        serie_pc = Request("serie_pc")
        processore_pc = Request("processore_pc")
        stato_pc = Request("stato_pc")
        tipo_pc = Request("tipo_pc")
        nome_dominio_pc = Request("nome_dominio_pc")
        inventario_pc = Request("inventario_pc")
        reparto_pc = Request("reparto_pc")
        stanza_pc = Request("stanza_pc")
        padiglione_pc = Request("padiglione_pc")
        piano_pc = Request("piano_pc")
        presidio_pc = Request("presidio_pc")
        so_pc = Request("so_pc")
        ram_pc = Request("ram_pc")
        indirizzo_ip_pc = Request("indirizzo_ip_pc")
        swprivate_pc = Request("swprivate_pc")
        data_ins_pc = DateTime.Now()
        ora_ins_pc = DateTime.Now.ToLocalTime()
        note_pc = Request("note_pc")
        anno_pc = Request("anno_pc")
        id_pc = Request("id_pc")
        cartella_pc = Request("cartella_pc")
        dominio_pc = Request("dominio_pc")
        inserito_da = Request("inserito_da")

        ' Recupero dati immessi nel form (monitor)
        marca_video_pc = Request("marca_video_pc")
        inventario_video_pc = Request("inventario_video_pc")
        serie_video_pc = Request("serie_video_pc")
        anno_video_pc = Request("anno_video_pc")
        stato_video_pc = Request("stato_video_pc")
        modello_video_pc = Request("modello_video_pc")

        ' Recupero i dati della ricerca totale
        totale = Request("totale")

        ' Controllo se la ricerca è totale
        If totale <> "" Then
            strSQL = ""
            strSQL = strSQL & "Select * from datapc where (marca_pc like '%" & totale & "%') OR (modello_pc like '%" & totale & "%') OR (serie_pc like '%" & totale & "%') OR (processore_pc like '%" & totale & "%')"
            strSQL = strSQL & "OR (stato_pc like '%" & totale & "%') OR (tipo_pc like '%" & totale & "%') OR (nome_dominio_pc like '%" & totale & "%') OR (id like '%" & totale & "%')"
            strSQL = strSQL & "OR (inventario_pc like '%" & totale & "%') OR (reparto_pc like '%" & totale & "%') OR (stanza_pc like '%" & totale & "%') OR (padiglione_pc like '%" & totale & "%')"
            strSQL = strSQL & "OR (piano_pc like '%" & totale & "%') OR (presidio_pc like '%" & totale & "%') OR (so_pc like '%" & totale & "%') OR (ram_pc like '%" & totale & "%')"
            strSQL = strSQL & "OR (indirizzo_ip_pc like '%" & totale & "%') OR (swprivate_pc like '%" & totale & "%') OR (note_pc like '%" & totale & "%') OR (anno_pc like '%" & totale & "%')"
            strSQL = strSQL & "OR (marca_video_pc like '%" & totale & "%') OR (inventario_video_pc like '%" & totale & "%') OR (serie_video_pc like '%" & totale & "%') OR (dominio_pc like '%" & totale & "%')"
            strSQL = strSQL & "OR (stato_video_pc like '%" & totale & "%') OR (anno_video_pc like '%" & totale & "%') OR (modello_video_pc like '%" & totale & "%') OR (cartella_pc like '%" & totale & "%') OR (inserito_da like '%" & totale & "%') order by " & ordina_per & " asc"
        Else
            strSQL = ""
            strSQL = strSQL & "Select * from datapc where (marca_pc like '%" & marca_pc & "%') AND (modello_pc like '%" & modello_pc & "%') AND (serie_pc like '%" & serie_pc & "%') AND (processore_pc like '%" & processore_pc & "%')"
            strSQL = strSQL & "AND (stato_pc like '%" & stato_pc & "%') AND (tipo_pc like '%" & tipo_pc & "%') AND (nome_dominio_pc like '%" & nome_dominio_pc & "%') AND (ID like '%" & id_pc & "%')"
            strSQL = strSQL & "AND (inventario_pc like '%" & inventario_pc & "%') AND (reparto_pc like '%" & reparto_pc & "%') AND (stanza_pc like '%" & stanza_pc & "%') AND (padiglione_pc like '%" & padiglione_pc & "%')"
            strSQL = strSQL & "AND (piano_pc like '%" & piano_pc & "%') AND (presidio_pc like '%" & presidio_pc & "%') AND (so_pc like '%" & so_pc & "%') AND (ram_pc like '%" & ram_pc & "%') AND (dominio_pc like '%" & dominio_pc & "%')"
            strSQL = strSQL & "AND (indirizzo_ip_pc like '%" & indirizzo_ip_pc & "%') AND (swprivate_pc like '%" & swprivate_pc & "%') AND (note_pc like '%" & note_pc & "%') AND (anno_pc like '%" & anno_pc & "%') AND (inserito_da like '%" & inserito_da & "%')"

            ' Controllo se devo cercare anche il monitor
            If (marca_video_pc <> "") Or (inventario_video_pc <> "") Or (serie_video_pc <> "") Or (stato_video_pc <> "") Or (anno_video_pc <> "") Or (modello_video_pc <> "") Then
                strSQL = strSQL & "AND (marca_video_pc like '%" & marca_video_pc & "%') AND (inventario_video_pc like '%" & inventario_video_pc & "%') AND (serie_video_pc like '%" & serie_video_pc & "%')"
                strSQL = strSQL & "AND (stato_video_pc like '%" & stato_video_pc & "%') AND (anno_video_pc like '%" & anno_video_pc & "%') AND (modello_video_pc like '%" & modello_video_pc & "%') order by " & ordina_per & " asc"
            Else
                strSQL = strSQL & " order by " & ordina_per & " asc"
            End If
        End If

        Dim lbl As New Label

        ' Conto i risultati e imposto valori per il report
        conteggio = 0
        id_report = ""

        Dim sb As New System.Text.StringBuilder()
        sb.Append("<table class='ricerca-pc-tab-intest'><tr><td class='ricerca-pc-tab-td-id'>ID</td><td class='ricerca-pc-tab-td'>" & globals.ResourceHelper.GetString("String120") & "</td><td class='ricerca-pc-tab-td'>" & globals.ResourceHelper.GetString("String122") & "</td><td class='ricerca-pc-tab-td'>" & globals.ResourceHelper.GetString("String131") & "</td><td class='ricerca-pc-tab-td'>" & globals.ResourceHelper.GetString("String123") & "</td></tr></table>")

        Dim qrytop As String = strSQL
        Dim DbPathtop As String, Conntop As SqlConnection
        DbPathtop = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()
            id_report = id_report & read.Item("ID").ToString & " "
            conteggio = conteggio + 1
            sb.Append("<table class=""ricerca-pc-tab"" onclick=""location.href='dettagli_pc.aspx?id_pc=" & read.Item("ID").ToString & "';""><tr><td class='ricerca-pc-tab-td-id'><div class=""ricerca-pc-tab-div-value"">" & read.Item("ID").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("marca_pc").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("modello_pc").ToString & "</div></td><td <td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("anno_pc").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("serie_pc").ToString & "</div></td></tr></table>")
        End While
        If conteggio = 0 Then
            sb.Clear()
            sb.Append("<b> " & globals.ResourceHelper.GetString("String160") & "</b>")
        End If
        Conntop.Close()
        Conntop.Dispose()
        read.Close()
        cmdtop.Dispose()

        lbl.Text = sb.ToString
        searchList.Controls.Add(lbl)
    End Sub


End Class
