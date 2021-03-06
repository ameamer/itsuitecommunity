'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml

Partial Class gestione_stampanti_elimina_stampante
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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

        Dim ModID As String, tipo As String = "", sn As String = ""

        ' Ricavo i dati per log
        Dim qrytop As String = "SELECT * FROM stampanti WHERE ID=" & CInt(Request.QueryString("id_stampante"))
        Dim DbPathtop As String, Conntop As SqlConnection
        DbPathtop = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()
            If read.Item("numero_serie_stampante") IsNot DBNull.Value Then
                If Not String.IsNullOrEmpty(read.Item("numero_serie_stampante").ToString) Then
                    sn = read.Item("numero_serie_stampante").ToString
                End If
            End If
        End While
        Conntop.Close()
        Conntop.Dispose()
        read.Close()
        cmdtop.Dispose()

        ' Ricavo l'id
        ModID = Request.QueryString("id_stampante")

        ' Avvio eliminazione
        Dim qrydel As String = "DELETE FROM stampanti WHERE ID=" & ModID
        Dim DbPath As String, Conn As SqlConnection
        DbPath = "../App_Data/itstdb.mdf"
        Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conn = New SqlConnection(connecttop)
        Dim cmd As SqlCommand = New SqlCommand(qrydel, Conn)
        Conn.Open()
        cmd.ExecuteNonQuery()
        Conn.Close()
        Conn.Dispose()
        cmd.Dispose()

        Diagnostics.Debug.WriteLine("Stampante eliminata con successo.")

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/stamplog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("STAMPLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "DELSTAMP", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = ModID
        elem.AppendChild(idelm)
        Dim snelm As XmlElement = xWr.CreateElement("SN")
        snelm.InnerText = sn
        elem.AppendChild(snelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("gestione_stampanti_lista.aspx?t=del_ok")

    End Sub

End Class
