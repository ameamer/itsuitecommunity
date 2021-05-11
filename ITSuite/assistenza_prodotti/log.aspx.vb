'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Xml

Partial Class assistenza_prodotti_log
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String16") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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

        Dim lbl As New Label
        Dim xmlDoc As New XmlDocument
        Dim ArticleNodeList As XmlNodeList
        Dim xmlPath As String = "../App_Data/asslog.xml"
        xmlDoc.Load(Server.MapPath(xmlPath))
        ArticleNodeList = xmlDoc.ChildNodes
        For Each articlenode As XmlNode In ArticleNodeList
            If articlenode.Name = "ASSLOGGER" Then
                For Each articlenode2 As XmlNode In articlenode

                    If articlenode2.Name = "NEWASS" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ADDED NEW ASSISTANCE REQUEST:</b><br/>"
                        For Each basenode As XmlNode In articlenode2
                            Dim result As String = ""
                            result = basenode.Name
                            For Each Node As XmlNode In basenode
                                result = result & " " & Node.InnerText
                                lbl.Text = lbl.Text & result & "<br />"
                            Next
                        Next
                        lbl.Text = lbl.Text & "<b>------------------</b></div>"
                    End If

                    If articlenode2.Name = "NEWUPDATE" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ADDED UPDATE TO ASSISTANCE REQUEST</b><br/>"
                        For Each basenode As XmlNode In articlenode2
                            Dim result As String = ""
                            result = basenode.Name
                            For Each Node As XmlNode In basenode
                                result = result & " " & Node.InnerText
                                lbl.Text = lbl.Text & result & "<br />"
                            Next
                        Next
                        lbl.Text = lbl.Text & "<b>------------------</b></div>"
                    End If

                    If articlenode2.Name = "ASSCLOSED" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>CLOSED ASSISTANCE REQUEST:</b><br/>"
                        For Each basenode As XmlNode In articlenode2
                            Dim result As String = ""
                            result = basenode.Name
                            For Each Node As XmlNode In basenode
                                result = result & " " & Node.InnerText
                                lbl.Text = lbl.Text & result & "<br />"
                            Next
                        Next
                        lbl.Text = lbl.Text & "<b>------------------</b></div>"
                    End If

                Next
            End If
        Next
        If String.IsNullOrEmpty(lbl.Text) Then
            lbl.Text = globals.ResourceHelper.GetString("String430")
        End If
        GeneralPanel.Controls.Add(lbl)
    End Sub


End Class
