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

Partial Class gestione_altro_hardware_risultati_ricerca_altro_hw
    Inherits System.Web.UI.Page

    Public inventario_hardware, anno_hardware, marca_hardware, tipo_hardware, stato_hardware, note_hardware, id_hardware, serie_hardware,
            presidio_hw, reparto_hw, padiglione_hw, ricgen_altro_hw, ip_hardware, modello_hardware, ordina_per, ordina_per_visualizzato,
            strSQL, pag, id_report As String
    Public pagecount As Integer
    Public conteggio As Integer
    Public risultati_pag As Integer
    Public globals As New ITSuite_Globalization()


    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

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

        inventario_hardware = Request("inventario_hardware")
        anno_hardware = Request("anno_hardware")
        marca_hardware = Request("marca_hardware")
        tipo_hardware = Request("tipo_hardware")
        stato_hardware = Request("stato_hardware")
        serie_hardware = Request("serie_hardware")
        id_hardware = Request("id_hardware")
        presidio_hw = Request("presidio_hw")
        reparto_hw = Request("reparto_hw")
        padiglione_hw = Request("padiglione_hw")
        ip_hardware = Request("ip_hardware")
        ricgen_altro_hw = Request("ricgen_altro_hw")
        modello_hardware = Request("modello_hardware")
        note_hardware = Request("note_hardware")

        'se cerca id aumento la precisione della ricerca
        Dim uguale_circa As String
        If id_hardware = "" Then
            uguale_circa = "AND (ID like '%"
            uguale_circa = uguale_circa & id_hardware & "%')"
        Else
            uguale_circa = "AND (ID ="
            uguale_circa = uguale_circa & id_hardware & ")"
        End If

        If ricgen_altro_hw <> "" Then
            strSQL = ""
            strSQL = strSQL & "Select * from datahardware where (inventario_hardware like '%" & ricgen_altro_hw & "%') OR (anno_hardware like '%" & ricgen_altro_hw & "%') "
            strSQL = strSQL & "OR (marca_hardware like '%" & ricgen_altro_hw & "%') OR (tipo_hardware like '%" & ricgen_altro_hw & "%') "
            strSQL = strSQL & "OR (stato_hardware like '%" & ricgen_altro_hw & "%') OR (serie_hardware like '%" & ricgen_altro_hw & "%') "
            strSQL = strSQL & "OR (modello_hardware like '%" & ricgen_altro_hw & "%') OR (note_hardware like '%" & ricgen_altro_hw & "%') "
            strSQL = strSQL & "OR (ID like '%" & ricgen_altro_hw & "%') OR (presidio_hw like '%" & ricgen_altro_hw & "%') OR (reparto_hw like '%" & ricgen_altro_hw & "%') "
            strSQL = strSQL & "OR (padiglione_hw like '%" & ricgen_altro_hw & "%') OR (ip_hardware like '%" & ricgen_altro_hw & "%') order by " & ordina_per & " asc"
        Else
            strSQL = ""
            strSQL = strSQL & "Select * from datahardware where (inventario_hardware like '%" & inventario_hardware & "%') AND (anno_hardware like '%" & anno_hardware & "%') "
            strSQL = strSQL & "AND (marca_hardware like '%" & marca_hardware & "%') AND (tipo_hardware like '%" & tipo_hardware & "%') "
            strSQL = strSQL & "AND (stato_hardware like '%" & stato_hardware & "%') AND (serie_hardware like '%" & serie_hardware & "%') "
            strSQL = strSQL & "AND (modello_hardware like '%" & modello_hardware & "%')  AND (note_hardware like '%" & note_hardware & "%') "
            strSQL = strSQL & "AND (ID like '%" & id_hardware & "%') AND (presidio_hw like '%" & presidio_hw & "%') AND (reparto_hw like '%" & reparto_hw & "%') "
            strSQL = strSQL & "AND (padiglione_hw like '%" & padiglione_hw & "%') AND (ip_hardware like '%" & ip_hardware & "%') order by " & ordina_per & " asc"
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
            sb.Append("<table class=""ricerca-pc-tab"" onclick=""location.href='dettagli_altro_hw.aspx?id_hw=" & read.Item("ID").ToString & "';""><tr><td class='ricerca-pc-tab-td-id'><div class=""ricerca-pc-tab-div-value"">" & read.Item("ID").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("marca_hardware").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("modello_hardware").ToString & "</div></td><td <td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("anno_hardware").ToString & "</div></td><td class=""ricerca-pc-tab-td""><div class=""ricerca-pc-tab-div-value"">" & read.Item("serie_hardware").ToString & "</div></td></tr></table>")
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
