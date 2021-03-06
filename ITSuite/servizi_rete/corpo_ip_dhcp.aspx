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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="corpo_ip_dhcp.aspx.vb" Inherits="servizi_rete_corpo_ip_dhcp" %>
<meta http-equiv="Refresh" content="3;url=intest_ip_server.aspx?so=<%=so %>"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
<%=globals.ResourceHelper.GetString("String535")%><br /><br />
<%=globals.ResourceHelper.GetString("String501")%>: DHCP<br />
<%=globals.ResourceHelper.GetString("String490")%>: <%=Session("soselezionatoserver")%><br /><br />
<%=globals.ResourceHelper.GetString("String505")%><br />
<%=globals.ResourceHelper.GetString("String506")%><br />
</div>

<script type="text/javascript">
    function CallPgm1(cmd) {
        try {
             var shell = new ActiveXObject("WScript.shell");
             shell.run(cmd,1,true);
        }
        catch (err) {
            document.getElementById("generalmsg").innerHTML = '<br /><%=globals.ResourceHelper.GetString("String491")%>' + err.message;
        }
}
</script>

 <%
         If (hostpc = "") Then
%>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
             Response.End()
         End If
        %>

<% 
    ' Se non richiesto Wins
    If wins = "" Then
        If Session("soselezionatoserver") = "Windows XP" Then %>
<body  onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set dns name=\'<%=connessione%>\' source=dhcp');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set address name=\'<%=connessione%>\' source=dhcp');">
    </body>
<% Else %>
<body style="overflow:hidden;*overflow:inherit;" onload="CallPgm1('%windir%/system32/cmdkey /add:<%=hostpc%> /user:<%=utente%> /pass:<%=password%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set dns name=\'<%=connessione%>\' source=dhcp');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set address name=\'<%=connessione%>\' source=dhcp');CallPgm1('%windir%/system32/cmdkey /delete:<%=hostpc%>');">
    </body>
<% 
        End If
    End If

    ' Se richiesto Wins
    If wins <> "" Then
        If Session("soselezionatoserver") = "Windows XP" Then
%>
<body onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set dns name=\'<%=connessione%>\' source=dhcp');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set wins \'<%=connessione%>\' static <%=wins%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set address name=\'<%=connessione%>\' source=dhcp');">
</body>
<%              Else %>

<body  style="overflow:hidden;*overflow:inherit;" onload="CallPgm1('%windir%/system32/cmdkey /add:<%=hostpc%> /user:<%=utente%> /pass:<%=password%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set dns name=\'<%=connessione%>\' source=dhcp');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set wins \'<%=connessione%>\' static <%=wins%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set address name=\'<%=connessione%>\' source=dhcp');CallPgm1('%windir%/system32/cmdkey /delete:<%=hostpc%>');">
</body>
<%              End If
            End If

    %>
