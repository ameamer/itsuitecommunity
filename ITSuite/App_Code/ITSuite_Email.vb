'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Imports System.Net.Mail
Imports Microsoft.VisualBasic

''' <summary>
''' Contiene elementi relativi alla gestione della posta elettronica di ITSuite.
''' </summary>
Public Class ITSuite_Email

    ''' <summary>
    ''' Invia una nuova e-mail.
    ''' </summary>
    ''' <param name="usr">String - nome utente server</param>
    ''' <param name="psw">String - password server</param>
    ''' <param name="srv">String - indirizzo server</param>
    ''' <param name="port">Integer - porta server</param>
    ''' <param name="mailfrom">MailAddress - mittente</param>
    ''' <param name="mailto">MailAddressCollection - destinatario</param>
    ''' <param name="subject">String - oggetto</param>
    ''' <param name="body">String - messaggio</param>
    ''' <returns></returns>
    Public Shared Function SendMail(usr As String, psw As String, srv As String, port As Integer, ssl As Boolean, mailfrom As MailAddress, mailto As MailAddressCollection, subject As String, body As String) As String
        Dim utilisateur As String = usr
        Dim pass As String = psw
        Dim server As String = srv
        Dim Message As New System.Net.Mail.MailMessage()
        Message.From = mailfrom
        For Each ind As MailAddress In mailto
            Message.To.Add(ind)
        Next
        Message.Subject = subject
        Message.Body = body
        Message.IsBodyHtml = True
        Dim client As New SmtpClient(server)

        If ssl Then
            client.EnableSsl = True
        Else
            client.EnableSsl = False
        End If

        client.Port = port
        client.Credentials = New System.Net.NetworkCredential(utilisateur, pass)

        Dim res As String
        Try
            client.Send(Message)
            res = "ok"
        Catch ex As Exception
            res = ex.ToString
        End Try

        Return res
    End Function

End Class
