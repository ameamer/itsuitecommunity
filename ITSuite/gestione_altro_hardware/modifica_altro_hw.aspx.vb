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
Imports System.IO
Imports System.Xml

Partial Class gestione_altro_hardware_modifica_altro_hw
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' L'id della stampante selezionata.
    ''' </summary>
    Public id_hw, tipo_hardware, marca_hardware, modello_hardware, serie_hardware, inventario_hardware, anno_hardware, cartella_hw,
        reparto_hw, padiglione_hw, presidio_hw, stato_hardware, note_hardware, ip_hardware, driver_hw, topmsg, activeUser As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String169") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        id_hw = Request.QueryString("id_hw")
        activeUser = Session("username")

        If Page.IsPostBack Then
            Diagnostics.Debug.WriteLine("è postback - " & Request("__EVENTVALIDATION"))
            ErrorMsg.Visible = True
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            ErrorMsg.Text = ""
            topmsg = ""
        End If

        Dim qrytop As String = "SELECT * FROM datahardware WHERE ID=" & CInt(id_hw)
        Dim DbPathtop As String, Conntop As SqlConnection
        DbPathtop = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()
            tipo_hardware = read.Item("tipo_hardware").ToString
            marca_hardware = read.Item("marca_hardware").ToString
            modello_hardware = read.Item("modello_hardware").ToString
            serie_hardware = read.Item("serie_hardware").ToString
            inventario_hardware = read.Item("inventario_hardware").ToString
            anno_hardware = read.Item("anno_hardware").ToString
            reparto_hw = read.Item("reparto_hw").ToString
            padiglione_hw = read.Item("padiglione_hw").ToString
            presidio_hw = read.Item("presidio_hw").ToString
            stato_hardware = read.Item("stato_hardware").ToString
            note_hardware = read.Item("note_hardware").ToString
            cartella_hw = read.Item("cartella_hw").ToString
            ip_hardware = read.Item("ip_hardware").ToString

            If read.Item("FileName").ToString <> "" Then
                DivisionBar.Visible = True
                LabelInfoPhoto.Enabled = True
                LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_hw & "', '', ''); return false;")
                LabelInfoPhoto.Attributes.Add("style", "cursor:pointer")
                LabelInfoPhoto.Font.Underline = True
                LabelInfoPhoto.Text = read.Item("FileName").ToString & ", " & read.Item("FileSize").ToString & " bytes."
                LinkDeletePhoto.ForeColor = Drawing.Color.Red
                LinkDeletePhoto.Text = globals.ResourceHelper.GetString("String147")
                LinkDeletePhoto.Visible = True
            Else
                LabelInfoPhoto.Enabled = False
                LabelInfoPhoto.Attributes.Remove("onclick")
                DivisionBar.Visible = False
                LinkDeletePhoto.Visible = False
                LabelInfoPhoto.Font.Underline = False
                LabelInfoPhoto.Attributes.Add("style", "cursor:default")
                LabelInfoPhoto.Text = globals.ResourceHelper.GetString("String152")
            End If
        End While

        Conntop.Close()
        read.Close()
        cmdtop.Dispose()
    End Sub


    ''' <summary>
    ''' Si verifica al clic su Carica durante l'aggiunta della foto all'elemento (con foto non presente).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ButtonUploadPhoto_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (PhotoUpload.HasFile) Then
            topmsg = ""
            Dim fi As New FileInfo(PhotoUpload.FileName)
            Dim ext As String = fi.Extension
            Select Case ext
                Case ".jpg", ".jpeg", ".JPG", ".JPEG", ".png", ".PNG", ".gif", ".GIF"
                    Diagnostics.Debug.WriteLine("File immagine permesso - " & ext)
                Case Else
                    ErrorMsg.Text = globals.ResourceHelper.GetString("String170") & " - " & ext & "<br />" & globals.ResourceHelper.GetString("String171")
                    Exit Sub
            End Select
            Dim photoStream As Stream = PhotoUpload.PostedFile.InputStream
            Dim photoLength As Integer = PhotoUpload.PostedFile.ContentLength
            Dim photoMime As String = PhotoUpload.PostedFile.ContentType
            Dim photoName As String = Path.GetFileName(PhotoUpload.PostedFile.FileName)
            Dim photoData As Byte() = New Byte(photoLength - 1) {}
            photoStream.Read(photoData, 0, photoLength)
            Dim qry As String = "UPDATE datahardware SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, dataora_ultimamodhw=@Fultima, autore_ultimamodhw=@Fultimamod WHERE ID=" & CInt(id_hw)
            Dim DbPath As String, Conn As SqlConnection
            DbPath = "../App_Data/itstdb.mdf"
            Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
            cmd.Parameters.AddWithValue("@Fname", photoName)
            cmd.Parameters.AddWithValue("@Fsize", photoLength)
            cmd.Parameters.AddWithValue("@Fbin", photoData)
            cmd.Parameters.AddWithValue("@Ftype", photoMime)
            cmd.Parameters.AddWithValue("@Fultima", DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString())
            cmd.Parameters.AddWithValue("@Fultimamod", Session("username"))
            Conn.Open()
            cmd.ExecuteNonQuery()
            DivisionBar.Visible = True
            LabelInfoPhoto.Enabled = True
            LabelInfoPhoto.Attributes.Add("style", "cursor:pointer")
            LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_hw & "', '', '');")
            LabelInfoPhoto.Font.Underline = True
            LabelInfoPhoto.Text = PhotoUpload.FileName & ", " & PhotoUpload.FileBytes.Length.ToString & " bytes."
            LinkDeletePhoto.ForeColor = Drawing.Color.Red
            LinkDeletePhoto.Text = "Elimina"
            LinkDeletePhoto.Visible = True
            Conn.Close()
            cmd.Dispose()
            ErrorMsg.Text = "Il file è stato caricato con successo"

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/hwlog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("HWLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "ADDIMGHW", Nothing)
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
        Else
            Diagnostics.Debug.WriteLine("messaggio non caricato ok --> " & id_hw)
            ErrorMsg.Text = "Nessun file selezionato"
        End If
    End Sub

    ''' <summary>
    ''' Si verifica al clic su elimina foto.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub LinkDeletePhoto_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim confirm_val As String = confirm_value.Value
        Diagnostics.Debug.WriteLine(confirm_val)
        If confirm_val = "Yes" Then
            Dim qry As String = "UPDATE datahardware SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, dataora_ultimamodhw=@Fultima, autore_ultimamodhw=@Fultimamod WHERE ID=" & CInt(id_hw)
            Dim DbPath As String, Conn As SqlConnection
            DbPath = "../App_Data/itstdb.mdf"
            Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
            cmd.Parameters.AddWithValue("@Fname", "")
            cmd.Parameters.AddWithValue("@Fsize", "")
            cmd.Parameters.AddWithValue("@Fbin", Data.SqlTypes.SqlBinary.Null)
            cmd.Parameters.AddWithValue("@Ftype", "")
            cmd.Parameters.AddWithValue("@Fultima", DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString())
            cmd.Parameters.AddWithValue("@Fultimamod", Session("username"))
            Conn.Open()
            cmd.ExecuteNonQuery()
            Conn.Close()
            cmd.Dispose()
            LabelInfoPhoto.Enabled = False
            LabelInfoPhoto.Attributes.Remove("onclick")
            DivisionBar.Visible = False
            LinkDeletePhoto.Visible = False
            LabelInfoPhoto.Font.Underline = False
            LabelInfoPhoto.Attributes.Add("style", "cursor:default")
            LabelInfoPhoto.Text = "Nessuna foto presente."
            ErrorMsg.Text = "Il file è stato eliminato"
            topmsg = ""

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/hwlog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("HWLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "DELIMGHW", Nothing)
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
        Else
            ErrorMsg.Text = ""
            topmsg = "nodelimg"
        End If
    End Sub

End Class
