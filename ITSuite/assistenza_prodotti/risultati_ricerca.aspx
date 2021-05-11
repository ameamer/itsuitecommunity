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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="risultati_ricerca.aspx.vb" Inherits="assistenza_prodotti_risultati_ricerca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String181")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String181")%><i><%=terminericerca %></i>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">

        <% If tiporicerca = "only" Then %>

        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="AssSearchSQL">
            <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='../assistenza_prodotti/dettagli_assistenza.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="data_aperturaLabel" runat="server" Text='<%# Eval("data_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ora_aperturaLabel" runat="server" Text='<%# Eval("ora_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazione_aperturaLabel" runat="server" Text='<%# Eval("intestazione_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%=globals.ResourceHelper.GetString("String160")%></td>
                    </tr>
                </table>            </EmptyDataTemplate>

            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='../assistenza_prodotti/dettagli_assistenza.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="data_aperturaLabel" runat="server" Text='<%# Eval("data_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ora_aperturaLabel" runat="server" Text='<%# Eval("ora_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazione_aperturaLabel" runat="server" Text='<%# Eval("intestazione_apertura") %>' />
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
                                    <th runat="server" class="ricerca-pc-tab-th">ID</th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String232")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String233")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String129")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String229")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String128")%></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="AssSearchSQL" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:FormParameter FormField="schterm" Name="ID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <% end if %>

        <% If tiporicerca = "free" Then %>

        <asp:ListView ID="ListView2" runat="server" DataSourceID="AssFreeSearchSQL">
            <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='../assistenza_prodotti/dettagli_assistenza.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="data_aperturaLabel" runat="server" Text='<%# Eval("data_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ora_aperturaLabel" runat="server" Text='<%# Eval("ora_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazione_aperturaLabel" runat="server" Text='<%# Eval("intestazione_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%=globals.ResourceHelper.GetString("String160")%></td>
                    </tr>
                </table>            </EmptyDataTemplate>

            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='../assistenza_prodotti/dettagli_assistenza.aspx?id=<%# Eval("ID") %>'">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="data_aperturaLabel" runat="server" Text='<%# Eval("data_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ora_aperturaLabel" runat="server" Text='<%# Eval("ora_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                    </td>
                    <td>
                        <asp:Label ID="intestazione_aperturaLabel" runat="server" Text='<%# Eval("intestazione_apertura") %>' />
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
                                    <th runat="server" class="ricerca-pc-tab-th">ID</th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String232")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String233")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String129")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String229")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String128")%></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="AssFreeSearchSQL" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:FormParameter FormField="schterm" Name="altra_ass" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_apertura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_chiusura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="autore_dettagli1" Type="String" />
                <asp:FormParameter FormField="schterm" Name="data_apertura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="data_chiusura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli_apertura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli_chiusura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="dettagli1" Type="String" />
                <asp:FormParameter FormField="schterm" Name="idaltrohw" Type="String" />
                <asp:FormParameter FormField="schterm" Name="idpc" Type="String" />
                <asp:FormParameter FormField="schterm" Name="idstamp" Type="String" />
                <asp:FormParameter FormField="schterm" Name="intestazione_apertura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ora_apertura" Type="String" />
                <asp:FormParameter FormField="schterm" Name="stato" Type="String" />
                <asp:FormParameter FormField="schterm" Name="ID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <% End if %>
    </form>

</asp:Content>