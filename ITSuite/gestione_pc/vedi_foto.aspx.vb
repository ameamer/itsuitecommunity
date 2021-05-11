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

Partial Class gestione_pc_vedi_foto
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Id della foto
    ''' </summary>
    Public Shared ID_PHOTO As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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

        ' Provo visualizzazione foto. Se rilevato errore, effettuo logout.
        Try
            ID_PHOTO = Request.QueryString("id")
            Dim qry As String = "SELECT BinaryData FROM datapc WHERE ID=" & CInt(ID_PHOTO)
            Dim DbPath As String, Conn As SqlConnection
            DbPath = "../App_Data/itstdb.mdf"
            Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
            Conn = New SqlConnection(connect)
            Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
            Conn.Open()
            Dim pictureData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()
            generalImage.Src = "data:image/jpg;base64," & Convert.ToBase64String(pictureData)
        Catch ex As Exception
            Response.Redirect("../logout.aspx")
        End Try

    End Sub

End Class
