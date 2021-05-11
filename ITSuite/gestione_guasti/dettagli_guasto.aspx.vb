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
Imports System.IO
Imports System.Net.Mail
Imports System.Xml

Partial Class gestione_guasti_dettagli_guasto
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public idguasto As String
    Public status As String
    Public userrich As String
    Public tp As String
    Public usertoassign As String
    Public clienttoassign As String
    Public isMyTicket As Boolean

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String189") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        idguasto = Request.QueryString("id")
        tp = Request.QueryString("t")
        isMyTicket = False

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                Else
                    Dim DbPathtop As String = "", Conntop As SqlConnection, qrytop As String = "", connecttop As String = "", cmdtop As SqlCommand, read As SqlDataReader

                    DettaglioGuastiSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLDettaglioGuastiCommand()
                    DettaglioGuastiSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()

                    Select Case tp
                        Case "naf" ' Nuova assegnazione
                            usertoassign = Request.Form("Usertoassign")
                            If Not String.IsNullOrEmpty(usertoassign) Then
                                DbPathtop = "../App_Data/itstdb.mdf"
                                connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                                Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
                        cb As New SqlCommandBuilder(da)
                                    Dim ds As New DataSet
                                    da.Fill(ds, "guasti")
                                    Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
                                    Row.Item(10) = usertoassign
                                    Row.Item(11) = Session("username")
                                    da.UpdateCommand = cb.GetUpdateCommand
                                    da.Update(ds, "guasti")
                                    da.Dispose()
                                    cb.Dispose()
                                    ds.Dispose()
                                End Using
                                ErrorMsg.Text = globals.ResourceHelper.GetString("String214") & " <b>" & usertoassign & "</b>"
                                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                            End If

                        Case "ncf"
                            clienttoassign = Request.Form("Clienttoassign")
                            If Not String.IsNullOrEmpty(clienttoassign) Then
                                DbPathtop = "../App_Data/itstdb.mdf"
                                connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                                Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
                    cb As New SqlCommandBuilder(da)
                                    Dim ds As New DataSet
                                    da.Fill(ds, "guasti")
                                    Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
                                    Row.Item(27) = clienttoassign
                                    da.UpdateCommand = cb.GetUpdateCommand
                                    da.Update(ds, "guasti")
                                    da.Dispose()
                                    cb.Dispose()
                                    ds.Dispose()
                                End Using
                                ErrorMsg.Text = globals.ResourceHelper.GetString("String213")
                                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                            End If
                    End Select

                    ' Imposto lista degli utenti per nuova assegnazione (se admin)
                    TitleNewAssign.Text = globals.ResourceHelper.GetString("String215")
                    qrytop = "Select * from Utenti where tipo_utente='Amministratore' or tipo_utente='Tecnico ticketing' order by nomeutente ASC"
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Conntop = New SqlConnection(connecttop)
                    cmdtop = New SqlCommand(qrytop, Conntop)
                    Conntop.Open()
                    read = cmdtop.ExecuteReader()
                    While read.Read()
                        LabelListUserTech.Text = LabelListUserTech.Text & "<option value='" & read.Item("nomeutente").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>" & read.Item("nomeutente").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>"
                    End While
                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    ' Imposto lista dei clienti (se admin)
                    LabelTitleNewClientAssign.Text = globals.ResourceHelper.GetString("String216")
                    qrytop = "Select * from Utenti order by nomeutente ASC"
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Conntop = New SqlConnection(connecttop)
                    cmdtop = New SqlCommand(qrytop, Conntop)
                    Conntop.Open()
                    read = cmdtop.ExecuteReader()
                    While read.Read()
                        LabelNewClientAssign.Text = LabelNewClientAssign.Text & "<option value='" & read.Item("ID").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>" & read.Item("nomeutente").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>"
                    End While
                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    qrytop = "SELECT * FROM guasti where ID=" & idguasto
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Conntop = New SqlConnection(connecttop)
                    cmdtop = New SqlCommand(qrytop, Conntop)
                    Conntop.Open()
                    read = cmdtop.ExecuteReader()
                    If read.Read() Then
                        addupdatepanel.CssClass = "paneldetails-display"
                        status = read.Item("stato").ToString

                        Dim user As String = read.Item("utente").ToString, usermail = "", nomeusr As String = "", cognomeusr As String = ""

                        Dim qrydetuser As String = "SELECT * FROM Utenti WHERE ID=" & CInt(user)
                        Dim DbPathdetuser As String = "../App_Data/itstdb.mdf"
                        Dim connectdetuser As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathdetuser)
                        Dim Conndetuser As New SqlConnection(connectdetuser)
                        Dim cmddetuser As New SqlCommand(qrydetuser, Conndetuser)
                        Conndetuser.Open()
                        Dim readusr As SqlDataReader = cmddetuser.ExecuteReader()
                        While readusr.Read()
                            usermail = readusr.Item("email").ToString
                            userrich = usermail
                            nomeusr = readusr.Item("nome").ToString
                            cognomeusr = readusr.Item("cognome").ToString
                            LabelUserReq.Text = globals.ResourceHelper.GetString("String212") & ":<br /><a href='../gestione_utenti/dettagli_utente.aspx?id=" & readusr.Item("ID").ToString & "'><b>" & cognomeusr & " " & nomeusr & ", " & usermail & "</b></a>"
                        End While
                        Conndetuser.Close()
                        Conndetuser.Dispose()
                        readusr.Close()
                        cmddetuser.Dispose()

                        If (read.Item("utente").ToString = Session("user_id")) And (read.Item("dettagli1").ToString <> Session("username")) Then
                            isMyTicket = True
                        Else
                            isMyTicket = False
                        End If

                        If Not IsDBNull(read.Item("dettagliutente").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagliutente").ToString)) Then
                                UpdatesClientPanel.CssClass = "paneldetails-displaynone"
                            Else
                                UpdatesClientPanelContainer.Visible = True
                                UpdatesClientPanel.CssClass = "paneldetails-displayupdatesclient"
                                UpdatesClienti.Text = read.Item("dettagliutente")
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli2").ToString) Then
                            If String.IsNullOrEmpty(read.Item("dettagli2").ToString) Then
                                dettagli2.CssClass = "paneldetails-displaynone"
                            Else
                                updatesScreen.Visible = True
                                dettagli2.CssClass = "paneldetails-displayupdates"

                                Dim hideclientvalue As String() = read.Item("dettagli2").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & hideclientvalue(1)
                                    Else
                                        dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & hideclientvalue(1)
                                    End If
                                Else
                                    dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & read.Item("dettagli2").ToString
                                End If

                                addupdatepanel.CssClass = "paneldetails-display"
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli3").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli3").ToString)) Then
                                dettagli3.CssClass = "paneldetails-displaynone"
                            Else
                                updatesScreen.Visible = True
                                dettagli3.CssClass = "paneldetails-displayupdates"

                                Dim hideclientvalue As String() = read.Item("dettagli3").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & hideclientvalue(1)
                                    Else
                                        dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & ":</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & hideclientvalue(1)
                                    End If
                                Else
                                    dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & read.Item("dettagli3").ToString
                                End If

                                addupdatepanel.CssClass = "paneldetails-display"
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli4").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli4").ToString)) Then
                                dettagli4.CssClass = "paneldetails-displaynone"
                            Else
                                updatesScreen.Visible = True
                                dettagli4.CssClass = "paneldetails-displayupdates"

                                Dim hideclientvalue As String() = read.Item("dettagli4").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & hideclientvalue(1)
                                    Else
                                        dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & hideclientvalue(1)
                                    End If
                                Else
                                    dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & read.Item("dettagli4").ToString
                                End If

                                addupdatepanel.CssClass = "paneldetails-display"
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli5").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli5").ToString)) Then
                                dettagli5.CssClass = "paneldetails-displaynone"
                            Else
                                updatesScreen.Visible = True
                                dettagli5.CssClass = "paneldetails-displayupdates"

                                Dim hideclientvalue As String() = read.Item("dettagli4").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & hideclientvalue(1)
                                    Else
                                        dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & hideclientvalue(1)
                                    End If
                                Else
                                    dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & read.Item("dettagli5").ToString
                                End If

                            End If
                        End If

                        If Not IsDBNull(read.Item("motivoattesa").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("motivoattesa").ToString)) Then
                                attesapanel.CssClass = "paneldetailsattesa-displaynone"
                            Else
                                updatesScreen.Visible = True
                                attesapanel.CssClass = "paneldetailsattesa-display"
                                attesatext.Text = read.Item("motivoattesa").ToString
                            End If
                        End If

                        If Not IsDBNull(read.Item("motivo").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("motivo").ToString)) Then
                                chiusurapanel.CssClass = "paneldetailschiusa-displaynone"
                            Else
                                updatesScreen.Visible = True
                                addupdatepanel.CssClass = "paneldetails-displaynone"
                                chiusurapanel.CssClass = "paneldetailschiusa-display"
                                chiusuratext.Text = "<b>" & globals.ResourceHelper.GetString("String219") & read.Item("datachiusura").ToString & globals.ResourceHelper.GetString("String220") & read.Item("autorechiusura").ToString & "</b><br />" & read.Item("motivo").ToString
                            End If
                        End If

                        If Not IsDBNull(read.Item("adminfiles").ToString) Or Not IsDBNull(read.Item("Files").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("Files").ToString)) And String.IsNullOrEmpty(Convert.ToString(read.Item("adminfiles").ToString)) Then
                                filepanel.CssClass = "panelfiles-displaynone"
                            Else
                                UpoloadedFilepanel.Visible = True
                                filepanel.CssClass = "panelfiles-display"
                                Dim fileadded As String() = read.Item("adminfilestitle").ToString.Split("§")

                                dettaglifilepanel.Text = ""

                                For Each st As String In fileadded
                                    dettaglifilepanel.Text = dettaglifilepanel.Text & st
                                Next

                                fileadded = read.Item("FilesTitle").ToString.Split("§")

                                For Each st As String In fileadded
                                    dettaglifilepanel.Text = dettaglifilepanel.Text & st
                                Next
                            End If
                        End If

                    Else
                        Conntop.Close()
                        Conntop.Dispose()
                        read.Close()
                        cmdtop.Dispose()
                        Response.Redirect("../logout.aspx")
                    End If

                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()
                End If

            Case "personale"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                Else
                    Dim DbPathtop As String = "", Conntop As SqlConnection, qrytop As String = "", connecttop As String = "",
                        cmdtop As SqlCommand, read As SqlDataReader, utentereq As String = ""

                    ' Imposto lista degli utenti per nuova assegnazione (se admin)
                    TitleNewAssign.Text = globals.ResourceHelper.GetString("String221")
                    qrytop = "Select * from Utenti order by nomeutente ASC"
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Conntop = New SqlConnection(connecttop)
                    cmdtop = New SqlCommand(qrytop, Conntop)
                    Conntop.Open()
                    read = cmdtop.ExecuteReader()
                    While read.Read()
                        Response.Write("<option value='" & read.Item("nomeutente").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>ID: " & read.Item("ID").ToString & ", " & read.Item("nomeutente").ToString & ", " & read.Item("email").ToString & ", " & read.Item("cognome").ToString & " " & read.Item("nome").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>")
                    End While
                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    qrytop = "SELECT * FROM guasti where ID=" & idguasto
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Conntop = New SqlConnection(connecttop)
                    cmdtop = New SqlCommand(qrytop, Conntop)
                    Conntop.Open()
                    read = cmdtop.ExecuteReader()
                    If read.Read() Then
                        addupdatepanel.CssClass = "paneldetails-display"
                        status = read.Item("stato").ToString
                        utentereq = read.Item("utente").ToString

                        If utentereq = Session("user_id") Then
                            DettaglioGuastiSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLDettaglioGuastiCommandCliente()
                            DettaglioGuastiSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                        Else
                            DettaglioGuastiSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLDettaglioGuastiCommandPersonale()
                            DettaglioGuastiSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
                        End If

                        Dim user As String = read.Item("utente").ToString, usermail = "", nomeusr As String = "", cognomeusr As String = ""

                        Dim qrydetuser As String = "SELECT * FROM Utenti WHERE ID=" & CInt(user)
                        Dim DbPathdetuser As String = "../App_Data/itstdb.mdf"
                        Dim connectdetuser As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathdetuser)
                        Dim Conndetuser As New SqlConnection(connectdetuser)
                        Dim cmddetuser As New SqlCommand(qrydetuser, Conndetuser)
                        Conndetuser.Open()
                        Dim readusr As SqlDataReader = cmddetuser.ExecuteReader()
                        While readusr.Read()
                            usermail = readusr.Item("email").ToString
                            userrich = usermail
                            nomeusr = readusr.Item("nome").ToString
                            cognomeusr = readusr.Item("cognome").ToString
                            LabelUserReq.Text = globals.ResourceHelper.GetString("String212") & ":<br /><b>" & cognomeusr & " " & nomeusr & ", " & usermail & "</b>"
                        End While
                        Conndetuser.Close()
                        Conndetuser.Dispose()
                        readusr.Close()
                        cmddetuser.Dispose()

                        If read.Item("utente").ToString = Session("user_id") Then
                            isMyTicket = True
                        Else
                            isMyTicket = False
                        End If

                        If (read.Item("dettagli1").ToString <> Session("username")) And (read.Item("utente").ToString <> Session("user_id")) Then
                            Conntop.Close()
                            Conntop.Dispose()
                            read.Close()
                            cmdtop.Dispose()
                            Response.Redirect("../logout.aspx")
                        End If

                        If Not IsDBNull(read.Item("dettagliutente").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagliutente").ToString)) Then
                                UpdatesClientPanel.CssClass = "paneldetails-displaynone"
                            Else
                                UpdatesClientPanelContainer.Visible = True
                                UpdatesClientPanel.CssClass = "paneldetails-displayupdatesclient"
                                UpdatesClienti.Text = read.Item("dettagliutente")
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli2").ToString) Then
                            If String.IsNullOrEmpty(read.Item("dettagli2").ToString) Then
                                dettagli2.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli2").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        updatesScreen.Visible = True
                                        dettagli2.CssClass = "paneldetails-displayupdates"
                                        dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli2.CssClass = "paneldetails-displayupdates"
                                        dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli2.CssClass = "paneldetails-displayupdates"
                                    dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & read.Item("dettagli2").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli3").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli3").ToString)) Then
                                dettagli3.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli3").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        updatesScreen.Visible = True
                                        dettagli3.CssClass = "paneldetails-displayupdates"
                                        dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli3.CssClass = "paneldetails-displayupdates"
                                        dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli3.CssClass = "paneldetails-displayupdates"
                                    dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & read.Item("dettagli3").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli4").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli4").ToString)) Then
                                dettagli4.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli4").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        updatesScreen.Visible = True
                                        dettagli4.CssClass = "paneldetails-displayupdates"
                                        dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli4.CssClass = "paneldetails-displayupdates"
                                        dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli4.CssClass = "paneldetails-displayupdates"
                                    dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & read.Item("dettagli4").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli5").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli5").ToString)) Then
                                dettagli5.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli5").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        updatesScreen.Visible = True
                                        dettagli5.CssClass = "paneldetails-displayupdates"
                                        dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String217") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli5.CssClass = "paneldetails-displayupdates"
                                        dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli5.CssClass = "paneldetails-displayupdates"
                                    dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String218") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & read.Item("dettagli5").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("motivoattesa").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("motivoattesa").ToString)) Then
                                attesapanel.CssClass = "paneldetailsattesa-displaynone"
                            Else
                                updatesScreen.Visible = True
                                attesapanel.CssClass = "paneldetailsattesa-display"
                                attesatext.Text = read.Item("motivoattesa").ToString
                            End If
                        End If

                        If Not IsDBNull(read.Item("motivo").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("motivo").ToString)) Then
                                chiusurapanel.CssClass = "paneldetailschiusa-displaynone"
                            Else
                                updatesScreen.Visible = True
                                addupdatepanel.CssClass = "paneldetails-displaynone"
                                chiusurapanel.CssClass = "paneldetailschiusa-display"
                                chiusuratext.Text = "<b>" & globals.ResourceHelper.GetString("String219") & read.Item("datachiusura").ToString & globals.ResourceHelper.GetString("String220") & read.Item("autorechiusura").ToString & "</b><br />" & read.Item("motivo").ToString
                            End If
                        End If

                        If Not IsDBNull(read.Item("adminfiles").ToString) Or Not IsDBNull(read.Item("Files").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("Files").ToString)) And String.IsNullOrEmpty(Convert.ToString(read.Item("adminfiles").ToString)) Then
                                filepanel.CssClass = "panelfiles-displaynone"
                            Else
                                UpoloadedFilepanel.Visible = True
                                filepanel.CssClass = "panelfiles-display"
                                Dim fileadded As String() = read.Item("adminfilestitle").ToString.Split("§")

                                dettaglifilepanel.Text = ""

                                For Each st As String In fileadded
                                    dettaglifilepanel.Text = dettaglifilepanel.Text & st
                                Next

                                fileadded = read.Item("FilesTitle").ToString.Split("§")

                                For Each st As String In fileadded
                                    dettaglifilepanel.Text = dettaglifilepanel.Text & st
                                Next
                            End If
                        End If

                    Else
                        Conntop.Close()
                        Conntop.Dispose()
                        read.Close()
                        cmdtop.Dispose()
                        Response.Redirect("../logout.aspx")
                    End If

                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()
                End If

            Case "cliente"
                If Session("abilita_gestione_guasti") = "0" Then
                    Response.Redirect("../logout.aspx")
                Else
                    Dim DbPathtop As String = "", Conntop As SqlConnection, qrytop As String = "", connecttop As String = "", cmdtop As SqlCommand, read As SqlDataReader

                    DettaglioGuastiSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLDettaglioGuastiCommandCliente()
                    DettaglioGuastiSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()

                    ' Imposto lista degli utenti per nuova assegnazione (se admin)
                    TitleNewAssign.Text = "Seleziona dalla lista sottostante l'utente a cui assegnare il ticket e poi seleziona il tasto OK:"
                    qrytop = "Select * from Utenti order by nomeutente ASC"
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Conntop = New SqlConnection(connecttop)
                    cmdtop = New SqlCommand(qrytop, Conntop)
                    Conntop.Open()
                    read = cmdtop.ExecuteReader()
                    While read.Read()
                        Response.Write("<option value='" & read.Item("nomeutente").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>ID: " & read.Item("ID").ToString & ", " & read.Item("nomeutente").ToString & ", " & read.Item("email").ToString & ", " & read.Item("cognome").ToString & " " & read.Item("nome").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>")
                    End While
                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    qrytop = "SELECT * FROM guasti where ID=" & idguasto
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Conntop = New SqlConnection(connecttop)
                    cmdtop = New SqlCommand(qrytop, Conntop)
                    Conntop.Open()
                    read = cmdtop.ExecuteReader()
                    If read.Read() Then
                        addupdatepanel.CssClass = "paneldetails-display"
                        status = read.Item("stato").ToString

                        Dim user As String = read.Item("utente").ToString, usermail = "", nomeusr As String = "", cognomeusr As String = ""

                        Dim qrydetuser As String = "SELECT * FROM Utenti WHERE ID=" & CInt(user)
                        Dim DbPathdetuser As String = "../App_Data/itstdb.mdf"
                        Dim connectdetuser As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathdetuser)
                        Dim Conndetuser As New SqlConnection(connectdetuser)
                        Dim cmddetuser As New SqlCommand(qrydetuser, Conndetuser)
                        Conndetuser.Open()
                        Dim readusr As SqlDataReader = cmddetuser.ExecuteReader()
                        While readusr.Read()
                            usermail = readusr.Item("email").ToString
                            userrich = usermail
                            nomeusr = readusr.Item("nome").ToString
                            cognomeusr = readusr.Item("cognome").ToString
                            LabelUserReq.Text = globals.ResourceHelper.GetString("String212") & ":<br /><b>" & cognomeusr & " " & nomeusr & ", " & usermail & "</b>"
                        End While
                        Conndetuser.Close()
                        Conndetuser.Dispose()
                        readusr.Close()
                        cmddetuser.Dispose()

                        If read.Item("utente").ToString = Session("user_id") Then
                            isMyTicket = True
                        Else
                            isMyTicket = False
                            Conntop.Close()
                            Conntop.Dispose()
                            read.Close()
                            cmdtop.Dispose()
                            Response.Redirect("../logout.aspx")
                        End If

                        If Not IsDBNull(read.Item("dettagliutente").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagliutente").ToString)) Then
                                UpdatesClientPanel.CssClass = "paneldetails-displaynone"
                            Else
                                UpdatesClientPanelContainer.Visible = True
                                UpdatesClientPanel.CssClass = "paneldetails-displayupdatesclient"
                                UpdatesClienti.Text = read.Item("dettagliutente")
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli2").ToString) Then
                            If String.IsNullOrEmpty(read.Item("dettagli2").ToString) Then
                                dettagli2.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli2").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli2text.Text = String.Empty
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli2.CssClass = "paneldetails-displayupdates"
                                        dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli2.CssClass = "paneldetails-displayupdates"
                                    dettagli2text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli2").ToString & "<br />il </b>" & read.Item("dettagli2").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli3").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli3").ToString)) Then
                                dettagli3.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli3").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli3text.Text = String.Empty
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli3.CssClass = "paneldetails-displayupdates"
                                        dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli3.CssClass = "paneldetails-displayupdates"
                                    dettagli3text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli3").ToString & "<br />il </b>" & read.Item("dettagli3").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli4").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli4").ToString)) Then
                                dettagli4.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli4").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli4text.Text = String.Empty
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli4.CssClass = "paneldetails-displayupdates"
                                        dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli4.CssClass = "paneldetails-displayupdates"
                                    dettagli4text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli4").ToString & "<br />il </b>" & read.Item("dettagli4").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("dettagli5").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("dettagli5").ToString)) Then
                                dettagli5.CssClass = "paneldetails-displaynone"
                            Else
                                Dim hideclientvalue As String() = read.Item("dettagli5").ToString.Split("§")
                                If hideclientvalue.Length > 1 Then
                                    If hideclientvalue(0) = "N" Then
                                        dettagli5text.Text = String.Empty
                                    Else
                                        updatesScreen.Visible = True
                                        dettagli5.CssClass = "paneldetails-displayupdates"
                                        dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & hideclientvalue(1)
                                        addupdatepanel.CssClass = "paneldetails-display"
                                    End If
                                Else
                                    updatesScreen.Visible = True
                                    dettagli5.CssClass = "paneldetails-displayupdates"
                                    dettagli5text.Text = "<b>" & globals.ResourceHelper.GetString("String222") & "</b> <b>" & read.Item("autore_dettagli5").ToString & "<br />il </b>" & read.Item("dettagli5").ToString
                                    addupdatepanel.CssClass = "paneldetails-display"
                                End If
                            End If
                        End If

                        If Not IsDBNull(read.Item("motivoattesa").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("motivoattesa").ToString)) Then
                                attesapanel.CssClass = "paneldetailsattesa-displaynone"
                            Else
                                updatesScreen.Visible = True
                                attesapanel.CssClass = "paneldetailsattesa-display"
                                attesatext.Text = read.Item("motivoattesa").ToString
                            End If
                        End If

                        If Not IsDBNull(read.Item("motivo").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("motivo").ToString)) Then
                                chiusurapanel.CssClass = "paneldetailschiusa-displaynone"
                            Else
                                updatesScreen.Visible = True
                                addupdatepanel.CssClass = "paneldetails-displaynone"
                                chiusurapanel.CssClass = "paneldetailschiusa-display"
                                chiusuratext.Text = "<b>" & globals.ResourceHelper.GetString("String219") & read.Item("datachiusura").ToString & globals.ResourceHelper.GetString("String220") & read.Item("autorechiusura").ToString & "</b><br />" & read.Item("motivo").ToString
                            End If
                        End If

                        If Not IsDBNull(read.Item("Files").ToString) Then
                            If String.IsNullOrEmpty(Convert.ToString(read.Item("Files").ToString)) Then
                                filepanel.CssClass = "panelfiles-displaynone"
                            Else
                                UpoloadedFilepanel.Visible = True
                                filepanel.CssClass = "panelfiles-display"
                                Dim fileadded As String() = read.Item("FilesTitle").ToString.ToString.Split("§")

                                dettaglifilepanel.Text = ""

                                For Each st As String In fileadded
                                    dettaglifilepanel.Text = dettaglifilepanel.Text & st
                                Next
                            End If
                        End If

                    Else
                        Conntop.Close()
                        Conntop.Dispose()
                        read.Close()
                        cmdtop.Dispose()
                        Response.Redirect("../logout.aspx")
                    End If

                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()
                End If

            Case Else
                Response.Redirect("../logout.aspx")
        End Select
    End Sub

    ''' <summary>
    ''' Aggiunta di un nuovo aggiornamento.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub AddUpdateButton_Click(sender As Object, e As EventArgs)
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim dettaglio As String = TextNewUpdate.Text

        If String.IsNullOrEmpty(Convert.ToString(dettaglio.Replace(" ", ""))) Then
            ErrorMsg.Text = globals.ResourceHelper.GetString("String223")
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Exit Sub
        End If

        Dim DbPathtop As String = "", qrytop As String = "", connecttop As String = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "guasti")

            Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
            Dim user As String = "", usermail = "", nomeusr As String = "", cognomeusr As String = ""
            user = Row.Item(27).ToString

            Dim qrydetuser As String = "SELECT * FROM Utenti WHERE ID=" & CInt(user)
            Dim DbPathdetuser As String = "../App_Data/itstdb.mdf"
            Dim connectdetuser As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathdetuser)
            Dim Conndetuser As New SqlConnection(connectdetuser)
            Dim cmddetuser As New SqlCommand(qrydetuser, Conndetuser)
            Conndetuser.Open()
            Dim read As SqlDataReader = cmddetuser.ExecuteReader()
            While read.Read()
                usermail = read.Item("email").ToString
                nomeusr = read.Item("nome").ToString
                cognomeusr = read.Item("cognome").ToString
            End While
            Conndetuser.Close()
            Conndetuser.Dispose()
            read.Close()
            cmddetuser.Dispose()

            ' dettagli2
            If IsDBNull(Row.Item(12)) Then
                If CheckBoxVisible.Checked = False Then
                    Row.Item(12) = "N§" & "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                Else
                    Row.Item(12) = "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                End If

                Row.Item(13) = Session("username")
                Row.Item(23) = "aperta"
                da.UpdateCommand = cb.GetUpdateCommand
                da.Update(ds, "guasti")
                da.Dispose()
                cb.Dispose()
                ds.Dispose()

                ' Scrivo log
                Dim xmlPath As String = "../App_Data/tktlog.xml"
                Dim xWr As New XmlDocument
                xWr.Load(Server.MapPath(xmlPath))
                Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
                Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWUPDATE", Nothing)
                xWr.DocumentElement.AppendChild(elem)
                Dim idelm As XmlElement = xWr.CreateElement("ID")
                idelm.InnerText = idguasto
                elem.AppendChild(idelm)
                Dim userelm As XmlElement = xWr.CreateElement("USER")
                userelm.InnerText = Session("username")
                elem.AppendChild(userelm)
                Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
                DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                elem.AppendChild(DateTimeElm)
                xWr.Save(Server.MapPath(xmlPath))

                ' Invio mail
                If Session("emailenabled") = "1" Then
                    Dim ConnectorDB As SqlConnection
                    Dim SqlCom As SqlCommand

                    Try
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

                        If chkSendMailToUser.Checked() Then
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                            emails.Clear()
                            emails.Add(New MailAddress(usermail))
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                        Else
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
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
                            idelm0.InnerText = idguasto
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
                            idelm0.InnerText = idguasto
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
                        idelm0.InnerText = idguasto
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
                Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
                Exit Sub
            End If

            ' dettagli3
            If IsDBNull(Row.Item(14)) Then
                If CheckBoxVisible.Checked = False Then
                    Row.Item(14) = "N§" & "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                Else
                    Row.Item(14) = "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                End If
                Row.Item(15) = Session("username")
                Row.Item(23) = "aperta"
                da.UpdateCommand = cb.GetUpdateCommand
                da.Update(ds, "guasti")
                da.Dispose()
                cb.Dispose()
                ds.Dispose()
                ' scrivo log
                Dim xmlPath As String = "../App_Data/tktlog.xml"
                Dim xWr As New XmlDocument
                xWr.Load(Server.MapPath(xmlPath))
                Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
                Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWUPDATE", Nothing)
                xWr.DocumentElement.AppendChild(elem)
                Dim idelm As XmlElement = xWr.CreateElement("ID")
                idelm.InnerText = idguasto
                elem.AppendChild(idelm)
                Dim userelm As XmlElement = xWr.CreateElement("USER")
                userelm.InnerText = Session("username")
                elem.AppendChild(userelm)
                Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
                DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                elem.AppendChild(DateTimeElm)
                xWr.Save(Server.MapPath(xmlPath))

                ' Invio mail
                If Session("emailenabled") = "1" Then
                    Dim ConnectorDB As SqlConnection
                    Dim SqlCom As SqlCommand

                    Try
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

                        If chkSendMailToUser.Checked() Then
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                            emails.Clear()
                            emails.Add(New MailAddress(usermail))
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                        Else
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
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
                            idelm0.InnerText = idguasto
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
                            idelm0.InnerText = idguasto
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
                        idelm0.InnerText = idguasto
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

                Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
                Exit Sub
            End If

            ' dettagli4
            If IsDBNull(Row.Item(16)) Then
                If CheckBoxVisible.Checked = False Then
                    Row.Item(16) = "N§" & "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                Else
                    Row.Item(16) = "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                End If
                Row.Item(17) = Session("username")
                Row.Item(23) = "aperta"
                da.UpdateCommand = cb.GetUpdateCommand
                da.Update(ds, "guasti")
                da.Dispose()
                cb.Dispose()
                ds.Dispose()
                ' scrivo log
                Dim xmlPath As String = "../App_Data/tktlog.xml"
                Dim xWr As New XmlDocument
                xWr.Load(Server.MapPath(xmlPath))
                Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
                Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWUPDATE", Nothing)
                xWr.DocumentElement.AppendChild(elem)
                Dim idelm As XmlElement = xWr.CreateElement("ID")
                idelm.InnerText = idguasto
                elem.AppendChild(idelm)
                Dim userelm As XmlElement = xWr.CreateElement("USER")
                userelm.InnerText = Session("username")
                elem.AppendChild(userelm)
                Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
                DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                elem.AppendChild(DateTimeElm)
                xWr.Save(Server.MapPath(xmlPath))

                ' Invio mail
                If Session("emailenabled") = "1" Then
                    Dim ConnectorDB As SqlConnection
                    Dim SqlCom As SqlCommand

                    Try
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

                        If chkSendMailToUser.Checked() Then
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                            emails.Clear()
                            emails.Add(New MailAddress(usermail))
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                        Else
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
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
                            idelm0.InnerText = idguasto
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
                            idelm0.InnerText = idguasto
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
                        idelm0.InnerText = idguasto
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
                Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
                Exit Sub
            End If

            ' dettagli5
            If IsDBNull(Row.Item(18)) Then
                If CheckBoxVisible.Checked = False Then
                    Row.Item(18) = "N§" & "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                Else
                    Row.Item(18) = "<b>" & data & " | " & ora & "</b><br />" & dettaglio
                End If
                Row.Item(19) = Session("username")
                Row.Item(23) = "aperta"
                da.UpdateCommand = cb.GetUpdateCommand
                da.Update(ds, "guasti")
                da.Dispose()
                cb.Dispose()
                ds.Dispose()
                ' scrivo log
                Dim xmlPath As String = "../App_Data/tktlog.xml"
                Dim xWr As New XmlDocument
                xWr.Load(Server.MapPath(xmlPath))
                Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
                Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWUPDATE", Nothing)
                xWr.DocumentElement.AppendChild(elem)
                Dim idelm As XmlElement = xWr.CreateElement("ID")
                idelm.InnerText = idguasto
                elem.AppendChild(idelm)
                Dim userelm As XmlElement = xWr.CreateElement("USER")
                userelm.InnerText = Session("username")
                elem.AppendChild(userelm)
                Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
                DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                elem.AppendChild(DateTimeElm)
                xWr.Save(Server.MapPath(xmlPath))

                ' Invio mail
                If Session("emailenabled") = "1" Then
                    Dim ConnectorDB As SqlConnection
                    Dim SqlCom As SqlCommand

                    Try
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

                        If chkSendMailToUser.Checked() Then
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                            emails.Clear()
                            emails.Add(New MailAddress(usermail))
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                        Else
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String715") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String716") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String230") & ": " & dettaglio & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
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
                            idelm0.InnerText = idguasto
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
                            idelm0.InnerText = idguasto
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
                        idelm0.InnerText = idguasto
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
                Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
                Exit Sub
            End If

            ErrorMsg.Text = globals.ResourceHelper.GetString("String224")
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)

            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "guasti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

    End Sub

    ''' <summary>
    ''' Si verifica alla chiusura del ticket.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ChiuditicketButton_Click(sender As Object, e As EventArgs)
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim motivochiusura As String = TextNewUpdate.Text

        If String.IsNullOrEmpty(Convert.ToString(motivochiusura.Replace(" ", ""))) Then
            ErrorMsg.Text = "Non hai specificato nessun motivo per la chiusura del ticket. Impossibile chiudere."
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Exit Sub
        End If

        Dim DbPathtop As String = "", qrytop As String = "", connecttop As String = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "guasti")

            Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
            Row.Item(20) = motivochiusura
            Row.Item(21) = data & " | " & ora
            Row.Item(22) = Session("username")
            Row.Item(23) = "chiusa"

            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "guasti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' scrivo log
        Dim xmlPath As String = "../App_Data/tktlog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "TKTCLOSED", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = idguasto
        elem.AppendChild(idelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        ' Invio mail
        If Session("emailenabled") = "1" Then
            Dim read As SqlDataReader
            Dim ConnectorDB As SqlConnection
            Dim SqlCom As SqlCommand

            Try
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

                If chkSendMailToUser.Checked() Then
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String717") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String718") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String718") & motivochiusura & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                    emails.Clear()
                    emails.Add(New MailAddress(userrich))
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String717") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String718") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String718") & motivochiusura & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                Else
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String717") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String718") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & DateTime.Now.ToLocalTime.ToShortDateString() & globals.ResourceHelper.GetString("String713") & DateTime.Now.ToLongTimeString() & "<br />" & globals.ResourceHelper.GetString("String718") & motivochiusura & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
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
                    idelm0.InnerText = idguasto
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
                    idelm0.InnerText = idguasto
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
                idelm0.InnerText = idguasto
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

        Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
    End Sub

    ''' <summary>
    ''' Si verifica all'aggiunta del ticket in attesa.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub AttesaticketButton_Click(sender As Object, e As EventArgs)
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim motivoattesa As String = TextNewUpdate.Text

        If String.IsNullOrEmpty(Convert.ToString(motivoattesa.Replace(" ", ""))) Then
            ErrorMsg.Text = globals.ResourceHelper.GetString("String721")
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Exit Sub
        End If

        Dim DbPathtop As String = "", qrytop As String = "", connecttop As String = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "guasti")

            Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
            Row.Item(23) = "in attesa"
            Row.Item(24) = Row.Item(24).ToString & "<div style='width:100%;height:auto;padding-top:10px;padding-bottom:10px;'><b>" & globals.ResourceHelper.GetString("String720") & data & " | " & ora & " da<br />" & Session("username") & "</b><br/>" & motivoattesa & "<br/></div>"

            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "guasti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' scrivo log
        Dim xmlPath As String = "../App_Data/tktlog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWWAIT", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = idguasto
        elem.AppendChild(idelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        ' Invio mail
        If Session("emailenabled") = "1" Then
            Dim read As SqlDataReader
            Dim ConnectorDB As SqlConnection
            Dim SqlCom As SqlCommand

            Try
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

                If chkSendMailToUser.Checked() Then
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String722") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String723") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br />" & globals.ResourceHelper.GetString("String724") & motivoattesa & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                    emails.Clear()
                    emails.Add(New MailAddress(userrich))
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String722") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String723") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br />" & globals.ResourceHelper.GetString("String724") & motivoattesa & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                Else
                    resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String722") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String723") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br />" & globals.ResourceHelper.GetString("String724") & motivoattesa & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
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
                    idelm0.InnerText = idguasto
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
                    idelm0.InnerText = idguasto
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
                idelm0.InnerText = idguasto
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

        Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
    End Sub


    ''' <summary>
    ''' Si verifica al click su upload file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ButtonUpload_Click(sender As Object, e As EventArgs)
        If UploadFileTkt.HasFile Then
            Dim fileExt As String
            Dim newfilename As String = Guid.NewGuid().ToString
            Dim title As String = TextBoxUploadFileTkt.Text
            Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
            Dim ora As String = DateTime.Now.ToLongTimeString()
            Dim finfo As New FileInfo(UploadFileTkt.PostedFile.FileName)
            Dim filenametotext As String = finfo.Name
            Dim DbPathtop As String = "", qrytop As String = "", connecttop As String = ""

            If title.Replace(" ", "") = "" Then
                ErrMsg.Text = globals.ResourceHelper.GetString("String225")
                PanelErr.Visible = True
                Exit Sub
            End If

            fileExt = System.IO.Path.GetExtension(UploadFileTkt.FileName)

            Try

                UploadFileTkt.SaveAs(Server.MapPath("../Files_Uploaded/") &
                       newfilename & fileExt)

                If Session("autenticato") = "admin" Or (Session("autenticato") = "personale") Then
                    If CheckBoxVisibileClienteFile.Checked = True Then

                        DbPathtop = "../App_Data/itstdb.mdf"
                        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                        Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
                cb As New SqlCommandBuilder(da)

                            Dim ds As New DataSet
                            da.Fill(ds, "guasti")

                            Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
                            Row.Item(25) = Row.Item(25).ToString & newfilename & fileExt & ","
                            Row.Item(26) = Row.Item(26).ToString & "<br /><b>" & globals.ResourceHelper.GetString("String226") & data & " | " & ora & " da<br />" & Session("username") & "</b><br/>" & title & "<br />" & globals.ResourceHelper.GetString("String228") & " <a href='../Files_Uploaded/" & newfilename & fileExt & "' download='download'>" & filenametotext & "</a><br/>§"

                            da.UpdateCommand = cb.GetUpdateCommand
                            da.Update(ds, "guasti")

                            da.Dispose()
                            cb.Dispose()
                            ds.Dispose()
                        End Using
                    Else
                        DbPathtop = "../App_Data/itstdb.mdf"
                        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                        Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
                cb As New SqlCommandBuilder(da)

                            Dim ds As New DataSet
                            da.Fill(ds, "guasti")

                            Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
                            Row.Item(29) = Row.Item(29).ToString & newfilename & fileExt & ","
                            Row.Item(30) = Row.Item(30).ToString & "<br /><b>" & globals.ResourceHelper.GetString("String227") & data & " | " & ora & " da<br />" & Session("username") & "</b><br/>" & title & "<br />" & globals.ResourceHelper.GetString("String228") & " <a href='../Files_Uploaded/" & newfilename & fileExt & "' download='download'>" & filenametotext & "</a><br/>§"

                            da.UpdateCommand = cb.GetUpdateCommand
                            da.Update(ds, "guasti")

                            da.Dispose()
                            cb.Dispose()
                            ds.Dispose()
                        End Using
                    End If

                Else
                    DbPathtop = "../App_Data/itstdb.mdf"
                    connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                    Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
            cb As New SqlCommandBuilder(da)

                        Dim ds As New DataSet
                        da.Fill(ds, "guasti")

                        Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
                        Row.Item(25) = Row.Item(25).ToString & newfilename & fileExt & ","
                        Row.Item(26) = Row.Item(26).ToString & "<br /><b>" & globals.ResourceHelper.GetString("String226") & data & " | " & ora & " da<br />" & Session("username") & "</b><br/>" & title & "<br />" & globals.ResourceHelper.GetString("String228") & " <a href='../Files_Uploaded/" & newfilename & fileExt & "' download='download'>" & filenametotext & "</a><br/>§"

                        da.UpdateCommand = cb.GetUpdateCommand
                        da.Update(ds, "guasti")

                        da.Dispose()
                        cb.Dispose()
                        ds.Dispose()
                    End Using
                End If

                PanelErr.Visible = False

                ' scrivo log
                Dim xmlPath As String = "../App_Data/tktlog.xml"
                Dim xWr As New XmlDocument
                xWr.Load(Server.MapPath(xmlPath))
                Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
                Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWFILE", Nothing)
                xWr.DocumentElement.AppendChild(elem)
                Dim idelm As XmlElement = xWr.CreateElement("ID")
                idelm.InnerText = idguasto
                elem.AppendChild(idelm)
                Dim filelm As XmlElement = xWr.CreateElement("FILE")
                filelm.InnerText = newfilename & fileExt
                elem.AppendChild(filelm)
                Dim userelm As XmlElement = xWr.CreateElement("USER")
                userelm.InnerText = Session("username")
                elem.AppendChild(userelm)
                Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
                DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
                elem.AppendChild(DateTimeElm)
                xWr.Save(Server.MapPath(xmlPath))

                ' Invio mail
                If Session("emailenabled") = "1" Then
                    Dim read As SqlDataReader
                    Dim ConnectorDB As SqlConnection
                    Dim SqlCom As SqlCommand

                    Try
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

                        If chkSendMailToUser.Checked() Then
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String725") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String726") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                            emails.Clear()
                            emails.Add(New MailAddress(userrich))
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String725") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String726") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
                        Else
                            resmail = ITSuite_Email.SendMail(Session("utentemail"), Session("passwordmail"), Session("servermail"), CInt(Session("portamail")), Session("sslmail"), New MailAddress(Session("mittentemail")), emails, globals.ResourceHelper.GetString("String725") & idguasto, Session("intromail") & "<br/>" & globals.ResourceHelper.GetString("String726") & idguasto & globals.ResourceHelper.GetString("String220") & Session("username") & globals.ResourceHelper.GetString("String712") & data & globals.ResourceHelper.GetString("String713") & ora & "<br /><a href='" & Session("generalserver") & "/gestione_guasti/dettagli_guasto.aspx?id=" & idguasto & "'>" & globals.ResourceHelper.GetString("String714") & "</a><br /><br />" & Session("endmail"))
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
                            idelm0.InnerText = idguasto
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
                            idelm0.InnerText = idguasto
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
                        idelm0.InnerText = idguasto
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

                Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
                Exit Sub

            Catch ex As Exception
                ErrMsg.Text = "Errore durante l'upload del file. Dettagli: " & ex.ToString
                PanelErr.Visible = True
            End Try

        Else
            ErrMsg.Text = "Non hai selezionato nessun file."
            PanelErr.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Si verifica alla conferma dell'assegnazione di un altro utente.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub OkNewAssign_Click(sender As Object, e As EventArgs)
        Dim DbPathtop As String = "", qrytop As String = "", connecttop As String = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/tktlog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWASSIGN", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = idguasto
        elem.AppendChild(idelm)
        Dim userass As XmlElement = xWr.CreateElement("USER")
        '  userass.InnerText = ResponseUsersList.SelectedItem.Text
        elem.AppendChild(userass)
        Dim userelm As XmlElement = xWr.CreateElement("USEREDITOR")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)
    End Sub

    ''' <summary>
    ''' Aggiunta di dettagli dal cliente al ticket.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub AddDetailsClient_Click(sender As Object, e As EventArgs)
        Dim data As String = DateTime.Now.ToLocalTime.ToShortDateString()
        Dim ora As String = DateTime.Now.ToLongTimeString()
        Dim dettagliocliente As String = TextNewUpdate.Text

        If String.IsNullOrEmpty(Convert.ToString(dettagliocliente.Replace(" ", ""))) Then
            ErrorMsg.Text = "Non hai scritto nessun dettaglio. Impossibile continuare."
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Exit Sub
        End If

        Dim DbPathtop As String = "", qrytop As String = "", connecttop As String = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Using da As New SqlDataAdapter("SELECT * FROM guasti where ID=" & idguasto, connecttop),
            cb As New SqlCommandBuilder(da)

            Dim ds As New DataSet
            da.Fill(ds, "guasti")

            Dim Row As DataRow = ds.Tables("guasti").Rows.Item(0)
            Row.Item(23) = "aperta"
            Row.Item(28) = Row.Item(28).ToString & "<div style='width:100%;height:auto;padding-top:10px;padding-bottom:10px;'><b>Aggiunti dettagli dal cliente il: " & data & " | " & ora & " da<br />" & Session("username") & "</b><br/>" & dettagliocliente & "<br/></div>"

            da.UpdateCommand = cb.GetUpdateCommand
            da.Update(ds, "guasti")

            da.Dispose()
            cb.Dispose()
            ds.Dispose()
        End Using

        ' Scrivo log
        Dim xmlPath As String = "../App_Data/tktlog.xml"
        Dim xWr As New XmlDocument
        xWr.Load(Server.MapPath(xmlPath))
        Dim PCLoggerNode As XmlNode = xWr.SelectSingleNode("TKTLOGGER")
        Dim elem As XmlNode = xWr.CreateNode(XmlNodeType.Element, "NEWCLIENTUPDATE", Nothing)
        xWr.DocumentElement.AppendChild(elem)
        Dim idelm As XmlElement = xWr.CreateElement("ID")
        idelm.InnerText = idguasto
        elem.AppendChild(idelm)
        Dim userelm As XmlElement = xWr.CreateElement("USER")
        userelm.InnerText = Session("username")
        elem.AppendChild(userelm)
        Dim DateTimeElm As XmlElement = xWr.CreateElement("DATETIME")
        DateTimeElm.InnerText = DateTime.Now.ToLocalTime.ToShortDateString() & " | " & DateTime.Now.ToLongTimeString()
        elem.AppendChild(DateTimeElm)
        xWr.Save(Server.MapPath(xmlPath))

        Response.Redirect("dettagli_guasto.aspx?id=" & idguasto)

    End Sub

    ''' <summary>
    ''' Si verifica al bound della lista dei dettagli.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DetailsView1_DataBound(sender As Object, e As EventArgs)
        Dim detvw As DetailsView = sender
        Dim headerRow As DetailsViewRow = detvw.HeaderRow

        detvw.Fields.Item(1).HeaderText = globals.ResourceHelper.GetString("String229")
        detvw.Fields.Item(2).HeaderText = globals.ResourceHelper.GetString("String230")
        detvw.Fields.Item(3).HeaderText = globals.ResourceHelper.GetString("String127")
        detvw.Fields.Item(4).HeaderText = globals.ResourceHelper.GetString("String126")
        detvw.Fields.Item(5).HeaderText = globals.ResourceHelper.GetString("String125")
        detvw.Fields.Item(6).HeaderText = globals.ResourceHelper.GetString("String234")
        detvw.Fields.Item(7).HeaderText = globals.ResourceHelper.GetString("String56")
        detvw.Fields.Item(8).HeaderText = globals.ResourceHelper.GetString("String232")
        detvw.Fields.Item(9).HeaderText = globals.ResourceHelper.GetString("String233")
        detvw.Fields.Item(10).HeaderText = globals.ResourceHelper.GetString("String231")
        detvw.Fields.Item(11).HeaderText = globals.ResourceHelper.GetString("String235")
        detvw.Fields.Item(12).HeaderText = globals.ResourceHelper.GetString("String128")

    End Sub
End Class
