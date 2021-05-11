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

Partial Class gestione_altro_hardware_salva_hw
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public tipo_hardware As String = "", marca_hardware As String = "", modello_hardware As String = "", serie_hardware As String = "",
    anno_hardware As String = "", inventario_hardware As String = "", stato_hardware As String = "", note_hardware As String = "",
    presidio_hw As String = "", reparto_hw As String = "", padiglione_hw As String = "", ip_hardware As String = "",
    cartella_hardware As String = "", id_hw As String

    Private qrytop, DbPathtop, connecttop As String
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

        'recupero dati immessi nel form
        tipo_hardware = Request("tipo_hardware")
        marca_hardware = Request("marca_hardware")
        modello_hardware = Request("modello_hardware")
        serie_hardware = Request("serie_hardware")
        anno_hardware = Request("anno_hardware")
        inventario_hardware = Request("inventario_hardware")
        stato_hardware = Request("stato_hardware")
        note_hardware = Request("note_hardware")
        cartella_hardware = Request("cartella_hw")
        presidio_hw = Request("presidio_hw")
        reparto_hw = Request("reparto_hw")
        padiglione_hw = Request("padiglione_hw")
        ip_hardware = Request("ip_hardware")

        'controllo se ha cancellato i dati obbligatori
        If (marca_hardware = "") Or (modello_hardware = "") Or (serie_hardware = "") Or (anno_hardware = "") Or (stato_hardware = "") Or
   (reparto_hw = "") Or (padiglione_hw = "") Or (presidio_hw = "") Then
            Response.Write("<script type='text/javascript'>alert('" & globals.ResourceHelper.GetString("String452") & "');history.go(-1);</script>")
            Response.End()
            Exit Sub
        End If

        ' Controllo esistenza dell'elemento
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM datahardware where (marca_hardware = '" & Request("marca_hardware") & "') AND (modello_hardware = '" & Request("modello_hardware") & "') AND (serie_hardware = '" & Request("serie_hardware") & "')"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        If read.Read() Then
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
            Response.Write("<script type = ""text/javascript"">alert('" & globals.ResourceHelper.GetString("String453") & "');history.go(-1);</script>")
            Response.End()
            Exit Sub
        Else
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
        End If

        ' Avvio inserimento nuovo elemento
        Using da As New SqlDataAdapter("SELECT * FROM datahardware order by ID desc", connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "datahardware")

            Dim NewRow As DataRow = ds.Tables("datahardware").NewRow()
            NewRow.Item(1) = tipo_hardware
            NewRow.Item(2) = marca_hardware
            NewRow.Item(3) = modello_hardware
            NewRow.Item(4) = serie_hardware
            NewRow.Item(5) = anno_hardware
            NewRow.Item(6) = stato_hardware
            NewRow.Item(7) = inventario_hardware
            NewRow.Item(10) = DateTime.Now.ToLocalTime.ToShortDateString()
            NewRow.Item(11) = DateTime.Now.ToLongTimeString()
            NewRow.Item(12) = note_hardware
            NewRow.Item(13) = Session("username")
            NewRow.Item(18) = cartella_hardware
            NewRow.Item(21) = presidio_hw
            NewRow.Item(22) = reparto_hw
            NewRow.Item(23) = padiglione_hw
            NewRow.Item(24) = ip_hardware

            ds.Tables("datahardware").Rows.Add(NewRow)
            da.UpdateCommand = cb.GetUpdateCommand
            da.InsertCommand = cb.GetInsertCommand
            da.DeleteCommand = cb.GetDeleteCommand
            da.Update(ds, "datahardware")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' Seleziono ultimo elemento inserito dall'utente per ricavarne ID
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT TOP 1 ID FROM datahardware WHERE autoreinserimento_hardware = '" & Session("Username") & "' order by ID desc"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim readNew As SqlDataReader = SqlCom.ExecuteReader()
        While readNew.Read()
            id_hw = readNew.Item("ID").ToString
        End While
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        read.Close()
        SqlCom.Dispose()

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/hwlog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("HWLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWHW", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = id_hw
        elem.AppendChild(idelm)
        Dim tyelm As XmlElement = xWr.CreateElement("TIPO")
        tyelm.InnerText = tipo_hardware
        elem.AppendChild(tyelm)
        Dim snelm As XmlElement = xWr.CreateElement("SN")
        snelm.InnerText = serie_hardware
        elem.AppendChild(snelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_altro_hw.aspx?id_hw=" & id_hw & "&t=new")
    End Sub

End Class
