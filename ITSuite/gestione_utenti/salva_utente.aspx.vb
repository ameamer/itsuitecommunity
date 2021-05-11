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

Partial Class gestione_utenti_salva_utente
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
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim nomeutente As String
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
             connect As String = ""

        ' Controllo campi vuoti
        If Request.Form("matricola_utente").ToString.Replace(" ", "") = "" Or
            Request.Form("dettagli_utente").ToString.Replace(" ", "") = "" Or Request.Form("ubicazione_utente").ToString.Replace(" ", "") = "" Or
            Request.Form("note_utente").ToString.Replace(" ", "") = "" Or
            Request.Form("stato_utente").ToString.Replace(" ", "") = "" Or Request.Form("cognome").ToString.Replace(" ", "") = "" Or
            Request.Form("nome").ToString.Replace(" ", "") = "" Or Request.Form("email").ToString.Replace(" ", "") = "" Then
            Response.Redirect("modifica_utente.aspx?id=" & iduser & "&err=emptyfields")
            Response.End()
        End If

        qry = "SELECT * FROM Utenti WHERE ID='" & iduser & "'"
        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        ' Inserisco nel DB
        Using da As New SqlDataAdapter(qry, connect),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "Utenti")

            Dim NewRow As DataRow = ds.Tables("Utenti").Rows.Item(0)
            NewRow.Item(1) = Request.Form("matricola_utente")
            If NewRow.Item(6).ToString = "Cliente" Then
                NewRow.Item(6) = "Cliente"
            Else
                NewRow.Item(6) = Request.Form("tipo_utente")
            End If
            NewRow.Item(7) = Request.Form("dettagli_utente")
            NewRow.Item(10) = Request.Form("ubicazione_utente")
            NewRow.Item(13) = data
            NewRow.Item(17) = ora
            NewRow.Item(14) = Request.Form("note_utente")
            NewRow.Item(15) = Request.Form("stato_utente")
            NewRow.Item(16) = Session("username")
            NewRow.Item(23) = Request.Form("cognome")
            NewRow.Item(24) = Request.Form("nome")
            NewRow.Item(25) = Request.Form("email")

            nomeutente = NewRow.Item(2).ToString

            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "Utenti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/userslog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("USRLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "USRUPDATE", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = iduser
        elem.AppendChild(idelm)
        Dim usrelm As XmlElement = xWr.CreateElement("USER")
        usrelm.InnerText = nomeutente
        elem.AppendChild(usrelm)
        Dim userelm As XmlElement = xWr.CreateElement("USEREDITOR")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_utente.aspx?id=" & iduser)
    End Sub
End Class
