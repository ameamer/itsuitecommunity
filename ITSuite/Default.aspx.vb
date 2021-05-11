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
Imports ITSuite_Properties.DefaultPage

Partial Class _Default
    Inherits System.Web.UI.Page

    ' Imposto variabili pubbliche
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
        LabelTitleLogin.Text = globals.ResourceHelper.GetString("String17").ToString()
        nome_utente.Attributes.Item("placeholder") = globals.ResourceHelper.GetString("String7").ToString()
        pswinput.Attributes.Item("placeholder") = globals.ResourceHelper.GetString("String8").ToString()
        LoginButton.Text = globals.ResourceHelper.GetString("String9").ToString()

        ' Scelta linguaggio
        LinkITA.Text = "ITA"
        LinkEN.Text = "ENG"
        LabelIta.Text = "ITA"
        LabelEn.Text = "ENG"
        Select Case globals.ResourceHelper.BaseName
            Case "Resources.Italian"
                LinkITA.Visible = False
                LabelIta.Visible = True
                LabelEn.Visible = False
                LinkEN.Visible = True

            Case "Resources.English"
                LinkITA.Visible = True
                LabelIta.Visible = False
                LabelEn.Visible = True
                LinkEN.Visible = False
        End Select

        ' In caso di messaggi in querystring
        Dim errmsg As String = Request.QueryString("err")
        If errmsg IsNot String.Empty And errmsg IsNot Nothing And errmsg <> "" Then
            Select Case errmsg
                Case "logerr"
                    ErrLabel.Text = globals.ResourceHelper.GetString("String5") & " (0xf01)"
                    ErrLabel.Visible = True
                Case "techusernoenabled"
                    ErrLabel.Text = globals.ResourceHelper.GetString("String6") & " (0xf02)"
                    ErrLabel.Visible = True
                Case "usernoenabled"
                    ErrLabel.Text = globals.ResourceHelper.GetString("String6") & " (0xf03)"
                    ErrLabel.Visible = True
                Case "logerrprp"
                    ErrLabel.Text = globals.ResourceHelper.GetString("String6") & " (0xf04)"
                    ErrLabel.Visible = True
                Case Else
                    ErrLabel.Text = globals.ResourceHelper.GetString("String5") & " (0xf05)"
                    ErrLabel.Visible = False
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Click su Accedi.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub LoginButton_Click(sender As Object, e As EventArgs)

        Dim nome_ut As String = nome_utente.Text,
            pass As String = pswinput.Text

        ' Visualizzo titolo
        ErrLabel.Visible = True

        ' Ricavo dati dal database impostazioni 
        Dim segensettings As Boolean = SetGeneralSettingsProperties()
        If Not segensettings Then
            Response.Redirect("default.aspx?err=logerrprp")
            Response.End()
        End If

        ' Ricavo hash sha256 della password
        Using sha256ash As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
            Dim data As Byte() = sha256ash.ComputeHash(Encoding.UTF8.GetBytes(pass))
            Dim sBuilder As New StringBuilder()
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i
            Dim hash As String = sBuilder.ToString()
            pass_sha256 = hash
        End Using

        ' Verifico dati inseriti e avvio login dell'utente
        qrytop = "Select * FROM Utenti WHERE nomeutente='" & nome_ut & "' AND password='" & pass_sha256 & "'"
        DbPathtop = "App_Data/itstdb.mdf"
        connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & Server.MapPath(DbPathtop)
        Conntop = New SqlConnection(connecttop)
        cmdtop = New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        read = cmdtop.ExecuteReader()
        If Not read.Read() Then
            autenticato = False
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Response.Redirect("default.aspx?err=logerr")
            Response.End()
        Else
            ErrLabel.Visible = False
            autenticato = True

            ' Elementi pagina dell'utente
            paging = read.Item("paging").ToString
            languser = read.Item("lingua").ToString

            ' Controllo abilitazione utenti ticketing
            If Not String.IsNullOrEmpty(abilita_utenti_stpers) Then
                If abilita_utenti_stpers = "0" And read.Item("tipo_utente").ToString = "Tecnico ticketing" Then
                    autenticato = False
                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()
                    Response.Redirect("default.aspx?err=techusernoenabled")
                    Response.End()
                End If
            End If

            ' Controllo se l'utente è attivo
            If Not String.IsNullOrEmpty(read.Item("stato_utente").ToString) Then
                If read.Item("stato_utente").ToString <> "Attivo" Then
                    autenticato = False
                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()
                    Response.Redirect("default.aspx?err=usernoenabled")
                    Response.End()
                End If
            End If

            ' Controllo sfondo dell'utente
            If Not IsDBNull(read.Item("Sfondo").ToString) Then
                If Not String.IsNullOrEmpty(read.Item("Sfondo").ToString) Then
                    sfondo_utente = read.Item("Sfondo").ToString
                End If
            End If

            ' Controllo db e id dell'utente
            database_utente = read.Item("database_utente").ToString
            user_id = read.Item("ID").ToString

            ' Controllo tipo utente e avvio l'accesso
            Select Case read.Item("tipo_utente").ToString

                Case "Amministratore"
                    Session("username") = nome_ut

                    Dim setsess As Boolean = ITSuite_Session.SetLoginSession(ITSuite_Usertypes.Usertype.Admin)
                    If Not setsess Then
                        Conntop.Close()
                        Conntop.Dispose()
                        read.Close()
                        cmdtop.Dispose()
                        Response.Redirect("default.aspx?err=logerrprp")
                        Response.End()
                    End If

                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    Response.Redirect("scelta_servizio/scelta_servizio_admin.aspx")
                    Response.End()

                Case "Tecnico ticketing"
                    Session("username") = nome_ut

                    Dim setsess As Boolean = ITSuite_Session.SetLoginSession(ITSuite_Usertypes.Usertype.TechUser)
                    If Not setsess Then
                        Conntop.Close()
                        Conntop.Dispose()
                        read.Close()
                        cmdtop.Dispose()
                        Response.Redirect("default.aspx?err=logerrprp")
                        Response.End()
                    End If

                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    Response.Redirect("scelta_servizio/scelta_servizio_admin.aspx")
                    Response.End()

                Case "Cliente"
                    Session("username") = nome_ut

                    Dim setsess As Boolean = ITSuite_Session.SetLoginSession(ITSuite_Usertypes.Usertype.Customer)
                    If Not setsess Then
                        Conntop.Close()
                        Conntop.Dispose()
                        read.Close()
                        cmdtop.Dispose()
                        Response.Redirect("default.aspx?err=logerrprp")
                        Response.End()
                    End If

                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    Response.Redirect("gestione_guasti/gestione_guasti_all.aspx")
                    Response.End()

                Case Else
                    Conntop.Close()
                    Conntop.Dispose()
                    read.Close()
                    cmdtop.Dispose()

                    Response.Redirect("logout.aspx")
                    Response.End()

            End Select
        End If
    End Sub

    ''' <summary>
    ''' Click su lingua italiana.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub LinkITA_Click(sender As Object, e As EventArgs)
        Session("lingua") = "IT"
        Response.Redirect("default.aspx")
    End Sub

    ''' <summary>
    ''' Click su lingua inglese.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub LinkEN_Click(sender As Object, e As EventArgs)
        Session("lingua") = "EN"
        Response.Redirect("default.aspx")
    End Sub
End Class
