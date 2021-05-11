'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class gestione_utenti_nuovo_utente
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String37") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If

        Select Case Request.QueryString("err")
            Case "emptyfields"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String163")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "errtabgeneraladmin"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String474")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "errdbalreadypresent"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String475")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "erruseralreadypresent"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String476")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "errnotabname"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String477")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "errpswlength"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String478")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
            Case "errpswcompare"
                ErrorMsg.Text = globals.ResourceHelper.GetString("String479")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideLabel();", True)
        End Select

    End Sub
End Class
