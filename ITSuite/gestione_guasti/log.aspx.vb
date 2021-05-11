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

Partial Class gestione_guasti_log
    Inherits System.Web.UI.Page
    Public globals As New ITSuite_Globalization()

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DataBind()

        Me.Title = globals.ResourceHelper.GetString("String241") & " | ITSuite by Ame Amer (admin@ameamer.com)"

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
        Dim xmlPath As String = "../App_Data/tktlog.xml"
        xmlDoc.Load(Server.MapPath(xmlPath))
        ArticleNodeList = xmlDoc.ChildNodes
        For Each articlenode As XmlNode In ArticleNodeList
            If articlenode.Name = "TKTLOGGER" Then
                For Each articlenode2 As XmlNode In articlenode

                    If articlenode2.Name = "NEWTKT" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>CREATED NEW TICKET:</b><br/>"
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
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ADDED UPDATE TO TICKET:</b><br/>"
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

                    If articlenode2.Name = "TKTCLOSED" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>TICKET CLOSED:</b><br/>"
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

                    If articlenode2.Name = "NEWWAIT" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>SET TICKET TO PENDING:</b><br/>"
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

                    If articlenode2.Name = "NEWFILE" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ADDED FILE TO TICKET:</b><br/>"
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

                    If articlenode2.Name = "NEWASSIGN" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ASSIGNMENT OF TICKET CHANGED:</b><br/>"
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

                    If articlenode2.Name = "NEWCLIENTUPDATE" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>ADDED UPDATE FORM CUSTOMER:</b><br/>"
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

                    If articlenode2.Name = "EMAILSERVICE" Then
                        lbl.Text = lbl.Text & "<div style='font-size:small; width:100%;'><b>E-MAIL SERVICE:</b><br/>"
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
