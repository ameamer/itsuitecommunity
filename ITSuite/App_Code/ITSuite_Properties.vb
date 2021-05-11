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
''' Contiene elementi relativi alle proprietà di ITSuite.
''' </summary>
Public Class ITSuite_Properties

    ''' <summary>
    ''' Contiene le proprietà condivise della pagina default principale.
    ''' </summary>
    Partial Public Class DefaultPage
        Public Shared abilita_utenti_standard As String = ""
        Public Shared abilita_strumenti_standard As String = ""
        Public Shared abilita_utenti_stpers As String = ""
        Public Shared abilita_strumenti_stpers As String = ""
        Public Shared abilita_gestione_guasti As String = ""
        Public Shared abilita_assistenza_prodotti As String = ""
        Public Shared abilita_software_aziendale As String = ""
        Public Shared abilita_servizi_windows As String = ""
        Public Shared abilita_servizi_rete As String = ""
        Public Shared abilita_autocompip As String = ""
        Public Shared sfondo_login As String = ""
        Public Shared ip_predefinito As String = ""
        Public Shared ip_alternativo As String = ""
        Public Shared submask_predefinita As String = ""
        Public Shared submask_alternativa As String = ""
        Public Shared gwy_predefinito As String = ""
        Public Shared gwy_alternativo As String = ""
        Public Shared dns1_predefinito As String = ""
        Public Shared dns1_alternativo As String = ""
        Public Shared dns2_predefinito As String = ""
        Public Shared dns2_alternativo As String = ""
        Public Shared wins_predefinito As String = ""
        Public Shared wins_alternativo As String = ""
        Public Shared lan_predefinita As String = ""
        Public Shared lan_alternativa1 As String = ""
        Public Shared lan_alternativa2 As String = ""
        Public Shared lan_alternativa3 As String = ""
        Public Shared servizi_rete As String = ""
        Public Shared paging As String = ""
        Public Shared abilita_utenti_stpers_mod As String = ""
        Public Shared abilita_utenti_stpers_ass As String = ""
        Public Shared user_id As String = ""
        Public Shared qrytop As String = ""
        Public Shared DbPathtop As String = ""
        Public Shared Conntop As SqlConnection
        Public Shared cmdtop As SqlCommand
        Public Shared read As SqlDataReader
        Public Shared connecttop As String = ""
        Public Shared pass_sha256 As String = ""
        Public Shared autenticato As Boolean
        Public Shared sfondo_utente As String = ""
        Public Shared database_utente As String = ""
        Public Shared usermail As String = ""
        Public Shared pswmail As String = ""
        Public Shared srvmail As String = ""
        Public Shared portmail As String = ""
        Public Shared sslmail As String = ""
        Public Shared intmail As String = ""
        Public Shared endmail As String = ""
        Public Shared generalserver As String = ""
        Public Shared mittentemail As String = ""
        Public Shared languser As String = ""
        Public Shared emailenabled As String = ""
        Public Shared lang As String = System.Globalization.RegionInfo.CurrentRegion.Name

        ''' <summary>
        ''' Imposta i valori nelle variabili condivise dello stato delle impostazioni di ITSuite.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function SetGeneralSettingsProperties() As Boolean
            ' Ricavo dati dal database impostazioni
            qrytop = "SELECT * FROM impostazionigenerali order by ID ASC"
            DbPathtop = "App_Data/itstdb.mdf"
            connecttop = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & System.Web.HttpContext.Current.Server.MapPath(DbPathtop)
            Conntop = New SqlConnection(connecttop)
            cmdtop = New SqlCommand(qrytop, Conntop)
            Conntop.Open()
            read = cmdtop.ExecuteReader()
            While read.Read()
                abilita_utenti_standard = read.Item("abilita_utenti_standard").ToString
                abilita_strumenti_standard = read.Item("abilita_strumenti_standard").ToString
                abilita_utenti_stpers = read.Item("abilita_utenti_stpers").ToString
                abilita_strumenti_stpers = read.Item("abilita_strumenti_stpers").ToString
                abilita_gestione_guasti = read.Item("abilita_gestione_guasti").ToString
                abilita_assistenza_prodotti = read.Item("abilita_assistenza_prodotti").ToString
                abilita_software_aziendale = read.Item("abilita_software_aziendale").ToString
                sfondo_login = read.Item("sfondo_login").ToString
                ip_predefinito = read.Item("ip_predefinito").ToString
                ip_alternativo = read.Item("ip_alternativo").ToString
                submask_predefinita = read.Item("submask_predefinita").ToString
                submask_alternativa = read.Item("submask_alternativa").ToString
                gwy_predefinito = read.Item("gwy_predefinito").ToString
                gwy_alternativo = read.Item("gwy_alternativo").ToString
                abilita_software_aziendale = read.Item("abilita_software_aziendale").ToString
                sfondo_login = read.Item("sfondo_login").ToString
                abilita_servizi_windows = read.Item("abilita_servizi_windows").ToString
                abilita_servizi_rete = read.Item("abilita_servizi_rete").ToString
                abilita_autocompip = read.Item("abilita_autocompip").ToString
                dns1_predefinito = read.Item("dns1_predefinito").ToString
                dns1_alternativo = read.Item("dns1_alternativo").ToString
                dns2_predefinito = read.Item("dns2_predefinito").ToString
                dns2_alternativo = read.Item("dns2_alternativo").ToString
                wins_predefinito = read.Item("wins_predefinito").ToString
                wins_alternativo = read.Item("wins_alternativo").ToString
                lan_predefinita = read.Item("lan_predefinita").ToString
                lan_alternativa1 = read.Item("lan_alternativa1").ToString
                lan_alternativa2 = read.Item("lan_alternativa2").ToString
                lan_alternativa3 = read.Item("lan_alternativa3").ToString
                servizi_rete = read.Item("servizi_rete").ToString
                abilita_utenti_stpers_mod = read.Item("abilita_utenti_stpers_mod").ToString
                abilita_utenti_stpers_ass = read.Item("abilita_utenti_stpers_ass").ToString
                usermail = read.Item("usermail").ToString
                pswmail = read.Item("pswmail").ToString
                srvmail = read.Item("srvmail").ToString
                portmail = read.Item("portmail").ToString
                sslmail = read.Item("sslmail").ToString
                intmail = read.Item("intmail").ToString
                endmail = read.Item("endmail").ToString
                emailenabled = read.Item("emailenabled").ToString
                mittentemail = read.Item("mittentemail").ToString
                generalserver = read.Item("itsuiteaddressname").ToString
            End While
            Conntop.Close()
            Conntop.Dispose()
            read.Close()
            cmdtop.Dispose()

            Return True
        End Function
    End Class

End Class
