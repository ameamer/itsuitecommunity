'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Data.SqlClient
Imports System.Net.Mail
Imports Microsoft.VisualBasic

''' <summary>
''' Contiene le funzioni delle liste di ITSuite.
''' </summary>
Partial Public Class ITSuite_Listing


    ''' <summary>
    ''' Contiene le funzioni di lista relative alle marche.
    ''' </summary>
    Partial Public Class Marche

        ''' <summary>
        ''' Avvia strumento di popolazione del selector delle marche.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorMarchePCConnection() As Object
            Dim qrytop As String = "Select * from marchepc order by marche_pc ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option Tostring='" & read.Item("marche_pc").ToString & "' title='" & read.Item("marche_pc").ToString & "' style='color: black'>" & read.Item("marche_pc").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Avvia strumento di popolazione del selector delle marche monitor.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorMarcheMonitorConnection() As Object
            Dim qrytop As String = "Select * from marchemonitor_tab order by marche_monitor ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("marche_monitor").ToString & "' title='" & read.Item("marche_monitor").ToString & "' style='color: black'>" & read.Item("marche_monitor").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Selettore marche stampanti.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorMarcheStampantiConnection() As Object
            Dim qrytop As String = "SELECT * FROM marchestampanti order by marche_stampanti ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option value='" & read.Item("marche_stampanti").ToString & "' title='" & read.Item("marche_stampanti").ToString & "' style='color: black'>" & read.Item("marche_stampanti").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Selettore marche altro hardware.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorMarcheHwConnection() As Object
            Dim qrytop As String = "SELECT * FROM marche_hw order by marche_hw ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option value='" & read.Item("marche_hw").ToString & "' title='" & read.Item("marche_hw").ToString & "' style='color: black'>" & read.Item("marche_hw").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

    End Class

    ''' <summary>
    ''' Contiene le funzioni di lista relative alle reti.
    ''' </summary>
    Partial Public Class Rete
        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei domini.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorDominiConnection() As Object
            Dim qrytop As String = "Select * from listadomini order by domini ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("domini").ToString & "' title='" & read.Item("domini").ToString & "' style='color: black'>" & read.Item("domini").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

    End Class

    ''' <summary>
    ''' Contiene le funzioni di lista relative alle ubicazioni.
    ''' </summary>
    Partial Public Class Ubicazioni
        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei reparti.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorRepartiConnection() As Object
            Dim qrytop As String = "Select * from listareparti order by reparti_presidio ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("reparti_presidio").ToString & "' title='" & read.Item("reparti_presidio").ToString & "' style='color: black'>" & read.Item("reparti_presidio").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei padiglioni.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorPadiglioniConnection() As Object
            Dim qrytop As String = "Select * from listapadiglioni order by padiglioni ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("padiglioni").ToString & "' title='" & read.Item("padiglioni").ToString & "' style='color: black'>" & read.Item("padiglioni").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei presidi.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorPresidiConnection() As Object
            Dim qrytop As String = "Select * from listapresidi order by presidi ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("presidi").ToString & "' title='" & read.Item("presidi").ToString & "' style='color: black'>" & read.Item("presidi").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function
    End Class

    ''' <summary>
    ''' Contiene le funzioni di lista relative agli stati.
    ''' </summary>
    Partial Public Class Stati

        ''' <summary>
        ''' Avvia strumento di popolazione del selector degli stati.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorStatiConnection() As Object
            Dim qrytop As String = "Select * from tab_stati order by stati_hw ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("stati_hw").ToString & "' title='" & read.Item("stati_hw").ToString & "' style='color: black'>" & read.Item("stati_hw").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Avvia strumento di popolazione del selector degli stati monitor.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorStatiMonitorConnection() As Object
            Dim qrytop As String = "Select * from statimonitor_tab order by stati_monitor ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("stati_monitor").ToString & "' title='" & read.Item("stati_monitor").ToString & "' style='color: black'>" & read.Item("stati_monitor").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

    End Class

    ''' <summary>
    ''' Contiene le funzioni di lista relative agli anni.
    ''' </summary>
    Partial Public Class Anni
        ''' <summary>
        ''' Avvia strumento di popolazione del selector degli anni.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorAnni() As Object
            For i As Integer = 2000 To 2030
                HttpContext.Current.Response.Write("<option value='" & i & "'>" & i & "</option>")
            Next
            Return 0
        End Function
    End Class

    ''' <summary>
    ''' Contiene le liste relative alle stampanti.
    ''' </summary>
    Partial Public Class Stampanti

        ''' <summary>
        ''' Avvia strumento di popolazione del selector delle stampanti.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorStampantiConnection(id_stampante_collegata As String) As Object
            Dim globals As New ITSuite_Globalization()
            Dim qrytop As String = "Select * from stampanti order by ID ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            If String.IsNullOrEmpty(id_stampante_collegata) Then
                If read.FieldCount() > 0 Then
                    HttpContext.Current.Response.Write("<option value=''>" & globals.ResourceHelper.GetString("String623") & "</option>")
                End If
            Else
                HttpContext.Current.Response.Write("<option value=''>" & globals.ResourceHelper.GetString("String416") & "</option>")
            End If

            While read.Read()
                If Not String.IsNullOrEmpty(id_stampante_collegata) Then
                    If read.Item("ID").ToString = id_stampante_collegata Then
                        HttpContext.Current.Response.Write("<option selected='selected' value='" & read.Item("ID").ToString & "' title='ID:" & read.Item("ID").ToString & " | Marca: " & read.Item("marca_stampante").ToString & " | Modello: " & read.Item("modello_stampante").ToString & " | S/N: " & read.Item("numero_serie_stampante").ToString & " | Inv.: " & read.Item("inventario_stampante").ToString & "' style='color: black'>(In uso) ID: " & read.Item("ID").ToString & " | Marca: " & read.Item("marca_stampante").ToString & " | Modello: " & read.Item("modello_stampante").ToString & " | S/N: " & read.Item("numero_serie_stampante").ToString & "| Inv.: " & read.Item("inventario_stampante").ToString & "</option>")
                    Else
                        HttpContext.Current.Response.Write("<option value='" & read.Item("ID").ToString & "' title='ID:" & read.Item("ID").ToString & " | Marca: " & read.Item("marca_stampante").ToString & " | Modello: " & read.Item("modello_stampante").ToString & " | S/N: " & read.Item("numero_serie_stampante").ToString & " | Inv.: " & read.Item("inventario_stampante").ToString & "' style='color: black'>ID: " & read.Item("ID").ToString & " | Marca: " & read.Item("marca_stampante").ToString & " | Modello: " & read.Item("modello_stampante").ToString & " | S/N: " & read.Item("numero_serie_stampante").ToString & "| Inv.: " & read.Item("inventario_stampante").ToString & "</option>")
                    End If
                Else
                    HttpContext.Current.Response.Write("<option value='" & read.Item("ID").ToString & "' title='ID:" & read.Item("ID").ToString & " | Marca: " & read.Item("marca_stampante").ToString & " | Modello: " & read.Item("modello_stampante").ToString & " | S/N: " & read.Item("numero_serie_stampante").ToString & " | Inv.: " & read.Item("inventario_stampante").ToString & "' style='color: black'>ID: " & read.Item("ID").ToString & " | Marca: " & read.Item("marca_stampante").ToString & " | Modello: " & read.Item("modello_stampante").ToString & " | S/N: " & read.Item("numero_serie_stampante").ToString & "| Inv.: " & read.Item("inventario_stampante").ToString & "</option>")
                End If
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function
    End Class

    ''' <summary>
    ''' Contiene le liste relative agli altri hardware.
    ''' </summary>
    Partial Public Class AltroHW
        ''' <summary>
        ''' Avvia strumento di popolazione del selector dell'altro hardware.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorOtherHwConnection(id_altrohw_collegato As String) As Object
            Dim globals As New ITSuite_Globalization()
            Dim qrytop As String = "Select * from datahardware order by ID ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            If String.IsNullOrEmpty(id_altrohw_collegato) Then
                If read.FieldCount() > 0 Then
                    HttpContext.Current.Response.Write("<option value=''>" & globals.ResourceHelper.GetString("String624") & "</option>")
                End If
            Else
                HttpContext.Current.Response.Write("<option value=''>" & globals.ResourceHelper.GetString("String416") & "</option>")
            End If
            While read.Read()
                If Not String.IsNullOrEmpty(id_altrohw_collegato) Then
                    If read.Item("ID").ToString = id_altrohw_collegato Then
                        HttpContext.Current.Response.Write("<option selected='selected' value='" & read.Item("ID").ToString.ToString & "' title='ID: " & read.Item("ID").ToString.ToString & " | Tipo: " & read.Item("tipo_hardware").ToString.ToString & " | Marca: " & read.Item("marca_hardware").ToString.ToString & " | Mod.: " & read.Item("modello_hardware").ToString.ToString & " | S/N: " & read.Item("serie_hardware").ToString.ToString & " | Inv.: " & read.Item("inventario_hardware").ToString.ToString & "' style='color: black'>(In uso) ID: " & read.Item("ID").ToString.ToString & " | Tipo: " & read.Item("tipo_hardware").ToString.ToString & " | Marca: " & read.Item("marca_hardware").ToString.ToString & " | Mod.: " & read.Item("modello_hardware").ToString.ToString & " | S/N: " & read.Item("serie_hardware").ToString.ToString & " | Inv.: " & read.Item("inventario_hardware").ToString.ToString & "</option>")
                    Else
                        HttpContext.Current.Response.Write("<option value='" & read.Item("ID").ToString.ToString & "' title='ID: " & read.Item("ID").ToString.ToString & " | Tipo: " & read.Item("tipo_hardware").ToString.ToString & " | Marca: " & read.Item("marca_hardware").ToString.ToString & " | Mod.: " & read.Item("modello_hardware").ToString.ToString & " | S/N: " & read.Item("serie_hardware").ToString.ToString & " | Inv.: " & read.Item("inventario_hardware").ToString.ToString & "' style='color: black'>ID: " & read.Item("ID").ToString.ToString & " | Tipo: " & read.Item("tipo_hardware").ToString.ToString & " | Marca: " & read.Item("marca_hardware").ToString.ToString & " | Mod.: " & read.Item("modello_hardware").ToString.ToString & " | S/N: " & read.Item("serie_hardware").ToString.ToString & " | Inv.: " & read.Item("inventario_hardware").ToString.ToString & "</option>")
                    End If
                Else
                    HttpContext.Current.Response.Write("<option value='" & read.Item("ID").ToString.ToString & "' title='ID: " & read.Item("ID").ToString.ToString & " | Tipo: " & read.Item("tipo_hardware").ToString.ToString & " | Marca: " & read.Item("marca_hardware").ToString.ToString & " | Mod.: " & read.Item("modello_hardware").ToString.ToString & " | S/N: " & read.Item("serie_hardware").ToString.ToString & " | Inv.: " & read.Item("inventario_hardware").ToString.ToString & "' style='color: black'>ID: " & read.Item("ID").ToString.ToString & " | Tipo: " & read.Item("tipo_hardware").ToString.ToString & " | Marca: " & read.Item("marca_hardware").ToString.ToString & " | Mod.: " & read.Item("modello_hardware").ToString.ToString & " | S/N: " & read.Item("serie_hardware").ToString.ToString & " | Inv.: " & read.Item("inventario_hardware").ToString.ToString & "</option>")
                End If
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Apre selettore dei tipi hardware.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorTipiHW() As Object
            Dim qrytop As String = "SELECT * FROM tipi_hw order by tipi_hw ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option value='" & read.Item("tipi_hw").ToString & "' title='" & read.Item("tipi_hw").ToString & "' style='color: black'>" & read.Item("tipi_hw").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

    End Class


    ''' <summary>
    ''' Contiene funzioni relative agli utenti.
    ''' </summary>
    Partial Public Class Utenti

        ''' <summary>
        ''' Popola il selector con la lista di tutti gli utenti di sistema di ITSuite.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenUtentiSelector() As Object
            Dim globals As New ITSuite_Globalization()
            Dim qrytop As String = "SELECT * FROM Utenti WHERE stato_utente='Attivo' AND tipo_utente!='Cliente' order by nomeutente ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            HttpContext.Current.Response.Write("<option value='' title='" & globals.ResourceHelper.GetString("String625") & "' style='color: black'>" & globals.ResourceHelper.GetString("String626") & "</option>")
            While read.Read()
                HttpContext.Current.Response.Write("<option value='" & read.Item("nomeutente").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>" & read.Item("ID").ToString & ", " & read.Item("nomeutente").ToString & ", " & read.Item("email").ToString & ", " & read.Item("cognome").ToString & " " & read.Item("nome").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Popola il selector con la lista di tutti gli utenti di tipo "Cliente".
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenClientiSelector() As Object
            Dim globals As New ITSuite_Globalization()
            Dim qrytop As String = ""
            If HttpContext.Current.Session("Autenticato") = "personale" Or HttpContext.Current.Session("Autenticato") = "cliente" Then
                qrytop = "SELECT * FROM Utenti WHERE stato_utente='Attivo' AND ID='" & HttpContext.Current.Session("user_id") & "' order by nomeutente ASC"
            End If
            If HttpContext.Current.Session("Autenticato") = "admin" Then
                qrytop = "SELECT * FROM Utenti WHERE stato_utente='Attivo' order by nomeutente ASC"
            End If
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            HttpContext.Current.Response.Write("<option value='' title='" & globals.ResourceHelper.GetString("String627") & "' style='color: black'>" & globals.ResourceHelper.GetString("String628") & "</option>")
            While read.Read()
                If HttpContext.Current.Session("Autenticato") = "personale" Or HttpContext.Current.Session("Autenticato") = "cliente" Then
                    HttpContext.Current.Response.Write("<option selected='selected' value='" & read.Item("ID").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>" & read.Item("ID").ToString & ", " & read.Item("nomeutente").ToString & ", " & read.Item("email").ToString & ", " & read.Item("cognome").ToString & " " & read.Item("nome").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>")
                Else
                    If HttpContext.Current.Session("Autenticato") = "admin" Then
                        If read.Item("ID").ToString = HttpContext.Current.Session("user_id") Then
                            HttpContext.Current.Response.Write("<option selected='selected' value='" & read.Item("ID").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>" & read.Item("ID").ToString & ", " & read.Item("nomeutente").ToString & ", " & read.Item("email").ToString & ", " & read.Item("cognome").ToString & " " & read.Item("nome").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>")
                        Else
                            HttpContext.Current.Response.Write("<option value='" & read.Item("ID").ToString & "' title='" & read.Item("nomeutente").ToString & "' style='color: black'>" & read.Item("ID").ToString & ", " & read.Item("nomeutente").ToString & ", " & read.Item("email").ToString & ", " & read.Item("cognome").ToString & " " & read.Item("nome").ToString & " (" & read.Item("tipo_utente").ToString & ")</option>")
                        End If
                    End If
                End If
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function
    End Class

    ''' <summary>
    ''' Contiene le funzioni di lista relative ai PC.
    ''' </summary>
    Partial Public Class PC
        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei processori.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorProcessoriConnection() As Object
            Dim qrytop As String = "Select * from processoripc order by processori_pc ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("processori_pc").ToString & "' title='" & read.Item("processori_pc").ToString & "' style='color: black'>" & read.Item("processori_pc").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei software esterni.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorOtherSWConnection() As Object
            Dim qrytop As String = "Select * from listasw order by sw ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("sw").ToString & "' title='" & read.Item("sw").ToString & "' style='color: black'>" & read.Item("sw").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei sistemi operativi.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorOSConnection() As Object
            Dim qrytop As String = "Select * from sistemioperativi order by sistemi_operativi ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("sistemi_operativi").ToString & "' title='" & read.Item("sistemi_operativi").ToString & "' style='color: black'>" & read.Item("sistemi_operativi").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Avvia strumento di popolazione del selector dei tipi PC.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorTipiPCConnection() As Object
            Dim qrytop As String = "Select * from listatipipc order by tipi_pc ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            While read.Read()
                HttpContext.Current.Response.Write("<option ToString='" & read.Item("tipi_pc").ToString & "' title='" & read.Item("tipi_pc").ToString & "' style='color: black'>" & read.Item("tipi_pc").ToString & "</option>")
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

        ''' <summary>
        ''' Popola il selettore della lista dei PC.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function OpenSelectorPcConnection(id_pc_collegato As String) As Object
            Dim globals As New ITSuite_Globalization()
            Dim qrytop As String = "Select * from datapc order by id ASC"
            Dim DbPathtop As String = "../App_Data/itstdb.mdf"
            Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
            Dim Conntop As New SqlConnection(connecttop)
            Dim cmdtop As New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            Dim read As SqlDataReader = cmdtop.ExecuteReader()
            If String.IsNullOrEmpty(id_pc_collegato) Then
                If read.FieldCount() > 0 Then
                    HttpContext.Current.Response.Write("<option value=''>" & globals.ResourceHelper.GetString("String762") & "...</option>")
                End If
            Else
                HttpContext.Current.Response.Write("<option value=''>" & globals.ResourceHelper.GetString("String416") & "</option>")
            End If

            While read.Read()
                If Not String.IsNullOrEmpty(id_pc_collegato) Then
                    If read.Item("ID").ToString = id_pc_collegato Then
                        HttpContext.Current.Response.Write("<option selected='selected' value='" & read.Item("ID").ToString & "' style='color: black'>(In Uso) " & read.Item("ID").ToString & " (" & read.Item("marca_pc").ToString & " " & read.Item("modello_pc").ToString & ") | S/N " & read.Item("serie_pc").ToString & "</option>")
                    Else
                        HttpContext.Current.Response.Write("<option value='" & read.Item("ID").ToString & "' style='color: black'>" & read.Item("ID").ToString & " (" & read.Item("marca_pc").ToString & " " & read.Item("modello_pc").ToString & ") | S/N " & read.Item("serie_pc").ToString & "</option>")
                    End If
                Else
                    HttpContext.Current.Response.Write("<option value='" & read.Item("ID").ToString & "' style='color: black'>" & read.Item("ID").ToString & " (" & read.Item("marca_pc").ToString & " " & read.Item("modello_pc").ToString & ") | S/N " & read.Item("serie_pc").ToString & "</option>")
                End If
            End While

            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()
            Return 0
        End Function

    End Class

End Class
