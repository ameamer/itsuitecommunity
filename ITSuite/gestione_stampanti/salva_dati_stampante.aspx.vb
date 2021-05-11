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

Partial Class gestione_stampanti_salva_dati_stampante
    Inherits System.Web.UI.Page
    Private marca_stampante, modello_stampante, numero_serie_stampante, inventario_stampante,
         anno_stampante, cartella_stampante, ip_stampante, stato_stampante, note_stampante, topmsg,
         presidio_stampante, reparto_stampante, padiglione_stampante, qrytop, DbPathtop, connecttop, id_stamp As String

    Private ConnectorDB As SqlConnection
    Private SqlCom As SqlCommand
    Private read As SqlDataReader
    Public globals As New ITSuite_Globalization()

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
        id_stamp = Request("id_stamp")
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

        'controllo se ha cancellato i dati obbligatori
        If (Request("numero_serie_stampante") = "") Or (Request("numero_serie_stampante") = " ") Or (Request("modello_stampante") = "") Or (Request("modello_stampante") = " ") Then
            Response.Write("<script type='text/javascript'>alert('" & globals.ResourceHelper.GetString("String449") & "\n\n" & globals.ResourceHelper.GetString("String450") & "');history.go(-1);</script>")
            Response.End()
            Exit Sub
        End If

        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM stampanti where (numero_serie_stampante = '" & Request("numero_serie_stampante") & "') AND (modello_stampante = '" & Request("modello_stampante") & "') AND (marca_stampante = '" & Request("marca_stampante") & "')"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        read = SqlCom.ExecuteReader()
        If read.Read() Then
            If read.Item("ID").ToString <> id_stamp Then
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()
                Response.Write("<script type=""text/javascript""> alert('" & globals.ResourceHelper.GetString("String451") & "');history.go(-1);</script>")
                Response.End()
                Exit Sub
            Else
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()
            End If
        Else
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
        End If

        ' Avvio inserimento
        Using da As New SqlDataAdapter("Select * from stampanti where ID = " & id_stamp, connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "stampanti")

            Dim Row As DataRow = ds.Tables("stampanti").Rows.Item(0)
            Row.Item(1) = inventario_stampante
            Row.Item(2) = modello_stampante
            Row.Item(3) = numero_serie_stampante
            Row.Item(4) = cartella_stampante
            Row.Item(5) = marca_stampante
            Row.Item(6) = anno_stampante
            Row.Item(10) = presidio_stampante
            Row.Item(11) = reparto_stampante
            Row.Item(12) = padiglione_stampante
            Row.Item(13) = ip_stampante
            Row.Item(14) = stato_stampante
            Row.Item(15) = note_stampante
            Row.Item(16) = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
            Row.Item(17) = Session("username")

            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "stampanti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/stamplog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("STAMPLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "MODSTAMP", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = id_stamp
        elem.AppendChild(idelm)
        Dim snelm As XmlElement = xWr.CreateElement("SN")
        snelm.InnerText = Request("numero_serie_stampante")
        elem.AppendChild(snelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_stampante.aspx?id_stampante=" & id_stamp)
    End Sub

End Class
