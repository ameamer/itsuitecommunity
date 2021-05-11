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

Partial Class gestione_stampanti_risultati_ricerca_stampanti
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public totale, inventario_stampante, modello_stampante,
        marca_stampante, anno_stampante, id_stampante, ordina_per, strSQL, pag,
        stato_stampante, numero_serie_stampante, presidio_stampante, ordina_per_visualizzato,
        padiglione_stampante, reparto_stampante, ip_stampante, ricgen_stampante, pagecount, id_report As String
    Public conteggio As Integer
    Public risultati_pag As Integer

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String181") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        ' Risultati pagina
        risultati_pag = CInt(Session("risultati_pag"))

        ordina_per = Request("ordina_per")
        If ordina_per = "" Then ordina_per = Request.QueryString("ordina_per")
        If ordina_per = "id" Then ordina_per = "ID"
        If ordina_per = "marca" Then ordina_per = "marca_stampante"
        If ordina_per = "modello" Then ordina_per = "modello_stampante"
        If ordina_per = "anno" Then ordina_per = "anno_stampante"
        If ordina_per = "serie" Then ordina_per = "numero_serie_stampante"
        Select Case ordina_per
            Case "id", "ID"
                ordina_per_visualizzato = "ID"
            Case "marca"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String120").ToLower()
            Case "modello"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String122").ToLower()
            Case "anno"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String131").ToLower()
            Case "serie"
                ordina_per_visualizzato = globals.ResourceHelper.GetString("String123").ToLower()
        End Select

        inventario_stampante = Request("inventario_stampante")
        marca_stampante = Request("marca_stampante")
        modello_stampante = Request("modello_stampante")
        anno_stampante = Request("anno_stampante")
        id_stampante = Request("id_stampante")
        stato_stampante = Request("stato_stampante")
        numero_serie_stampante = Request("numero_serie_stampante")
        presidio_stampante = Request("presidio_stampante")
        reparto_stampante = Request("reparto_stampante")
        padiglione_stampante = Request("padiglione_stampante")
        ip_stampante = Request("ip_stampante")
        ricgen_stampante = Request("ricgen_stampante")

        'se cerca id aumento la precisione della ricerca
        Dim uguale_circa As String
        If id_stampante = "" Then
            uguale_circa = "AND (ID like '%"
            uguale_circa = uguale_circa & id_stampante & "%')"
        Else
            uguale_circa = "AND (ID ="
            uguale_circa = uguale_circa & id_stampante & ")"
        End If

        If ricgen_stampante <> "" Then
            strSQL = ""
            strSQL = strSQL & "Select * from stampanti where (inventario_stampante like '%" & ricgen_stampante & "%') OR (numero_serie_stampante like '%" & ricgen_stampante & "%') "
            strSQL = strSQL & "OR (marca_stampante like '%" & ricgen_stampante & "%') OR (modello_stampante like '%" & ricgen_stampante & "%') "
            strSQL = strSQL & "OR (presidio_stampante like '%" & ricgen_stampante & "%') OR (padiglione_stampante like '%" & ricgen_stampante & "%') OR (reparto_stampante like '%" & ricgen_stampante & "%') "
            strSQL = strSQL & "OR (anno_stampante like '%" & ricgen_stampante & "%') OR (ID like '%" & ricgen_stampante & "%') OR (stato_stampante like '%" & ricgen_stampante & "%') OR (ip_stampante like '%" & ricgen_stampante & "%') order by " & ordina_per & " asc"
        Else
            strSQL = ""
            strSQL = strSQL & "Select * from stampanti where (inventario_stampante like '%" & inventario_stampante & "%') AND (numero_serie_stampante like '%" & numero_serie_stampante & "%') "
            strSQL = strSQL & "AND (marca_stampante like '%" & marca_stampante & "%') AND (modello_stampante like '%" & modello_stampante & "%') "
            strSQL = strSQL & "AND (presidio_stampante like '%" & presidio_stampante & "%') AND (padiglione_stampante like '%" & padiglione_stampante & "%') AND (reparto_stampante like '%" & reparto_stampante & "%') "
            strSQL = strSQL & "AND (anno_stampante like '%" & anno_stampante & "%') " & uguale_circa & " AND (stato_stampante like '%" & stato_stampante & "%') AND (ip_stampante like '%" & ip_stampante & "%') order by " & ordina_per & " asc"
        End If

        Dim lbl As New Label

        'conto i risultati
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
            sb.Append("<table class=""ricerca-pc-tab"" onclick=""location.href='dettagli_stampante.aspx?id_stampante=" & read.Item("ID").ToString & "';""><tr><td class='ricerca-pc-tab-td-id'><div class=""ricerca-pc-tab-div-value"">" & read.Item("ID").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("marca_stampante").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("modello_stampante").ToString & "</div></td><td <td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("anno_stampante").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("numero_serie_stampante").ToString & "</div></td></tr></table>")
        End While
        If conteggio = 0 Then
            sb.Clear()
            sb.Append("<b>" & globals.ResourceHelper.GetString("String160") & "</b>")
        End If
        Conntop.Close()
        Conntop.Dispose()
        read.Close()
        cmdtop.Dispose()

        lbl.Text = sb.ToString
        searchList.Controls.Add(lbl)

    End Sub

End Class
