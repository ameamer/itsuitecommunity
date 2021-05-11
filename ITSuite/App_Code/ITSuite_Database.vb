'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports Microsoft.VisualBasic

''' <summary>
''' Contiene elementi relativi al database di ITSuite.
''' </summary>
Public Class ITSuite_Database

    ''' <summary>
    ''' Contiene funzioni sulle connessioni ai DB.
    ''' </summary>
    Partial Public Class DBConnectionStrings

        ''' <summary>
        ''' La stringa di connessione al DB SQL Server.
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property SQLSrvConnectionString As String
            Get
                Dim ConnStr As String
                ConnStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True"
                Return ConnStr
            End Get
        End Property

        ''' <summary>
        ''' Contiene funzioni relative ai comandi SQL.
        ''' </summary>
        Partial Public Class SQLCommands
            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione della lista degli utenti di sistema.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLSysuserListCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [Id], [matricola_utente], [nomeutente], [tipo_utente], [stato_utente] FROM [Utenti] WHERE tipo_utente='Amministratore' OR tipo_utente='Tecnico ticketing' ORDER BY [nomeutente]"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione della lista degli utenti.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLUserListCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [Id], [matricola_utente], [nomeutente], [tipo_utente], [stato_utente] FROM [Utenti] ORDER BY [nomeutente]"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione della lista dei clienti.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLCustomerListCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [Id], [matricola_utente], [nomeutente], [tipo_utente], [stato_utente] FROM [Utenti] WHERE tipo_utente='Cliente' ORDER BY [nomeutente]"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione della lista stampanti.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLListaStampCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [marca_stampante], [modello_stampante], [numero_serie_stampante], [inventario_stampante] FROM [stampanti] ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione del dettaglio di una stampante.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLDettaglioStampCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT * FROM [stampanti] WHERE ([Id] = @Id)"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione del dettaglio di un utente.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLDettaglioUserCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT * FROM [Utenti] WHERE ([Id] = @Id)"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione del dettaglio di un hardware.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLDettaglioHWCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT * FROM [datahardware] WHERE ([Id] = @Id)"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione del dettaglio di un PC.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLDettaglioPCCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT * FROM [datapc] WHERE ([Id] = @Id)"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione della lista di tutti gli altri HW.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLAltroHwListaGenerale As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [Id], [tipo_hardware], [marca_hardware], [modello_hardware], [serie_hardware], [inventario_hardware] FROM [datahardware] ORDER BY [Id] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione del dettaglio di un ticket guasti.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLDettaglioGuastiCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT * FROM [guasti] WHERE ([Id] = @Id)"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione del dettaglio di un ticket guasti (utenti ticketing).
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLDettaglioGuastiCommandPersonale As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [padiglione], [presidio], [reparto], [ubicazione_guasto], [intestazione], [corpo], [autore_apertura], [dettagli1], [autore_dettagli1], [stato] FROM [guasti] WHERE ([ID] = @ID) And [dettagli1]='" & HttpContext.Current.Session("username") & "'"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione del dettaglio di un ticket guasti (utenti clienti).
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLDettaglioGuastiCommandCliente As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [padiglione], [presidio], [reparto], [ubicazione_guasto], [intestazione], [corpo], [autore_apertura], [dettagli1], [autore_dettagli1], [stato] FROM [guasti] WHERE ([ID] = @ID) And [utente]='" & HttpContext.Current.Session("user_id") & "'"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLTuttiGuastiCommandAdmin As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [Id], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] ORDER BY [Id] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti assegnati all'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLTuttiGuastiCommandPersonale As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([dettagli1]='" & HttpContext.Current.Session("username") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti con cliente l'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLTuttiGuastiCommandCliente As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([utente]='" & HttpContext.Current.Session("user_id") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti chiusi.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiChiusiCommandAdmin As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autorechiusura], [datachiusura], [stato] FROM [guasti] WHERE ([stato] = 'chiusa') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti chiusi assegnati all'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiChiusiCommandPersonale As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [dettagli1], [stato], [autorechiusura], [datachiusura] FROM [guasti] WHERE ([stato] = 'chiusa') AND ([dettagli1]='" & HttpContext.Current.Session("username") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti chiusi con cliente l'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiChiusiCommandCliente As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [dettagli1], [stato], [autorechiusura], [datachiusura] FROM [guasti] WHERE ([stato] = 'chiusa') AND ([utente]='" & HttpContext.Current.Session("user_id") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti in attesa.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiAttesaCommandAdmin As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([stato] = 'in attesa') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti in attesa assegnati all'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiAttesaCommandPersonale As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([stato] = 'in attesa') AND ([dettagli1]='" & HttpContext.Current.Session("username") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti in attesa assegnati all'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiAttesaCommandCliente As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([stato] = 'in attesa') AND ([utente]='" & HttpContext.Current.Session("user_id") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti aperti.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiApertiCommandAdmin As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([stato] = 'aperta') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti aperti assegnati all'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiApertiCommandPersonale As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([stato] = 'aperta') AND ([dettagli1]='" & HttpContext.Current.Session("username") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutti i ticket guasti aperti assegnati all'utente in uso.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLGuastiApertiCommandCliente As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data], [ora], [presidio], [reparto], [intestazione], [autore_apertura], [dettagli1], [stato] FROM [guasti] WHERE ([stato] = 'aperta') AND ([utente]='" & HttpContext.Current.Session("user_id") & "') ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property


            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutte le richieste di assistenza chiuse.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLAssChiuseCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [dettagli_chiusura], [autore_chiusura], [data_chiusura], [stato] FROM [assistenzaprodotti] WHERE ([stato] = 'chiusa') ORDER BY [data_chiusura] ASC"
                    Return SQLCommand
                End Get
            End Property

            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutte le richieste di assistenza aperte.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLAssAperteCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data_apertura], [ora_apertura], [autore_apertura], [intestazione_apertura], [stato] FROM [assistenzaprodotti] WHERE ([stato] = 'aperta') ORDER BY [data_chiusura] ASC"
                    Return SQLCommand
                End Get
            End Property


            ''' <summary>
            ''' Seleziona gli elementi necessari alla visualizzazione di tutte le richieste di assistenza chiuse.
            ''' </summary>
            ''' <returns></returns>
            Public Shared ReadOnly Property SQLAssTutteCommand As String
                Get
                    Dim SQLCommand As String
                    SQLCommand = "SELECT [ID], [data_apertura], [ora_apertura], [autore_apertura], [intestazione_apertura], [stato] FROM [assistenzaprodotti] ORDER BY [ID] DESC"
                    Return SQLCommand
                End Get
            End Property
        End Class

    End Class

End Class
