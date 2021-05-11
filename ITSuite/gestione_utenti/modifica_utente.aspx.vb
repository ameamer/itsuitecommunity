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

Partial Class gestione_utenti_modifica_utente
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()
    Public iduser, matricola_utente, nome_utente, tipo_utente, dettagli_utente, database_utente,
         creato_da, ubicazione_utente, data_creazione, ora_creazione, note_utente, topmsg, stato_utente,
         cognome, nome, email, errmsg As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String41") & " | ITSuite by Ame Amer (admin@ameamer.com)"
        ButtonUploadPhoto.DataBind()

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If

        iduser = Request.QueryString("id")
        errmsg = Request.QueryString("err")

        Select Case errmsg
            Case "emptyfields"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String163")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
        End Select

        If Page.IsPostBack Then
            Diagnostics.Debug.WriteLine("è postback - " & Request("__EVENTVALIDATION"))
            ErrorMsg.Visible = True
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            ErrorMsg.Text = ""
            topmsg = ""
        End If

        Dim qrytop As String = "SELECT * FROM Utenti WHERE ID=" & CInt(iduser)
        Dim DbPathtop As String, Conntop As SqlConnection
        DbPathtop = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()
            matricola_utente = read.Item("matricola_utente").ToString
            nome_utente = read.Item("nomeutente").ToString
            tipo_utente = read.Item("tipo_utente").ToString
            dettagli_utente = read.Item("dettagli_utente").ToString
            database_utente = read.Item("database_utente").ToString
            creato_da = read.Item("creato_da").ToString
            ubicazione_utente = read.Item("ubicazione_utente").ToString
            data_creazione = read.Item("data_creazione_utente").ToString
            ora_creazione = read.Item("ora_creazione_utente").ToString
            note_utente = read.Item("note_utente").ToString
            stato_utente = read.Item("stato_utente").ToString
            cognome = read.Item("cognome").ToString
            nome = read.Item("nome").ToString
            email = read.Item("email").ToString
            If read.Item("FileName").ToString <> "" Then
                DivisionBar.Visible = True
                LabelInfoPhoto.Enabled = True
                LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & iduser & "', '', '');return false;")
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
        Conntop.Dispose()
        read.Close()
        cmdtop.Dispose()

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
            Dim qry As String = "UPDATE Utenti SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, data_modifica=@Fdata, ora_modifica=@Fora, autore_modifica=@Faut WHERE ID=" & CInt(iduser)
            Dim DbPath As String, Conn As SqlConnection
            DbPath = "../App_Data/itstdb.mdf"
            Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
            cmd.Parameters.AddWithValue("@Fname", "")
            cmd.Parameters.AddWithValue("@Fsize", "")
            cmd.Parameters.AddWithValue("@Fbin", Data.SqlTypes.SqlBinary.Null)
            cmd.Parameters.AddWithValue("@Ftype", "")
            cmd.Parameters.AddWithValue("@Fdata", DateTime.Now.ToLocalTime.ToShortDateString())
            cmd.Parameters.AddWithValue("@Fora", DateTime.Now.ToLongTimeString())
            cmd.Parameters.AddWithValue("@Faut", Session("username"))
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
            Dim xmlPath As String = "../App_Data/userslog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("USRLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "USRDELPHOTO", Nothing)
            xWr.DocumentElement.AppendChild(elem)
            Dim idelm As XmlElement = xWr.CreateElement("ID")
            idelm.InnerText = iduser
            elem.AppendChild(idelm)
            Dim usrelm As XmlElement = xWr.CreateElement("USER")
            usrelm.InnerText = nome_utente
            elem.AppendChild(usrelm)
            Dim userelm As XmlElement = xWr.CreateElement("USEREDITOR")
            userelm.InnerText = Session("username")
            elem.AppendChild(userelm)
            Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
            DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
            elem.AppendChild(DateTimeElm)
            xWr.Save(Server.MapPath(xmlPath))
        Else
            '  ErrorMsg.Text = ""
            topmsg = "nodelimg"
        End If
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
            Dim qry As String = "UPDATE Utenti SET FileName=@Fname, FileSize=@Fsize, BinaryData=@Fbin, ContentType=@Ftype, data_modifica=@Fdata, ora_modifica=@Fora, autore_modifica=@Faut WHERE ID=" & CInt(iduser)
            Dim DbPath As String, Conn As SqlConnection
            DbPath = "../App_Data/itstdb.mdf"
            Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
            cmd.Parameters.AddWithValue("@Fname", photoName)
            cmd.Parameters.AddWithValue("@Fsize", photoLength)
            cmd.Parameters.AddWithValue("@Fbin", photoData)
            cmd.Parameters.AddWithValue("@Ftype", photoMime)
            cmd.Parameters.AddWithValue("@Fdata", DateTime.Now.ToLocalTime.ToShortDateString())
            cmd.Parameters.AddWithValue("@Fora", DateTime.Now.ToLongTimeString())
            cmd.Parameters.AddWithValue("@Faut", Session("username"))
            Conn.Open()
            cmd.ExecuteNonQuery()

            DivisionBar.Visible = True
            LabelInfoPhoto.Enabled = True
            LabelInfoPhoto.Attributes.Add("style", "cursor:pointer")
            LabelInfoPhoto.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & iduser & "', '', '');return false;")
            LabelInfoPhoto.Font.Underline = True
            LabelInfoPhoto.Text = PhotoUpload.FileName & ", " & PhotoUpload.FileBytes.Length.ToString & " bytes."
            LinkDeletePhoto.ForeColor = Drawing.Color.Red
            LinkDeletePhoto.Text = globals.ResourceHelper.GetString("String147")
            LinkDeletePhoto.Visible = True
            Conn.Close()
            cmd.Dispose()
            ErrorMsg.Text = globals.ResourceHelper.GetString("String412")

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/userslog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("USRLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "USRADDPHOTO", Nothing)
            xWr.DocumentElement.AppendChild(elem)
            Dim idelm As XmlElement = xWr.CreateElement("ID")
            idelm.InnerText = iduser
            elem.AppendChild(idelm)
            Dim usrelm As XmlElement = xWr.CreateElement("USER")
            usrelm.InnerText = nome_utente
            elem.AppendChild(usrelm)
            Dim userelm As XmlElement = xWr.CreateElement("USEREDITOR")
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

End Class
