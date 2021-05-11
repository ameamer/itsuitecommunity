
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
Imports System.IO
Imports System.Xml

Partial Class Components_uninst
    Inherits System.Web.UI.Page


    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("Autenticato") <> "admin" Then
            Response.Redirect("../logout.aspx")
        End If

        Dim qry As String = "",
            DbPath As String = "../App_Data/itstdb.mdf",
            connect As String = "",
            ConnectorDB As SqlConnection,
            SqlCom As SqlCommand,
            count As Integer = 0,
            tname As String = "",
            xmlfile As String = "",
            name As String = "",
            dev As String = "",
            files As String = "",
            installpath As String = "",
            devaddr As String = "",
            filesar As String() = {},
            nameComp As String = Request.QueryString("n"),
            namem As String = "",
            link As String = "",
            xmlDoc As New XmlDocument,
            ArticleNodeList As XmlNodeList,
            xmlPath As String = "",
            qrydel As String = "",
            cmd As SqlCommand,
            newFInfo As FileInfo,
            fnm As String = ""

        ' Ricavo dati del componente installato da db
        qry = ""
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        qry = "SELECT * FROM comp WHERE ID=" & nameComp & " ORDER BY name ASC"
        ConnectorDB = New SqlConnection(connect)
        SqlCom = New SqlCommand(qry, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        While read.Read()
            tname = read.Item("tname").ToString
            xmlfile = read.Item("tname").ToString & ".xml"
        End While
        read.Close()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()

        newFInfo = New FileInfo(Server.MapPath("../Components/" & xmlfile))
        fnm = newFInfo.Name

        ' Ricavo dati componente da XML
        xmlPath = "../Components/" & fnm
        xmlDoc.Load(Server.MapPath(xmlPath))
        ArticleNodeList = xmlDoc.ChildNodes
        For Each articlenode As XmlNode In ArticleNodeList
            If articlenode.Name = "ITSUITECOMPONENT" Then
                For Each articlenode2 As XmlNode In articlenode
                    If articlenode2.Name = "PACKET" Then
                        For Each basenode As XmlNode In articlenode2
                            If basenode.Name = "NAME" Then
                                For Each Node As XmlNode In basenode
                                    name = Node.InnerText
                                Next
                            End If

                            If basenode.Name = "LINK" Then
                                For Each Node As XmlNode In basenode
                                    link = Node.InnerText
                                Next
                            End If

                            If basenode.Name = "DEV" Then
                                For Each Node As XmlNode In basenode
                                    dev = Node.InnerText
                                Next
                            End If

                            If basenode.Name = "FILES" Then
                                For Each Node As XmlNode In basenode
                                    files = New String(Node.InnerText.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
                                Next
                            End If

                            If basenode.Name = "INSTALLPATH" Then
                                For Each Node As XmlNode In basenode
                                    installpath = Node.InnerText
                                Next
                            End If

                            If basenode.Name = "DEVADDRESS" Then
                                For Each Node As XmlNode In basenode
                                    devaddr = Node.InnerText
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next

        ' Avvio eliminazione da db
        qrydel = "DELETE FROM comp WHERE ID=" & nameComp
        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        ConnectorDB = New SqlConnection(connect)
        cmd = New SqlCommand(qrydel, ConnectorDB)
        ConnectorDB.Open()
        cmd.ExecuteNonQuery()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        cmd.Dispose()

        ' Elimino file del componente
        filesar = files.Split("|")
        For i As Integer = 0 To filesar.Length - 1
            File.Delete(Server.MapPath("../Components/" & filesar(i)))
        Next

        ' Installazione terminata, redirezione alla pagina della lista dei componenti
        Response.Redirect("../opzioni_generali/opzioni_generali_home_comp.aspx?r=uninstok", False)
        Context.ApplicationInstance.CompleteRequest()

    End Sub

End Class
