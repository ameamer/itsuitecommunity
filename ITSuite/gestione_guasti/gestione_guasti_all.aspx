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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="gestione_guasti_all.aspx.vb" Inherits="gestione_guasti_gestione_guasti_all" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../script/jquery-3.2.1.min.js"></script>
<script type="text/javascript" src="../script/main.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <div class="HorizontalTopMenuContainer">
        <div class="HorizontalTopMenuItemSelected" style="border-left: 1px solid lightgray;" >
            <%=globals.ResourceHelper.GetString("String88") %>
        </div>
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../gestione_guasti/gestione_guasti_home.aspx'">
            <a href="../gestione_guasti/gestione_guasti_home.aspx" title="<%=globals.ResourceHelper.GetString("String19") %>"><%=globals.ResourceHelper.GetString("String19") %></a>
        </div>
                <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../gestione_guasti/gestione_guasti_inattesa.aspx'">
             <a href="../gestione_guasti/gestione_guasti_inattesa.aspx" title="<%=globals.ResourceHelper.GetString("String20") %>"><%=globals.ResourceHelper.GetString("String20") %></a>
        </div>
                <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../gestione_guasti/gestione_guasti_chiusi.aspx'">
           <a href="../gestione_guasti/gestione_guasti_chiusi.aspx" title="<%=globals.ResourceHelper.GetString("String21") %>"><%=globals.ResourceHelper.GetString("String21") %></a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
<asp:Label runat="server" ID="LabelSubMenu"></asp:Label>
    <div class="settings-button-right-title" style="margin-top:0px; margin-right:31px;margin-left:0px;" title="Nuovo ticket" onclick="location.href='../gestione_guasti/nuovo_guasto.aspx';">
     <a href="../gestione_guasti/nuovo_guasto.aspx" title="<%=globals.ResourceHelper.GetString("String22") %>" style="border: 0px solid black; text-decoration:underline; font-weight:bold; margin-top: 0px;color:darkgreen;"><%=globals.ResourceHelper.GetString("String22") %></a>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
     <form runat="server">
        <asp:Timer ID="AutoRefresh" runat="server" Interval="5000" OnTick="AutoRefresh_Tick" ClientIDMode="AutoID"></asp:Timer>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ListView ID="ListViewGuasti" runat="server" DataKeyNames="ID" DataSourceID="TuttiGuastiSource">
                    <AlternatingItemTemplate>
                        <tr class="listelementclassalternative" onclick="location.href='../gestione_guasti/dettagli_guasto.aspx?id=<%# Eval("ID") %>'">
                            <td>
                                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                            </td>
                            <td>
                                <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") & " " & Eval("ora") %>' />
                            </td>
                            <td>
                                <asp:Label ID="presidioLabel" runat="server" Text='<%# Eval("presidio") %>' />
                            </td>
                            <td>
                                <asp:Label ID="repartoLabel" runat="server" Text='<%# Eval("reparto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="intestazioneLabel" runat="server" Text='<%# Eval("intestazione") %>' />
                            </td>
                            <td>
                                <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("dettagli1") %>' />
                            </td>
                            <td>
                                <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; ">
                            <tr>
                                <td><%=globals.ResourceHelper.GetString("String160") %></td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr class="listelementclass" onclick="location.href='../gestione_guasti/dettagli_guasto.aspx?id=<%# Eval("ID") %>'">
                            <td>
                                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                            </td>
                            <td>
                                <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") & " " & Eval("ora") %>' />
                            </td>
                            <td>
                                <asp:Label ID="presidioLabel" runat="server" Text='<%# Eval("presidio") %>' />
                            </td>
                            <td>
                                <asp:Label ID="repartoLabel" runat="server" Text='<%# Eval("reparto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="intestazioneLabel" runat="server" Text='<%# Eval("intestazione") %>' />
                            </td>
                            <td>
                                <asp:Label ID="autore_aperturaLabel" runat="server" Text='<%# Eval("autore_apertura") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("dettagli1") %>' />
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
                                            <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String240") %></th>
                                            <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String127") %></th>
                                            <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String125") %></th>
                                            <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String229") %></th>
                                            <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String56") %></th>
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

                <asp:SqlDataSource ID="TuttiGuastiSource" runat="server" ProviderName="System.Data.SqlClient">
                </asp:SqlDataSource>

              <div class="LastUpdateScreen">
                <asp:Label ID="LastUpdateLabel" runat="server"></asp:Label>
                   </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="AutoRefresh" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</asp:Content>

