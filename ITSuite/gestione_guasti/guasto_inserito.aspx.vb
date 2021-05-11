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
Imports System.Net.Mail
Imports System.Xml

Partial Class gestione_guasti_guasto_inserito
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "1" Then
                    Diagnostics.Debug.WriteLine("Accesso admin")
                Else
                    Response.Redirect("../logout.aspx")
                End If
            Case "personale"
                If Session("abilita_gestione_guasti") = "1" Then
                    Diagnostics.Debug.WriteLine("Accesso tecnico ticketing")

                Else
                    Response.Redirect("../logout.aspx")
                End If
            Case "cliente"
                If Session("abilita_gestione_guasti") = "1" Then
                    Diagnostics.Debug.WriteLine("Accesso cliente")

                Else
                    Response.Redirect("../logout.aspx")
                End If
            Case Else
                Response.Redirect("../logout.aspx")
        End Select

        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", id_guasto As String = ""
        Dim ConnectorDB As SqlConnection
        Dim SqlCom As SqlCommand
        Dim intest As String = Request("intest-guasto")
        Dim body As String = Request("dettagli-guasto")
        Dim reparto As String = Request("reparto_guasto")
        Dim padiglione As String = Request("padiglione_guasto")
        Dim presidio As String = Request("presidio_guasto")
        Dim ubicazione As String = Request("ubicazione_guasto")
        Dim assegnazione As String = Request("assegnazione_utente")
        Dim utente As String = Request("utente")
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim emailtouser As String = Request("inviacopia")

        If Session("Autenticato") = "personale" Or Session("Autenticato") = "cliente" Then
            If Session("user_id") <> utente Then
                Response.Write("<form name='rediremptyfields' method='post' action='nuovo_guasto.aspx?err=requsrerr' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /><input name='reparto' value='" & reparto & "' /> <input name='padiglione' value='" & padiglione & "' /> <input name='presidio' value='" & presidio & "' />  <input name='ubicazione' value='" & ubicazione & "' /> </form>")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
                Exit Sub
            End If

            If String.IsNullOrEmpty(intest) Or String.IsNullOrEmpty(body) Or String.IsNullOrEmpty(ubicazione) Or String.IsNullOrEmpty(utente) Or
                 String.IsNullOrEmpty(reparto) Or String.IsNullOrEmpty(padiglione) Or String.IsNullOrEmpty(presidio) Then
                Response.Write("<form name='rediremptyfields' method='post' action='nuovo_guasto.aspx?err=emptyfields' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /><input name='reparto' value='" & reparto & "' /> <input name='padiglione' value='" & padiglione & "' /> <input name='presidio' value='" & presidio & "' />  <input name='ubicazione' value='" & ubicazione & "' /> </form>")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
                Exit Sub
            End If
        End If

        If Session("Autenticato") = "admin" Then
            If String.IsNullOrEmpty(intest) Or String.IsNullOrEmpty(body) Or String.IsNullOrEmpty(ubicazione) Or String.IsNullOrEmpty(utente) Or
                String.IsNullOrEmpty(assegnazione) Or String.IsNullOrEmpty(reparto) Or String.IsNullOrEmpty(padiglione) Or String.IsNullOrEmpty(presidio) Then
                Response.Write("<form name='rediremptyfields' method='post' action='nuovo_guasto.aspx?err=emptyfields' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /><input name='reparto' value='" & reparto & "' /> <input name='padiglione' value='" & padiglione & "' /> <input name='presidio' value='" & presidio & "' />  <input name='ubicazione' value='" & ubicazione & "' /> <input name='assegnazione_utente' value='" & assegnazione & "' /> </form>")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
                Exit Sub
            End If
        End If

        DbPathtop = "../App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            ' Avvio inserimento nuovo elemento
            Using da As New SqlDataAdapter("SELECT * FROM guasti order by ID desc", connecttop),
            cb As New SqlCommandBuilder(da)

                Dim ds As New DataSet
                da.Fill(ds, "guasti")

                Dim NewRow As DataRow = ds.Tables("guasti").NewRow()
                NewRow.Item(1) = data
                NewRow.Item(2) = ora
                NewRow.Item(3) = padiglione
                NewRow.Item(4) = presidio
                NewRow.Item(5) = reparto
                NewRow.Item(6) = ubicazione
                NewRow.Item(7) = intest
                NewRow.Item(8) = body
                NewRow.Item(9) = Session("username")
                NewRow.Item(10) = assegnazione
                NewRow.Item(11) = Session("username")
                NewRow.Item(23) = "aperta"
                NewRow.Item(27) = utente

                ds.Tables("guasti").Rows.Add(NewRow)
                da.UpdateCommand = cb.GetUpdateCommand
                da.InsertCommand = cb.GetInsertCommand
                da.DeleteCommand = cb.GetDeleteCommand
                da.Update(ds, "guasti")

                da.Dispose()
                cb.Dispose()
                ds.Dispose()
            End Using

            ' Seleziono ultimo elemento inserito dall'utente per ricavarne ID
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = ""
            qrytop = "SELECT TOP 1 ID FROM guasti WHERE autore_apertura = '" & Session("Username") & "' order by ID desc"
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            Dim read As SqlDataReader = SqlCom.ExecuteReader()
            While read.Read()
                id_guasto = read.Item("ID").ToString
            End While
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()

            ' Seleziono utente richiedente e ricavo suoi dati
            Dim usermail As String = ""
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = ""
            qrytop = "SELECT * FROM Utenti WHERE ID=" & CInt(utente)
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            read = SqlCom.ExecuteReader()
            While read.Read()
                usermail = read.Item("email").ToString
            End While
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()

            ' Invio mail
            If Session("emailenabled") = "1" Then
            Try
                ' Avvio invio mail ai destinatari
                Dim emails As New MailAddressCollection()

                Dim count As Integer = 0
                qrytop = ""
                DbPathtop = "../App_Data/itstdb.mdf"
                connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                qrytop = "SELECT * FROM email"
                ConnectorDB = New SqlConnection(connecttop)
                SqlCom = New SqlCommand(qrytop, ConnectorDB)
                ConnectorDB.Open()
                read = SqlCom.ExecuteReader()
                While read.Read()
                    emails.Add(New MailAddress(read.Item("mail").ToString))
                End While
                read.Close()
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                SqlCom.Dispose()

                Dim resmail As String = ""

                If emailtouser = "1" Then
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String710") & id_guasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String711") & id_guasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br />" & globals.ResourceHelper.GetString("String229") & ": " & intest & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & id_guasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                    emails.Clear()
                    emails.Add(New MailAddress(usermail))
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String710") & id_guasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String711") & id_guasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br />" & globals.ResourceHelper.GetString("String229") & ": " & intest & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & id_guasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                Else
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String710") & id_guasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String711") & id_guasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br />" & globals.ResourceHelper.GetString("String229") & ": " & intest & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & id_guasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                End If

                If resmail = "ok" Then
                    ' Scrivo log
                    Dim xmlPath1 As String = "../App_Data/tktlog.xml"
                    Dim xWr1 As New XmlDocument
                    xWr1.Load(Server.MapPath(xmlPath1))
                    Dim PCLoggerNode1 As XmlNode = xWr1.SelectSingleNode("TKTLOGGER")
                    Dim elem1 As XmlNode = xWr1.CreateNode(XmlNodeType.Element, "EMAILSERVICE", Nothing)
                    xWr1.DocumentElement.AppendChild(elem1)
                    Dim idelm0 As XmlElement = xWr1.CreateElement("ID")
                    idelm0.InnerText = id_guasto
                    elem1.AppendChild(idelm0)
                    Dim idelm1 As XmlElement = xWr1.CreateElement("EMAILRESULT")
                    idelm1.InnerText = globals.ResourceHelper.GetString("String729")
                    elem1.AppendChild(idelm1)
                    Dim userelm1 As XmlElement = xWr1.CreateElement("USER")
                    userelm1.InnerText = Session("username")
                    elem1.AppendChild(userelm1)
                    Dim DateTimeElm1 As XmlElement = xWr1.CreateElement("DATETIME")
                    DateTimeElm1.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                    elem1.AppendChild(DateTimeElm1)
                    xWr1.Save(Server.MapPath(xmlPath1))
                Else
                    ' Scrivo log
                    Dim xmlPath1 As String = "../App_Data/tktlog.xml"
                    Dim xWr1 As New XmlDocument
                    xWr1.Load(Server.MapPath(xmlPath1))
                    Dim PCLoggerNode1 As XmlNode = xWr1.SelectSingleNode("TKTLOGGER")
                    Dim elem1 As XmlNode = xWr1.CreateNode(XmlNodeType.Element, "EMAILSERVICE", Nothing)
                    xWr1.DocumentElement.AppendChild(elem1)
                    Dim idelm0 As XmlElement = xWr1.CreateElement("ID")
                    idelm0.InnerText = id_guasto
                    elem1.AppendChild(idelm0)
                    Dim idelm1 As XmlElement = xWr1.CreateElement("EMAILRESULT")
                    idelm1.InnerText = globals.ResourceHelper.GetString("String730") & resmail
                    elem1.AppendChild(idelm1)
                    Dim userelm1 As XmlElement = xWr1.CreateElement("USER")
                    userelm1.InnerText = Session("username")
                    elem1.AppendChild(userelm1)
                    Dim DateTimeElm1 As XmlElement = xWr1.CreateElement("DATETIME")
                    DateTimeElm1.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                    elem1.AppendChild(DateTimeElm1)
                    xWr1.Save(Server.MapPath(xmlPath1))
                End If

            Catch ex As Exception
                ' Scrivo log
                Dim xmlPath1 As String = "../App_Data/tktlog.xml"
                Dim xWr1 As New XmlDocument
                xWr1.Load(Server.MapPath(xmlPath1))
                Dim PCLoggerNode1 As XmlNode = xWr1.SelectSingleNode("TKTLOGGER")
                Dim elem1 As XmlNode = xWr1.CreateNode(XmlNodeType.Element, "EMAILSERVICE", Nothing)
                xWr1.DocumentElement.AppendChild(elem1)
                Dim idelm0 As XmlElement = xWr1.CreateElement("ID")
                idelm0.InnerText = id_guasto
                elem1.AppendChild(idelm0)
                Dim idelm1 As XmlElement = xWr1.CreateElement("EMAILRESULT")
                idelm1.InnerText = globals.ResourceHelper.GetString("String730") & ex.ToString
                elem1.AppendChild(idelm1)
                    Dim userelm1 As XmlElement = xWr1.CreateElement("USER")
                    userelm1.InnerText = Session("username")
                    elem1.AppendChild(userelm1)
                    Dim DateTimeElm1 As XmlElement = xWr1.CreateElement("DATETIME")
                    DateTimeElm1.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                    elem1.AppendChild(DateTimeElm1)
                    xWr1.Save(Server.MapPath(xmlPath1))
                End Try

            End If

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/tktlog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWTKT", Nothing)
            xWr.DocumentElement.AppendChild(elem)
            Dim idelm As XmlElement = xWr.CreateElement("ID")
            idelm.InnerText = id_guasto
            elem.AppendChild(idelm)
            Dim userelm As XmlElement = xWr.CreateElement("USER")
            userelm.InnerText = Session("username")
            elem.AppendChild(userelm)
            Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
            DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
            elem.AppendChild(DateTimeElm)
            xWr.Save(Server.MapPath(xmlPath))

            Response.Redirect("dettagli_guasto.aspx?id=" & id_guasto)

    End Sub
End Class
