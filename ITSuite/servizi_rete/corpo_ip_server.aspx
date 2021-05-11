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

<%@ Page Language="VB" AspCompat="true"  AutoEventWireup="false" CodeFile="corpo_ip_server.aspx.vb" Inherits="servizi_rete_corpo_ip_server" %>
<meta http-equiv="Refresh" content="3;url=intest_ip_server.aspx?so=<%=so %>"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
<%=globals.ResourceHelper.GetString("String535")%><br /><br />
<%=globals.ResourceHelper.GetString("String501")%>: <%=ind %><br />
<%=globals.ResourceHelper.GetString("String490")%>: <%=Session("soselezionatoserver")%><br /><br />
<%=globals.ResourceHelper.GetString("String505")%><br />
<%=globals.ResourceHelper.GetString("String506")%><br />
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

    <%
        ' Controllo se lo voglio in dhcp
        If (dhcp = "on") Then
            Response.Redirect("corpo_ip_dhcp.aspx?wins=" & wins & "&connessione=" & connessione & "&hostpc=" & hostpc & "&utente=" & utente & "&pass=" & password & "&so=" & so)
            Response.End()
        End If

        If (hostpc = "") Or (ind = "") Or (gwy = "") Or (submask = "") Or (dns1 = "") Or (dns2 = "") Or (connessione = "") Or (utente = "") Or (password = "") Then
%>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
        Response.End()
    End If

    ' Se non richiesto Wins
    If wins = "" Then
        If Session("soselezionatoserver") = "Windows XP" Then %>
<body  onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set dns name=\'<%=connessione%>\' static <%=dns1%> Primary');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip add dns name=\'<%=connessione%>\' addr=<%=dns2%> index=2');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set address name=\'<%=connessione%>\' source=static addr=<%=ind%> mask=<%=submask%> gateway=<%=gwy%> gwmetric=0');">
    </body>
<% Else %>
<body style="overflow:hidden;*overflow:inherit;" onload="CallPgm1('%windir%/system32/cmdkey /add:<%=hostpc%> /user:<%=utente%> /pass:<%=password%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> netsh interface ip set dns name=\'<%=connessione%>\' static <%=dns1%> Primary');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> netsh interface ip add dns name=\'<%=connessione%>\' addr=<%=dns2%> index=2');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -d netsh interface ip set address name=\'<%=connessione%>\' source=static addr=<%=ind%> mask=<%=submask%> gateway=<%=gwy%> gwmetric=0');CallPgm1('%windir%/system32/cmdkey.exe /delete:<%=hostpc%>');">
    </body>
<% 
        End If
    End If

    ' Se richiesto Wins
    If wins <> "" Then
        If Session("soselezionatoserver") = "Windows XP" Then
%>
<body onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set dns name=\'<%=connessione%>\' static <%=dns1%> Primary');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip add dns name=\'<%=connessione%>\' addr=<%=dns2%> index=2');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set wins \'<%=connessione%>\' static <%=wins%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> -u <%=utente%> -p <%=password%> netsh interface ip set address name=\'<%=connessione%>\' source=static addr=<%=ind%> mask=<%=submask%> gateway=<%=gwy%> gwmetric=0');">
</body>
<%              Else %>

<body  style="overflow:hidden;*overflow:inherit;" onload="CallPgm1('%windir%/system32/cmdkey.exe /add:<%=hostpc%> /user:<%=utente%> /pass:<%=password%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> netsh interface ip set dns name=\'<%=connessione%>\' static <%=dns1%> Primary');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> netsh interface ip add dns name=\'<%=connessione%>\' addr=<%=dns2%> index=2');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> netsh interface ip set wins \'<%=connessione%>\' static <%=wins%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=hostpc%> netsh interface ip set address name=\'<%=connessione%>\' source=static addr=<%=ind%> mask=<%=submask%> gateway=<%=gwy%> gwmetric=0');CallPgm1('%windir%/system32/cmdkey.exe /delete:<%=hostpc%>');">
</body>
<%              End If
            End If

    %>
