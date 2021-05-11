'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Partial Class gestione_stampanti_stampante_inserita
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Private marca_stampante, modello_stampante, numero_serie_stampante, inventario_stampante,
         anno_stampante, cartella_stampante, ip_stampante, stato_stampante, note_stampante,
         presidio_stampante, reparto_stampante, padiglione_stampante, qrytop, DbPathtop, connecttop, id_stamp As String

    Private ConnectorDB As SqlConnection
    Private SqlCom As SqlCommand

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

        ' ricavo dati
        marca_stampante = Request("marca_stampante")
        modello_stampante = Request("modello_stampante")
        numero_serie_stampante = Request("numero_serie_stampante")
        inventario_stampante = Request("inventario_stampante")
        cartella_stampante = Request("cartella_stampante")
        anno_stampante = Request("anno_stampante")
        stato_stampante = Request("stato_stampante")
        ip_stampante = Request("ip_stampante")
        note_stampante = Request("note_stampante")
        presidio_stampante = Request("presidio_stampante")
        reparto_stampante = Request("reparto_stampante")
        padiglione_stampante = Request("padiglione_stampante")

        ' controllo marca, anno e stato
        If (marca_stampante = "") Or (modello_stampante = "") Or (numero_serie_stampante = "") Or (anno_stampante = "") Or (stato_stampante = "") Or
           (reparto_stampante = "") Or (padiglione_stampante = "") Or (presidio_stampante = "") Then
            Response.Write("<script type ='text/javascript'>alert('" & globals.ResourceHelper.GetString("String452") & "');history.go(-1);</script>")
            Response.End()
            Exit Sub
        End If

        ' Controllo esistenza dell'elemento
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM stampanti where (numero_serie_stampante = '" & numero_serie_stampante & "') AND (modello_stampante = '" & modello_stampante & "') AND (marca_stampante = '" & marca_stampante & "')"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        If read.Read() Then
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
            Response.Write("<script type='text/javascript'>alert('" & globals.ResourceHelper.GetString("String451") & "');history.go(-1);</script>")
            Response.End()
            Exit Sub
        Else
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
        End If

        ' Avvio inserimento nuovo elemento
        Using da As New SqlDataAdapter("SELECT * FROM stampanti order by ID desc", connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "stampanti")

            Dim NewRow As DataRow = ds.Tables("stampanti").NewRow()
            NewRow.Item(1) = inventario_stampante
            NewRow.Item(2) = modello_stampante
            NewRow.Item(3) = numero_serie_stampante
            NewRow.Item(4) = cartella_stampante
            NewRow.Item(5) = marca_stampante
            NewRow.Item(6) = anno_stampante
            NewRow.Item(7) = Session("username")
            NewRow.Item(8) = DateTime.Now.ToLocalTime.ToShortDateString()
            NewRow.Item(9) = DateTime.Now.ToLongTimeString()
            NewRow.Item(10) = presidio_stampante
            NewRow.Item(11) = reparto_stampante
            NewRow.Item(12) = padiglione_stampante
            NewRow.Item(13) = ip_stampante
            NewRow.Item(14) = stato_stampante
            NewRow.Item(15) = note_stampante

            ds.Tables("stampanti").Rows.Add(NewRow)
            da.UpdateCommand = cb.GetUpdateCommand
            da.InsertCommand = cb.GetInsertCommand
            da.DeleteCommand = cb.GetDeleteCommand
            da.Update(ds, "stampanti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' Seleziono ultimo elemento inserito dall'utente per ricavarne ID
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT TOP 1 ID FROM stampanti WHERE inserita_da = '" & Session("Username") & "' order by ID desc"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim readNewPc As SqlDataReader = SqlCom.ExecuteReader()
        While readNewPc.Read()
            id_stamp = readNewPc.Item("ID").ToString
        End While
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        read.Close()
        SqlCom.Dispose()

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/stamplog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("STAMPLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWSTAMP", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = id_stamp
        elem.AppendChild(idelm)
        Dim snelm As XmlElement = xWr.CreateElement("SN")
        snelm.InnerText = numero_serie_stampante
        elem.AppendChild(snelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_stampante.aspx?id_stampante=" & id_stamp & "&t=new")
    End Sub
End Class
