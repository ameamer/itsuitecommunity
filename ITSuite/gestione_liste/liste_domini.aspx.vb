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
Imports System.Text.RegularExpressions

Partial Class gestione_liste_liste_domini
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        PanelGen.DataBind()

        Me.Title = globals.ResourceHelper.GetString("String288") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If
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

    ' Sezione salvataggio dati
    Protected Sub SaveSettings_Click(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        Dim dbcolname As String() = btn.ID.Split(New String() {"_confirmbutton"}, StringSplitOptions.None)
        Dim txbx As TextBox = Form.FindControl(dbcolname(0))
        Dim qrytop As String = "", DbPathtop As String = "", connecttop As String = ""
        Dim qry As String = "UPDATE impostazionigenerali SET " & dbcolname(0) & "=@Fn"
        Dim DbPath As String, Conn As SqlConnection
        DbPath = "../App_Data/itstdb.mdf"
        Dim connect As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        Conn = New SqlConnection(connect)
        Dim cmd As SqlCommand = New SqlCommand(qry, Conn)
        cmd.Parameters.AddWithValue("@Fn", txbx.Text)
        Conn.Open()
        cmd.ExecuteNonQuery()
        Conn.Close()
        Conn.Dispose()
        cmd.Dispose()
        Session(dbcolname(0)) = txbx.Text
    End Sub

End Class
