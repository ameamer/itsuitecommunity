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

Partial Class scelta_servizio_scelta_servizio_admin
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        If Session("Autenticato") = "admin" Or Session("Autenticato") = "personale" Then
            Diagnostics.Debug.WriteLine("Accesso alla pagina consentito.")
        Else
            Response.Redirect("../logout.aspx")
        End If

        ' La path del database
        Dim DbPath As String = ""

        Select Case Session("Autenticato")
            Case "admin"
                DbPath = "../App_Data/itstdb.mdf"

                ' Numero dei PC
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM datapc", cn)
                    LabelNPCNumber.Text = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using

                ' Numero dei monitor
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM datapc WHERE marca_video_pc <> ''", cn)
                    LabelNMonNumber.Text = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using

                ' Numero delle stampanti
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM stampanti", cn)
                    LabelNStampNumber.Text = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using

                ' Numero altro hw
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM datahardware", cn)
                    LabelNHWNumber.Text = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using

                ' Numero guasti aperti/totali
                Dim p1 As String = ""
                Dim p2 As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE stato='aperta'", cn)
                    p1 = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti", cn)
                    p2 = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelGOpenN.Text = p1 & " / " & p2

                ' Numero guasti in attesa/totali
                Dim p1w As String = ""
                Dim p2w As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE stato='in attesa'", cn)
                    p1w = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti", cn)
                    p2w = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelGWaitN.Text = p1w & " / " & p2w

                ' Numero guasti chiusi/totali
                Dim p1c As String = ""
                Dim p2c As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE stato='chiusa'", cn)
                    p1c = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti", cn)
                    p2c = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelGCloseN.Text = p1c & " / " & p2c

                ' Numero assistenze aperte/totali
                Dim p1ass As String = ""
                Dim p2ass As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM assistenzaprodotti WHERE stato='aperta'", cn)
                    p1ass = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM assistenzaprodotti", cn)
                    p2ass = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelAssOpenN.Text = p1ass & " / " & p2ass

                ' Numero assistenze chiuse/totali
                Dim p1assc As String = ""
                Dim p2assc As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM assistenzaprodotti WHERE stato='chiusa'", cn)
                    p1assc = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM assistenzaprodotti", cn)
                    p2assc = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelAssCloseN.Text = p1assc & " / " & p2assc

                ' Numero utenti
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM Utenti", cn)
                    LabelUtentiN.Text = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using

                ' Database
                Dim n1 As String = Convert.ToDouble(FormatNumber(ITSuite_Files.GetFileSize(Server.MapPath("../App_Data/itstdb.mdf")), 2))
                LabelMediaDbN.Text = n1 & " Kb"

            Case "personale"
                DbPath = "../App_Data/itstdb.mdf"
                ' Numero guasti aperti/totali
                Dim p1 As String = ""
                Dim p2 As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE stato='aperta' AND dettagli1='" & Session("username") & "'", cn)
                    p1 = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE dettagli1='" & Session("username") & "'", cn)
                    p2 = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelGOpenNP.Text = p1 & " / " & p2

                ' Numero guasti in attesa/totali
                Dim p1w As String = ""
                Dim p2w As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE stato='in attesa' AND dettagli1='" & Session("username") & "'", cn)
                    p1w = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE dettagli1='" & Session("username") & "'", cn)
                    p2w = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelGWaitNP.Text = p1w & " / " & p2w

                ' Numero guasti chiusi/totali
                Dim p1c As String = ""
                Dim p2c As String = ""
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE stato='chiusa' AND dettagli1='" & Session("username") & "'", cn)
                    p1c = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                Using cn As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath))
                    cn.Open()
                    Dim cmd As New SqlCommand("Select COUNT(*) FROM guasti WHERE dettagli1='" & Session("username") & "'", cn)
                    p2c = cmd.ExecuteScalar()
                    cmd.Dispose()
                    cn.Close()
                    cn.Dispose()
                End Using
                LabelGCloseNP.Text = p1c & " / " & p2c

            Case Else
                Response.Redirect("../logout.aspx")

        End Select
    End Sub

    ' Valori dei click dei tasti della Dashboard
    Protected Sub AddNewPC_Click(sender As Object, e As EventArgs)
        Response.Redirect("../gestione_pc/inserisci_pc_home.aspx")
    End Sub
    Protected Sub AddNewStamp_Click(sender As Object, e As EventArgs)
        Response.Redirect("../gestione_stampanti/inserisci_stampante.aspx")
    End Sub
    Protected Sub AddNewHw_Click(sender As Object, e As EventArgs)
        Response.Redirect("../gestione_altro_hardware/inserisci_hw_home.aspx")
    End Sub
    Protected Sub AddNewTicket_Click(sender As Object, e As EventArgs)
        Response.Redirect("../gestione_guasti/nuovo_guasto.aspx")
    End Sub
    Protected Sub AddNewAss_Click(sender As Object, e As EventArgs)
        Response.Redirect("../assistenza_prodotti/nuova_assistenza.aspx")
    End Sub
    Protected Sub AddNewUser_Click(sender As Object, e As EventArgs)
        Response.Redirect("../gestione_utenti/nuovo_utente.aspx")
    End Sub
    Protected Sub GestDb_Click(sender As Object, e As EventArgs)
        Response.Redirect("../gestione_db/gestione_db_home.aspx")
    End Sub

    ''' <summary>
    ''' Tasto "vedi tutti i ticket".
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ShowAllTicketsButton_Click(sender As Object, e As EventArgs)
        Response.Redirect("../gestione_guasti/gestione_guasti_all.aspx")
    End Sub

    ''' <summary>
    ''' Tasto "vedi tutte le assistenze".
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ShowAllAss_Click(sender As Object, e As EventArgs)
        Response.Redirect("../assistenza_prodotti/assistenza_prodotti_all.aspx")
    End Sub
End Class
