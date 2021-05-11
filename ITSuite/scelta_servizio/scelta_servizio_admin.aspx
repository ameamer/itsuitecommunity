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

<%@ Page Title="Dashboard | ITSuite by Ame Amer (admin@ameamer.com)" Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="scelta_servizio_admin.aspx.vb" Inherits="scelta_servizio_scelta_servizio_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
   <asp:Label runat="server" ID="PageTitleTxt" Text='<%# globals.ResourceHelper.GetString("String10") %>'></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <asp:Label runat="server" ID="PageSubtitleTxt" Text='<%# globals.ResourceHelper.GetString("String11") %>'></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">

    <form runat="server">

        <%  If Session("Autenticato") = "admin" Then %>

        <div class="title-container-listpage-first" style="border-bottom: 0px solid black; margin-bottom: 15px;">
            <div style="display: inline-block; border: 0px solid black; vertical-align: middle">
                <img src="../img/hw_status.png" style="vertical-align: middle" /></div>
            <div style="display: inline-block; border: 0px solid black; margin-left: 2px; margin-bottom: 0px; vertical-align: middle">
                <asp:Label runat="server" ID="HWStatusTxt" Text='<%# globals.ResourceHelper.GetString("String12") %>'></asp:Label></div>
        </div>
        <div class="table-container-dash">

            <div class="table-container-dash-sub">
                <div class="dshboardsubitems">

                    <asp:Label runat="server" ID="LabelNPC" Text='<%# globals.ResourceHelper.GetString("String1") & ": "%>'></asp:Label><a href="../gestione_pc/listapc.aspx"><asp:Label runat="server" ID="LabelNPCNumber" Font-Bold="true"></asp:Label></a>
                </div>
                <div class="dshboardsubitems">
                    <asp:Label runat="server" ID="LabelNMon" Text='<%# globals.ResourceHelper.GetString("String2") & ": "%>'></asp:Label><a href="../gestione_pc/listamonitor.aspx"><asp:Label runat="server" ID="LabelNMonNumber" Font-Bold="true"></asp:Label></a>
                </div>
                <div class="dshboardsubitems">
                    <asp:Label runat="server" ID="LabelNStamp" Text='<%# globals.ResourceHelper.GetString("String3") & ": "%>'></asp:Label><a href="../gestione_stampanti/gestione_stampanti_lista.aspx"><asp:Label runat="server" ID="LabelNStampNumber" Font-Bold="true"></asp:Label></a>
                </div>
                <div class="dshboardsubitems">
                    <asp:Label runat="server" ID="LabelNHW" Text='<%# globals.ResourceHelper.GetString("String4") & ": "%>'></asp:Label><a href="../gestione_altro_hardware/gestione_altrohw_lista.aspx"><asp:Label runat="server" ID="LabelNHWNumber" Font-Bold="true"></asp:Label></a>
                </div>
                <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String13")%>' CssClass="button-nets" Style="margin-top: 25px; background-color: #cadfff; width: 230px;" ID="AddNewPC" OnClick="AddNewPC_Click" />
                <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String14")%>' CssClass="button-nets" Style="margin-top: 25px; background-color: #ffd6b8; width: 230px;" ID="AddNewStamp" OnClick="AddNewStamp_Click" />
                <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String15")%>' CssClass="button-nets" Style="margin-top: 25px; background-color: #fff5bf; width: 230px;" ID="AddNewHw" OnClick="AddNewHw_Click" />
            </div>

            <div class="logbut-dash">
                <a href="../gestione_pc/log.aspx" style="color: darkgray">
                    <asp:Label ID="ShowLogTxt" runat="server" Text='<%# globals.ResourceHelper.GetString("String16") %>'></asp:Label></a>
            </div>
        </div>

        </div>
     
            <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 0px solid lightgray; background-color: #dddddd">

                <div class="title-container-listpage-first" style="border-bottom: 0px solid black; margin-bottom: 15px;">
                    <div style="display: inline-block; border: 0px solid black; vertical-align: middle">
                        <img src="../img/tkt_status.png" style="vertical-align: middle" /></div>
                    <div style="display: inline-block; border: 0px solid black; margin-left: 2px; margin-bottom: 0px; vertical-align: middle">
                        <asp:Label runat="server" ID="TktStatusTxt" Text='<%# globals.ResourceHelper.GetString("String18") %>'></asp:Label>
                    </div>
                </div>
                <div class="table-container-dash">
                    <% If Session("abilita_gestione_guasti") = "1" %>
                    <div class="table-container-dash-sub">
                        <div class="dshboardsubitems">
                            <asp:Label runat="server" ID="LabelGOpen" Text='<%# globals.ResourceHelper.GetString("String19") & ": " %>'></asp:Label><a href="../gestione_guasti/gestione_guasti_home.aspx"><asp:Label runat="server" ID="LabelGOpenN" Font-Bold="true" Text='<%# globals.ResourceHelper.GetString("String19") & ": " %>'></asp:Label></a>
                        </div>
                        <div class="dshboardsubitems">
                            <asp:Label runat="server" ID="LabelGWait" Text='<%# globals.ResourceHelper.GetString("String20") & ": "%>'></asp:Label><a href="../gestione_guasti/gestione_guasti_inattesa.aspx"><asp:Label runat="server" ID="LabelGWaitN" Font-Bold="true"></asp:Label></a>
                        </div>
                        <div class="dshboardsubitems">
                            <asp:Label runat="server" ID="LabelGClose" Text='<%# globals.ResourceHelper.GetString("String21") & ": "%>'></asp:Label><a href="../gestione_guasti/gestione_guasti_chiusi.aspx"><asp:Label runat="server" ID="LabelGCloseN" Font-Bold="true"></asp:Label></a>
                        </div>
                        <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String22") %>' CssClass="button-nets" Style="margin-top: 56px; background-color: #cadfff; width: 230px;" ID="AddNewTicket" OnClick="AddNewTicket_Click" />
                        <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String23") %>' CssClass="button-nets" Style="margin-top: 56px; background-color: white; width: 230px;" ID="ShowAllTicketsButton" OnClick="ShowAllTicketsButton_Click" />
                    </div>
                    <div class="logbut-dash">
                        <a href="../gestione_guasti/log.aspx" style="color: darkgray">
                            <asp:Label ID="ShowLogTktTxt" runat="server" Text='<%# globals.ResourceHelper.GetString("String16") %>'></asp:Label></a>
                    </div>
                    <% else %>
                    <div class="dshboardsubitems">
                        <b>
                            <asp:Label runat="server" ID="Txtdeactivatedtktsrv" Text='<%# globals.ResourceHelper.GetString("String24") %>'></asp:Label></b>
                        <asp:Label runat="server" ID="TxtGoTo" Text='<%# globals.ResourceHelper.GetString("String25") %>'></asp:Label>
                        <a href="../opzioni_generali/opzioni_generali_home.aspx">
                            <asp:Label runat="server" ID="LabelLinkOpzioni" Font-Bold="true" Text='<%# globals.ResourceHelper.GetString("String26") %>'></asp:Label></a>
                        <asp:Label runat="server" ID="TxtActivate" Text='<%# globals.ResourceHelper.GetString("String27") %>'></asp:Label>
                    </div>
                    <% End if %>
                </div>
            </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 0px solid lightgray; background-color: #ffffff">
            <div class="title-container-listpage-first" style="border-bottom: 0px solid black; margin-bottom: 15px;">
                <div style="display: inline-block; border: 0px solid black; vertical-align: middle">
                    <img src="../img/ass_status.png" style="vertical-align: middle" />
                </div>
                <div style="display: inline-block; border: 0px solid black; margin-left: 2px; margin-bottom: 0px; vertical-align: middle">
                    <asp:Label ID="AssProdTxt" runat="server" Text='<%# globals.ResourceHelper.GetString("String29") %>'></asp:Label>
                </div>
            </div>
            <div class="table-container-dash">
                <% If Session("abilita_assistenza_prodotti") = "1" %>
                <div class="table-container-dash-sub">
                    <div class="dshboardsubitems">
                        <asp:Label runat="server" ID="LabelAssOpen" Text='<%# globals.ResourceHelper.GetString("String30") & ": " %>'></asp:Label><a href="../assistenza_prodotti/assistenza_prodotti_home.aspx"><asp:Label runat="server" ID="LabelAssOpenN" Font-Bold="true"></asp:Label></a>
                    </div>
                    <div class="dshboardsubitems">
                        <asp:Label runat="server" ID="LabelAssClose" Text='<%# globals.ResourceHelper.GetString("String31") & ": " %>'></asp:Label><a href="../assistenza_prodotti/assistenza_prodotti_chiuse.aspx"><asp:Label runat="server" ID="LabelAssCloseN" Font-Bold="true"></asp:Label></a>
                    </div>
                    <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String32") %>' CssClass="button-nets" Style="margin-top: 87px; background-color: #cadfff; width: 230px;" ID="AddNewAss" OnClick="AddNewAss_Click" />
                    <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String33") %>' CssClass="button-nets" Style="margin-top: 56px; background-color: white; width: 230px;" ID="ShowAllAss" OnClick="ShowAllAss_Click" />
                </div>
                <div class="logbut-dash">
                    <a href="../assistenza_prodotti/log.aspx" style="color: darkgray">
                        <asp:Label ID="ShowAssLog" runat="server" Text='<%# globals.ResourceHelper.GetString("String16") %>'></asp:Label></a>
                </div>
                <% else %>
                <div class="dshboardsubitems">
                    <b>
                        <asp:Label runat="server" ID="TxtdeactivatedAss" Text='<%# globals.ResourceHelper.GetString("String34") %>'></asp:Label></b>
                    <asp:Label runat="server" ID="TxtGoToAss" Text='<%# globals.ResourceHelper.GetString("String25") %>'></asp:Label>
                    <a href="../opzioni_generali/opzioni_generali_home.aspx">
                        <asp:Label runat="server" ID="LabelLinkOpzioniAss" Font-Bold="true" Text='<%# globals.ResourceHelper.GetString("String26") %>'></asp:Label></a>
                    <asp:Label runat="server" ID="TxtActivateAss" Text='<%# globals.ResourceHelper.GetString("String27") %>'></asp:Label>
                </div>
                <% End if %>
            </div>
        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 0px solid lightgray; background-color: #dddddd">
            <div class="title-container-listpage-first" style="border-bottom: 0px solid black; margin-bottom: 15px;">
                <div style="display: inline-block; border: 0px solid black; vertical-align: middle">
                    <img src="../img/usr_status.png" style="vertical-align: middle" />
                </div>
                <div style="display: inline-block; border: 0px solid black; margin-left: 2px; margin-bottom: 0px; vertical-align: middle">
                    <asp:Label runat="server" ID="TxtUserStatus" Text='<%# globals.ResourceHelper.GetString("String35") %>'></asp:Label>
                </div>
            </div>
            <div class="table-container-dash">
                <div class="table-container-dash-sub">
                    <div class="dshboardsubitems">
                        <asp:Label runat="server" ID="LabelUtenti" Text='<%# globals.ResourceHelper.GetString("String36") & ": "%>'></asp:Label><a href="../gestione_utenti/gestione_utenti_home.aspx"><asp:Label runat="server" ID="LabelUtentiN" Font-Bold="true"></asp:Label></a>
                    </div>
                    <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String37") %>' CssClass="button-nets" Style="margin-top: 120px; background-color: #cadfff; width: 230px;" ID="AddNewUser" OnClick="AddNewUser_Click" />

                </div>
                <div class="logbut-dash">
                    <a href="../gestione_utenti/log.aspx" style="color: darkgray">
                        <asp:Label ID="TxtLogUsers" runat="server" Text='<%# globals.ResourceHelper.GetString("String16") %>'></asp:Label></a>
                </div>
            </div>
        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 0px solid lightgray; background-color: #ffffff">
            <div class="title-container-listpage-first" style="border-bottom: 0px solid black; margin-bottom: 15px;">
                <div style="display: inline-block; border: 0px solid black; vertical-align: middle">
                    <img src="../img/db_status.png" style="vertical-align: middle" />
                </div>
                <div style="display: inline-block; border: 0px solid black; margin-left: 2px; margin-bottom: 0px; vertical-align: middle">
                    <asp:Label runat="server" ID="TxtDbStatus" Text='<%# globals.ResourceHelper.GetString("String38")%>'></asp:Label>
                </div>
            </div>
            <div>
                <div class="dshboardsubitems">
                    <asp:Label runat="server" ID="LabelMediaDb" Text='<%# globals.ResourceHelper.GetString("String39") & ": " %>'></asp:Label><a href="../gestione_db/gestione_db_home.aspx"><asp:Label runat="server" ID="LabelMediaDbN" Font-Bold="true"></asp:Label></a>
                </div>
                <asp:Button runat="server" CssClass="button-nets" Text='<%# globals.ResourceHelper.GetString("String40") %>' Style="margin-top: 120px; background-color: #cadfff; width: 230px;" ID="GestDb" OnClick="GestDb_Click" />
            </div>
        </div>

        <% 
            End If

            If Session("Autenticato") = "personale" Then
        %>

        <div class="div-central" style="padding-left: 0px; padding-top: 0px; padding-right: 0px;">
            <div class="title-container-listpage-first" style="border: 0px solid black; margin-bottom: 15px;">
                <div style="display: inline-block; border: 0px solid black; vertical-align: middle">
                    <img src="../img/tkt_status.png" alt="Stato dei ticket" style="vertical-align: middle" />
                </div>
                <div style="display: inline-block; border: 0px solid black; margin-left: 2px; margin-bottom: 0px; vertical-align: middle">Stato dei ticket</div>
            </div>

            <% If Session("abilita_gestione_guasti") = "1" %>
            <div>
                <div class="dshboardsubitems">
                    <asp:Label runat="server" ID="LabelGOpenP" Text='<%# globals.ResourceHelper.GetString("String19") & ": " %>'></asp:Label><a href="../gestione_guasti/gestione_guasti_home.aspx"><asp:Label runat="server" ID="LabelGOpenNP" Font-Bold="true"></asp:Label></a>
                </div>
                <div class="dshboardsubitems">
                    <asp:Label runat="server" ID="LabelGWaitP" Text='<%# globals.ResourceHelper.GetString("String20") & ": " %>'></asp:Label><a href="../gestione_guasti/gestione_guasti_inattesa.aspx"><asp:Label runat="server" ID="LabelGWaitNP" Font-Bold="true"></asp:Label></a>
                </div>
                <div class="dshboardsubitems">
                    <asp:Label runat="server" ID="LabelGCloseP" Text='<%# globals.ResourceHelper.GetString("String21") & ": " %>'></asp:Label><a href="../gestione_guasti/gestione_guasti_chiusi.aspx"><asp:Label runat="server" ID="LabelGCloseNP" Font-Bold="true"></asp:Label></a>
                </div>

            </div>
            <% else %>
            <div class="dshboardsubitems">
                <b>
                    <asp:Label runat="server" ID="Label1" Text='<%# globals.ResourceHelper.GetString("String24") %>'></asp:Label></b>
                <asp:Label runat="server" ID="Label2" Text='<%# globals.ResourceHelper.GetString("String25") %>'></asp:Label>
                <a href="../opzioni_generali/opzioni_generali_home.aspx">
                    <asp:Label runat="server" ID="Label3" Font-Bold="true" Text='<%# globals.ResourceHelper.GetString("String26") %>'></asp:Label></a>
                <asp:Label runat="server" ID="Label4" Text='<%# globals.ResourceHelper.GetString("String27") %>'></asp:Label>
            </div>
            <% End If %>
        </div>

        </div>

        <% End if %>

        <div class="div-central" style="min-height: 0px; height: 0px;">
    </form>

</asp:Content>