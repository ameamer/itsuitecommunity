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
''' Contiene elementi relativi ai tipi di utente di ITSuite.
''' </summary>
Public Class ITSuite_Usertypes

    ''' <summary>
    ''' Contiene i tipi di utenti di ITSuite.
    ''' </summary>
    Public Enum Usertype
        ''' <summary>
        ''' Utente amministratore di ITSuite.
        ''' </summary>
        Admin = 0
        ''' <summary>
        ''' Utente tecnico ticketing di ITSuite.
        ''' </summary>
        TechUser = 1
        ''' <summary>
        ''' Utente cliente di ITSuite.
        ''' </summary>
        Customer = 2
    End Enum

End Class
