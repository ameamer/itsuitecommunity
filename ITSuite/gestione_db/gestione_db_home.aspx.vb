
Imports System.Data.SqlClient

Partial Class gestione_db_gestione_db_home
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String40") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If

        Me.Title = globals.ResourceHelper.GetString("String40") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Dim srvversion As String = ""
        Dim qry As String = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
        Dim DbPath As String, Conn As SqlConnection
        DbPath = "../App_Data/itstdb.mdf"
        Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
        Conn.Open()
        srvversion = Conn.ServerVersion
        LabelTest.Text = "<font color='green'>" & globals.ResourceHelper.GetString("String187") & "</font>"
        Dim tabnumber As String = cmd.ExecuteScalar()
        Conn.Close()
        Conn.Dispose()
        cmd.Dispose()

        LabelType.Text = "Microsoft SQL Server (localDB)"
        Dim sqlvstoshow As String() = srvversion.Split(".")
        Select Case sqlvstoshow(0)
            Case "8"
                LabelSrvVersion.Text = "Microsoft SQL Server 2000"
            Case "9"
                LabelSrvVersion.Text = "Microsoft SQL Server 2005"
            Case "10"
                LabelSrvVersion.Text = "Microsoft SQL Server 2008"
            Case "11"
                LabelSrvVersion.Text = "Microsoft SQL Server 2012"
            Case "12"
                LabelSrvVersion.Text = "Microsoft SQL Server 2014"
            Case "13"
                LabelSrvVersion.Text = "Microsoft SQL Server 2016"
            Case "14"
                LabelSrvVersion.Text = "Microsoft SQL Server 2017"
            Case "15"
                LabelSrvVersion.Text = "Microsoft SQL Server 2019"
            Case "16"
                LabelSrvVersion.Text = "Microsoft SQL Server 2021"
            Case Else
                LabelSrvVersion.Text = globals.ResourceHelper.GetString("String188")
        End Select

        LabelTabNumber.Text = tabnumber
        Dim n1 As String = Convert.ToDouble(FormatNumber(ITSuite_Files.GetFileSize(Server.MapPath("../App_Data/itstdb.mdf")), 2))
        LabelDbUse.Text = n1 & " Kb"

    End Sub

End Class
