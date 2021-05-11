
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

Partial Class assistenza_prodotti_assistenza_inserita
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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

        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = ""
        Dim ConnectorDB As SqlConnection
        Dim SqlCom As SqlCommand
        Dim intest As String = Request("intest-ass")
        Dim body As String = Request("dettagli-ass")
        Dim tipo As String = Request("tipo_prodass")
        Dim pc As String = Request("pcsel")
        Dim stmp As String = Request("stmp")
        Dim altrohw As String = Request("altrohw")
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()

        Select Case tipo
            Case "0" ' Nessun tipo
                Response.Write("<form name='rediremptyfields' method='post' action='nuova_assistenza.aspx?err=notype' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /> </form>")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
                Exit Sub

            Case "1" ' PC
                If String.IsNullOrEmpty(pc) Then
                    Response.Write("<form name='rediremptyfields' method='post' action='nuova_assistenza.aspx?err=notype' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /> </form>")
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
                    Exit Sub
                End If

            Case "2" ' Stampante
                If String.IsNullOrEmpty(stmp) Then
                    Response.Write("<form name='rediremptyfields' method='post' action='nuova_assistenza.aspx?err=notype' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /> </form>")
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
                    Exit Sub
                End If

            Case "3" ' Altro HW
                If String.IsNullOrEmpty(altrohw) Then
                    Response.Write("<form name='rediremptyfields' method='post' action='nuova_assistenza.aspx?err=notype' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /> </form>")
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
                    Exit Sub
                End If

        End Select

        If String.IsNullOrEmpty(intest) Or String.IsNullOrEmpty(body) Or String.IsNullOrEmpty(tipo) Then
            Response.Write("<form name='rediremptyfields' method='post' action='nuova_assistenza.aspx?err=emptyfields' style='display:none;'><input name='intest' value='" & intest & "' /><input name='body' value='" & body & "' /> </form>")
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "document.rediremptyfields.submit();", True)
            Exit Sub
        Else

            DbPathtop = "../App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            ' Avvio inserimento nuovo elemento
            Using da As New SqlDataAdapter("SELECT * FROM assistenzaprodotti order by ID desc", connecttop),
            cb As New SqlCommandBuilder(da)

                Dim ds As New DataSet
                da.Fill(ds, "assistenzaprodotti")

                Dim NewRow As DataRow = ds.Tables("assistenzaprodotti").NewRow()

                If tipo = "1" Then
                    NewRow.Item(3) = pc
                End If

                If tipo = "2" Then
                    NewRow.Item(2) = stmp
                End If

                If tipo = "3" Then
                    NewRow.Item(1) = altrohw
                End If

                NewRow.Item(5) = data
                NewRow.Item(6) = ora
                NewRow.Item(7) = Session("username")
                NewRow.Item(8) = intest
                NewRow.Item(9) = body
                NewRow.Item(15) = "aperta"

                ds.Tables("assistenzaprodotti").Rows.Add(NewRow)
                da.UpdateCommand = cb.GetUpdateCommand
                da.InsertCommand = cb.GetInsertCommand
                da.DeleteCommand = cb.GetDeleteCommand
                da.Update(ds, "assistenzaprodotti")

                da.Dispose()
                cb.Dispose()
                ds.Dispose()
            End Using

            ' Avvio redirect ai dettagli dopo l'inserimento dell'elemento
            Dim id_assinserita As String = ""
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = ""
            qrytop = "SELECT TOP 1 ID FROM assistenzaprodotti WHERE autore_apertura = '" & Session("Username") & "' order by ID desc"
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            Dim read As SqlDataReader = SqlCom.ExecuteReader()
            While read.Read()
                id_assinserita = read.Item("ID").ToString
            End While
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()

            ' Scrivo log
            Dim xmlPath As String = "../App_Data/asslog.xml"
            Dim xWr As New XmlDocument
            xWr.Load(Server.MapPath(xmlPath))
            Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("ASSLOGGER")
            Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWASS", Nothing)
            xWr.DocumentElement.AppendChild(elem)
            Dim idelm As XmlElement = xWr.CreateElement("ID")
            idelm.InnerText = id_assinserita
            elem.AppendChild(idelm)
            Dim userelm As XmlElement = xWr.CreateElement("USER")
            userelm.InnerText = Session("username")
            elem.AppendChild(userelm)
            Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
            DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
            elem.AppendChild(DateTimeElm)
            xWr.Save(Server.MapPath(xmlPath))

            Response.Redirect("dettagli_assistenza.aspx?id=" & id_assinserita)
        End If
    End Sub

End Class
