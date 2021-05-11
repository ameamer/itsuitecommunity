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
Imports System.IO

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public iduser As String
    Public relativepath As String
    Public userType As String
    Public enablehwtkt As String
    Public enableasstkt As String
    Public enablenetsrv As String
    Public enableass As String
    Public enablewin As String
    Public enableswaz As String
    Public enabletkt As String
    Public usrnm As String
    Public versionString As String
    Public editionString As String
    Public licenseString As String
    Public copyrightString As String
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Imposto stringhe
        versionString = globals.ResourceHelper.GetString("String653")
        editionString = globals.ResourceHelper.GetString("String770")
        licenseString = globals.ResourceHelper.GetString("String654")
        copyrightString = globals.ResourceHelper.GetString("String771")

        Dim newpath As String = HttpContext.Current.Request.PhysicalApplicationPath & "App_Data"
        'Dim newpath As String = HttpContext.Current.Request.PhysicalApplicationPath & "itsuite\App_Data"
        AppDomain.CurrentDomain.SetData("DataDirectory", newpath)
        relativepath = Request.ApplicationPath
        usrnm = Session("username")
        ' Ricavo dati dell'utente che ha effettuato l'accesso
        iduser = Session("user_id")
        userType = Session("Autenticato")
        enablehwtkt = Session("abilita_utenti_stpers_mod")
        enableasstkt = Session("abilita_utenti_stpers_ass")
        enableass = Session("abilita_assistenza_prodotti")
        enablenetsrv = Session("abilita_servizi_rete")
        enablewin = Session("abilita_servizi_windows")
        enableswaz = Session("abilita_software_aziendale")
        enabletkt = Session("abilita_gestione_guasti")

        ' Componenti aggiuntivi
        Dim pg As String = Path.GetDirectoryName(Page.AppRelativeVirtualPath)
        Dim dirname As String() = pg.Split("\")
        Dim DbPathtop As String = ""
        DbPathtop = "../App_Data/itstdb.mdf"

        Dim qrytop As String = "", connecttop As String = ""
        Dim ConnectorDB As SqlConnection
        Dim SqlCom As SqlCommand
        Dim read As SqlDataReader
        Dim comp As String = ""
        Dim count As Integer = 0
        comp = "<div id=""dropdown-comp"" class=""logo-div-sup-menu-container-dropdown"">"

        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        qrytop = "SELECT * FROM comp ORDER BY name ASC"
        ConnectorDB = New SqlConnection(connecttop)
        SqlCom = New SqlCommand(qrytop, ConnectorDB)
        ConnectorDB.Open()
        read = SqlCom.ExecuteReader()

        While read.Read()
            If Session("Autenticato") = "admin" Then
                comp = comp & "<div class=""logo-div-sup-menu-dropdown"" onclick=""location.href='../Components/" & read.Item("link") & "'""><a href ='../Components/" & read.Item("link") & "' >" & read.Item("name") & "</a></div>"
                count = count + 1
            End If
            If Not read.Item("tktusers").ToString Is DBNull.Value And Session("Autenticato") = "personale" Then
                If Not String.IsNullOrEmpty(read.Item("tktusers").ToString) Then
                    If read.Item("tktusers").ToString = "1" Then
                        comp = comp & "<div class=""logo-div-sup-menu-dropdown"" onclick=""location.href='../Components/" & read.Item("link") & "'""><a href ='../Components/" & read.Item("link") & "' >" & read.Item("name") & "</a></div>"
                        count = count + 1
                    End If
                End If
            End If

            If Not read.Item("customerusers").ToString Is DBNull.Value And Session("Autenticato") = "cliente" Then
                If Not String.IsNullOrEmpty(read.Item("customerusers").ToString) Then
                    If read.Item("customerusers").ToString = "1" Then
                        comp = comp & "<div class=""logo-div-sup-menu-dropdown"" onclick=""location.href='../Components/" & read.Item("link") & "'""><a href ='../Components/" & read.Item("link") & "' >" & read.Item("name") & "</a></div>"
                        count = count + 1
                    End If
                End If
            End If
        End While

        If count = 0 Then
            comp = comp & "<div class=""title-general-submenu"" style=""color:gray; height:auto;"">" & globals.ResourceHelper.GetString("String108") & "</div>"
        End If

        ConnectorDB.Close()
        ConnectorDB.Dispose()
        read.Close()
        SqlCom.Dispose()

        comp = comp & "</div>"

        FucLabel.Text = comp

    End Sub

End Class