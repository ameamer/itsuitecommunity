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

Partial Class gestione_altro_hardware_report_altro_hw
    Inherits System.Web.UI.Page

    Public conteggio, id_report As String
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String455") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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
        'conteggio
        conteggio = 0
    End Sub

    ''' <summary>
    ''' Stampail report a video in html.
    ''' </summary>
    ''' <returns></returns>
    Public Function StampReport() As Object
        Dim i As Integer, x As String()
        i = 0
        x = Split(id_report, " ")

        For i = 0 To UBound(x) - 1
            conteggio = conteggio + 1
            Dim qrytop As String = "Select * from datahardware where ID = " & x(i) & " order by ID"
            Dim DbPathtop As String, Conntop As SqlConnection
            DbPathtop = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Conntop = New SqlConnection(connecttop)
            Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                Response.Write(
                    "<tr><td class=""cell-report-general-body"">" & read.Item("ID").ToString &
                    "<td class=""cell-report-general-body"">" & read.Item("tipo_hardware").ToString &
                    "</td><td class=""cell-report-general-body"">" & read.Item("marca_hardware").ToString &
                    "</td><td class=""cell-report-general-body"">" & read.Item("modello_hardware").ToString &
                    "</td><td Class=""cell-report-general-body"">" & read.Item("serie_hardware").ToString &
                    "</td> <td class=""cell-report-general-body"">" & read.Item("inventario_hardware").ToString &
                    "</td><td class=""cell-report-general-body"">" & read.Item("anno_hardware").ToString & "</td>" &
                    "<td class=""cell-report-general-body"">" & read.Item("ip_hardware").ToString & "</td>" &
                    "<td class=""cell-report-general-body"">" & read.Item("stato_hardware").ToString & "</td>" &
                    "<td Class=""cell-report-general-body"">" & read.Item("note_hardware").ToString & "</td>" &
                    "<td class=""cell-report-general-body"">" & read.Item("datainserimento_hardware").ToString & " | " & read.Item("orainserimento_hardware").ToString & "</td>" &
                    "<td class=""cell-report-general-body"">" & read.Item("reparto_hw").ToString & "</td>" &
                    "<td class=""cell-report-general-body"">" & read.Item("padiglione_hw").ToString & "</td>" &
                    "<td class=""cell-report-general-body"">" & read.Item("presidio_hw").ToString & "</td> </tr>")
            End While

            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()

        Next

        Return 0
    End Function


End Class
