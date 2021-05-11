<%--
'****************************************************************
'****************************************************************
' Copyright (c) 2018 Ame Amer
' http://www.ameamer.com/
' admin@ameamer.com
' distribuited under BSD 3-clause License:
' https://opensource.org/licenses/bsd-license.php
'****************************************************************
'****************************************************************
--%>

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="risultati_ricerca.aspx.vb" Inherits="gestione_utenti_risultati_ricerca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String181")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String486")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
    <form runat="server">

        <% If tiporicerca = "only" Then %>

        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="IDUserSearchSQL">  
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%=globals.ResourceHelper.GetString("String160")%></td>
                    </tr>
                </table>            </EmptyDataTemplate>
            <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='../gestione_utenti/dettagli_utente.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cognomeLabel" runat="server" Text='<%# Eval("cognome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeutenteLabel" runat="server" Text='<%# Eval("nomeutente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tipo_utenteLabel" runat="server" Text='<%# Eval("tipo_utente") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='../gestione_utenti/dettagli_utente.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cognomeLabel" runat="server" Text='<%# Eval("cognome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeutenteLabel" runat="server" Text='<%# Eval("nomeutente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tipo_utenteLabel" runat="server" Text='<%# Eval("tipo_utente") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" class="tableresult">
                    <tr runat="server">
                        <td runat="server">
                            <table class="ricerca-pc-tab" id="itemPlaceholderContainer" runat="server">
                                <tr runat="server" class="ricerca-pc-tab-tr">
                                    <th runat="server" class="ricerca-pc-tab-th">ID</th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String48")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String49")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String50")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String47")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String51")%></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" class="pagerlist">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>

        </asp:ListView>
        <br />

        <asp:SqlDataSource ID="IDUserSearchSQL" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:FormParameter FormField="schterm" Name="ID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <br />

        <% End If %>

        <% If tiporicerca = "free" Then %>

        <asp:ListView ID="ListView2" runat="server" DataSourceID="FreeUserSearchSQL" DataKeyNames="ID">
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%=globals.ResourceHelper.GetString("String160")%></td>
                    </tr>
                </table>            </EmptyDataTemplate>
            <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='../gestione_utenti/dettagli_utente.aspx?id=<%# Eval("ID") %>'">
                                       <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cognomeLabel" runat="server" Text='<%# Eval("cognome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeutenteLabel" runat="server" Text='<%# Eval("nomeutente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tipo_utenteLabel" runat="server" Text='<%# Eval("tipo_utente") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='../gestione_utenti/dettagli_utente.aspx?id=<%# Eval("ID") %>'">
                                      <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cognomeLabel" runat="server" Text='<%# Eval("cognome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeutenteLabel" runat="server" Text='<%# Eval("nomeutente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tipo_utenteLabel" runat="server" Text='<%# Eval("tipo_utente") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" class="tableresult">
                    <tr runat="server">
                        <td runat="server">
                            <table class="ricerca-pc-tab" id="itemPlaceholderContainer" runat="server">
                                <tr runat="server" class="ricerca-pc-tab-tr">
                                    <th runat="server" class="ricerca-pc-tab-th">ID</th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String48")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String49")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String50")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String47")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String51")%></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="FreeUserSearchSQL" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:FormParameter FormField="schterm" Name="matricola_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="nomeutente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="tipo_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="database_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="creato_da" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ubicazione_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="data_creazione_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ora_creazione_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="data_modifica" Type="String" />
                <asp:FormParameter FormField="schterm" Name="note_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="stato_utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_modifica" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ora_modifica" Type="String" />
                <asp:FormParameter FormField="schterm" Name="FileName" Type="String" />
                <asp:FormParameter FormField="schterm" Name="cognome" Type="String" />
                <asp:FormParameter FormField="schterm" Name="nome" Type="String" />
                <asp:FormParameter FormField="schterm" Name="email" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <% End If %>
    </form>

</asp:Content>

