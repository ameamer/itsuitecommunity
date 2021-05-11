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

<%@ Page Language="VB" AspCompat="true"  MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="assistenza_prodotti_home.aspx.vb" Inherits="assistenza_prodotti_assistenza_prodotti_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <div class="HorizontalTopMenuContainer">
    <div class="HorizontalTopMenuItemNotSelected" style="border-left: 1px solid lightgray;" onclick="location.href='../assistenza_prodotti/assistenza_prodotti_all.aspx'">
               <a href="../assistenza_prodotti/assistenza_prodotti_all.aspx" title='<%=globals.ResourceHelper.GetString("String91")%>'><%=globals.ResourceHelper.GetString("String91")%></a>
        </div>
        <div class="HorizontalTopMenuItemSelected">
            <%=globals.ResourceHelper.GetString("String30")%>
        </div>
                <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../assistenza_prodotti/assistenza_prodotti_chiuse.aspx'">
           <a href="../assistenza_prodotti/assistenza_prodotti_chiuse.aspx" title='<%=globals.ResourceHelper.GetString("String31")%>'><%=globals.ResourceHelper.GetString("String31")%></a>
        </div>
    </div>
     </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String739")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form id="form1" runat="server">
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="AssAperteSql">
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
        <asp:SqlDataSource ID="AssAperteSql" runat="server" ProviderName="System.Data.SqlClient">
        </asp:SqlDataSource>
    </form>
</asp:Content>
