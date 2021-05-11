'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports Microsoft.VisualBasic
Imports ITSuite_Properties.DefaultPage

''' <summary>
''' Contiene elementi relativi alla sessione di ITSuite.
''' </summary>
Public Class ITSuite_Session
    ''' <summary>
    ''' Contiene i valori della sessione in corso.
    ''' </summary>
    Partial Public Class SessionHelper
        Public Shared ReadOnly Property UserAuthType As String
            Get
                Return HttpContext.Current.Session("Autenticato")
            End Get
        End Property

        Public Shared ReadOnly Property UserAuthRole As String
            Get
                Return HttpContext.Current.Session("tipo_utente")
            End Get
        End Property

        Public Shared ReadOnly Property UserAuth As String
            Get
                Return HttpContext.Current.Session("username")
            End Get
        End Property

        Public Shared ReadOnly Property UserId As String
            Get
                Return HttpContext.Current.Session("user_id")
            End Get
        End Property

    End Class

    ''' <summary>
    ''' Imposta la sessione utente di accesso.
    ''' </summary>
    ''' <param name="usrtype">ITSuite_Usertypes.Usertype - il tipo di utente di ITSuite</param>
    ''' <returns></returns>
    Public Shared Function SetLoginSession(usrtype As ITSuite_Usertypes.Usertype) As Boolean

        Select Case usrtype
            Case ITSuite_Usertypes.Usertype.Admin
                If String.IsNullOrEmpty(languser.ToString) Then
                    HttpContext.Current.Session("lingua") = lang
                Else
                    HttpContext.Current.Session("lingua") = languser
                End If
                HttpContext.Current.Session("Autenticato") = "admin"
                HttpContext.Current.Session("tipo_utente") = "admin"
                HttpContext.Current.Session("database_path") = database_utente
                HttpContext.Current.Session("sfondo_utente") = sfondo_utente
                HttpContext.Current.Session("abilita_utenti_standard") = abilita_utenti_standard
                HttpContext.Current.Session("abilita_strumenti_standard") = abilita_strumenti_standard
                HttpContext.Current.Session("abilita_utenti_stpers") = abilita_utenti_stpers
                HttpContext.Current.Session("abilita_strumenti_stpers") = abilita_strumenti_stpers
                HttpContext.Current.Session("abilita_gestione_guasti") = abilita_gestione_guasti
                HttpContext.Current.Session("abilita_assistenza_prodotti") = abilita_assistenza_prodotti
                HttpContext.Current.Session("abilita_software_aziendale") = abilita_software_aziendale
                HttpContext.Current.Session("sfondo_login") = sfondo_login
                HttpContext.Current.Session("risultati_pag") = paging
                HttpContext.Current.Session("ip_predefinito") = ip_predefinito
                HttpContext.Current.Session("ip_alternativo") = ip_alternativo
                HttpContext.Current.Session("submask_predefinita") = submask_predefinita
                HttpContext.Current.Session("submask_alternativa") = submask_alternativa
                HttpContext.Current.Session("gwy_predefinito") = gwy_predefinito
                HttpContext.Current.Session("gwy_alternativo") = gwy_alternativo
                HttpContext.Current.Session("dns1_predefinito") = dns1_predefinito
                HttpContext.Current.Session("dns1_alternativo") = dns1_alternativo
                HttpContext.Current.Session("dns2_predefinito") = dns2_predefinito
                HttpContext.Current.Session("dns2_alternativo") = dns2_alternativo
                HttpContext.Current.Session("wins_predefinito") = wins_predefinito
                HttpContext.Current.Session("wins_alternativo") = wins_alternativo
                HttpContext.Current.Session("lan_predefinita") = lan_predefinita
                HttpContext.Current.Session("lan_alternativa1") = lan_alternativa1
                HttpContext.Current.Session("lan_alternativa2") = lan_alternativa2
                HttpContext.Current.Session("lan_alternativa3") = lan_alternativa3
                HttpContext.Current.Session("abilita_servizi_windows") = abilita_servizi_windows
                HttpContext.Current.Session("abilita_servizi_rete") = abilita_servizi_rete
                HttpContext.Current.Session("abilita_autocompip") = abilita_autocompip
                HttpContext.Current.Session("servizi_rete") = servizi_rete
                HttpContext.Current.Session("abilita_utenti_stpers_mod") = abilita_utenti_stpers_mod
                HttpContext.Current.Session("abilita_utenti_stpers_ass") = abilita_utenti_stpers_ass
                HttpContext.Current.Session("user_id") = user_id
                HttpContext.Current.Session("utentemail") = usermail
                HttpContext.Current.Session("passwordmail") = pswmail
                HttpContext.Current.Session("servermail") = srvmail
                HttpContext.Current.Session("portamail") = portmail
                HttpContext.Current.Session("sslmail") = sslmail
                HttpContext.Current.Session("intromail") = intmail
                HttpContext.Current.Session("endmail") = endmail
                HttpContext.Current.Session("emailenabled") = emailenabled
                HttpContext.Current.Session("mittentemail") = mittentemail
                HttpContext.Current.Session("generalserver") = generalserver

            Case ITSuite_Usertypes.Usertype.TechUser
                If String.IsNullOrEmpty(languser) Then
                    HttpContext.Current.Session("lingua") = lang
                Else
                    HttpContext.Current.Session("lingua") = languser
                End If

                HttpContext.Current.Session("Autenticato") = "personale"
                HttpContext.Current.Session("tipo_utente") = "personale"
                HttpContext.Current.Session("database_path") = database_utente
                HttpContext.Current.Session("sfondo_utente") = sfondo_utente
                HttpContext.Current.Session("abilita_utenti_standard") = abilita_utenti_standard
                HttpContext.Current.Session("abilita_strumenti_standard") = abilita_strumenti_standard
                HttpContext.Current.Session("abilita_utenti_stpers") = abilita_utenti_stpers
                HttpContext.Current.Session("abilita_utenti_stpers_mod") = abilita_utenti_stpers_mod
                HttpContext.Current.Session("abilita_utenti_stpers_ass") = abilita_utenti_stpers_ass
                HttpContext.Current.Session("abilita_strumenti_stpers") = abilita_strumenti_stpers
                HttpContext.Current.Session("abilita_gestione_guasti") = abilita_gestione_guasti
                HttpContext.Current.Session("abilita_assistenza_prodotti") = abilita_assistenza_prodotti
                HttpContext.Current.Session("abilita_software_aziendale") = abilita_software_aziendale
                HttpContext.Current.Session("abilita_servizi_windows") = abilita_servizi_windows
                HttpContext.Current.Session("sfondo_login") = sfondo_login
                HttpContext.Current.Session("risultati_pag") = read.Item("paging").ToString
                HttpContext.Current.Session("user_id") = user_id
                HttpContext.Current.Session("utentemail") = usermail
                HttpContext.Current.Session("passwordmail") = pswmail
                HttpContext.Current.Session("servermail") = srvmail
                HttpContext.Current.Session("portamail") = portmail
                HttpContext.Current.Session("sslmail") = sslmail
                HttpContext.Current.Session("intromail") = intmail
                HttpContext.Current.Session("endmail") = endmail
                HttpContext.Current.Session("emailenabled") = emailenabled
                HttpContext.Current.Session("mittentemail") = mittentemail
                HttpContext.Current.Session("generalserver") = generalserver

            Case ITSuite_Usertypes.Usertype.Customer
                If String.IsNullOrEmpty(languser) Then
                    HttpContext.Current.Session("lingua") = lang
                Else
                    HttpContext.Current.Session("lingua") = languser
                End If

                HttpContext.Current.Session("Autenticato") = "cliente"
                HttpContext.Current.Session("tipo_utente") = "cliente"
                HttpContext.Current.Session("database_path") = database_utente
                HttpContext.Current.Session("sfondo_utente") = sfondo_utente
                HttpContext.Current.Session("abilita_utenti_standard") = abilita_utenti_standard
                HttpContext.Current.Session("abilita_strumenti_standard") = abilita_strumenti_standard
                HttpContext.Current.Session("abilita_utenti_stpers") = abilita_utenti_stpers
                HttpContext.Current.Session("abilita_strumenti_stpers") = abilita_strumenti_stpers
                HttpContext.Current.Session("abilita_gestione_guasti") = abilita_gestione_guasti
                HttpContext.Current.Session("abilita_assistenza_prodotti") = abilita_assistenza_prodotti
                HttpContext.Current.Session("abilita_software_aziendale") = abilita_software_aziendale
                HttpContext.Current.Session("abilita_utenti_stpers_mod") = abilita_utenti_stpers_mod
                HttpContext.Current.Session("sfondo_login") = sfondo_login
                HttpContext.Current.Session("tabella_rubrica_personale") = "tab_general"
                HttpContext.Current.Session("risultati_pag") = read.Item("paging").ToString
                HttpContext.Current.Session("user_id") = user_id
                HttpContext.Current.Session("generalserver") = generalserver

        End Select

        Return True
    End Function

End Class
