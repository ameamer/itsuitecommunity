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

Partial Class gestione_utenti_salva_nuovo_utente
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If

        Dim iduser As String = Request.Form("id")
        ' Dim DbPath, Conn, Rs As Object
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            Conn As SqlConnection, connect As String = "", cmd As SqlCommand, read As SqlDataReader

        ' Controllo campi vuoti
        If Request.Form("matricola_utente").ToString.Replace(" ", "") = "" Or Request.Form("database_utente").ToString.Replace(" ", "") = "" Or
            Request.Form("dettagli_utente").ToString.Replace(" ", "") = "" Or Request.Form("ubicazione_utente").ToString.Replace(" ", "") = "" Or
            Request.Form("note_utente").ToString.Replace(" ", "") = "" Or Request.Form("nomeutente").ToString.Replace(" ", "") = "" Or
            Request.Form("password1").ToString.Replace(" ", "") = "" Or Request.Form("password2").ToString.Replace(" ", "") = "" Or
            Request.Form("stato_utente").ToString.Replace(" ", "") = "" Or Request.Form("cognome_utente").ToString.Replace(" ", "") = "" Or
            Request.Form("nome_utente").ToString.Replace(" ", "") = "" Or Request.Form("email_utente").ToString.Replace(" ", "") = "" Then
            Response.Redirect("nuovo_utente.aspx?err=emptyfields")
            Response.End()
        End If

        ' Controllo nome db 1
        If (Request.Form("tipo_utente") = "Amministratore") And (Request.Form("database_utente") = "tab_general") Or (Request.Form("tipo_utente") = "Tecnico ticketing") And (Request.Form("database_utente") = "tab_general") Then
            Response.Redirect("nuovo_utente.aspx?err=errtabgeneraladmin")
            Response.End()
        End If

        ' Controllo nome db 2
        If (Request.Form("database_utente") = "tab_").ToString.Replace(" ", "") Then
            Response.Redirect("nuovo_utente.aspx?err=errnotabname")
            Response.End()
        End If

        ' Controllo nome db 3
        If Request.Form("database_utente") <> "tab_general" And (Request.Form("tipo_utente") <> "Utenti standard") Then
            Dim isalreadydb As Boolean = False

            qry = "SELECT * FROM Utenti WHERE database_utente='" & Request.Form("database_utente") & "'"
            DbPath = "../App_Data/itstdb.mdf"
            connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            cmd = New SqlCommand(qry, Conn)
            Conn.Open()
            read = cmd.ExecuteReader()
            If read.Read() Then
                isalreadydb = True
            End If
            Conn.Close()
            Conn.Dispose()
            read.Close()
            cmd.Dispose()

            If isalreadydb Then
                Response.Redirect("nuovo_utente.aspx?err=errdbalreadypresent")
                Response.End()
            End If

        End If

        ' Controllo esistenza nome utente
        Dim isalreadyuser As Boolean = False
        qry = "SELECT * FROM Utenti WHERE nomeutente='" & Request.Form("nomeutente") & "'"
        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        cmd = New SqlCommand(qry, Conn)
        Conn.Open()
        read = cmd.ExecuteReader()
        If read.Read() Then
            isalreadyuser = True
        End If
        Conn.Close()
        Conn.Dispose()
        read.Close()
        cmd.Dispose()

        If isalreadyuser Then
            Response.Redirect("nuovo_utente.aspx?err=erruseralreadypresent")
            Response.End()
        End If

        ' Controllo coerenza password
        Dim psw1 As String = Request.Form("password1")
        Dim psw2 As String = Request.Form("password2")
        If psw1.Length < 8 Then
            Response.Redirect("nuovo_utente.aspx?err=errpswlength")
            Response.End()
        End If
        If psw1 <> psw2 Then
            Response.Redirect("nuovo_utente.aspx?err=errpswcompare")
            Response.End()
        End If

        ' Ricavo e imposto hash md5 della password
        Dim pass As String = psw1
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

        ' Inserisco nel DB
        Using da As New SqlDataAdapter("SELECT * FROM Utenti order by ID desc", connect),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "Utenti")

            Dim NewRow As DataRow = ds.Tables("Utenti").NewRow()
            NewRow.Item(1) = Request.Form("matricola_utente")
            NewRow.Item(2) = Request.Form("nomeutente")
            NewRow.Item(3) = pass_sha256
            NewRow.Item(6) = Request.Form("tipo_utente")
            NewRow.Item(7) = Request.Form("dettagli_utente")
            NewRow.Item(8) = Request.Form("database_utente")
            NewRow.Item(9) = Session("username")
            NewRow.Item(10) = Request.Form("ubicazione_utente")
            NewRow.Item(11) = data
            NewRow.Item(12) = ora
            NewRow.Item(14) = Request.Form("note_utente")
            NewRow.Item(15) = Request.Form("stato_utente")
            NewRow.Item(22) = "50"
            NewRow.Item(23) = Request.Form("cognome_utente")
            NewRow.Item(24) = Request.Form("nome_utente")
            NewRow.Item(25) = Request.Form("email_utente")

            ds.Tables("Utenti").Rows.Add(NewRow)
            da.UpdateCommand = cb.GetUpdateCommand
            da.InsertCommand = cb.GetInsertCommand
            da.DeleteCommand = cb.GetDeleteCommand
            da.Update(ds, "Utenti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        Dim idrel As String = ""

        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT TOP 1 ID FROM Utenti WHERE creato_da = '" & Session("Username") & "' order by ID desc"
        Dim ConnectorDB As SqlConnection = New SqlConnection(connecttop)
        Dim SqlCom As SqlCommand = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim readNew As SqlDataReader = SqlCom.ExecuteReader()
        While readNew.Read()
            idrel = readNew.Item("ID").ToString
        End While
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        read.Close()
        SqlCom.Dispose()

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/userslog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("USRLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWUSR", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = idrel
        elem.AppendChild(idelm)
        Dim newusr As XmlElement = xWr.CreateElement("NEWUSER")
        newusr.InnerText = Request.Form("nomeutente")
        elem.AppendChild(newusr)
        Dim userelm As XmlElement = xWr.CreateElement("USERCREATOR")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_utente.aspx?id=" & idrel & "&n=newitm")

    End Sub

End Class
