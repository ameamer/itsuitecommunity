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

Partial Class gestione_pc_report_pc
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public id_report, conteggio As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String418") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        'taglio gli id per report
        id_report = Request("report")
        conteggio = 0
    End Sub

    Public Function StampReportPC() As Object

        Dim i As Integer, x As String()
        i = 0
        x = Split(id_report, " ")

        For i = 0 To UBound(x) - 1
            conteggio = conteggio + 1
            Dim qrytop As String = "Select * from datapc where ID = " & x(i) & " order by ID"
            Dim DbPathtop As String, Conntop As SqlConnection
            DbPathtop = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Conntop = New SqlConnection(connecttop)
            Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()

            While read.Read()
                Response.Write("<tr><td class=""cell-report-general-body"">" & read.Item("ID").ToString & "</td><td class=""cell-report-general-body"">" & read.Item("dominio_pc").ToString & "\" &
                             read.Item("nome_dominio_pc").ToString & "</td><td class=""cell-report-general-body"">" & read.Item("marca_pc").ToString & "</td><td class=""cell-report-general-body"">" &
                             read.Item("modello_pc").ToString & "</td><td Class=""cell-report-general-body"">" & read.Item("serie_pc").ToString & "</td> <td class=""cell-report-general-body"">" &
                             read.Item("inventario_pc").ToString & "</td><td class=""cell-report-general-body"">" & read.Item("reparto_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("stanza_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("piano_pc").ToString & "</td>" &
                      "<td Class=""cell-report-general-body"">" & read.Item("padiglione_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("presidio_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("so_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("ram_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("processore_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("indirizzo_ip_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("swprivate_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("stato_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("anno_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("tipo_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("note_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("marca_video_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("modello_video_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("pollici_video_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("inventario_video_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("serie_video_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("stato_video_pc").ToString & "</td>" &
                      "<td class=""cell-report-general-body"">" & read.Item("note_video_pc").ToString & "</td></tr>")
            End While

            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()

        Next

        Return 0
    End Function


End Class
