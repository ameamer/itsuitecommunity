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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="servizi_rete_home.aspx.vb" Inherits="servizi_rete_servizi_rete_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script type="text/javascript">
          function toggle_visibility(id, button) {
           var e = document.getElementById(id);
           if (e.style.display == 'block') {
               e.style.display = 'none';
               button.style.opacity = '0.6';
               button.removeAttribute('style');
           }

           else {
               e.style.display = 'block';
               button.style.opacity = '1.0';
           }
          }

       function CallPgm1(cmd) {
           try {
               var shell = new ActiveXObject("WScript.shell");
               shell.run(cmd, 1, true);
           }
           catch (err) {
               alert("<%=globals.ResourceHelper.GetString("String554")%>")
           }
       }

     //  Attiva Win firewall
       function activateWinFw(os) {
           if (os == "xp") {
               var r = confirm("<%=globals.ResourceHelper.GetString("String576")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh firewall set opmode enable');
               }
           } else {
               var r = confirm("<%=globals.ResourceHelper.GetString("String577")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh advfirewall set publicprofile state on'); CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh advfirewall set privateprofile state on'); CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh advfirewall set domainprofile state on');
               }
           }

       }

       // Disattiva Win firewall
       function deactivateWinFw(os) {
           if (os == "xp") {
               var r = confirm("<%=globals.ResourceHelper.GetString("String578")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh firewall set opmode disable');
               }
           } else {
               var r = confirm("<%=globals.ResourceHelper.GetString("String579")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh advfirewall set publicprofile state off'); CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh advfirewall set privateprofile state off'); CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh advfirewall set domainprofile state off');
               }
           }

       }

     
       // resetta Win firewall
       function resetWinFw(os) {
           if (os == "xp") {
               var r = confirm("<%=globals.ResourceHelper.GetString("String580")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe Rundll32 setupapi,InstallHinfSection Ndi-Steelhead 132 %windir%/inf/netrass.inf'); CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh firewall reset');;
               }
           } else {
               var r = confirm("<%=globals.ResourceHelper.GetString("String581")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe Rundll32.exe setupapi,InstallHinfSection Ndi-Steelhead 132 %windir%/inf/netrass.inf'); CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh advfirewall reset');
               }
           }

       }
  
       // disattiva servizio windows firewall
       function deactivateService(os) {
           if (os == "xp") {
               var r = confirm("<%=globals.ResourceHelper.GetString("String582")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe net stop sharedaccess');
               }
           } else {
               var r = confirm("<%=globals.ResourceHelper.GetString("String583")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe net stop mpssvc');
               }
           }

       }

     // attiva servizio windows firewall
       function activateService(os) {
           if (os == "xp") {
               var r = confirm("<%=globals.ResourceHelper.GetString("String584")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe net start sharedaccess');
               }
           } else {
               var r = confirm("<%=globals.ResourceHelper.GetString("String585")%>");
               if (r == true) {
                   CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe net start mpssvc');
               }
           }

       }
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String92")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String556")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">

    <div class="listservice-container" onclick="toggle_visibility('subitem-listnetservice-container', this);">
        <img src="../img/world_icon_80x80.png" alt='<%=globals.ResourceHelper.GetString("String559")%>' title='<%=globals.ResourceHelper.GetString("String559")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String559")%>'><%=globals.ResourceHelper.GetString("String559")%></a>

    </div>

    <div style="border-bottom: 1px solid gray; margin-bottom: 20px; display: none;" id="subitem-listnetservice-container">
        <div class="listservice-items-title">
            <%=globals.ResourceHelper.GetString("String557")%>
        </div>

        <div class="subitem-listservice-container">
            <div class="subitemtext-listservice-container" onclick="toggle_visibility('subsubitemvista-listnetservice-container', this);">
                <%=globals.ResourceHelper.GetString("String532")%>
            </div>
        </div>

        <div class="subsubitemvista-listnetservice-container" id="subsubitemvista-listnetservice-container">
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/intest_ip_server.aspx?so=vista'">
                <%=globals.ResourceHelper.GetString("String534")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/intest_route_server.aspx?so=vista'">
                <%=globals.ResourceHelper.GetString("String523")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/winfirewall_server_home.aspx?so=vista'">
                <%=globals.ResourceHelper.GetString("String558")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/info_server_home.aspx?so=vista'">
                <%=globals.ResourceHelper.GetString("String553")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/conn_server_home.aspx?so=vista'">
                <%=globals.ResourceHelper.GetString("String526")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/arresta_server_home.aspx?so=vista'">
                <%=globals.ResourceHelper.GetString("String494")%>
            </div>
        </div>

        <div class="subitem-listservice-container">
            <div class="subitemtext-listservice-container" onclick="toggle_visibility('subsubitemxp-listnetservice-container', this);">
                <%=globals.ResourceHelper.GetString("String533")%>
            </div>
        </div>

        <div class="subsubitemvista-listnetservice-container" id="subsubitemxp-listnetservice-container">
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/intest_ip_server.aspx?so=xp'">
                <%=globals.ResourceHelper.GetString("String534")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/intest_route_server.aspx?so=xp'">
                <%=globals.ResourceHelper.GetString("String523")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/winfirewall_server_home.aspx?so=xp'">
                <%=globals.ResourceHelper.GetString("String558")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/info_server_home.aspx?so=xp'">
                <%=globals.ResourceHelper.GetString("String553")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/conn_server_home.aspx?so=xp'">
                <%=globals.ResourceHelper.GetString("String526")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="location.href='../servizi_rete/arresta_server_home.aspx?so=xp'">
                <%=globals.ResourceHelper.GetString("String494")%>
            </div>
        </div>

    </div>

    <div class="listservice-container" onclick="toggle_visibility('subitem-listfwservice-container', this);">
        <img src="../img/msfw_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String560")%>' title='<%=globals.ResourceHelper.GetString("String560")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String560")%>'><%=globals.ResourceHelper.GetString("String560")%></a>
    </div>

    <div style="border-bottom: 1px solid gray; margin-bottom: 20px; display: none;" id="subitem-listfwservice-container">
        <div class="listservice-items-title">
            <%=globals.ResourceHelper.GetString("String561")%>
        </div>

        <div class="subitem-listservice-container">
            <div class="subitemtext-listservice-container" onclick="toggle_visibility('subsubitemvista-listfwservice-container', this);">
                <%=globals.ResourceHelper.GetString("String532")%>
            </div>
        </div>

        <div class="subsubitemvista-listnetservice-container" id="subsubitemvista-listfwservice-container">
            <div class="subsubitem-listservice-container" onclick="activateWinFw('vista');">
                <%=globals.ResourceHelper.GetString("String562")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="deactivateWinFw('vista');">
                <%=globals.ResourceHelper.GetString("String563")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="resetWinFw('vista');">
                <%=globals.ResourceHelper.GetString("String564")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="deactivateService('vista');">
                <%=globals.ResourceHelper.GetString("String565")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="activateService('vista');">
                <%=globals.ResourceHelper.GetString("String566")%>
            </div>
        </div>

        <div class="subitem-listservice-container">
            <div class="subitemtext-listservice-container" onclick="toggle_visibility('subsubitemxp-listfwservice-container', this);">
                <%=globals.ResourceHelper.GetString("String533")%>
            </div>
        </div>
        <div class="subsubitemvista-listnetservice-container" id="subsubitemxp-listfwservice-container">
            <div class="subsubitem-listservice-container" onclick="activateWinFw('vista');">
                <%=globals.ResourceHelper.GetString("String562")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="deactivateWinFw('vista');">
                <%=globals.ResourceHelper.GetString("String563")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="resetWinFw('vista');">
                <%=globals.ResourceHelper.GetString("String564")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="deactivateService('vista');">
                <%=globals.ResourceHelper.GetString("String565")%>
            </div>
            <div class="subsubitem-listservice-container" onclick="activateService('vista');">
                <%=globals.ResourceHelper.GetString("String566")%>
            </div>
        </div>
    </div>

    <div class="listservice-container" onclick="location.href='../servizi_rete/cambiaip_home.aspx'">
        <img src="../img/ip_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String567")%>' title='<%=globals.ResourceHelper.GetString("String567")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String567")%>'><%=globals.ResourceHelper.GetString("String567")%></a>
    </div>

    <div class="listservice-container" onclick="toggle_visibility('subitem-listpingfromserver-container', this);">
        <img src="../img/ping_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String536")%>' title='<%=globals.ResourceHelper.GetString("String536")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String536")%>'><%=globals.ResourceHelper.GetString("String536")%></a>
    </div>
    <div style="border-bottom: 1px solid gray; margin-bottom: 20px; display: none;" id="subitem-listpingfromserver-container">
        <div class="listservice-items-title">
            <%=globals.ResourceHelper.GetString("String568")%>
        </div>

        <div class="subitem-listservice-container">
            <div class="subitemtext-listservice-container">
                <input type="text" class="input-list-text-service-std" id="iptopingserver" />&nbsp;<input type="button" class="input-list-btn-service-std" value="Ping" onclick="location.href = '../servizi_rete/corpo_ping_server.aspx?ip=' + document.getElementById('iptopingserver').value;" />
            </div>
        </div>
    </div>

    <div class="listservice-container" onclick="toggle_visibility('subitem-listtracertfromserver-container', this);">
        <img src="../img/tracert_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String543")%>' title='<%=globals.ResourceHelper.GetString("String543")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String543")%>'><%=globals.ResourceHelper.GetString("String543")%></a>
    </div>
    <div style="border-bottom: 1px solid gray; margin-bottom: 20px; display: none;" id="subitem-listtracertfromserver-container">
        <div class="listservice-items-title">
            <%=globals.ResourceHelper.GetString("String569")%>
        </div>

        <div class="subitem-listservice-container">
            <div class="subitemtext-listservice-container">
                <input type="text" class="input-list-text-service-std" id="iptotracertserver" />&nbsp;<input type="button" class="input-list-btn-service-std" value="Tracert" onclick="location.href = '../servizi_rete/corpo_tracert_server.aspx?ip=' + document.getElementById('iptotracertserver').value;" />
            </div>
        </div>
    </div>

    <div class="listservice-container" onclick="location.href='../servizi_rete/cambiarotte.aspx'">
        <img src="../img/route_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String570")%>' title='<%=globals.ResourceHelper.GetString("String570")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String570")%>'><%=globals.ResourceHelper.GetString("String570")%></a>
    </div>

    <div class="listservice-container" onclick="location.href='../servizi_rete/telnet_home.aspx'">
        <img src="../img/telnet_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String571")%>' title='<%=globals.ResourceHelper.GetString("String571")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String571")%>'><%=globals.ResourceHelper.GetString("String571")%></a>
    </div>

    <div class="listservice-container" onclick="CallPgm1('notepad.exe %windir%/system32/drivers/etc/hosts')">
        <img src="../img/hosts_icon_50x50.png" alt='<%=globals.ResourceHelper.GetString("String572")%>' title='<%=globals.ResourceHelper.GetString("String572")%>' style="vertical-align: middle;" />
        <a href="#" class="a-listprincipal" title='<%=globals.ResourceHelper.GetString("String572")%>'><%=globals.ResourceHelper.GetString("String572")%></a>
    </div>

</asp:Content>

