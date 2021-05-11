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

Partial Class opzioni_generali_salva_opzioni
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

        ' Ricavo i valori immessi
        Dim stdusr As String = Request.Form("enableStdUsers")
        Dim tchusr As String = Request.Form("enableTechUsers")
        Dim tchusrmod As String = Request.Form("enableTechUsersToMod")
        Dim tchusrass As String = Request.Form("enableTechUsersToAss")
        Dim gestguast As String = Request.Form("enableTicketing")
        Dim enableintsw As String = Request.Form("enableSw")
        Dim enableassprd As String = Request.Form("assProd")
        Dim enablewinsvc As String = Request.Form("ServWin")
        Dim enablenet As String = Request.Form("ServNet")
        Dim autoipint As String = Request.Form("AutoIP")
        Dim enableservnet As String = Request.Form("NetInt")
        Dim paging As String = Request.Form("PagingN")
        Dim strum1 As String = Request.Form("Strum1N")
        Dim strum2 As String = Request.Form("Strum2N")
        Dim strum3 As String = Request.Form("Strum3N")
        Dim strum4 As String = Request.Form("Strum4N")
        Dim strum5 As String = Request.Form("Strum5N")
        Dim strum6 As String = Request.Form("Strum6N")
        Dim strum7 As String = Request.Form("Strum7N")
        Dim strum8 As String = Request.Form("Strum8N")
        Dim strum9 As String = Request.Form("Strum9N")
        Dim strum10 As String = Request.Form("Strum10N")
        Dim strum1T As String = Request.Form("Strum1T")
        Dim strum2T As String = Request.Form("Strum2T")
        Dim strum3T As String = Request.Form("Strum3T")
        Dim strum4T As String = Request.Form("Strum4T")
        Dim strum5T As String = Request.Form("Strum5T")
        Dim strum6T As String = Request.Form("Strum6T")
        Dim strum7T As String = Request.Form("Strum7T")
        Dim strum8T As String = Request.Form("Strum8T")
        Dim strum9T As String = Request.Form("Strum9T")
        Dim strum10T As String = Request.Form("Strum10T")
        Dim srvgeneral As String = Request.Form("srvgeneral")


        ' Fix ai valori selezionati
        If String.IsNullOrEmpty(stdusr) Then
            stdusr = "0"
        End If
        If String.IsNullOrEmpty(tchusr) Then
            tchusr = "0"
        End If
        If String.IsNullOrEmpty(gestguast) Then
            gestguast = "0"
        End If
        If String.IsNullOrEmpty(enableintsw) Then
            enableintsw = "0"
        End If
        If String.IsNullOrEmpty(enableassprd) Then
            enableassprd = "0"
        End If
        If String.IsNullOrEmpty(enablewinsvc) Then
            enablewinsvc = "0"
        End If
        If String.IsNullOrEmpty(enablenet) Then
            enablenet = "0"
        End If
        If String.IsNullOrEmpty(autoipint) Then
            autoipint = "0"
        End If
        If String.IsNullOrEmpty(tchusrmod) Then
            tchusrmod = "0"
        End If
        If String.IsNullOrEmpty(tchusrass) Then
            tchusrass = "0"
        End If
        If String.IsNullOrEmpty(enableservnet) Then
            enableservnet = "0"
        End If
        If String.IsNullOrEmpty(paging) Then
            Response.Redirect("opzioni_generali_home.aspx?e=pgn")
            Exit Sub
        End If
        Try
            paging = CInt(paging)
        Catch ex As Exception
            Response.Redirect("opzioni_generali_home.aspx?e=pgnnmb")
            Exit Sub
        End Try

        If String.IsNullOrEmpty(strum1) And Not String.IsNullOrEmpty(strum1T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st1")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum1) And String.IsNullOrEmpty(strum1T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st1-1")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum2) And Not String.IsNullOrEmpty(strum2T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st2")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum2) And String.IsNullOrEmpty(strum2T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st2-2")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum3) And Not String.IsNullOrEmpty(strum3T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st3")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum3) And String.IsNullOrEmpty(strum3T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st3-3")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum4) And Not String.IsNullOrEmpty(strum4T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st4")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum4) And String.IsNullOrEmpty(strum4T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st4-4")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum5) And Not String.IsNullOrEmpty(strum5T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st5")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum5) And String.IsNullOrEmpty(strum5T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st5-5")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum6) And Not String.IsNullOrEmpty(strum6T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st6")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum6) And String.IsNullOrEmpty(strum6T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st6-6")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum7) And Not String.IsNullOrEmpty(strum7T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st7")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum7) And String.IsNullOrEmpty(strum7T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st7-7")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum8) And Not String.IsNullOrEmpty(strum8T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st8")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum8) And String.IsNullOrEmpty(strum8T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st8-8")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum9) And Not String.IsNullOrEmpty(strum9T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st9")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum9) And String.IsNullOrEmpty(strum9T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st9-9")
            Exit Sub
        End If
        If String.IsNullOrEmpty(strum10) And Not String.IsNullOrEmpty(strum10T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st10")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strum10) And String.IsNullOrEmpty(strum10T) Then
            Response.Redirect("opzioni_generali_home.aspx?e=st10-10")
            Exit Sub
        End If

        ' Aggiorno DB
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            Conn As SqlConnection, connect As String = "", cmd As SqlCommand

        ' Imposto valori nel db
        qry = "UPDATE impostazionigenerali SET abilita_utenti_standard='" & stdusr & "', itsuiteaddressname='" & srvgeneral & "', abilita_utenti_stpers='" & tchusr & "', abilita_gestione_guasti='" & gestguast & "', abilita_software_aziendale='" & enableintsw & "', abilita_assistenza_prodotti='" & enableassprd & "', abilita_servizi_windows='" & enablewinsvc & "', abilita_servizi_rete='" & enablenet & "', abilita_autocompip='" & autoipint & "', servizi_rete='" & enableservnet & "', strumenti1='" & strum1 & "', strumenti2='" & strum2 & "', strumenti3='" & strum3 & "', strumenti4='" & strum4 & "', strumenti5='" & strum5 & "', strumenti6='" & strum6 & "', strumenti7='" & strum7 & "', strumenti8='" & strum8 & "', strumenti9='" & strum9 & "', strumenti10='" & strum10 & "', strumenti1title='" & strum1T & "', strumenti2title='" & strum2T & "', strumenti3title='" & strum3T & "', strumenti4title='" & strum4T & "', strumenti5title='" & strum5T & "', strumenti6title='" & strum6T & "', strumenti7title='" & strum7T & "', strumenti8title='" & strum8T & "', strumenti9title='" & strum9T & "', strumenti10title='" & strum10T & "', abilita_utenti_stpers_mod='" & tchusrmod & "', abilita_utenti_stpers_ass='" & tchusrass & "'"
        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        cmd = New SqlCommand(qry, Conn)
        Conn.Open()
        cmd.ExecuteNonQuery()
        Conn.Close()
        Conn.Dispose()
        cmd.Dispose()

        ' Imposto valori utente
        qry = "UPDATE Utenti SET paging='" & paging & "'"
        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        cmd = New SqlCommand(qry, Conn)
        Conn.Open()
        cmd.ExecuteNonQuery()
        Conn.Close()
        Conn.Dispose()
        cmd.Dispose()

        ' Imposto valori di sessione
        Session("abilita_utenti_standard") = stdusr
        Session("abilita_utenti_stpers") = tchusr
        Session("abilita_gestione_guasti") = gestguast
        Session("abilita_software_aziendale") = enableintsw
        Session("abilita_assistenza_prodotti") = enableassprd
        Session("abilita_servizi_windows") = enablewinsvc
        Session("abilita_servizi_rete") = enablenet
        Session("abilita_autocompip") = autoipint
        Session("servizi_rete") = enableservnet
        Session("risultati_pag") = paging
        Session("abilita_utenti_stpers_mod") = tchusrmod
        Session("abilita_utenti_stpers_ass") = tchusrass
        Session("generalserver") = srvgeneral

        ' Redirigo alla pagina delle opzioni
        Response.Redirect("opzioni_generali_home.aspx?s=ok")
    End Sub

End Class
