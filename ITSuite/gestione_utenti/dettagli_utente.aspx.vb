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

Partial Class gestione_utenti_dettagli_utente
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public iduser As String
    Public errormsg As String
    Public isedit As Boolean = False
    Public usertype As String
    Public actUser As String
    Public userdetailed As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String54") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        actUser = Session("username")
        iduser = Request.QueryString("id")
        errormsg = Request.QueryString("err")
        userdetailed = ""

        Select Case errormsg
            Case "errpswcompare"
                ErrorMsgText.Text = globals.ResourceHelper.GetString("String68")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                Exit Select
            Case "errpswlength"
                ErrorMsgText.Text = globals.ResourceHelper.GetString("String69")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                Exit Select
            Case "noerr"
                ErrorMsgText.Text = globals.ResourceHelper.GetString("String70")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                Exit Select
            Case "errpswactusr"
                ErrorMsgText.Text = globals.ResourceHelper.GetString("String71") & " (" & actUser & ")"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                Exit Select
        End Select

        ' Imposto SQL
        DetailsUserSqlSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
        DetailsUserSqlSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLDettaglioUserCommand()

        Select Case Session("Autenticato")
            Case "admin"
                Dim qrytop As String = ""
                Dim DbPathtop As String = "../App_Data/itstdb.mdf"
                Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                qrytop = "SELECT * FROM Utenti where ID=" & iduser
                Dim ConnectorDB As SqlConnection = New SqlConnection(connecttop)
                Dim SqlCom As SqlCommand = New SqlCommand(qrytop, ConnectorDB)
                ConnectorDB.Open()
                Dim read As SqlDataReader = SqlCom.ExecuteReader()
                While read.Read()
                    TitleNewAssign.Text = globals.ResourceHelper.GetString("String63") & ":<br /><font color='green'>" & read.Item("nomeutente").ToString & "</font>"
                    userdetailed = read.Item("nomeutente").ToString

                    ' Imposto dettagli
                    IdLabel.Text = "ID:&nbsp;<b>" & iduser & "</b>"
                    UsernameLabel.Text = globals.ResourceHelper.GetString("String47") & ":&nbsp;<b>" & read.Item("nomeutente") & "</b>"
                    CognomeLabel.Text = globals.ResourceHelper.GetString("String48") & ":&nbsp;<b>" & read.Item("cognome") & "</b>"
                    NomeLabel.Text = globals.ResourceHelper.GetString("String49") & ":&nbsp;<b>" & read.Item("nome") & "</b>"
                    EmailLabel.Text = globals.ResourceHelper.GetString("String50") & ":&nbsp;<b>" & read.Item("email") & "</b>"
                    TipoLabel.Text = globals.ResourceHelper.GetString("String51") & ":&nbsp;<b>" & read.Item("tipo_utente") & "</b>"

                    ' Imposto eventuale lingua
                    Select Case read.Item("lingua").ToString()
                        Case "IT"
                            DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67")})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano", .Selected = True})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English"})
                        Case "EN"
                            DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67")})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano"})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English", .Selected = True})

                        Case Else
                            DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67"), .Selected = True})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano"})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English"})
                    End Select

                    If Not IsDBNull(read.Item("autore_modifica").ToString) Then
                        If Not String.IsNullOrEmpty(read.Item("autore_modifica").ToString) Then
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String64"), .DataField = "autore_modifica"})
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String65"), .DataField = "data_modifica"})
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String66"), .DataField = "ora_modifica"})
                        End If
                    End If
                    If Not IsDBNull(read.Item("FileName").ToString) Then
                        If Not String.IsNullOrEmpty(read.Item("FileName").ToString) Then
                            Try
                                Dim pictureData As Byte() = DirectCast(read.Item("BinaryData"), Byte())
                                generalImage.Src = "data:image/jpg;base64," & Convert.ToBase64String(pictureData)
                                Aimage.NavigateUrl = "vedi_foto.aspx?id=" & iduser
                                Aimage.Target = "_blank"
                            Catch ex As Exception
                                Aimage.NavigateUrl = "#"
                                generalImage.Src = "../img/no-img-usr-200x200.png"
                            End Try
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String157"), .DataField = "FileName", .DataFormatString = "<a target='_blank' href='vedi_foto.aspx?id=" & iduser & "'>{0}</a>", .HtmlEncode = False})
                        Else
                            Aimage.NavigateUrl = "#"
                            generalImage.Src = "../img/no-img-usr-200x200.png"
                        End If
                    Else
                        Aimage.NavigateUrl = "#"
                        generalImage.Src = "../img/no-img-usr-200x200.png"
                    End If

                End While

                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()

            Case "personale"
                Dim qrytop As String = ""
                Dim DbPathtop As String = "../App_Data/itstdb.mdf"
                Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                qrytop = "SELECT * FROM Utenti where ID=" & iduser
                Dim ConnectorDB As SqlConnection = New SqlConnection(connecttop)
                Dim SqlCom As SqlCommand = New SqlCommand(qrytop, ConnectorDB)
                ConnectorDB.Open()
                Dim read As SqlDataReader = SqlCom.ExecuteReader()
                While read.Read()
                    If Session("Autenticato") = "personale" Then
                        If Session("username") <> read.Item("nomeutente").ToString Then
                            ConnectorDB.Close()
                            ConnectorDB.Dispose()
                            read.Close()
                            SqlCom.Dispose()
                            Response.Redirect("../logout.aspx")
                            Exit Sub
                        End If
                    End If

                    TitleNewAssign.Text = globals.ResourceHelper.GetString("String63") & ":<br /><font color='green'>" & read.Item("nomeutente").ToString & "</font>"
                    userdetailed = read.Item("nomeutente").ToString

                    ' Imposto dettagli
                    IdLabel.Text = "ID:&nbsp;<b>" & iduser & "</b>"
                    UsernameLabel.Text = globals.ResourceHelper.GetString("String47") & ":&nbsp;<b>" & read.Item("nomeutente") & "</b>"
                    CognomeLabel.Text = globals.ResourceHelper.GetString("String48") & ":&nbsp;<b>" & read.Item("cognome") & "</b>"
                    NomeLabel.Text = globals.ResourceHelper.GetString("String49") & ":&nbsp;<b>" & read.Item("nome") & "</b>"
                    EmailLabel.Text = globals.ResourceHelper.GetString("String50") & ":&nbsp;<b>" & read.Item("email") & "</b>"
                    TipoLabel.Text = globals.ResourceHelper.GetString("String51") & ":&nbsp;<b>" & read.Item("tipo_utente") & "</b>"

                    ' Imposto eventuale lingua
                    Select Case read.Item("lingua").ToString()
                        Case "IT"
                            DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67")})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano", .Selected = True})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English"})
                        Case "EN"
                            DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67")})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano"})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English", .Selected = True})

                        Case Else
                            DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67"), .Selected = True})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano"})
                            DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English"})
                    End Select

                    If Not IsDBNull(read.Item("autore_modifica").ToString) Then
                        If Not String.IsNullOrEmpty(read.Item("autore_modifica").ToString) Then
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String64"), .DataField = "autore_modifica"})
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String65"), .DataField = "data_modifica"})
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String66"), .DataField = "ora_modifica"})
                        End If
                    End If
                    If Not IsDBNull(read.Item("FileName").ToString) Then
                        If Not String.IsNullOrEmpty(read.Item("FileName").ToString) Then
                            Try
                                Dim pictureData As Byte() = DirectCast(read.Item("BinaryData"), Byte())
                                generalImage.Src = "data:image/jpg;base64," & Convert.ToBase64String(pictureData)
                                Aimage.NavigateUrl = "vedi_foto.aspx?id=" & iduser
                                Aimage.Target = "_blank"
                            Catch ex As Exception
                                Aimage.NavigateUrl = "#"
                                generalImage.Src = "../img/no-img-usr-200x200.png"
                            End Try
                            DetailsView1.Fields.Add(New BoundField With {.HeaderText = "Foto", .DataField = "FileName", .DataFormatString = "<a target='_blank' href='vedi_foto.aspx?id=" & iduser & "'>{0}</a>", .HtmlEncode = False})
                        Else
                            Aimage.NavigateUrl = "#"
                            generalImage.Src = "../img/no-img-usr-200x200.png"
                        End If
                    Else
                        Aimage.NavigateUrl = "#"
                        generalImage.Src = "../img/no-img-usr-200x200.png"
                    End If

                End While

                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()

            Case "cliente"
                If iduser = Session("user_id") Then
                    Dim qrytop As String = ""
                    Dim DbPathtop As String = "../App_Data/itstdb.mdf"
                    Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    qrytop = "SELECT * FROM Utenti where ID=" & iduser
                    Dim ConnectorDB As SqlConnection = New SqlConnection(connecttop)
                    Dim SqlCom As SqlCommand = New SqlCommand(qrytop, ConnectorDB)
                    ConnectorDB.Open()
                    Dim read As SqlDataReader = SqlCom.ExecuteReader()
                    While read.Read()
                        If Session("Autenticato") = "personale" Then
                            If Session("username") <> read.Item("nomeutente").ToString Then
                                ConnectorDB.Close()
                                ConnectorDB.Dispose()
                                read.Close()
                                SqlCom.Dispose()
                                Response.Redirect("../logout.aspx")
                                Exit Sub
                            End If
                        End If

                        TitleNewAssign.Text = globals.ResourceHelper.GetString("String63") & ":<br /><font color='green'>" & read.Item("nomeutente").ToString & "</font>"
                        userdetailed = read.Item("nomeutente").ToString

                        ' Imposto dettagli
                        IdLabel.Text = "ID:&nbsp;<b>" & iduser & "</b>"
                        UsernameLabel.Text = globals.ResourceHelper.GetString("String47") & ":&nbsp;<b>" & read.Item("nomeutente") & "</b>"
                        CognomeLabel.Text = globals.ResourceHelper.GetString("String48") & ":&nbsp;<b>" & read.Item("cognome") & "</b>"
                        NomeLabel.Text = globals.ResourceHelper.GetString("String49") & ":&nbsp;<b>" & read.Item("nome") & "</b>"
                        EmailLabel.Text = globals.ResourceHelper.GetString("String50") & ":&nbsp;<b>" & read.Item("email") & "</b>"
                        TipoLabel.Text = globals.ResourceHelper.GetString("String51") & ":&nbsp;<b>" & read.Item("tipo_utente") & "</b>"

                        ' Imposto eventuale lingua
                        Select Case read.Item("lingua").ToString()
                            Case "IT"
                                DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67")})
                                DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano", .Selected = True})
                                DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English"})
                            Case "EN"
                                DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67")})
                                DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano"})
                                DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English", .Selected = True})

                            Case Else
                                DropDownLangList.Items.Add(New ListItem With {.Value = "", .Text = globals.ResourceHelper.GetString("String67"), .Selected = True})
                                DropDownLangList.Items.Add(New ListItem With {.Value = "IT", .Text = "Italiano"})
                                DropDownLangList.Items.Add(New ListItem With {.Value = "EN", .Text = "English"})
                        End Select

                        If Not IsDBNull(read.Item("autore_modifica").ToString) Then
                            If Not String.IsNullOrEmpty(read.Item("autore_modifica").ToString) Then
                                DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String64"), .DataField = "autore_modifica"})
                                DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String65"), .DataField = "data_modifica"})
                                DetailsView1.Fields.Add(New BoundField With {.HeaderText = globals.ResourceHelper.GetString("String66"), .DataField = "ora_modifica"})
                            End If
                        End If
                        If Not IsDBNull(read.Item("FileName").ToString) Then
                            If Not String.IsNullOrEmpty(read.Item("FileName").ToString) Then
                                Try
                                    Dim pictureData As Byte() = DirectCast(read.Item("BinaryData"), Byte())
                                    generalImage.Src = "data:image/jpg;base64," & Convert.ToBase64String(pictureData)
                                    Aimage.NavigateUrl = "vedi_foto.aspx?id=" & iduser
                                    Aimage.Target = "_blank"
                                Catch ex As Exception
                                    Aimage.NavigateUrl = "#"
                                    generalImage.Src = "../img/no-img-usr-200x200.png"
                                End Try
                                DetailsView1.Fields.Add(New BoundField With {.HeaderText = "Foto", .DataField = "FileName", .DataFormatString = "<a target='_blank' href='vedi_foto.aspx?id=" & iduser & "'>{0}</a>", .HtmlEncode = False})
                            Else
                                Aimage.NavigateUrl = "#"
                                generalImage.Src = "../img/no-img-usr-200x200.png"
                            End If
                        Else
                            Aimage.NavigateUrl = "#"
                            generalImage.Src = "../img/no-img-usr-200x200.png"
                        End If

                    End While

                    ConnectorDB.Close()
                    ConnectorDB.Dispose()
                    read.Close()
                    SqlCom.Dispose()
                Else
                    Response.Redirect("../logout.aspx")
                End If

            Case Else
                Response.Redirect("../logout.aspx")
        End Select

    End Sub

    ''' <summary>
    ''' Si verifica al click su OK sulla schermata di cambio password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub OkNewPsw_Click(sender As Object, e As EventArgs)

        ' Verifico coerenza delle due password nuove
        If TextBoxNewPsw1.Text <> TextBoxNewPsw2.Text Then
            Response.Redirect("dettagli_utente.aspx?id=" & iduser & "&err=errpswcompare")
            Response.End()
            Exit Sub
        End If

        ' Verifico criteri di lunghezza
        If TextBoxNewPsw1.Text.Length < 8 Then
            Response.Redirect("dettagli_utente.aspx?id=" & iduser & "&err=errpswlength")
            Response.End()
            Exit Sub
        End If

        ' Controllo password utente
        Dim passActUser As String = TextBoxActUserPsw.Text
        Dim pass_sha256_ActUser As String = ""
        Dim pass_sha256_ActUser_srv As String = ""
        Using sha256hash As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
            Dim datasha256 As Byte() = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(passActUser))
            Dim sBuilder As New StringBuilder()
            Dim i As Integer
            For i = 0 To datasha256.Length - 1
                sBuilder.Append(datasha256(i).ToString("x2"))
            Next i
            Dim hash As String = sBuilder.ToString()
            pass_sha256_ActUser = hash
        End Using
        Dim qrytop As String = ""
        Dim DbPathtop As String = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM Utenti where nomeutente='" & actUser & "'"
        Dim ConnectorDB As SqlConnection = New SqlConnection(connecttop)
        Dim SqlCom As SqlCommand = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        While read.Read()
            pass_sha256_ActUser_srv = read.Item("password").ToString
        End While
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        read.Close()
        SqlCom.Dispose()

        If pass_sha256_ActUser_srv <> pass_sha256_ActUser Then
            Response.Redirect("dettagli_utente.aspx?id=" & iduser & "&err=errpswactusr")
            Response.End()
            Exit Sub
        End If

        ' Ricavo e imposto hash md5 della password
        Dim pass As String = TextBoxNewPsw1.Text
        Dim pass_sha256 As String
        Using sha256hash As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
            Dim datasha256 As Byte() = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(pass))
            Dim sBuilder As New StringBuilder()
            Dim i As Integer
            For i = 0 To datasha256.Length - 1
                sBuilder.Append(datasha256(i).ToString("x2"))
            Next i
            Dim hash As String = sBuilder.ToString()
            pass_sha256 = hash
        End Using

        ' Aggiorno password sul db
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()

        qrytop = "UPDATE Utenti SET data_modifica='" & data & "', ora_modifica='" & ora & "', autore_modifica='" & Session("username") & "', password='" & pass_sha256 & "'"
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        SqlCom.ExecuteNonQuery()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/userslog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("USRLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "USRCHGPSW", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = iduser
        elem.AppendChild(idelm)
        Dim usrelm As XmlElement = xWr.CreateElement("USER")
        usrelm.InnerText = userdetailed
        elem.AppendChild(usrelm)
        Dim userelm As XmlElement = xWr.CreateElement("USEREDITOR")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_utente.aspx?id=" & iduser & "&err=noerr")
    End Sub

    ''' <summary>
    ''' Si verifica al click su "Salva" nella sezione "Lingua".
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ButtonSaveLang_Click(sender As Object, e As EventArgs)
        Dim qrytop As String = ""
        Dim DbPathtop As String = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "UPDATE Utenti SET lingua='" & DropDownLangList.SelectedItem().Value & "' WHERE ID=" & iduser
        Dim ConnectorDB As SqlConnection = New SqlConnection(connecttop)
        Dim SqlCom As SqlCommand = New SqlCommand(qrytop, ConnectorDB)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        SqlCom.ExecuteNonQuery()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()

        If iduser = Session("user_id") Then
            Select Case DropDownLangList.SelectedItem().Value
                Case ""
                    Session("lingua") = System.Globalization.RegionInfo.CurrentRegion.Name
                Case "IT"
                    Session("lingua") = "IT"
                Case "EN"
                    Session("lingua") = "EN"
            End Select
        End If

        Response.Redirect("dettagli_utente.aspx?id=" & iduser)
        Response.End()
    End Sub

    ''' <summary>
    ''' Si verifica alla creazione dell'elemento dei dettagli dell'utente.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DetailsView1_DataBound(sender As Object, e As EventArgs)
        Dim detvw As DetailsView = sender
        Dim headerRow As DetailsViewRow = detvw.HeaderRow

        detvw.Fields.Item(0).HeaderText = globals.ResourceHelper.GetString("String53")
        detvw.Fields.Item(1).HeaderText = globals.ResourceHelper.GetString("String54")
        detvw.Fields.Item(2).HeaderText = globals.ResourceHelper.GetString("String55")
        detvw.Fields.Item(3).HeaderText = globals.ResourceHelper.GetString("String56")
        detvw.Fields.Item(4).HeaderText = globals.ResourceHelper.GetString("String57")
        detvw.Fields.Item(5).HeaderText = globals.ResourceHelper.GetString("String58")
        detvw.Fields.Item(6).HeaderText = globals.ResourceHelper.GetString("String59")
        detvw.Fields.Item(7).HeaderText = globals.ResourceHelper.GetString("String60")
        detvw.Fields.Item(8).HeaderText = globals.ResourceHelper.GetString("String61")

    End Sub
End Class
