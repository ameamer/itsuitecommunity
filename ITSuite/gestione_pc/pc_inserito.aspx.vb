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

Partial Class gestione_pc_pc_inserito
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    Private marca_pc, modello_pc, serie_pc, processore_pc, stato_pc, tipo_pc,
        dominio_pc, nome_pc, anno_pc, inventario_pc, so_pc, ram_pc, stanza_pc,
        piano_pc, reparto_pc, padiglione_pc, presidio_pc, swprivate_pc, note_pc,
        id_stampante_collegata, ip_pc, id_altrohw_collegato, marca_video_pc,
        modello_video_pc, pollici_video_pc, inventario_video_pc, serie_video_pc,
        note_video_pc, stato_video_pc, anno_video_pc, cartella_pc, qrytop, DbPathtop,
        connecttop, id_newpc As String

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

        ' Recupero dati immessi nel form
        marca_pc = Request.Form("marca_pc")
        modello_pc = Request.Form("modello_pc")
        dominio_pc = Request("dominio_pc")
        nome_pc = Request("nome_pc")
        anno_pc = Request("anno_pc")
        serie_pc = Request.Form("serie_pc")
        inventario_pc = Request.Form("inventario_pc")
        so_pc = Request.Form("so_pc")
        stato_pc = Request.Form("stato_pc")
        ram_pc = Request.Form("ram_pc")
        processore_pc = Request.Form("processore_pc")
        stanza_pc = Request.Form("stanza_pc")
        piano_pc = Request.Form("piano_pc")
        reparto_pc = Request.Form("reparto_pc")
        padiglione_pc = Request.Form("padiglione_pc")
        presidio_pc = Request.Form("presidio_pc")
        swprivate_pc = Request.Form("swprivate_pc")
        tipo_pc = Request.Form("tipo_pc")
        note_pc = Request.Form("note_pc")
        ip_pc = Request.Form("indirizzo_ip_pc")
        id_stampante_collegata = Request("id_stampante_collegata")
        id_altrohw_collegato = Request("id_altrohw_collegato")
        cartella_pc = Request("cartella_pc")
        marca_video_pc = Request("marca_video_pc")
        modello_video_pc = Request("modello_video_pc")
        pollici_video_pc = Request("pollici_video_pc")
        inventario_video_pc = Request("inventario_video_pc")
        serie_video_pc = Request("serie_video_pc")
        note_video_pc = Request("note_video_pc")
        stato_video_pc = Request("stato_video_pc")
        anno_video_pc = Request("anno_video_pc")

        ' Controllo inserimento dati obbligatori
        If String.IsNullOrEmpty(marca_pc) Or String.IsNullOrEmpty(modello_pc) Or String.IsNullOrEmpty(dominio_pc) Or String.IsNullOrEmpty(nome_pc) Or
           String.IsNullOrEmpty(anno_pc) Or String.IsNullOrEmpty(serie_pc) Or String.IsNullOrEmpty(so_pc) Or
           String.IsNullOrEmpty(stato_pc) Or String.IsNullOrEmpty(ram_pc) Or String.IsNullOrEmpty(processore_pc) Or String.IsNullOrEmpty(stanza_pc) Or
           String.IsNullOrEmpty(piano_pc) Or String.IsNullOrEmpty(reparto_pc) Or String.IsNullOrEmpty(padiglione_pc) Or String.IsNullOrEmpty(presidio_pc) Or
           String.IsNullOrEmpty(swprivate_pc) Or String.IsNullOrEmpty(tipo_pc) Then
            Response.Write("<script type='text/javascript'>alert('" & globals.ResourceHelper.GetString("String417") & "');history.go(-1);</script>")
            Response.End()
            Exit Sub
        End If

        ' Controllo esistenza del PC
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM datapc where (serie_pc = '" & serie_pc & "') AND (modello_pc = '" & modello_pc & "') AND (marca_pc = '" & marca_pc & "')"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        If read.Read() Then
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
            Response.Write("<script type='text/javascript'>alert('" & globals.ResourceHelper.GetString("String417") & "');history.go(-1);</script>")
            Response.End()
            Exit Sub
        Else
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
        End If

        ' Avvio inserimento nuovo PC
        Using da As New SqlDataAdapter("SELECT * FROM datapc order by ID desc", connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "datapc")

            Dim NewRow As DataRow = ds.Tables("datapc").NewRow()
            NewRow.Item(1) = nome_pc
            NewRow.Item(2) = dominio_pc
            NewRow.Item(3) = marca_pc
            NewRow.Item(4) = modello_pc
            NewRow.Item(5) = serie_pc
            NewRow.Item(6) = inventario_pc
            NewRow.Item(7) = reparto_pc
            NewRow.Item(8) = stanza_pc
            NewRow.Item(9) = Session("username")
            NewRow.Item(10) = padiglione_pc
            NewRow.Item(11) = piano_pc
            NewRow.Item(12) = presidio_pc
            NewRow.Item(13) = so_pc
            NewRow.Item(14) = ram_pc
            NewRow.Item(15) = processore_pc
            NewRow.Item(16) = ip_pc
            NewRow.Item(17) = swprivate_pc
            NewRow.Item(18) = DateTime.Now.ToLocalTime.ToShortDateString()
            NewRow.Item(19) = DateTime.Now.ToLongTimeString()
            NewRow.Item(20) = note_pc
            NewRow.Item(21) = stato_pc
            NewRow.Item(22) = anno_pc
            NewRow.Item(23) = id_stampante_collegata
            NewRow.Item(24) = tipo_pc
            NewRow.Item(25) = marca_video_pc
            NewRow.Item(26) = modello_video_pc
            NewRow.Item(27) = pollici_video_pc
            NewRow.Item(28) = inventario_video_pc
            NewRow.Item(29) = serie_video_pc
            NewRow.Item(30) = note_video_pc
            NewRow.Item(31) = stato_video_pc
            NewRow.Item(32) = id_altrohw_collegato
            NewRow.Item(33) = anno_video_pc
            NewRow.Item(40) = cartella_pc

            ds.Tables("datapc").Rows.Add(NewRow)
            da.UpdateCommand = cb.GetUpdateCommand
            da.InsertCommand = cb.GetInsertCommand
            da.DeleteCommand = cb.GetDeleteCommand
            da.Update(ds, "datapc")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' Seleziono ultimo pc inserito dall'utente per ricavarne ID
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT TOP 1 ID FROM datapc WHERE inserito_da = '" & Session("Username") & "' order by ID desc"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim readNewPc As SqlDataReader = SqlCom.ExecuteReader()
        While readNewPc.Read()
            id_newpc = readNewPc.Item("ID").ToString
        End While
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        read.Close()
        SqlCom.Dispose()

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/pclog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("PCLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWPC", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = id_newpc
        elem.AppendChild(idelm)
        Dim snelm As XmlElement = xWr.CreateElement("SN")
        snelm.InnerText = serie_pc
        elem.AppendChild(snelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        ' Vado ai dettagli del pc inserito
        Response.Redirect("dettagli_pc.aspx?id_pc=" & id_newpc & "&t=new")

    End Sub

End Class


