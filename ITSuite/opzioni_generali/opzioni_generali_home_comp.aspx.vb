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
Imports System.IO
Imports Ionic.Zip
Imports System.Collections.Generic

Partial Class opzioni_generali_opzioni_generali_home_comp
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public swtname As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String103") & " | ITSuite by Ame Amer (admin@ameamer.com)"
        ButtonUploadAddOn.DataBind()

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If
        TitleInstallAddOn.Text = globals.ResourceHelper.GetString("String664")

        Dim r As String = Request.QueryString("r")
        Select Case r
            Case "ok"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String665")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)

            Case "errfile"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String666")
                ErrorMsg.Visible = True
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)

            Case "errinst"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String667")
                ErrorMsg.Visible = True
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)

            Case "erralrinst"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String668")
                ErrorMsg.Visible = True
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)

            Case "uninstok"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String669")
                ErrorMsg.Visible = True
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
        End Select

        ' Componenti aggiuntivi installati
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            connect As String = "", ConnectorDB As SqlConnection, SqlCom As SqlCommand, count As Integer = 0
        LabelAddsOnInstalled.Text = ""
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM comp ORDER BY name ASC"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        While read.Read()
            count = count + 1
            Dim isfortktusrs As String
            Dim securityInfo As String
            If read.Item("securitypass").ToString = "yes" Then
                securityInfo = "</b><br /><font style='font-size:small; color:green;'><b>" & globals.ResourceHelper.GetString("String670") & "</b></font>"
            Else
                securityInfo = "</b><br /><font style='font-size:small; color:red;'><b>" & globals.ResourceHelper.GetString("String671") & "</b></font>"
            End If

            If read.Item("tktusers").ToString = "1" And read.Item("customerusers").ToString = "0" Then
                isfortktusrs = "</b><br /><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String676") & ": <b>" & globals.ResourceHelper.GetString("String672") & "</b></font>"
            End If
            If read.Item("customerusers").ToString = "1" And read.Item("tktusers").ToString = "0" Then
                isfortktusrs = "</b><br /><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String676") & ": <b>" & globals.ResourceHelper.GetString("String673") & "</b></font>"
            End If
            If read.Item("customerusers").ToString = "1" And read.Item("tktusers").ToString = "1" Then
                isfortktusrs = "</b><br /><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String676") & ": <b>" & globals.ResourceHelper.GetString("String674") & "</b></font>"
            End If
            If read.Item("customerusers").ToString <> "1" And read.Item("tktusers").ToString <> "1" Then
                isfortktusrs = "</b><br /><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String676") & ": <b>" & globals.ResourceHelper.GetString("String675") & "</b></font>"
            End If
            If count > 1 Then
                LabelAddsOnInstalled.Text = LabelAddsOnInstalled.Text & "<div style='width:100%; padding-bottom:15px; padding-top:12px; border-bottom:1px solid lightgray;'><b>" & read.Item("name").ToString & securityInfo & isfortktusrs & "</b><br/><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String677") & " <b>" & read.Item("tname").ToString & "</b></font><br/><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String678") & " <b>" & read.Item("dev").ToString & "</b><br />" & globals.ResourceHelper.GetString("String679") & " <b><a href='" & read.Item("devaddr").ToString & "' target='_blank' style='color:gray;'>" & read.Item("devaddr").ToString & "</a></b></font><br /><font style='color:red'><a onclick='if (confirm(""" & globals.ResourceHelper.GetString("String680") & """)) location.href=""../Components/uninst.aspx?n=" & read.Item("ID").ToString & """;' href='#' style='color:red; font-size:small;'>" & globals.ResourceHelper.GetString("String681") & "</a></font></div>"
            Else
                LabelAddsOnInstalled.Text = LabelAddsOnInstalled.Text & "<div style='width:100%; padding-bottom:15px;border-bottom:1px solid lightgray;'><b>" & read.Item("name").ToString & securityInfo & isfortktusrs & "</b><br/><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String677") & " <b>" & read.Item("tname").ToString & "</b></font><br/><font style='font-size:small; color:gray;'>" & globals.ResourceHelper.GetString("String678") & " <b>" & read.Item("dev").ToString & "</b><br />" & globals.ResourceHelper.GetString("String679") & " <b><a href='" & read.Item("devaddr").ToString & "' target='_blank' style='color:gray;'>" & read.Item("devaddr").ToString & "</a></b></font><br /><font style='color:red'><a onclick='if (confirm(""" & globals.ResourceHelper.GetString("String680") & """)) location.href=""../Components/uninst.aspx?n=" & read.Item("ID").ToString & """;' href='#' style='color:red; font-size:small;'>" & globals.ResourceHelper.GetString("String681") & "</a></font></div>"
            End If
        End While
        read.Close()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()

        If count = 0 Then
            LabelAddsOnInstalled.Text = globals.ResourceHelper.GetString("String682")
        End If

    End Sub

    ''' <summary>
    ''' Si verifica al click su "Carica" di un nuovo componente aggiuntivo.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ButtonUploadAddOn_Click(sender As Object, e As EventArgs)
        Dim qrytop As String = "", DbPathtop As String = "../App_Data/itstdb.mdf", connecttop As String = "", xmlname As String = Guid.NewGuid().ToString,
            dev As String = "", devaddr As String = "", files As String = "", installpath As String = "", tktusrs As String = "", customerusers As String = "",
            securitypass As String = ""

        Dim filesar As String() = {}

        If AddOnUpload.HasFile Then
            Try
                Dim extractPath As String = Server.MapPath("../temp/")
                Using zip As ZipFile = ZipFile.Read(AddOnUpload.PostedFile.InputStream)
                    zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently)
                End Using

                Dim lbl As New Label, name As String = "", link As String = ""
                Dim xmlDoc As New XmlDocument
                Dim ArticleNodeList As XmlNodeList
                Dim newFInfo As New FileInfo(AddOnUpload.PostedFile.FileName)
                Dim fnm As String = newFInfo.Name
                Dim xmlPath As String = "../temp/" & fnm.Split(".")(0) & ".xml"
                xmlDoc.Load(Server.MapPath(xmlPath))
                ArticleNodeList = xmlDoc.ChildNodes
                For Each articlenode As XmlNode In ArticleNodeList

                    If articlenode.Name = "ITSUITECOMPONENT" Then
                        For Each articlenode2 As XmlNode In articlenode
                            If articlenode2.Name = "PACKET" Then
                                For Each basenode As XmlNode In articlenode2
                                    If basenode.Name = "NAME" Then
                                        For Each Node As XmlNode In basenode
                                            name = Node.InnerText
                                        Next
                                    End If

                                    If basenode.Name = "LINK" Then
                                        For Each Node As XmlNode In basenode
                                            link = Node.InnerText
                                        Next
                                    End If

                                    If basenode.Name = "DEV" Then
                                        For Each Node As XmlNode In basenode
                                            dev = Node.InnerText
                                        Next
                                    End If

                                    If basenode.Name = "FILES" Then
                                        For Each Node As XmlNode In basenode
                                            files = New String(Node.InnerText.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
                                        Next
                                    End If

                                    If basenode.Name = "INSTALLPATH" Then
                                        For Each Node As XmlNode In basenode
                                            installpath = Node.InnerText
                                        Next
                                    End If

                                    If basenode.Name = "TICKETUSERS" Then
                                        For Each Node As XmlNode In basenode
                                            tktusrs = Node.InnerText
                                        Next
                                    End If

                                    If basenode.Name = "CUSTOMERUSERS" Then
                                        For Each Node As XmlNode In basenode
                                            customerusers = Node.InnerText
                                        Next
                                    End If

                                    If basenode.Name = "DEVADDRESS" Then
                                        For Each Node As XmlNode In basenode
                                            devaddr = Node.InnerText
                                        Next
                                    End If

                                Next
                            End If
                        Next
                    End If
                Next

                filesar = files.Split("|")
                For i As Integer = 0 To filesar.Length - 1
                    IO.File.Copy(Server.MapPath("../temp/" & filesar(i)), Server.MapPath("../Components/" & filesar(i)), True)
                Next

                For i As Integer = 0 To filesar.Length - 1
                    Dim textfileComp As New FileInfo(Server.MapPath("../temp/" & filesar(i)))
                    Dim stringReader As String

                    Using reader As StreamReader = textfileComp.OpenText()
                        stringReader = reader.ReadToEnd()
                    End Using

                    If stringReader.Contains("Session(") Then
                        securitypass = "no"
                        Exit For
                    Else
                        securitypass = "yes"
                    End If
                Next

                Dim qry As String = "", DbPath As String = "", connect As String = "", ConnectorDB As SqlConnection, SqlCom As SqlCommand, count As Integer = 0
                LabelAddsOnInstalled.Text = ""
                qrytop = ""
                DbPathtop = "../App_Data/itstdb.mdf"
                connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                qrytop = "SELECT * FROM comp WHERE name='" & name & "' ORDER BY name ASC"
                ConnectorDB = New SqlConnection(connecttop)
                SqlCom = New SqlCommand(qrytop, ConnectorDB)
                ConnectorDB.Open()
                Dim read As SqlDataReader = SqlCom.ExecuteReader()
                If read.Read() Then
                    For i As Integer = 0 To filesar.Length - 1
                        IO.File.Delete(Server.MapPath("../temp/" & filesar(i)))
                    Next

                    read.Close()
                    ConnectorDB.Close()
                    ConnectorDB.Dispose()
                    SqlCom.Dispose()
                    Response.Redirect("opzioni_generali_home_comp.aspx?r=erralrinst", False)
                    Context.ApplicationInstance.CompleteRequest()
                    Exit Sub
                End If
                read.Close()
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                SqlCom.Dispose()

                connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)

                Using da As New SqlDataAdapter("SELECT * FROM comp ORDER BY ID DESC", connecttop),
                    cb As New SqlCommandBuilder(da)

                    Dim ds As New DataSet
                    da.Fill(ds, "comp")

                    Dim NewRow As DataRow = ds.Tables("comp").NewRow()
                    NewRow.Item(1) = name
                    NewRow.Item(2) = dev
                    NewRow.Item(3) = link
                    NewRow.Item(4) = devaddr
                    NewRow.Item(5) = installpath
                    NewRow.Item(6) = tktusrs
                    NewRow.Item(7) = customerusers
                    NewRow.Item(8) = securitypass

                    ds.Tables("comp").Rows.Add(NewRow)
                    da.UpdateCommand = cb.GetUpdateCommand
                    da.InsertCommand = cb.GetInsertCommand
                    da.DeleteCommand = cb.GetDeleteCommand
                    da.Update(ds, "comp")

                    da.Dispose()
                    cb.Dispose()
                    ds.Dispose()
                End Using

            Catch ex As Exception
                For i As Integer = 0 To filesar.Length - 1
                    IO.File.Delete(Server.MapPath("../Components/" & filesar(i)))
                    IO.File.Delete(Server.MapPath("../temp/" & filesar(i)))
                Next
                Response.Redirect("opzioni_generali_home_comp.aspx?r=errinst", False)
                Context.ApplicationInstance.CompleteRequest()
                Exit Sub
            End Try
            For i As Integer = 0 To filesar.Length - 1
                IO.File.Delete(Server.MapPath("../temp/" & filesar(i)))
            Next
            Response.Redirect("opzioni_generali_home_comp.aspx?r=ok", False)
            Context.ApplicationInstance.CompleteRequest()
            Exit Sub

        Else
            For i As Integer = 0 To filesar.Length - 1
                IO.File.Delete(Server.MapPath("../Components/" & filesar(i)))
                IO.File.Delete(Server.MapPath("../temp/" & filesar(i)))
            Next
            Response.Redirect("opzioni_generali_home_comp.aspx?r=errfile", False)
            Context.ApplicationInstance.CompleteRequest()
            Exit Sub

        End If
    End Sub

End Class
