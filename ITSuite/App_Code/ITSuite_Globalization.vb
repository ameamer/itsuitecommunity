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
''' Contiene gli elementi relativi alla globalizzazione di ITSuite.
''' </summary>
Public Class ITSuite_Globalization

    ''' <summary>
    ''' Inizializza il sistema delle risorse sulla lingua dell'applicazione.
    ''' </summary>
    ''' <returns></returns>
    Public Function ResourceHelper() As System.Resources.ResourceManager
        Dim result As System.Resources.ResourceManager = Nothing

        If String.IsNullOrEmpty(HttpContext.Current.Session("lingua")) Then
            Select Case System.Globalization.RegionInfo.CurrentRegion.Name
                Case "IT" ' Lingua italiana
                    Dim rm As New System.Resources.ResourceManager("Resources.Italian", Reflection.Assembly.Load("App_GlobalResources"))
                    result = rm

                Case Else
                    Dim rm As New System.Resources.ResourceManager("Resources.English", Reflection.Assembly.Load("App_GlobalResources"))
                    result = rm

            End Select
        Else
            Select Case HttpContext.Current.Session("lingua")
                Case "IT" ' Lingua italiana
                    Dim rm As New System.Resources.ResourceManager("Resources.Italian", Reflection.Assembly.Load("App_GlobalResources"))
                    result = rm

                Case Else
                    Dim rm As New System.Resources.ResourceManager("Resources.English", Reflection.Assembly.Load("App_GlobalResources"))
                    result = rm
            End Select
        End If

        Return result
    End Function

End Class

