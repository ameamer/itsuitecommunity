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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="gestione_utenti_clienti.aspx.vb" Inherits="gestione_utenti_gestione_utenti_clienti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
        <div class="HorizontalTopMenuContainer">
        <div class="HorizontalTopMenuItemNotSelected" style="border-left: 1px solid lightgray;" onclick="location.href='../gestione_utenti/gestione_utenti_home.aspx'" >
             <a href="../gestione_utenti/gestione_utenti_home.aspx" title="Tutti gli utenti"><%=globals.ResourceHelper.GetString("String457")%></a>
        </div>
                  <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../gestione_utenti/gestione_utenti_sistema.aspx'">
            <a href="../gestione_utenti/gestione_utenti_sistema.aspx" title="Utenti di sistema"><%=globals.ResourceHelper.GetString("String458")%></a>
        </div>
        <div class="HorizontalTopMenuItemSelected">
            <%=globals.ResourceHelper.GetString("String459")%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
        <%=globals.ResourceHelper.GetString("String460")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
     <form runat="server" >
         <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="UserSqlSource">
            <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='../gestione_utenti/dettagli_utente.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="matricola_utenteLabel" runat="server" Text='<%# Eval("matricola_utente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeutenteLabel" runat="server" Text='<%# Eval("nomeutente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tipo_utenteLabel" runat="server" Text='<%# Eval("tipo_utente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="stato_utenteLabel" runat="server" Text='<%# Eval("stato_utente") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%=globals.ResourceHelper.GetString("String160")%></td>
                    </tr>
                </table>

            </EmptyDataTemplate>

            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='../gestione_utenti/dettagli_utente.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="matricola_utenteLabel" runat="server" Text='<%# Eval("matricola_utente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeutenteLabel" runat="server" Text='<%# Eval("nomeutente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tipo_utenteLabel" runat="server" Text='<%# Eval("tipo_utente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="stato_utenteLabel" runat="server" Text='<%# Eval("stato_utente") %>' />
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
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String53")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String47")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String51")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String61")%></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" class="pagerlist">
                            <asp:DataPager ID="DataPager1" runat="server" OnInit="DataPager1_Init">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="UserSqlSource" runat="server" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>

    </form>
</asp:Content>

