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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="servizi_windows_home.aspx.vb" Inherits="servizi_windows_servizi_windows_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
          function CallPgm1(cmd) {
              try {
                  var shell = new ActiveXObject("WScript.shell");
                  shell.run(cmd, 1, true);
              }
              catch (err) {
                  alert("<%=globals.ResourceHelper.GetString("String554")%>")
              }
         }
     </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String597")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String598")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/control');">
        <img src="../img/cpanel_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String599")%>' title='<%=globals.ResourceHelper.GetString("String599")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String599")%>'><%=globals.ResourceHelper.GetString("String600")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe start ms-settings:troubleshoot');">
        <img src="../img/fsystem_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String601")%>' title='<%=globals.ResourceHelper.GetString("String601")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String601")%>'><%=globals.ResourceHelper.GetString("String602")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/mstsc')">
        <img src="../img/remotedesk_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String603")%>' title='<%=globals.ResourceHelper.GetString("String603")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String603")%>'><%=globals.ResourceHelper.GetString("String604")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe start ms-settings:startupapps')">
        <img src="../img/sysconf_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String605")%>' title='<%=globals.ResourceHelper.GetString("String605")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String605")%>'><%=globals.ResourceHelper.GetString("String606")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit')">
        <img src="../img/cmd_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String607")%>' title='<%=globals.ResourceHelper.GetString("String607")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String607")%>'><%=globals.ResourceHelper.GetString("String608")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/shrpubw')">
        <img src="../img/sharefold_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String609")%>' title='<%=globals.ResourceHelper.GetString("String609")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String609")%>'><%=globals.ResourceHelper.GetString("String621")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/perfmon')">
        <img src="../img/monitorprest_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String610")%>' title='<%=globals.ResourceHelper.GetString("String610")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String610")%>'><%=globals.ResourceHelper.GetString("String610")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/regedt32')">
        <img src="../img/reg_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String611")%>' title='<%=globals.ResourceHelper.GetString("String611")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String611")%>'><%=globals.ResourceHelper.GetString("String612")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe start ms-settings:recovery')">
        <img src="../img/restore_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String613")%>' title='<%=globals.ResourceHelper.GetString("String613")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String613")%>'><%=globals.ResourceHelper.GetString("String614")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/control international')">
        <img src="../img/settinginternational_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String615")%>' title='<%=globals.ResourceHelper.GetString("String615")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String615")%>'><%=globals.ResourceHelper.GetString("String616")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/taskmgr')">
        <img src="../img/task_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String617")%>' title='<%=globals.ResourceHelper.GetString("String617")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String617")%>'><%=globals.ResourceHelper.GetString("String618")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('%windir%/system32/shutdown /s /t 150')">
        <img src="../img/off_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String619")%>' title='<%=globals.ResourceHelper.GetString("String619")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String619")%>'><%=globals.ResourceHelper.GetString("String620")%></a>
    </div>

</asp:Content>

