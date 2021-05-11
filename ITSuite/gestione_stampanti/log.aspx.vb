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

Partial Class gestione_stampanti_log
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
        Dim xmlPath As String = "../App_Data/stamplog.xml"
        xmlDoc.Load(Server.MapPath(xmlPath))
        ArticleNodeList = xmlDoc.ChildNodes
        For Each articlenode As XmlNode In ArticleNodeList
            If articlenode.Name = "STAMPLOGGER" Then
                For Each articlenode2 As XmlNode In articlenode

                    If articlenode2.Name = "NEWSTAMP" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ADD NEW PRINTER:</b><br/>"
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

                    If articlenode2.Name = "MODSTAMP" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>PRINTER MODIFIED:</b><br/>"
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

                    If articlenode2.Name = "ADDIMGSTAMP" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ADD IMAGE TO PRINTER:</b><br/>"
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

                    If articlenode2.Name = "DELIMGSTAMP" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>DELETED IMAGE FROM PRINTER:</b><br/>"
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

                    If articlenode2.Name = "DELSTAMP" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>DELETED PRINTER:</b><br/>"
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
            lbl.Text = "Log vuoto."
        End If
        GeneralPanel.Controls.Add(lbl)
    End Sub
End Class
