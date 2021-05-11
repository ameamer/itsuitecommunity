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
''' Contiene elementi relative alle API di ITSuite condivise.
''' </summary>
Public Class ITSuite_ExternalAPI
    ''' <summary>
    ''' Contiene elementi relativi ai tipi di utente di ITSuite.
    ''' </summary>
    Public Class Usertypes

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

    ''' <summary>
    ''' Contiene elementi relativi all'identita dell'utente di ITSuite.
    ''' </summary>
    Partial Public Class IdentityHelperEx

        ''' <summary>
        ''' Restituisce il ruolo di autenticazione dell'utente: "admin", "personale", "cliente".
        ''' </summary>
        Public Shared ReadOnly Property UserAuthRole As Usertypes.Usertype
            Get
                Dim tores As Usertypes.Usertype
                Select Case ITSuite_Session.SessionHelper.UserAuthRole
                    Case "admin"
                        tores = Usertypes.Usertype.Admin

                    Case "personale"
                        tores = Usertypes.Usertype.TechUser

                    Case "cliente"
                        tores = Usertypes.Usertype.Customer
                End Select

                Return tores
            End Get
        End Property

        ''' <summary>
        ''' Restituisce il nome utente attualmente collegato.
        ''' </summary>
        Public Shared ReadOnly Property UserAuth As String
            Get
                Return ITSuite_Session.SessionHelper.UserAuth
            End Get
        End Property

        ''' <summary>
        ''' Restituisce l'ID dell'utente attualmente collegato.
        ''' </summary>
        Public Shared ReadOnly Property UserId As String
            Get
                Return ITSuite_Session.SessionHelper.UserId
            End Get
        End Property
    End Class

    ''' <summary>
    ''' Contiene elementi relativi ai Componenti aggiunti di ITSuite.
    ''' </summary>
    Partial Public Class ComponentHelperEx
        ''' <summary>
        ''' Restituisce true se il componente è abilitato per i tecnici ticketing, altrimenti false.
        ''' </summary>
        ''' <param name="TechnicalName">String - il nome tecnico del componente aggiuntivo di ITSuite</param>
        ''' <returns></returns>
        Public Shared Function isComponentForTechUser(TechnicalName As String) As Boolean
            Dim res As Boolean = ITSuite_Components.isComponentForTechUsers(TechnicalName)
            Return res
        End Function
        ''' <summary>
        ''' Restituisce true se il componente è abilitato per i clienti, altrimenti false.
        ''' </summary>
        ''' <param name="TechnicalName">String - il nome tecnico del componente aggiuntivo di ITSuite</param>
        ''' <returns></returns>
        Public Shared Function isComponentForCustomerUser(TechnicalName As String) As Boolean
            Dim res As Boolean = ITSuite_Components.isComponentForCustomerUsers(TechnicalName)
            Return res
        End Function

    End Class

    ''' <summary>
    ''' Contiene elementi relativi alle impostazioni internazionali.
    ''' </summary>
    Partial Public Class GlobalizationHelperEx
        ''' <summary>
        ''' Se impostato, restituisce il codice lingua dell'utente. Se non impostato, restituisce "DEFAULT".
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetUserLang() As String
            Dim res As String = HttpContext.Current.Session("lingua")
            If String.IsNullOrEmpty(res) Then
                res = "DEFAULT"
            End If
            Return res
        End Function
    End Class

    ''' <summary>
    ''' Contiene elementi relativi ai prodotti presenti nel database di ITSuite.
    ''' </summary>
    Partial Public Class ProductsHelperEx
        ''' <summary>
        ''' Contiene elementi relativi ai PC presenti nel database di ITSuite
        ''' </summary>
        Partial Public Class PC

            ''' <summary>
            ''' La classe contenente i dati del PC richiesto.
            ''' </summary>
            Partial Public Class PCDataReuslt
                Public PCDomain As String
                Public PCName As String
                Public PCBrand As String
                Public PCModel As String
                Public SN As String
                Public Inventory As String
                Public Department As String
                Public Room As String
                Public Author As String
                Public Pavilion As String
                Public Floor As String
                Public Building As String
                Public OS As String
                Public Ram As String
                Public Cpu As String
                Public IP As String
                Public PrivateSoftware As String
                Public AddDate As String
                Public AddTime As String
                Public Notes As String
                Public Status As String
                Public Year As String
                Public PCType As String
                Public PCMonitorBrand As String
                Public PCMonitorModel As String
                Public PCMonitorInch As String
                Public PCMonitorInv As String
                Public PCMonitorSN As String
                Public PCMonitorNotes As String
                Public PCMonitorStatus As String
                Public PCMonitorYear As String
                Public IDConnPrinter As String
                Public IDConnHW As String
                Public PCDriverFolder As String
            End Class

            ''' <summary>
            ''' Restituisce i dati del PC richiesto salvato nel database di ITSuite.
            ''' </summary>
            ''' <param name="id"></param>
            ''' <returns></returns>
            Public Shared Function GetPcData(id As String) As PCDataReuslt
                Dim qrytop As String = "Select * from datapc WHERE ID=" & id & " order by id ASC"
                Dim DbPathtop As String = "../App_Data/itstdb.mdf"
                Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                Dim Conntop As New SqlConnection(connecttop)
                Dim cmdtop As New SqlCommand(qrytop, Conntop)
                Conntop.Open()
                Dim read As SqlDataReader = cmdtop.ExecuteReader()
                Dim PcRes As New PCDataReuslt()
                If read.Read() Then
                    PcRes.PCDomain = read.Item("dominio_pc").ToString
                    PcRes.PCName = read.Item("nome_dominio_pc").ToString
                    PcRes.PCBrand = read.Item("marca_pc").ToString
                    PcRes.PCModel = read.Item("modello_pc").ToString
                    PcRes.SN = read.Item("serie_pc").ToString
                    PcRes.Inventory = read.Item("inventario_pc").ToString
                    PcRes.Department = read.Item("reparto_pc").ToString
                    PcRes.Room = read.Item("stanza_pc").ToString
                    PcRes.Author = read.Item("inserito_da").ToString
                    PcRes.Pavilion = read.Item("padiglione_pc").ToString
                    PcRes.Floor = read.Item("piano_pc").ToString
                    PcRes.Building = read.Item("presidio_pc").ToString
                    PcRes.OS = read.Item("so_pc").ToString
                    PcRes.Ram = read.Item("ram_pc").ToString
                    PcRes.Cpu = read.Item("processore_pc").ToString
                    PcRes.IP = read.Item("indirizzo_ip_pc").ToString
                    PcRes.PrivateSoftware = read.Item("swprivate_pc").ToString
                    PcRes.AddDate = read.Item("data_ins_pc").ToString
                    PcRes.AddTime = read.Item("ora_ins_pc").ToString
                    PcRes.Notes = read.Item("note_pc").ToString
                    PcRes.Status = read.Item("stato_pc").ToString
                    PcRes.Year = read.Item("anno_pc").ToString
                    PcRes.PCType = read.Item("tipo_pc").ToString
                    PcRes.PCMonitorBrand = read.Item("marca_video_pc").ToString
                    PcRes.PCMonitorModel = read.Item("modello_video_pc").ToString
                    PcRes.PCMonitorInch = read.Item("pollici_video_pc").ToString
                    PcRes.PCMonitorInv = read.Item("inventario_video_pc").ToString
                    PcRes.PCMonitorSN = read.Item("serie_video_pc").ToString
                    PcRes.PCMonitorNotes = read.Item("note_video_pc").ToString
                    PcRes.PCMonitorStatus = read.Item("stato_video_pc").ToString
                    PcRes.PCMonitorYear = read.Item("anno_video_pc").ToString
                    PcRes.IDConnPrinter = read.Item("id_stampante_collegata").ToString
                    PcRes.IDConnHW = read.Item("id_altrohw_collegato").ToString
                    PcRes.PCDriverFolder = read.Item("cartella_pc").ToString
                Else
                    PcRes = Nothing
                End If
                Conntop.Close()
                Conntop.Dispose()
                read.Close()
                cmdtop.Dispose()

                Return PcRes
            End Function

            ''' <summary>
            ''' Restituisce la lista dei PC presenti nel database di ITSuite.
            ''' </summary>
            ''' <returns></returns>
            Public Shared Function GetPcList() As List(Of PCDataReuslt)
                Dim qrytop As String = "Select * from datapc order by id ASC"
                Dim DbPathtop As String = "../App_Data/itstdb.mdf"
                Dim connecttop As String = "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;AttachDbFileName=" & HttpContext.Current.Server.MapPath(DbPathtop)
                Dim Conntop As New SqlConnection(connecttop)
                Dim cmdtop As New SqlCommand(qrytop, Conntop)
                Conntop.Open()
                Dim read As SqlDataReader = cmdtop.ExecuteReader()
                Dim PcResList As New List(Of PCDataReuslt)
                While read.Read()
                    Dim PcRes As New PCDataReuslt
                    PcRes.PCDomain = read.Item("dominio_pc").ToString
                    PcRes.PCName = read.Item("nome_dominio_pc").ToString
                    PcRes.PCBrand = read.Item("marca_pc").ToString
                    PcRes.PCModel = read.Item("modello_pc").ToString
                    PcRes.SN = read.Item("serie_pc").ToString
                    PcRes.Inventory = read.Item("inventario_pc").ToString
                    PcRes.Department = read.Item("reparto_pc").ToString
                    PcRes.Room = read.Item("stanza_pc").ToString
                    PcRes.Author = read.Item("inserito_da").ToString
                    PcRes.Pavilion = read.Item("padiglione_pc").ToString
                    PcRes.Floor = read.Item("piano_pc").ToString
                    PcRes.Building = read.Item("presidio_pc").ToString
                    PcRes.OS = read.Item("so_pc").ToString
                    PcRes.Ram = read.Item("ram_pc").ToString
                    PcRes.Cpu = read.Item("processore_pc").ToString
                    PcRes.IP = read.Item("indirizzo_ip_pc").ToString
                    PcRes.PrivateSoftware = read.Item("swprivate_pc").ToString
                    PcRes.AddDate = read.Item("data_ins_pc").ToString
                    PcRes.AddTime = read.Item("ora_ins_pc").ToString
                    PcRes.Notes = read.Item("note_pc").ToString
                    PcRes.Status = read.Item("stato_pc").ToString
                    PcRes.Year = read.Item("anno_pc").ToString
                    PcRes.PCType = read.Item("tipo_pc").ToString
                    PcRes.PCMonitorBrand = read.Item("marca_video_pc").ToString
                    PcRes.PCMonitorModel = read.Item("modello_video_pc").ToString
                    PcRes.PCMonitorInch = read.Item("pollici_video_pc").ToString
                    PcRes.PCMonitorInv = read.Item("inventario_video_pc").ToString
                    PcRes.PCMonitorSN = read.Item("serie_video_pc").ToString
                    PcRes.PCMonitorNotes = read.Item("note_video_pc").ToString
                    PcRes.PCMonitorStatus = read.Item("stato_video_pc").ToString
                    PcRes.PCMonitorYear = read.Item("anno_video_pc").ToString
                    PcRes.IDConnPrinter = read.Item("id_stampante_collegata").ToString
                    PcRes.IDConnHW = read.Item("id_altrohw_collegato").ToString
                    PcRes.PCDriverFolder = read.Item("cartella_pc").ToString

                    PcResList.Add(PcRes)
                End While
                Conntop.Close()
                Conntop.Dispose()
                read.Close()
                cmdtop.Dispose()

                Return PcResList
            End Function

        End Class
    End Class

End Class
