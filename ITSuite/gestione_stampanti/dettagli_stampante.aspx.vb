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

Partial Class gestione_stampanti_dettagli_stampante
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' L'id della stampante selezionata.
    ''' </summary>
    Public Shared id_stampante, ip_stampante As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String433") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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
        SqlStampSource.ConnectionString = ITSuite_Database.DBConnectionStrings.SQLSrvConnectionString()
        SqlStampSource.SelectCommand = ITSuite_Database.DBConnectionStrings.SQLCommands.SQLDettaglioStampCommand()

        id_stampante = Request.QueryString("id_stampante")

        Dim qrytop As String = "SELECT * FROM stampanti WHERE ID=" & CInt(id_stampante)
        Dim DbPathtop As String, Conntop As SqlConnection
        DbPathtop = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        Dim cmdtop As SqlCommand = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()

            IdLabel.Text = "ID:&nbsp;<b>" & id_stampante & "</b>"
            MarcaLabel.Text = globals.ResourceHelper.GetString("String120") & ":&nbsp;<b>" & read.Item("marca_stampante") & "</b>"
            ModelloLabel.Text = globals.ResourceHelper.GetString("String122") & ":&nbsp;<b>" & read.Item("modello_stampante") & "</b>"
            SNLabel.Text = globals.ResourceHelper.GetString("String123") & ":&nbsp;<b>" & read.Item("numero_serie_stampante") & "</b>"
            InvLabel.Text = globals.ResourceHelper.GetString("String124") & ":&nbsp;<b>" & read.Item("inventario_stampante") & "</b>"
            AnnoLabel.Text = globals.ResourceHelper.GetString("String131") & ":&nbsp;<b>" & read.Item("anno_stampante") & "</b>"

            ' driver
            If read.Item("cartella_stampante") IsNot DBNull.Value Then
                If Not String.IsNullOrEmpty(read.Item("cartella_stampante").ToString) Then
                    LabelDrivers.Text = "<b><a href='../drivers/Default.aspx?path=" & read.Item("cartella_stampante").ToString & "&dev=" & read.Item("marca_stampante").ToString & " " & read.Item("modello_stampante").ToString & "'>" & read.Item("cartella_stampante").ToString & "</a></b>"
                Else
                    LabelDrivers.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String149") & "</b></font>"
                End If
            Else
                LabelDrivers.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String149") & "</b></font>"
            End If

            ' ip
            If read.Item("ip_stampante") IsNot DBNull.Value Then
                If Not String.IsNullOrEmpty(read.Item("ip_stampante").ToString) Then
                    ip_stampante = read.Item("ip_stampante")
                    LabelIP.Text = "<b>" & read.Item("ip_stampante").ToString & "<b>"
                Else
                    LabelIP.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String150") & "</b></font>"
                End If
            Else
                LabelIP.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String150") & "</b></font>"
            End If

            ' ultima modifica
            If read.Item("autoreultimamod_stampante") IsNot DBNull.Value Then
                If Not String.IsNullOrEmpty(read.Item("autoreultimamod_stampante").ToString) Then
                    LabelAutoreUltima.Text = "<b>" & read.Item("autoreultimamod_stampante").ToString & "<b>"
                    LabelDataoraUltima.Text = "<b>" & read.Item("ultimamod_stampante").ToString & "<b>"
                Else
                    LabelAutoreUltima.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String151") & "</b></font>"
                    LabelDataoraUltima.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String151") & "</b></font>"
                End If
            Else
                LabelAutoreUltima.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String151") & "</b></font>"
                LabelDataoraUltima.Text = "<font color='gray'><b>" & globals.ResourceHelper.GetString("String151") & "</b></font>"
            End If

            ' Immagine
            If read.Item("FileName").ToString <> "" Then
                PhotoDetails.Enabled = True
                PhotoDetails.Attributes.Add("onclick", "window.open('vedi_foto.aspx?id=" & id_stampante & "', '', '');return false;")
                PhotoDetails.Attributes.Add("style", "cursor:pointer")
                PhotoDetails.Font.Underline = True
                PhotoDetails.Text = read.Item("FileName").ToString
                Try
                    Dim pictureData As Byte() = DirectCast(read.Item("BinaryData"), Byte())
                    generalImage.Src = "data:image/jpg;base64," & Convert.ToBase64String(pictureData)
                    Aimage.NavigateUrl = "vedi_foto.aspx?id=" & id_stampante
                    Aimage.Target = "_blank"
                Catch ex As Exception
                    Aimage.NavigateUrl = "#"
                    generalImage.Src = "../img/no-img-stamp-200x200.png"
                End Try

            Else
                generalImage.Src = "../img/no-img-stamp-200x200.png"
                PhotoDetails.Attributes.Remove("onclick")
                PhotoDetails.Font.Underline = False
                PhotoDetails.Attributes.Add("style", "cursor:default")
                PhotoDetails.Text = globals.ResourceHelper.GetString("String152")
                PhotoDetails.Enabled = False
            End If
        End While

        Conntop.Close()
        read.Close()
        cmdtop.Dispose()

    End Sub

    ''' <summary>
    ''' Si verifica al bound della lista dei dettagli.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DetailsView1_DataBound(sender As Object, e As EventArgs)
        Dim detvw As DetailsView = sender
        Dim headerRow As DetailsViewRow = detvw.HeaderRow

        detvw.Fields.Item(0).HeaderText = globals.ResourceHelper.GetString("String125")
        detvw.Fields.Item(1).HeaderText = globals.ResourceHelper.GetString("String126")
        detvw.Fields.Item(2).HeaderText = globals.ResourceHelper.GetString("String127")
        detvw.Fields.Item(3).HeaderText = globals.ResourceHelper.GetString("String128")
        detvw.Fields.Item(4).HeaderText = globals.ResourceHelper.GetString("String132")
        detvw.Fields.Item(5).HeaderText = globals.ResourceHelper.GetString("String129")
        detvw.Fields.Item(6).HeaderText = globals.ResourceHelper.GetString("String153")
        detvw.Fields.Item(7).HeaderText = globals.ResourceHelper.GetString("String154")

    End Sub
End Class
