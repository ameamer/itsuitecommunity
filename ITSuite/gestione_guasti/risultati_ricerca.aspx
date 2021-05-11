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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="risultati_ricerca.aspx.vb" Inherits="gestione_guasti_risultati_ricerca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String253") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String254") %><i><%=terminericerca %></i>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">

        <% If tiporicerca = "only" Then %>

        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="TicketSearchSQL">  
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td> <%=globals.ResourceHelper.GetString("String160") %></td>
                    </tr>
                </table>            </EmptyDataTemplate>
            <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='../gestione_guasti/dettagli_guasto.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                    </td>
                    <td>
                        <asp:Label ID="oraLabel" runat="server" Text='<%# Eval("ora") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazioneLabel" runat="server" Text='<%# Eval("intestazione") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_dettagli1Label" runat="server" Text='<%# Eval("autore_dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dettagli1Label" runat="server" Text='<%# Eval("dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='../gestione_guasti/dettagli_guasto.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                    </td>
                    <td>
                        <asp:Label ID="oraLabel" runat="server" Text='<%# Eval("ora") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazioneLabel" runat="server" Text='<%# Eval("intestazione") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_dettagli1Label" runat="server" Text='<%# Eval("autore_dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dettagli1Label" runat="server" Text='<%# Eval("dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" class="tableresult">
                    <tr runat="server">
                        <td runat="server">
                            <table class="ricerca-pc-tab" id="itemPlaceholderContainer" runat="server">
                                <tr runat="server" class="ricerca-pc-tab-tr">
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String239") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String257") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String258") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String229") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String56") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String235") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String231") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String128") %></th>
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

        <asp:SqlDataSource ID="TicketSearchSQL" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:FormParameter FormField="schterm" Name="ID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <br />

        <% End If %>

        <% If tiporicerca = "free" Then %>

        <asp:ListView ID="ListView2" runat="server" DataSourceID="FreeSearchSQL" DataKeyNames="ID">
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%= globals.ResourceHelper.GetString("String160") %></td>
                    </tr>
                </table>            </EmptyDataTemplate>
            <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='../gestione_guasti/dettagli_guasto.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                    </td>
                    <td>
                        <asp:Label ID="oraLabel" runat="server" Text='<%# Eval("ora") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazioneLabel" runat="server" Text='<%# Eval("intestazione") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_dettagli1Label" runat="server" Text='<%# Eval("autore_dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dettagli1Label" runat="server" Text='<%# Eval("dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='../gestione_guasti/dettagli_guasto.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                    </td>
                    <td>
                        <asp:Label ID="oraLabel" runat="server" Text='<%# Eval("ora") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazioneLabel" runat="server" Text='<%# Eval("intestazione") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_dettagli1Label" runat="server" Text='<%# Eval("autore_dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dettagli1Label" runat="server" Text='<%# Eval("dettagli1") %>' />
                    </td>
                    <td>
                        <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" class="tableresult">
                    <tr runat="server">
                        <td runat="server">
                            <table class="ricerca-pc-tab" id="itemPlaceholderContainer" runat="server">
                                <tr runat="server" class="ricerca-pc-tab-tr">
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String239") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String257") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String258") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String229") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String56") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String235") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String231") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String128") %></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="FreeSearchSQL" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:FormParameter FormField="schterm" Name="autore_apertura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_dettagli1" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_dettagli2" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_dettagli3" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_dettagli4" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_dettagli5" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autorechiusura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="corpo" Type="String" />
                <asp:FormParameter FormField="schterm" Name="data" Type="String" />
                <asp:FormParameter FormField="schterm" Name="datachiusura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli1" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli2" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli3" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli4" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli5" Type="String" />
                <asp:FormParameter FormField="schterm" Name="intestazione" Type="String" />
                <asp:FormParameter FormField="schterm" Name="motivo" Type="String" />
                <asp:FormParameter FormField="schterm" Name="motivoattesa" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ora" Type="String" />
                <asp:FormParameter FormField="schterm" Name="padiglione" Type="String" />
                <asp:FormParameter FormField="schterm" Name="presidio" Type="String" />
                <asp:FormParameter FormField="schterm" Name="reparto" Type="String" />
                <asp:FormParameter FormField="schterm" Name="stato" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ubicazione_guasto" Type="String" />
                <asp:FormParameter FormField="schterm" Name="utente" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <% End If %>
    </form>
</asp:Content>

