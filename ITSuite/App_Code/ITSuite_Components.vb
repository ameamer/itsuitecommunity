'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' Contiene elementi relativi ai componenti di ITSuite.
''' </summary>
Public Class ITSuite_Components

    ''' <summary>
    ''' Restituisce True se è un componente per gli utenti Tecnici Ticketing, altrimenti False. 
    ''' </summary>
    ''' <param name="ComponentTechName">String - il nome tecnico del componente aggiuntivo</param>
    ''' <returns></returns>
    Public Shared Function isComponentForTechUsers(ComponentTechName As String) As Boolean
        Dim qry As String = "", DbPath As String = "", connect As String = "", ConnectorDB As SqlConnection,
            SqlCom As SqlCommand, count As Integer = 0, result As Boolean

        qry = ""
        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        qry = "SELECT * FROM comp WHERE tname='" & ComponentTechName & "' ORDER BY name ASC"
        ConnectorDB = New SqlConnection(connect)
        SqlCom = New SqlCommand(qry, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        While read.Read()
            If read.Item("tktusers").ToString = "1" Then
                result = True
            Else
                result = False
            End If
        End While
        read.Close()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()
        Return result
    End Function

    ''' <summary>
    ''' Restituisce True se è un componente per gli utenti clienti, altrimenti False. 
    ''' </summary>
    ''' <param name="ComponentTechName">String - il nome tecnico del componente aggiuntivo</param>
    ''' <returns></returns>
    Public Shared Function isComponentForCustomerUsers(ComponentTechName As String) As Boolean
        Dim qry As String = "", DbPath As String = "", connect As String = "", ConnectorDB As SqlConnection,
            SqlCom As SqlCommand, count As Integer = 0, result As Boolean

        DbPath = "../App_Data/itstdb.mdf"
        connect = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPath)
        qry = "SELECT * FROM comp WHERE tname='" & ComponentTechName & "' ORDER BY name ASC"
        ConnectorDB = New SqlConnection(connect)
        SqlCom = New SqlCommand(qry, ConnectorDB)
        ConnectorDB.Open()
        Dim read As SqlDataReader = SqlCom.ExecuteReader()
        While read.Read()
            If read.Item("customerusers").ToString = "1" Then
                result = True
            Else
                result = False
            End If
        End While
        read.Close()
        ConnectorDB.Close()
        ConnectorDB.Dispose()
        SqlCom.Dispose()
        Return result
    End Function

End Class
