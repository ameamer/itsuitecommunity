'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************

Partial Class servizi_rete_corpo_ping_server
    Inherits System.Web.UI.Page

    Public globals As New ITSuite_Globalization()

    Public Shared queryip, PATH, FILENAME, TARGET, PING_OUTPUT As String

    ''' <summary>
    ''' Pagina caricata.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.Title = globals.ResourceHelper.GetString("String536") & " | ITSuite by Ame Amer (admin@ameamer.com)"

        Result.DataBind()

        If Session("Autenticato") <> "admin" Or Session("abilita_servizi_rete") = "0" Then
            Response.Redirect("../logout.aspx")
        End If

        queryip = Request.QueryString("ip")

        ' Imposto sottotitolo
        SubLabel.Text = globals.ResourceHelper.GetString("String539") & queryip

    End Sub

    Public Function StartServerPing() As Object
        ' Attivo buffer e imposto path
        Response.Buffer = True
        PATH = Server.MapPath(".")

        ' Nome del file sul quale viene salvato il risulato del ping
        FILENAME = "file.txt"
        TARGET = PATH & "\" & FILENAME

        Dim objShell = Server.CreateObject("Wscript.Shell")
        ' Esecuzione del ping
        objShell.Run("%ComSpec% /c ping " & queryip & ">" & TARGET, 0, True)

        Try

            Dim fs = CreateObject("Scripting.FileSystemObject")
            ' Lettura del file
            Dim file = fs.OpenTextFile(TARGET, 1)
            Do While Not file.AtEndOfStream
                ' Questo ciclo legge tutte le righe del file
                ' e le salva nella variabile PING_OUTPUT
                PING_OUTPUT = PING_OUTPUT & (file.ReadLine & "<br>")
            Loop

            ' Chiudo il file
            file.Close()
        Catch ex As Exception
            Diagnostics.Debug.WriteLine("Errore durante scrittura del file di ping (0x009)")
            Response.Write(globals.ResourceHelper.GetString("String540"))
        End Try

        ' Stampo il risultato sulla pagina
        Response.Write("<br />" & PING_OUTPUT)

        ' Libero memoria
        Response.Flush()
        Response.Clear()
        PING_OUTPUT = ""
        Return 0
    End Function
End Class
