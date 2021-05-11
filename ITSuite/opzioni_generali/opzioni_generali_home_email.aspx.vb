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

Partial Class opzioni_generali_opzioni_generali_home_email
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String686") & " | ITSuite by Ame Amer (admin@ameamer.com)"
        chckenable.DataBind()
        ButtonSrvMail.DataBind()
        ButtonMsgMail.DataBind()

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If

        If Not IsPostBack Then

            Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            connect As String = "", ConnectorDB As SqlConnection, SqlCom As SqlCommand, count As Integer = 0
            qrytop = ""
            DbPathtop = "../App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = "SELECT * FROM impostazionigenerali"
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            Dim read As SqlDataReader = SqlCom.ExecuteReader()
            While read.Read()
                If read.Item("emailenabled").ToString IsNot DBNull.Value And String.IsNullOrEmpty(read.Item("emailenabled").ToString) = False Then
                    If read.Item("emailenabled").ToString = "1" Then
                        username.Text = read.Item("usermail").ToString
                        password.Text = read.Item("pswmail").ToString
                        mailsrvaddr.Text = read.Item("srvmail").ToString
                        mailsrvport.Text = read.Item("portmail").ToString
                        intestmail.Text = read.Item("intmail").ToString
                        closemail.Text = read.Item("endmail").ToString
                        mittentemail.Text = read.Item("mittentemail").ToString
                        If read.Item("sslmail").ToString = "True" Then
                            SSLcheckbox.Checked = True
                        Else
                            SSLcheckbox.Checked = False
                        End If
                        emailpanel.Visible = True
                        chckenable.Checked = True
                    Else
                        emailpanel.Visible = False
                    End If
                Else
                    emailpanel.Visible = False
                End If

            End While
            read.Close()
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            SqlCom.Dispose()

        End If
    End Sub

    ''' <summary>
    ''' Si verifica al cambio del check della checkbox di abilitazione e-mail.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub chckenable_CheckedChanged(sender As Object, e As EventArgs)
        If chckenable.Checked Then
            Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            connect As String = "", count As Integer = 0
            qrytop = ""
            DbPathtop = "../App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = "SELECT * FROM impostazionigenerali"

            Using da As New SqlDataAdapter(qrytop, connecttop),
            cb As New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.Fill(ds, "impostazionigenerali")
                Dim Row As DataRow = ds.Tables("impostazionigenerali").Rows.Item(0)
                Row.Item(58) = "1"
                da.UpdateCommand = cb.GetUpdateCommand
                da.Update(ds, "impostazionigenerali")
                da.Dispose()
                cb.Dispose()
                ds.Dispose()
            End Using

            emailpanel.Visible = True
            Session("emailenabled") = "1"

        Else
            Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            connect As String = "", count As Integer = 0
            qrytop = ""
            DbPathtop = "../App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = "SELECT * FROM impostazionigenerali"

            Using da As New SqlDataAdapter(qrytop, connecttop),
            cb As New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.Fill(ds, "impostazionigenerali")
                Dim Row As DataRow = ds.Tables("impostazionigenerali").Rows.Item(0)
                Row.Item(58) = "0"
                da.UpdateCommand = cb.GetUpdateCommand
                da.Update(ds, "impostazionigenerali")
                da.Dispose()
                cb.Dispose()
                ds.Dispose()
            End Using

            emailpanel.Visible = False
            Session("emailenabled") = "0"
        End If
    End Sub

    ''' <summary>
    ''' Salva impostazioni e-mail
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ButtonSrvMail_Click(sender As Object, e As EventArgs)
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
          connect As String = "", count As Integer = 0
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM impostazionigenerali"
        Using da As New SqlDataAdapter(qrytop, connecttop),
        cb As New SqlCommandBuilder(da)
            Dim ds As New DataSet
            da.Fill(ds, "impostazionigenerali")
            Dim Row As DataRow = ds.Tables("impostazionigenerali").Rows.Item(0)
            Row.Item(51) = username.Text
            Row.Item(52) = password.Text
            Row.Item(53) = mailsrvaddr.Text
            Row.Item(54) = mailsrvport.Text
            Row.Item(55) = SSLcheckbox.Checked.ToString
            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "impostazionigenerali")
            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        Session("utentemail") = username.Text
        Session("passwordmail") = password.Text
        Session("servermail") = mailsrvaddr.Text
        Session("portamail") = mailsrvport.Text
        Session("sslmail") = SSLcheckbox.Checked.ToString

    End Sub

    ''' <summary>
    ''' Salva impostazioni servizio e-mail.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ButtonMsgMail_Click(sender As Object, e As EventArgs)
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
        connect As String = "", count As Integer = 0
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM impostazionigenerali"

        Using da As New SqlDataAdapter(qrytop, connecttop),
        cb As New SqlCommandBuilder(da)
            Dim ds As New DataSet
            da.Fill(ds, "impostazionigenerali")
            Dim Row As DataRow = ds.Tables("impostazionigenerali").Rows.Item(0)
            Row.Item(56) = intestmail.Text
            Row.Item(57) = closemail.Text
            Row.Item(59) = mittentemail.Text
            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "impostazionigenerali")
            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        Session("intromail") = intestmail.Text
        Session("endmail") = closemail.Text
        Session("mittentemail") = mittentemail.Text

    End Sub

    Protected Sub TestMailButton_Click(sender As Object, e As EventArgs)
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            connect As String = "", ConnectorDB As SqlConnection, SqlCom As SqlCommand, count As Integer = 0
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)

        Dim read As SqlDataReader

        ' Recupero destinatari mail di notifica
        Dim emails As New Net.Mail.MailAddressCollection

        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM email"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        read = SqlCom.ExecuteReader()
        While read.Read()
            emails.Add(New Net.Mail.MailAddress(read.Item("mail").ToString))
        End While
        read.Close()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()

        ' Invio e-mail ai destinatari rilevati
        qrytop = "SELECT * FROM impostazionigenerali"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        read = SqlCom.ExecuteReader()
        While read.Read()
            username.Text = read.Item("usermail").ToString
            password.Text = read.Item("pswmail").ToString
            mailsrvaddr.Text = read.Item("srvmail").ToString
            mailsrvport.Text = read.Item("portmail").ToString

            Dim restest As String = ITSuite_Email.SendMail(read.Item("usermail").ToString, read.Item("pswmail").ToString, read.Item("srvmail").ToString, CInt(read.Item("portmail").ToString), Session("sslmail"), New Net.Mail.MailAddress(read.Item("mittentemail").ToString), emails, globals.ResourceHelper.GetString("String703"), globals.ResourceHelper.GetString("String702") & "<br /><br />ITSuite by ameamer.com (<a href='http://www.ameamer.com/itsuite/' targt='_blank'>www.ameamer.com/itsuite</a>)")
            If restest <> "ok" Then
                ErrorMsg.Text = globals.ResourceHelper.GetString("String687") & restest
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                read.Close()
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                SqlCom.Dispose()
                Exit Sub
            Else
                ErrorMsg.Text = globals.ResourceHelper.GetString("String688")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            End If

        End While
        read.Close()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()

    End Sub

    ''' <summary>
    ''' Controllo inserimento nuovo elemento.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs)
        For Each s As DictionaryEntry In e.Values
            If s.Value Is Nothing Then
                ErrorMsg.Text = globals.ResourceHelper.GetString("String689")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                e.Cancel = True
            End If
        Next
    End Sub
End Class
