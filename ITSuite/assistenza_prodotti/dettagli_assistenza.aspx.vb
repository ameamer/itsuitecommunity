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
Imports System.Xml

Partial Class assistenza_prodotti_dettagli_assistenza
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public idass As String
    Public stato As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String740") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        AddUpdateButton.DataBind()
        ChiudiRichiestaButton.DataBind()
        TextNewUpdate.DataBind()

        idass = Request.QueryString("id")

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                    Exit Sub
                End If

            Case "personale"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                    Exit Sub
                Else
                    If Session("abilita_utenti_stpers_ass") <> "1" Then
                        Response.Redirect("../logout.aspx")
                        Exit Sub
                    End If
                End If

            Case Else
                Response.Redirect("../logout.aspx")
                Exit Sub
        End Select

        DetailsAssSql.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
        DetailsAssSql.SelectCommand = "SELECT * FROM assistenzaprodotti WHERE ID=" & idass

        Dim idpc As String = ""
        Dim idstamp As String = ""
        Dim idhw As String = ""
        Dim dettagli1shared As String = ""
        Dim qrytop As String = "", DbPathtop As String = "../App_Data/itstdb.mdf", connecttop As String = ""
        Dim ConnectorDB As SqlConnection
        Dim SqlCom As SqlCommand
        Dim read As SqlDataReader

        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = ""
        qrytop = "SELECT * FROM assistenzaprodotti WHERE ID=" & idass
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        read = SqlCom.ExecuteReader()
        While read.Read()

            If Not IsDBNull(read.Item("idaltrohw").ToString) Then
                If Not String.IsNullOrEmpty(read.Item("idaltrohw").ToString) Then
                    idhw = read.Item("idaltrohw").ToString
                End If
            End If

            If Not IsDBNull(read.Item("idstamp").ToString) Then
                If Not String.IsNullOrEmpty(read.Item("idstamp").ToString) Then
                    idstamp = read.Item("idstamp").ToString
                End If
            End If

            If Not IsDBNull(read.Item("idpc").ToString) Then
                If Not String.IsNullOrEmpty(read.Item("idpc").ToString) Then
                    idpc = read.Item("idpc").ToString
                End If
            End If

            If Not IsDBNull(read.Item("dettagli1").ToString) Then
                If String.IsNullOrEmpty(read.Item("dettagli1").ToString) Then
                    dettagli1.CssClass = "paneldetails-displaynone"
                Else
                    dettagli1.CssClass = "paneldetails-displayupdates"
                    dettagli1text.Text = read.Item("dettagli1").ToString
                End If
            End If

            If Not IsDBNull(read.Item("dettagli_chiusura").ToString) Then
                If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli_chiusura").ToString)) Then
                    chiusurapanel.CssClass = "paneldetailschiusa-displaynone"
                Else
                    addupdatepanel.CssClass = "paneldetails-displaynone"
                    chiusurapanel.CssClass = "paneldetailschiusa-display"
                    chiusuratext.Text = "<b>" & globals.ResourceHelper.GetString("String219") & read.Item("data_chiusura").ToString & globals.ResourceHelper.GetString("String220") & read.Item("autore_chiusura").ToString & "</b><br />" & read.Item("dettagli_chiusura").ToString
                End If
            End If

        End While

        ConnectorDB.Close()
        ConnectorDB.Dispose()
        read.Close()
        SqlCom.Dispose()

        If Not String.IsNullOrEmpty(idhw) Then
            Dim typeprod As String = globals.ResourceHelper.GetString("String51") & ": <b>" & globals.ResourceHelper.GetString("String752") & "</b><br />"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = ""
            qrytop = "SELECT * FROM datahardware WHERE ID=" & idhw
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            read = SqlCom.ExecuteReader()
            While read.Read()
                typeprod = typeprod & "ID: <b>" & read.Item("ID").ToString & "</b><br />" & globals.ResourceHelper.GetString("String51") & ": <b>" & read.Item("tipo_hardware").ToString & "</b><br />" & globals.ResourceHelper.GetString("String120") & ": <b>" &
                read.Item("marca_hardware").ToString & "</b><br />" & globals.ResourceHelper.GetString("String122") & ": <b>" & read.Item("modello_hardware").ToString & "</b><br />" & globals.ResourceHelper.GetString("String123") & ": <b>" &
                read.Item("serie_hardware").ToString & "</b><br />" & globals.ResourceHelper.GetString("String124") & ": <b>" & read.Item("inventario_hardware").ToString &
                "</b><br />" & globals.ResourceHelper.GetString("String234") & ": <b>" & read.Item("presidio_hw").ToString & ",&nbsp;" & read.Item("reparto_hw").ToString &
                ",&nbsp;" & read.Item("padiglione_hw").ToString & "</b><br /><a href='../gestione_altro_hardware/dettagli_altro_hw.aspx?id_hw=" & read.Item("ID").ToString & "'>" & globals.ResourceHelper.GetString("String230") & "</a>"
            End While

            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()

            prodasslabel.Text = typeprod
        End If

        If idstamp <> "" Then
            Dim typeprod As String = globals.ResourceHelper.GetString("String51") & ": <b>" & globals.ResourceHelper.GetString("String753") & "</b><br />"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = ""
            qrytop = "SELECT * FROM stampanti WHERE ID=" & idstamp
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            read = SqlCom.ExecuteReader()
            While read.Read()
                typeprod = typeprod & "ID: <b>" & read.Item("ID").ToString & "</b><br />" & globals.ResourceHelper.GetString("String120") & ": <b>" & read.Item("marca_stampante").ToString & "</b><br />" & globals.ResourceHelper.GetString("String122") & ": <b>" &
                read.Item("modello_stampante").ToString & "</b><br />" & globals.ResourceHelper.GetString("String123") & ": <b>" & read.Item("numero_serie_stampante").ToString & "</b><br />" & globals.ResourceHelper.GetString("String124") & ": <b>" &
                read.Item("inventario_stampante").ToString & "</b><br />" & globals.ResourceHelper.GetString("String234") & ": <b>" & read.Item("presidio_stampante").ToString & ",&nbsp;" &
                read.Item("reparto_stampante").ToString & ",&nbsp;" & read.Item("padiglione_stampante").ToString &
                "</b><br /><a href='../gestione_stampanti/dettagli_stampante.aspx?id_stampante=" & read.Item("ID").ToString & "'>" & globals.ResourceHelper.GetString("String230") & "</a>"
            End While

            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()

            prodasslabel.Text = typeprod
        End If

        If idpc <> "" Then
            Dim typeprod As String = globals.ResourceHelper.GetString("String51") & ": <b>" & globals.ResourceHelper.GetString("String754") & "</b><br />"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = ""
            qrytop = "SELECT * FROM datapc WHERE ID=" & idpc
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            read = SqlCom.ExecuteReader()
            While read.Read()
                typeprod = typeprod & "ID: <b>" & read.Item("ID").ToString & "</b><br />" & globals.ResourceHelper.GetString("String120") & ": <b>" & read.Item("marca_pc").ToString & "</b><br />" & globals.ResourceHelper.GetString("String122") & ": <b>" &
                read.Item("modello_pc").ToString & "</b><br />" & globals.ResourceHelper.GetString("String123") & ": <b>" & read.Item("serie_pc").ToString & "</b><br />" & globals.ResourceHelper.GetString("String124") & ": <b>" &
                read.Item("inventario_pc").ToString & "</b><br />" & globals.ResourceHelper.GetString("String234") & ": <b>" & read.Item("presidio_pc").ToString & ",&nbsp;" &
                read.Item("reparto_pc").ToString & ",&nbsp;" & read.Item("padiglione_pc").ToString & "," & globals.ResourceHelper.GetString("String741") & read.Item("piano_pc").ToString & "," & globals.ResourceHelper.GetString("String742") &
                read.Item("stanza_pc").ToString & "</b><br /><a href='../gestione_pc/dettagli_pc.aspx?id_pc=" & read.Item("ID").ToString & "'>" & globals.ResourceHelper.GetString("String230") & "</a>"
            End While

            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()

            prodasslabel.Text = typeprod
        End If

    End Sub

    ''' <summary>
    ''' Aggiunge dettagli alla richiesta.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub AddUpdateButton_Click(sender As Object, e As EventArgs)
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim dettaglio As String = TextNewUpdate.Text
        Dim qrytop As String = "", DbPathtop As String = "../App_Data/itstdb.mdf", connecttop As String = ""

        If String.IsNullOrEmpty(Convert.ToString(dettaglio.Replace(" ", ""))) Then
            ErrorMsg.Text = globals.ResourceHelper.GetString("String743")
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Exit Sub
        End If

        Dim qry As String = "UPDATE assistenzaprodotti SET dettagli1=@Fdet WHERE ID=" & CInt(idass)
        Dim DbPath As String, Conn As SqlConnection
        DbPath = "../App_Data/itstdb.mdf"
        Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
        cmd.Parameters.AddWithValue("@Fdet", dettagli1text.Text & "<div style='width:100%;padding-top:10px; padding-bottom:10px;'><b>" & globals.ResourceHelper.GetString("String744") & data & " | " & ora & globals.ResourceHelper.GetString("String220") & "<br />" & Session("username") & "</b><br/>" & dettaglio & "</div>")
        Conn.Open()
        cmd.ExecuteNonQuery()

        ' scrivo log
        Dim xmlPath As String = "../App_Data/asslog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("ASSLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWUPDATE", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = idass
        elem.AppendChild(idelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_assistenza.aspx?id=" & idass)

    End Sub

    ''' <summary>
    ''' Aggiunge nota di chiusura e chiude la richiesta di assistenza
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ChiudiRichiestaButton_Click(sender As Object, e As EventArgs)
        Dim DbPath, Conn, Rs As Object
        Dim strSQL As String
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim dettaglio As String = TextNewUpdate.Text

        If String.IsNullOrEmpty(Convert.ToString(dettaglio.Replace(" ", ""))) Then
            ErrorMsg.Text = globals.ResourceHelper.GetString("String745")
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Exit Sub
        End If

        Dim qry As String = "UPDATE assistenzaprodotti SET dettagli_chiusura=@Fdet,  data_chiusura=@Fdata, autore_chiusura=@Faut, stato=@Fstato WHERE ID=" & CInt(idass)
        DbPath = "../App_Data/itstdb.mdf"
        Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
        cmd.Parameters.AddWithValue("@Fdet", dettaglio)
        cmd.Parameters.AddWithValue("@Fdata", data & " " & ora)
        cmd.Parameters.AddWithValue("@Faut", Session("username"))
        cmd.Parameters.AddWithValue("@Fstato", "chiusa")
        Conn.Open()
        cmd.ExecuteNonQuery()

        ' scrivo log
        Dim xmlPath As String = "../App_Data/asslog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("ASSLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "ASSCLOSED", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = idass
        elem.AppendChild(idelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_assistenza.aspx?id=" & idass)
    End Sub

    ''' <summary>
    ''' Si verifica al bound della lista dei dettagli.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DetailsView1_DataBound(sender As Object, e As EventArgs)
        Dim detvw As DetailsView = sender
        Dim headerRow As DetailsViewRow = detvw.HeaderRow

        detvw.Fields.Item(1).HeaderText = globals.ResourceHelper.GetString("String232")
        detvw.Fields.Item(2).HeaderText = globals.ResourceHelper.GetString("String233")
        detvw.Fields.Item(3).HeaderText = globals.ResourceHelper.GetString("String129")
        detvw.Fields.Item(4).HeaderText = globals.ResourceHelper.GetString("String229")
        detvw.Fields.Item(5).HeaderText = globals.ResourceHelper.GetString("String751")
        detvw.Fields.Item(6).HeaderText = globals.ResourceHelper.GetString("String128")
    End Sub
End Class
