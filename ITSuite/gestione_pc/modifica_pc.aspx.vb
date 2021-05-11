'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports ITSuite_Listing
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class gestione_pc_modifica_pc
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    Public id_pc As String
    Private topmsg As String
    Public cartella, marca_pc, modello_pc, dominio_pc, nome_pc, anno_pc,
        serie_pc, inv_pc, so_pc, stato_pc, ram_pc, proc_pc, stanza_pc, piano_pc, reparto_pc, pad_pc, presidio_pc,
        sw_pc, tipo_pc, note_pc, ip_pc, marca_video_pc, mod_video_pc, pollici_video_pc, inv_video_pc, serie_video_pc,
        stato_video_pc, anno_video_pc, note_video_pc, id_stampante_collegata, id_altrohw_collegato As String
    Public username As String


    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String414") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        id_pc = Request.QueryString("id_pc")
        username = Session("username")

        If Page.IsPostBack Then
            Diagnostics.Debug.WriteLine("è postback - " & Request("__EVENTVALIDATION"))
            ErrorMsg.Visible = True
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            ErrorMsg.Text = ""
            topmsg = ""
        End If

        Dim qrytop As String = "SELECT * FROM datapc WHERE ID=" & CInt(id_pc)
        Dim DbPathtop As String, Conntop As SqlConnection
        DbPathtop = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()
            cartella = read.Item("cartella_pc").ToString
            marca_pc = read.Item("marca_pc").ToString
            modello_pc = read.Item("modello_pc").ToString
            dominio_pc = read.Item("dominio_pc").ToString
            nome_pc = read.Item("nome_dominio_pc").ToString
            serie_pc = read.Item("serie_pc").ToString
            inv_pc = read.Item("inventario_pc").ToString
            piano_pc = read.Item("piano_pc").ToString
            reparto_pc = read.Item("reparto_pc").ToString
            stanza_pc = read.Item("stanza_pc").ToString
            pad_pc = read.Item("padiglione_pc").ToString
            presidio_pc = read.Item("presidio_pc").ToString
            so_pc = read.Item("so_pc").ToString
            ram_pc = read.Item("ram_pc").ToString
            proc_pc = read.Item("processore_pc").ToString
            ip_pc = read.Item("indirizzo_ip_pc").ToString
            sw_pc = read.Item("swprivate_pc").ToString
            note_pc = read.Item("note_pc").ToString
            stato_pc = read.Item("stato_pc").ToString
            anno_pc = read.Item("anno_pc").ToString
            tipo_pc = read.Item("tipo_pc").ToString
            marca_video_pc = read.Item("marca_video_pc").ToString
            mod_video_pc = read.Item("modello_video_pc").ToString
            pollici_video_pc = read.Item("pollici_video_pc").ToString
            inv_video_pc = read.Item("inventario_video_pc").ToString
            serie_video_pc = read.Item("serie_video_pc").ToString
            note_video_pc = read.Item("note_video_pc").ToString
            stato_video_pc = read.Item("stato_video_pc").ToString
            anno_video_pc = read.Item("anno_video_pc").ToString
            id_stampante_collegata = read.Item("id_stampante_collegata").ToString
            id_altrohw_collegato = read.Item("id_altrohw_collegato").ToString

            If Not String.IsNullOrEmpty(read.Item("FileName").ToString) Then
                DivisionBar.Visible = True
                LabelInfoPhoto.Enabled = True
                LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_pc & "', '', '');return false;")
                LabelInfoPhoto.Attributes.Add("style", "cursor:pointer")
                LabelInfoPhoto.Font.Underline = True
                LabelInfoPhoto.Text = read.Item("FileName").ToString & ", " & read.Item("FileSize").ToString & " bytes."
                LinkDeletePhoto.ForeColor = Drawing.Color.Red
                LinkDeletePhoto.Text = "Elimina"
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
        Conntop.Dispose()
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
            Dim qry As String = "UPDATE datapc SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, dataora_ultimapc=@Fultimadataora, autore_ultimapc=@Fautore WHERE ID=" & CInt(id_pc)
            Dim DbPath As String, Conn As SqlConnection
            DbPath = "../App_Data/itstdb.mdf"
            Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
            cmd.Parameters.AddWithValue("@Fname", photoName)
            cmd.Parameters.AddWithValue("@Fsize", photoLength)
            cmd.Parameters.AddWithValue("@Fbin", photoData)
            cmd.Parameters.AddWithValue("@Ftype", photoMime)
            cmd.Parameters.AddWithValue("@Fultimadataora", DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString())
            cmd.Parameters.AddWithValue("@Fautore", Session("username"))
            Conn.Open()
            cmd.ExecuteNonQuery()
            Diagnostics.Debug.WriteLine("File immagine caricato. ID PC: " & id_pc)
            DivisionBar.Visible = True
            LabelInfoPhoto.Enabled = True
            LabelInfoPhoto.Attributes.Add("style", "cursor:pointer")
            LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_pc & "', '', '');return false;")
            LabelInfoPhoto.Font.Underline = True
            LabelInfoPhoto.Text = PhotoUpload.FileName & ", " & PhotoUpload.FileBytes.Length.ToString & " bytes."
            LinkDeletePhoto.ForeColor = Drawing.Color.Red
            LinkDeletePhoto.Text = "Elimina"
            LinkDeletePhoto.Visible = True
            Conn.Close()
            cmd.Dispose()
            ErrorMsg.Text = globals.ResourceHelper.GetString("String412")

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/pclog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("PCLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "ADDIMGPC", Nothing)
            xWr.DocumentElement.AppendChild(elem)
            Dim idelm As XmlElement = xWr.CreateElement("ID")
            idelm.InnerText = id_pc
            elem.AppendChild(idelm)
            Dim snelm As XmlElement = xWr.CreateElement("SN")
            snelm.InnerText = Request("serie_pc")
            elem.AppendChild(snelm)
            Dim userelm As XmlElement = xWr.CreateElement("USER")
            userelm.InnerText = Session("username")
            elem.AppendChild(userelm)
            Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
            DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
            elem.AppendChild(DateTimeElm)
            xWr.Save(Server.MapPath(xmlPath))
        Else
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
        If confirm_val = "Yes" Then
            Dim qry As String = "UPDATE datapc SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, dataora_ultimapc=@Fultimadataora, autore_ultimapc=@Fautore WHERE ID=" & CInt(id_pc)
            Dim DbPath As String, Conn As SqlConnection
            DbPath = "../App_Data/itstdb.mdf"
            Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
            cmd.Parameters.AddWithValue("@Fname", "")
            cmd.Parameters.AddWithValue("@Fsize", "")
            cmd.Parameters.AddWithValue("@Fbin", Data.SqlTypes.SqlBinary.Null)
            cmd.Parameters.AddWithValue("@Ftype", "")
            cmd.Parameters.AddWithValue("@Fultimadataora", DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString())
            cmd.Parameters.AddWithValue("@Fautore", Session("username"))
            Conn.Open()
            cmd.ExecuteNonQuery()
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()
            LabelInfoPhoto.Enabled = False
            LabelInfoPhoto.Attributes.Remove("onclick")
            DivisionBar.Visible = False
            LinkDeletePhoto.Visible = False
            LabelInfoPhoto.Font.Underline = False
            LabelInfoPhoto.Attributes.Add("style", "cursor:default")
            LabelInfoPhoto.Text = "Nessuna foto presente."
            ErrorMsg.Text = globals.ResourceHelper.GetString("String413")
            topmsg = ""

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/pclog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("PCLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "DELIMGPC", Nothing)
            xWr.DocumentElement.AppendChild(elem)
            Dim idelm As XmlElement = xWr.CreateElement("ID")
            idelm.InnerText = id_pc
            elem.AppendChild(idelm)
            Dim snelm As XmlElement = xWr.CreateElement("SN")
            snelm.InnerText = Request("serie_pc")
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
