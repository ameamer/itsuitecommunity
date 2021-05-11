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

Partial Class software_aziendale_software_aziendale_home
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String94") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin"
                If Session("abilita_software_aziendale") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If

            Case "personale"
                If Session("abilita_software_aziendale") = "0" Then
                    Response.Redirect("../logout.aspx")
                End If

            Case Else
                Response.Redirect("../logout.aspx")

        End Select

        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
            Conn As SqlConnection, connect As String = "", cmd As SqlCommand, read As SqlDataReader
        qry = "SELECT * FROM swaziendali ORDER BY nomesw ASC"
        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        cmd = New SqlCommand(qry, Conn)
        Conn.Open()
        read = cmd.ExecuteReader()
        While read.Read()
            LabelSwList.Text = LabelSwList.Text & "<li><a href='" & read.Item("linksw").ToString & "'>" & read.Item("nomesw").ToString & "</a></li>"
        End While
        Conn.Close()
        Conn.Dispose()
        read.Close()
        cmd.Dispose()

    End Sub

End Class
