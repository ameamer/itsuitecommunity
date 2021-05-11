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

Partial Class gestione_stampanti_modifica_stampante
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' L'id della stampante selezionata.
    ''' </summary>
    Public id_stamp, cartella_stampante, marca_stampante, modello_stampante, numero_serie_stampante, inventario_stampante, anno_stampante, ip_stampante,
        stato_stampante, note_stampante, reparto_stampante, padiglione_stampante, presidio_stampante, actUser As String
    Private Shared topmsg As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String440") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        ButtonUploadPhoto.DataBind()

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

        id_stamp = Request.QueryString("id_stamp")
        actUser = Session("username")

        If Page.IsPostBack Then
            Diagnostics.Debug.WriteLine("è postback - " & Request("__EVENTVALIDATION"))
            ErrorMsg.Visible = True
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            ErrorMsg.Text = ""
            topmsg = ""
        End If

        Dim qrytop As String = "SELECT * FROM stampanti WHERE ID=" & CInt(id_stamp)
        Dim DbPathtop As String, Conntop As SqlConnection
        DbPathtop = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()
            cartella_stampante = read.Item("cartella_stampante").ToString
            marca_stampante = read.Item("marca_stampante").ToString
            modello_stampante = read.Item("modello_stampante").ToString
            numero_serie_stampante = read.Item("numero_serie_stampante").ToString
            inventario_stampante = read.Item("inventario_stampante").ToString
            anno_stampante = read.Item("anno_stampante").ToString
            ip_stampante = read.Item("ip_stampante").ToString
            stato_stampante = read.Item("stato_stampante").ToString
            note_stampante = read.Item("note_stampante").ToString
            reparto_stampante = read.Item("reparto_stampante").ToString
            padiglione_stampante = read.Item("padiglione_stampante").ToString
            presidio_stampante = read.Item("presidio_stampante").ToString

            If read.Item("FileName").ToString <> "" Then
                DivisionBar.Visible = True
                LabelInfoPhoto.Enabled = True
                LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_stamp & "', '', '');return false;")
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
                    ErrorMsg.Text = globals.ResourceHelper.GetString("String410") & " - " & ext & "<br />" & globals.ResourceHelper.GetString("String411") & " .jpg, .jpeg, .png, .gif"
                    Exit Sub
            End Select
            Dim photoStream As Stream = PhotoUpload.PostedFile.InputStream
            Dim photoLength As Integer = PhotoUpload.PostedFile.ContentLength
            Dim photoMime As String = PhotoUpload.PostedFile.ContentType
            Dim photoName As String = Path.GetFileName(PhotoUpload.PostedFile.FileName)
            Dim photoData As Byte() = New Byte(photoLength - 1) {}
            photoStream.Read(photoData, 0, photoLength)
            Dim qry As String = "UPDATE stampanti SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, ultimamod_stampante=@Fultima, autoreultimamod_stampante=@Fautore WHERE ID=" & CInt(id_stamp)
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
            cmd.Parameters.AddWithValue("@Fautore", Session("username"))
            Conn.Open()
            cmd.ExecuteNonQuery()
            Diagnostics.Debug.WriteLine("caricato " & id_stamp)
            DivisionBar.Visible = True
            LabelInfoPhoto.Enabled = True
            LabelInfoPhoto.Attributes.Add("style", "cursor:pointer")
            LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_stamp & "', '', '');return false;")
            LabelInfoPhoto.Font.Underline = True
            LabelInfoPhoto.Text = PhotoUpload.FileName & ", " & PhotoUpload.FileBytes.Length.ToString & " bytes."
            LinkDeletePhoto.ForeColor = Drawing.Color.Red
            LinkDeletePhoto.Text = "Elimina"
            LinkDeletePhoto.Visible = True
            Conn.Close()
            cmd.Dispose()
            ErrorMsg.Text = globals.ResourceHelper.GetString("String412")

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/stamplog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("STAMPLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "ADDIMGSTAMP", Nothing)
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
        Else
            Diagnostics.Debug.WriteLine("messaggio non caricato ok --> " & id_stamp)
            ErrorMsg.Text = globals.ResourceHelper.GetString("String172")
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
            Dim qry As String = "UPDATE stampanti SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, ultimamod_stampante=@Fultima, autoreultimamod_stampante=@Fautore WHERE ID=" & CInt(id_stamp)
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
            cmd.Parameters.AddWithValue("@Fautore", Session("username"))
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
            LabelInfoPhoto.Text = globals.ResourceHelper.GetString("String152")
            ErrorMsg.Text = globals.ResourceHelper.GetString("String413")
            topmsg = ""

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/stamplog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("STAMPLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "DELIMGSTAMP", Nothing)
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
        Else
            ErrorMsg.Text = ""
            topmsg = "nodelimg"
        End If
    End Sub

End Class
