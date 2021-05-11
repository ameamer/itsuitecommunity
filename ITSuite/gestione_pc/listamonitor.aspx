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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="listamonitor.aspx.vb" Inherits="gestione_pc_listamonitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%= globals.ResourceHelper.GetString("String75") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%= globals.ResourceHelper.GetString("String407") %> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="SqlMonitorList">
           <AlternatingItemTemplate>
                <tr class="listelementclassalternative" onclick="location.href='dettagli_pc.aspx?id_pc=<%# Eval("ID") %>';">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="marca_video_pcLabel" runat="server" Text='<%# Eval("marca_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="modello_video_pcLabel" runat="server" Text='<%# Eval("modello_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="pollici_video_pcLabel" runat="server" Text='<%# Eval("pollici_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="serie_video_pcLabel" runat="server" Text='<%# Eval("serie_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="inventario_video_pcLabel" runat="server" Text='<%# Eval("inventario_video_pc") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                  <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%= globals.ResourceHelper.GetString("String160") %></td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr class="listelementclass" onclick="location.href='dettagli_pc.aspx?id_pc=<%# Eval("ID") %>';">
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="marca_video_pcLabel" runat="server" Text='<%# Eval("marca_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="modello_video_pcLabel" runat="server" Text='<%# Eval("modello_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="pollici_video_pcLabel" runat="server" Text='<%# Eval("pollici_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="serie_video_pcLabel" runat="server" Text='<%# Eval("serie_video_pc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="inventario_video_pcLabel" runat="server" Text='<%# Eval("inventario_video_pc") %>' />
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
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String392") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String122") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String372") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String123") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String393") %></th>
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
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlMonitorList" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:Parameter DefaultValue="''" Name="marca_video_pc" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</asp:Content>

