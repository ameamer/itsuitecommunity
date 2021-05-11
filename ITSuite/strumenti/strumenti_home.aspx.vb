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

Partial Class Strumenti_strumenti_home
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public Shared link1 As String, link2 As String, link3 As String, link4 As String, link5 As String,
        link6 As String, link7 As String, link8 As String, link9 As String, link10 As String,
        link1title As String, link2title As String, link3title As String, link4title As String,
        link5title As String, link6title As String, link7title As String, link8title As String,
        link9title As String, link10title As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String107") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Select Case Session("Autenticato")
            Case "admin", "personale"
                Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = "", qry As String = "", DbPath As String = "",
        Conn As SqlConnection, connect As String = "", cmd As SqlCommand, read As SqlDataReader
                qry = "SELECT * FROM impostazionigenerali"
                DbPath = "../App_Data/itstdb.mdf"
                connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
                Conn = New SqlConnection(connect)
                cmd = New SqlCommand(qry, Conn)
                Conn.Open()
                read = cmd.ExecuteReader()
                While read.Read()
                    If Not String.IsNullOrEmpty(read.Item("strumenti1title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti1title").ToString) Then
                        link1 = read.Item("strumenti1").ToString
                        link1title = read.Item("strumenti1title").ToString
                        Panel1.Visible = True
                    Else
                        Panel1.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti2title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti2title").ToString) Then
                        link2 = read.Item("strumenti2").ToString
                        link2title = read.Item("strumenti2title").ToString
                        Panel2.Visible = True
                    Else
                        Panel2.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti3title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti3title").ToString) Then
                        link3 = read.Item("strumenti3").ToString
                        link3title = read.Item("strumenti3title").ToString
                        Panel3.Visible = True
                    Else
                        Panel3.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti4title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti4title").ToString) Then
                        link4 = read.Item("strumenti4").ToString
                        link4title = read.Item("strumenti4title").ToString
                        Panel4.Visible = True
                    Else
                        Panel4.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti5title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti5title").ToString) Then
                        link5 = read.Item("strumenti5").ToString
                        link5title = read.Item("strumenti5title").ToString
                        Panel5.Visible = True
                    Else
                        Panel5.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti6title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti6title").ToString) Then
                        link6 = read.Item("strumenti6").ToString
                        link6title = read.Item("strumenti6title").ToString
                        Panel6.Visible = True
                    Else
                        Panel6.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti7title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti7title").ToString) Then
                        link7 = read.Item("strumenti7").ToString
                        link7title = read.Item("strumenti7title").ToString
                        Panel7.Visible = True
                    Else
                        Panel7.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti8title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti8title").ToString) Then
                        link8 = read.Item("strumenti8").ToString
                        link8title = read.Item("strumenti8title").ToString
                        Panel8.Visible = True
                    Else
                        Panel8.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti9title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti9title").ToString) Then
                        link9 = read.Item("strumenti9").ToString
                        link9title = read.Item("strumenti9title").ToString
                        Panel9.Visible = True
                    Else
                        Panel9.Visible = False
                    End If

                    If Not String.IsNullOrEmpty(read.Item("strumenti10title").ToString) And Not String.IsNullOrEmpty(read.Item("strumenti10title").ToString) Then
                        link10 = read.Item("strumenti10").ToString
                        link10title = read.Item("strumenti10title").ToString
                        Panel10.Visible = True
                    Else
                        Panel10.Visible = False
                    End If
                End While
                Conn.Close()
                Conn.Dispose()
                read.Close()
                cmd.Dispose()

            Case Else
                Response.Redirect("../logout.aspx")
        End Select
    End Sub

End Class
