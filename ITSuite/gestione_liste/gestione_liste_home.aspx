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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="gestione_liste_home.aspx.vb" Inherits="gestione_liste_gestione_liste_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <div class="HorizontalTopMenuContainer">
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home.aspx'" style="border-left: 1px solid lightgray;">
            <a href="../opzioni_generali/opzioni_generali_home.aspx" title="<%= globals.ResourceHelper.GetString("String26")%>"><%= globals.ResourceHelper.GetString("String26")%></a>
        </div>
           <div class="HorizontalTopMenuItemSelected" >
            <%= globals.ResourceHelper.GetString("String101") %>
        </div>
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home_swaz.aspx'">
            <a href="../opzioni_generali/opzioni_generali_home_swaz.aspx" title="<%= globals.ResourceHelper.GetString("String94")%>"><%= globals.ResourceHelper.GetString("String94") %></a>
        </div>
                          <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home_comp.aspx'">
            <a href="../opzioni_generali/opzioni_generali_home_comp.aspx" title="<%= globals.ResourceHelper.GetString("String103")%>"><%= globals.ResourceHelper.GetString("String103") %></a>
        </div>
    </div>
     </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
       <%= globals.ResourceHelper.GetString("String261") %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">

    <div class="title-container-listpage-first">
        <%= globals.ResourceHelper.GetString("String262") %>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_presidi.aspx'">
        <img src="../img/presidi_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_presidi.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String263") %>"><%= globals.ResourceHelper.GetString("String263") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/lista_padiglioni.aspx'">
        <img src="../img/padiglioni_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/lista_padiglioni.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String264") %>"><%= globals.ResourceHelper.GetString("String264") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_reparti.aspx'">
        <img src="../img/reparti_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_reparti.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String265") %>"><%= globals.ResourceHelper.GetString("String265") %></a>
    </div>

    <br />

    <div class="title-container-listpage-first">
        <%= globals.ResourceHelper.GetString("String266") %>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_processori.aspx'">
        <img src="../img/fsystem_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_processori.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String267") %>"><%= globals.ResourceHelper.GetString("String267") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_so.aspx'">
        <img src="../img/so_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_so.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String268") %>"><%= globals.ResourceHelper.GetString("String268") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_marchepc.aspx'">
        <img src="../img/sysconf_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_marchepc.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String269") %>"><%= globals.ResourceHelper.GetString("String269") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_tipipc.aspx'">
        <img src="../img/tipipc_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_tipipc.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String270") %>"><%= globals.ResourceHelper.GetString("String270") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_othersw.aspx'">
        <img src="../img/sw_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_othersw.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String271") %>"><%= globals.ResourceHelper.GetString("String271") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_marchemonitor.aspx'">
        <img src="../img/monitor_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_marchemonitor.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String272") %>"><%= globals.ResourceHelper.GetString("String272") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_statimonitor.aspx'">
        <img src="../img/statimonitor_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_statimonitor.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String273") %>"><%= globals.ResourceHelper.GetString("String273") %></a>
    </div>

    <br />

    <div class="title-container-listpage-first">
        <%= globals.ResourceHelper.GetString("String274") %>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_marchehw.aspx'">
        <img src="../img/marchehw_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_marchehw.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String275") %>"><%= globals.ResourceHelper.GetString("String275") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_tipihw.aspx'">
        <img src="../img/tipihw_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_tipihw.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String276") %>"><%= globals.ResourceHelper.GetString("String276") %></a>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_marchestampanti.aspx'">
        <img src="../img/stamp_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_marchestampanti.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String277") %>"><%= globals.ResourceHelper.GetString("String277") %></a>
    </div>

    <br />

    <div class="title-container-listpage-first">
        <%= globals.ResourceHelper.GetString("String278") %>
    </div>

    <div class="listservice-container" onclick="location.href='../gestione_liste/liste_domini.aspx'">
        <img src="../img/ip_icon_50x50.png" style="vertical-align: middle;" />
        <a href="../gestione_liste/liste_domini.aspx" class="a-listprincipal" title="<%= globals.ResourceHelper.GetString("String279") %>"><%= globals.ResourceHelper.GetString("String279") %></a>
    </div>

</asp:Content>

