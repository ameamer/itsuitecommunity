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

Partial Class opzioni_generali_opzioni_generali_home
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()
    Public stdusr As String
    Public tchusr As String
    Public tchusrmod As String
    Public tchusrass As String
    Public gestguast As String
    Public enableswaz As String
    Public enableintsw As String
    Public enableassprd As String
    Public enablewinsvc As String
    Public enablenet As String
    Public autoipint As String
    Public enableservnet As String
    Public resultpaging As String
    Public srvgen As String
    Public strum1 As String, strum2 As String, strum3 As String, strum4 As String,
            strum5 As String, strum6 As String, strum7 As String, strum8 As String, strum9 As String,
            strum10 As String
    Public strum1T As String, strum2T As String, strum3T As String, strum4T As String,
            strum5T As String, strum6T As String, strum7T As String, strum8T As String, strum9T As String,
            strum10T As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String26") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If
        Dim s As String = Request.QueryString("s")
        Diagnostics.Debug.WriteLine("Salvataggio OK")
        Select Case s
            Case "ok"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String659")
                ErrorMsg.Visible = True
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
        End Select

        Dim qry As String = Request.QueryString("e")

        Select Case qry
            Case "pgn"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String660")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "pgnnmb"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String661")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st1-1"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "1"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st1"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "1"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st2-2"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "2"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st2"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "2"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st3-3"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "3"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st3"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "3"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st4-4"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "4"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st4"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "4"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st5-5"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "5"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st5"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "5"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st6-6"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "6"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st6"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "6"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st7-7"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "7"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st7"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "7"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st8-8"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "8"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st8"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "8"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st9-9"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "9"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st9"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "9"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st10-10"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String662") & "10"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "st10"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String663") & "10"
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
        End Select

        ' Ricavo valori da sessione
        stdusr = Session("abilita_utenti_standard")
        tchusr = Session("abilita_utenti_stpers")
        gestguast = Session("abilita_gestione_guasti")
        enableintsw = Session("abilita_software_aziendale")
        enableassprd = Session("abilita_assistenza_prodotti")
        enablewinsvc = Session("abilita_servizi_windows")
        enablenet = Session("abilita_servizi_rete")
        autoipint = Session("abilita_autocompip")
        enableservnet = Session("servizi_rete")
        resultpaging = Session("risultati_pag")
        tchusrmod = Session("abilita_utenti_stpers_mod")
        tchusrass = Session("abilita_utenti_stpers_ass")
        srvgen = Session("generalserver")

        ' Ricavo valori da DB
        Dim qrytop As String = "SELECT * FROM impostazionigenerali"
        Dim DbPathtop As String = "../App_Data/itstdb.mdf"
        Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
        Dim Conntop As New SqlConnection(connecttop)
        Dim cmdtop As New SqlCommand(qrytop, Conntop)
        Conntop.Open()
        Dim read As SqlDataReader = cmdtop.ExecuteReader()
        While read.Read()

            If read.Item("strumenti1").ToString IsNot Nothing And read.Item("strumenti1").ToString IsNot DBNull.Value And
                read.Item("strumenti1title").ToString IsNot Nothing And read.Item("strumenti1title").ToString IsNot DBNull.Value Then
                strum1 = read.Item("strumenti1").ToString
                strum1T = read.Item("strumenti1title").ToString
            Else
                strum1 = ""
                strum1T = ""
            End If

            If read.Item("strumenti2").ToString IsNot Nothing And read.Item("strumenti2").ToString IsNot DBNull.Value And
                read.Item("strumenti2title").ToString IsNot Nothing And read.Item("strumenti2title").ToString IsNot DBNull.Value Then
                strum2 = read.Item("strumenti2").ToString
                strum2T = read.Item("strumenti2title").ToString
            Else
                strum2 = ""
                strum2T = ""
            End If

            If read.Item("strumenti3").ToString IsNot Nothing And read.Item("strumenti3").ToString IsNot DBNull.Value And
                read.Item("strumenti3title").ToString IsNot Nothing And read.Item("strumenti3title").ToString IsNot DBNull.Value Then
                strum3 = read.Item("strumenti3").ToString
                strum3T = read.Item("strumenti3title").ToString
            Else
                strum3 = ""
                strum3T = ""
            End If

            If read.Item("strumenti4").ToString IsNot Nothing And read.Item("strumenti4").ToString IsNot DBNull.Value And
                read.Item("strumenti4title").ToString IsNot Nothing And read.Item("strumenti4title").ToString IsNot DBNull.Value Then
                strum4 = read.Item("strumenti4").ToString
                strum4T = read.Item("strumenti4title").ToString
            Else
                strum4 = ""
                strum4T = ""
            End If

            If read.Item("strumenti5").ToString IsNot Nothing And read.Item("strumenti5").ToString IsNot DBNull.Value And
                read.Item("strumenti5title").ToString IsNot Nothing And read.Item("strumenti5title").ToString IsNot DBNull.Value Then
                strum5 = read.Item("strumenti5").ToString
                strum5T = read.Item("strumenti5title").ToString
            Else
                strum5 = ""
                strum5T = ""
            End If

            If read.Item("strumenti6").ToString IsNot Nothing And read.Item("strumenti6").ToString IsNot DBNull.Value And
                read.Item("strumenti6title").ToString IsNot Nothing And read.Item("strumenti6title").ToString IsNot DBNull.Value Then
                strum6 = read.Item("strumenti6").ToString
                strum6T = read.Item("strumenti6title").ToString
            Else
                strum6 = ""
                strum6T = ""
            End If

            If read.Item("strumenti7").ToString IsNot Nothing And read.Item("strumenti7").ToString IsNot DBNull.Value And
                read.Item("strumenti7title").ToString IsNot Nothing And read.Item("strumenti7title").ToString IsNot DBNull.Value Then
                strum7 = read.Item("strumenti7").ToString
                strum7T = read.Item("strumenti7title").ToString
            Else
                strum7 = ""
                strum7T = ""
            End If

            If read.Item("strumenti8").ToString IsNot Nothing And read.Item("strumenti8").ToString IsNot DBNull.Value And
                read.Item("strumenti8title").ToString IsNot Nothing And read.Item("strumenti8title").ToString IsNot DBNull.Value Then
                strum8 = read.Item("strumenti8").ToString
                strum8T = read.Item("strumenti8title").ToString
            Else
                strum8 = ""
                strum8T = ""
            End If

            If read.Item("strumenti9").ToString IsNot Nothing And read.Item("strumenti9").ToString IsNot DBNull.Value And
                read.Item("strumenti9title").ToString IsNot Nothing And read.Item("strumenti9title").ToString IsNot DBNull.Value Then
                strum9 = read.Item("strumenti9").ToString
                strum9T = read.Item("strumenti9title").ToString
            Else
                strum9 = ""
                strum9T = ""
            End If

            If read.Item("strumenti10").ToString IsNot Nothing And read.Item("strumenti10").ToString IsNot DBNull.Value And
                read.Item("strumenti10title").ToString IsNot Nothing And read.Item("strumenti10title").ToString IsNot DBNull.Value Then
                strum10 = read.Item("strumenti10").ToString
                strum10T = read.Item("strumenti10title").ToString
            Else
                strum10 = ""
                strum10T = ""
            End If

        End While

        Conntop.Close()
        Conntop.Dispose()
        read.Close()
        cmdtop.Dispose()

    End Sub

    ''' <summary>
    ''' Controllo inserimento nuovo elemento.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs)
        For Each s As DictionaryEntry In e.Values
            If s.Value Is Nothing Then
                ErrorMsg.Text = globals.ResourceHelper.GetString("String286")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
                e.Cancel = True
            End If
        Next
    End Sub

End Class
