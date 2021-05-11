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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="winfirewall_server_exec.aspx.vb" Inherits="servizi_rete_winfirewall_server_exec" %>

<meta http-equiv="Refresh" content="3;url=arresta_server_home.aspx?so=<%=so %>"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
<%=globals.ResourceHelper.GetString("String586")%><br /><br />
<%=globals.ResourceHelper.GetString("String588")%>: <%=tipofwtoshow %>&nbsp;(<%=disattiva_wfw %>)<br />
<%=globals.ResourceHelper.GetString("String501")%>: <%=ip_wfw %><br />
<%=globals.ResourceHelper.GetString("String490")%>: <%=Session("soselezionatoserver")%><br /><br />
<%=globals.ResourceHelper.GetString("String589")%><br />

</div>

<script type="text/javascript">
    function CallPgm1(cmd) {
        try {
            var shell = new ActiveXObject("WScript.shell");
            shell.run(cmd, 1, true);
        }
        catch (err) {
            document.getElementById("generalmsg").innerHTML = '<br /><%=globals.ResourceHelper.GetString("String491")%>' + err.message;
        }
    }
</script>

    <% If (utente = "") Or (password = "") Or (ip_wfw = "") Then %>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
        Response.End()
    End If

    If Session("soselezionatoserver") = "Windows XP" Then %>
<body  onload="<% if disattiva_wfw="disattiva" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> -u <%=utente%> -p <%=password%> net stop sharedaccess');<% end if %><% if disattiva_wfw="disattiva_fw" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> -u <%=utente%> -p <%=password%> netsh firewall set opmode disable');<% End If %><% if disattiva_wfw="attiva" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> -u <%=utente%> -p <%=password%> net start sharedaccess');<% end if %><% if disattiva_wfw="attiva_fw" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> -u <%=utente%> -p <%=password%> netsh firewall set opmode enable');<% end If %><% if disattiva_wfw="reset_fw" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec -i \\\\<%=ip_wfw%> -u <%=utente%> -p <%=password%> Rundll32.exe setupapi,InstallHinfSection Ndi-Steelhead 132 %windir%/inf/netrass.inf');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec -i \\\\<%=ip_wfw%> -u <%=utente%> -p <%=password%> netsh firewall reset');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec -i \\\\<%=ip_wfw%> -u <%=utente%> -p <%=password%> net start sharedaccess');<% end if %>">
    </body>
<% Else %>
<body style="overflow:hidden;*overflow:inherit;" onload="CallPgm1('%windir%/system32/cmdkey /add:<%=ip_wfw%> /user:<%=utente%> /pass:<%=password%>');<% if disattiva_wfw="disattiva" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> net stop mpssvc');<% end if %><% if disattiva_wfw="disattiva_fw" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> netsh advfirewall set publicprofile state off');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> netsh advfirewall set privateprofile state off');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> netsh advfirewall set domainprofile state off');<% end if %><% if disattiva_wfw="attiva" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> net start mpssvc');<% end if %><% if disattiva_wfw="attiva_fw" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> netsh advfirewall set publicprofile state on');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> netsh advfirewall set privateprofile state on');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_wfw%> netsh advfirewall set domainprofile state on');<% end if %><% if disattiva_wfw="reset_fw" then %>CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec -i \\\\<%=ip_wfw%> Rundll32.exe setupapi,InstallHinfSection Ndi-Steelhead 132 %windir%/inf/netrass.inf');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec -i \\\\<%=ip_wfw%> netsh advfirewall reset');<% end if %>CallPgm1('%windir%/system32/cmdkey /delete:<%=ip_wfw%>')">
    </body>
<% End If %>
