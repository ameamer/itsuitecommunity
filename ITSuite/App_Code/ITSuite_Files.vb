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
''' Contiene elementi relativi alla gestione dei file di ITSuite.
''' </summary>
Public Class ITSuite_Files
    ''' <summary>
    ''' Restituisce la dimensione del file richiesto.
    ''' </summary>
    ''' <param name="filepath"></param>
    ''' <returns></returns>
    Public Shared Function GetFileSize(filepath As String) As String
        Dim fso, f, calcolokb As Object
        fso = HttpContext.Current.Server.CreateObject("Scripting.FileSystemObject")
        f = fso.GetFile(filepath)
        calcolokb = FormatNumber(f.Size / 1024, 2)
        f = Nothing
        fso = Nothing
        Return calcolokb
    End Function
End Class
