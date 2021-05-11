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
Imports System.Data.OleDb
Imports System.Data.SqlClient

Partial Class gestione_pc_det_pc
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public id_pc, ip_pc, id_stamp, id_hw As String

    ' Variabili database
    Private DbPathtop, connecttop, qrytop As String
    Private ConnectorDB As SqlConnection
    Private SqlCom As SqlCommand

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String369") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        ' Imposto SQL
        SqlDataSource1.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
        SqlDataSource1.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLDettaglioPCCommand()

        ' PC
        id_pc = Request.QueryString("id_pc")
        qrytop = ""
        DbPathtop = "../App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "Select * from datapc where (ID like '%" & id_pc & "%')"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        If Not read.Read() Then
            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()
            Response.Redirect("../logout.aspx")
            Exit Sub
        Else
            ' Imposto dettagli PC
            IdLabel.Text = "ID:&nbsp;<b>" & id_pc & "</b>"
            TipoLabel.Text = globals.ResourceHelper.GetString("String51") & ":&nbsp;<b>" & read.Item("tipo_pc") & "</b>"
            MarcaLabel.Text = globals.ResourceHelper.GetString("String120") & ":&nbsp;<b>" & read.Item("marca_pc") & "</b>"
            ModelloLabel.Text = globals.ResourceHelper.GetString("String122") & ":&nbsp;<b>" & read.Item("modello_pc") & "</b>"
            SNLabel.Text = globals.ResourceHelper.GetString("String123") & ":&nbsp;<b>" & read.Item("serie_pc") & "</b>"
            AnnoLabel.Text = globals.ResourceHelper.GetString("String131") & ":&nbsp;<b>" & read.Item("anno_pc") & "</b>"

            ' Autore ultima modifica
            If read.Item("autore_ultimapc").ToString IsNot DBNull.Value And Not String.IsNullOrEmpty(read.Item("autore_ultimapc").ToString) Then
                LabelAutoreUltimaPC.Text = "<b>" & read.Item("autore_ultimapc").ToString & "</b>"
                LabelDataoraUltimaPC.Text = "<b>" & read.Item("dataora_ultimapc").ToString & "</b>"
            Else
                LabelAutoreUltimaPC.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String151") & "</b></font>"
                LabelDataoraUltimaPC.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String151") & "</b></font>"
            End If

            ' Cartella driver
            If read.Item("cartella_pc").ToString IsNot DBNull.Value And Not String.IsNullOrEmpty(read.Item("cartella_pc").ToString) Then
                LabelDrivers.Text = "<b><a href='../drivers/Default.aspx?path=" & read.Item("cartella_pc").ToString & "&dev=" & read.Item("marca_pc").ToString & " " & read.Item("modello_pc").ToString & "'>" & read.Item("cartella_pc").ToString & "</a></b>"
            Else
                LabelDrivers.Text = "<b><font style='color:gray;'>" & globals.ResourceHelper.GetString("String149") & "</a></b>"
            End If

            ' Indirizzo IP
            If (read.Item("indirizzo_ip_pc").ToString IsNot DBNull.Value) And (Session("servizi_rete") = "1") Then
                If Not String.IsNullOrEmpty(read.Item("indirizzo_ip_pc").ToString) Then
                    ip_pc = read.Item("indirizzo_ip_pc").ToString
                    LabelIP.Text = "<b>" & read.Item("indirizzo_ip_pc").ToString & "</b>"
                Else
                    LabelIP.Text = "<b><font style='color:gray;'>" & globals.ResourceHelper.GetString("String150") & "</a></b>"
                End If
            End If
            If (read.Item("indirizzo_ip_pc").ToString IsNot DBNull.Value) And (Session("servizi_rete") = "0") Then
                If Not String.IsNullOrEmpty(read.Item("indirizzo_ip_pc").ToString) Then
                    ip_pc = read.Item("indirizzo_ip_pc").ToString
                    LabelIP.Text = "<b>" & read.Item("indirizzo_ip_pc").ToString & "</b>"
                End If
            End If

            ' Inmmagine
            If (read.Item("FileName").ToString IsNot DBNull.Value) Then
                If Not String.IsNullOrEmpty(read.Item("FileName").ToString) Then
                    ip_pc = read.Item("indirizzo_ip_pc").ToString
                    FileLabel.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_pc & "', '', '');return false;")
                    FileLabel.Attributes.Add("style", "cursor:pointer")
                    FileLabel.Font.Underline = True
                    FileLabel.Text = read.Item("FileName").ToString
                    FilePanel.Visible = True
                    Try
                        Dim pictureData As Byte() = DirectCast(read.Item("BinaryData"), Byte())
                        generalImage.Src = "data:image/jpg;base64," & Convert.ToBase64String(pictureData)
                        Aimage.NavigateUrl = "vedi_foto.aspx?id=" & id_pc
                        Aimage.Target = "_blank"
                    Catch ex As Exception
                        Aimage.NavigateUrl = "#"
                        generalImage.Src = "../img/no-img-pc-200x200.png"
                    End Try

                Else
                    generalImage.Src = "../img/no-img-pc-200x200.png"
                    FileLabel.Attributes.Remove("onclick")
                    FileLabel.Font.Underline = False
                    FileLabel.Attributes.Add("style", "cursor:default")
                    FileLabel.Text = "Nessuna foto presente"
                    FilePanel.Visible = False
                End If
            End If

            ' Ricavo id di stampante e altro hw collegato
            id_stamp = read.Item("id_stampante_collegata").ToString
            id_hw = read.Item("id_altrohw_collegato").ToString

            ' Marca monitor
            If (read.Item("marca_video_pc").ToString IsNot DBNull.Value) Then
                If Not String.IsNullOrEmpty(read.Item("marca_video_pc").ToString) Then
                    MonitorPanel.Visible = True
                    MarcaMonitorLabel.Text = read.Item("marca_video_pc").ToString
                    ModelloMonitorLabel.Text = read.Item("modello_video_pc").ToString
                    PolliciMonitorLabel.Text = read.Item("pollici_video_pc").ToString
                    SerieMonitorLabel.Text = read.Item("serie_video_pc").ToString
                    InvMonitorLabel.Text = read.Item("inventario_video_pc").ToString
                    StatoMonitorLabel.Text = read.Item("stato_video_pc").ToString
                    AnnoMonitorLabel.Text = read.Item("anno_video_pc").ToString
                    NoteMonitorLabel.Text = read.Item("note_video_pc").ToString
                End If
            End If

            ConnectorDB.Close()
            ConnectorDB.Dispose()
            read.Close()
            SqlCom.Dispose()

            ' Stampante collegata
            qrytop = ""
            DbPathtop = "../App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = "Select * from stampanti where (ID like '%" & id_stamp & "%')"
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            read = SqlCom.ExecuteReader()
            If Not read.Read() Then
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()
            Else
                If Not String.IsNullOrEmpty(id_stamp) Then
                    StampPanel.Visible = True
                    MarcaStampanteLabel.Text = read.Item("marca_stampante").ToString
                    ModelloStampanteLabel.Text = read.Item("modello_stampante").ToString
                    SerieStampanteLabel.Text = read.Item("numero_serie_stampante").ToString
                    If Not String.IsNullOrEmpty(read.Item("inventario_stampante").ToString) Then
                        InvStampanteLabel.Text = read.Item("inventario_stampante").ToString
                    Else
                        InvStampanteLabel.Text = "<font color='gray'>" & globals.ResourceHelper.GetString("String368") & "</font>"
                    End If
                    StatoStampanteLabel.Text = read.Item("stato_stampante").ToString
                Else
                    StampPanel.Visible = False
                End If
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()
            End If

            ' Altro hardware collegato
            qrytop = ""
            DbPathtop = "../App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            qrytop = "Select * from datahardware where (ID like '%" & id_hw & "%')"
            ConnectorDB = New SqlConnection(connecttop)
            SqlCom = New SqlCommand(qrytop, ConnectorDB)
            ConnectorDB.Open()
            read = SqlCom.ExecuteReader()
            If Not read.Read() Then
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()
            Else
                If Not String.IsNullOrEmpty(id_hw) Then
                    AltroHWPanel.Visible = True
                    TipoHWLabel.Text = read.Item("tipo_hardware").ToString
                    MarcaHWLabel.Text = read.Item("tipo_hardware").ToString
                    MarcaHWLabel.Text = read.Item("marca_hardware").ToString
                    ModelloHWLabel.Text = read.Item("modello_hardware").ToString
                    SerieHWLabel.Text = read.Item("serie_hardware").ToString
                    StatoHWLabel.Text = read.Item("stato_hardware").ToString
                    If Not String.IsNullOrEmpty(read.Item("inventario_hardware").ToString) Then
                        InvHWLabel.Text = read.Item("inventario_hardware").ToString
                    Else
                        InvHWLabel.Text = "<font color='gray'>Nessun numero inventario presente</font>"
                    End If
                Else
                    AltroHWPanel.Visible = False
                End If
                ConnectorDB.Close()
                ConnectorDB.Dispose()
                read.Close()
                SqlCom.Dispose()
            End If

        End If

    End Sub

    ''' <summary>
    ''' Si verifica al bound della lista dei dettagli.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DetailsView1_DataBound(sender As Object, e As EventArgs)
        Dim detvw As DetailsView = sender
        Dim headerRow As DetailsViewRow = detvw.HeaderRow

        detvw.Fields.Item(0).HeaderText = globals.ResourceHelper.GetString("String376")
        detvw.Fields.Item(1).HeaderText = globals.ResourceHelper.GetString("String366")
        detvw.Fields.Item(2).HeaderText = globals.ResourceHelper.GetString("String124")
        detvw.Fields.Item(3).HeaderText = globals.ResourceHelper.GetString("String351")
        detvw.Fields.Item(4).HeaderText = globals.ResourceHelper.GetString("String128")
        detvw.Fields.Item(5).HeaderText = globals.ResourceHelper.GetString("String377")
        detvw.Fields.Item(6).HeaderText = globals.ResourceHelper.GetString("String344")
        detvw.Fields.Item(7).HeaderText = globals.ResourceHelper.GetString("String378")
        detvw.Fields.Item(8).HeaderText = globals.ResourceHelper.GetString("String379")
        detvw.Fields.Item(9).HeaderText = globals.ResourceHelper.GetString("String125")
        detvw.Fields.Item(10).HeaderText = globals.ResourceHelper.GetString("String126")
        detvw.Fields.Item(11).HeaderText = globals.ResourceHelper.GetString("String127")
        detvw.Fields.Item(12).HeaderText = globals.ResourceHelper.GetString("String380")
        detvw.Fields.Item(13).HeaderText = globals.ResourceHelper.GetString("String132")
        detvw.Fields.Item(14).HeaderText = globals.ResourceHelper.GetString("String129")
        detvw.Fields.Item(15).HeaderText = globals.ResourceHelper.GetString("String153")
        detvw.Fields.Item(16).HeaderText = globals.ResourceHelper.GetString("String154")
    End Sub
End Class
