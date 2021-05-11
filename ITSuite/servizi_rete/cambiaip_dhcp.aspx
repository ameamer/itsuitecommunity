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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="cambiaip_dhcp.aspx.vb" Inherits="servizi_rete_cambiaip_dhcp" %>
<meta http-equiv="Refresh" content="3;url=cambiaip_home.aspx"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
    <%=globals.ResourceHelper.GetString("String503")%><br />
    <br />
    <%=globals.ResourceHelper.GetString("String504")%>: DHCP<br />
    <br />
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
            document.getElementById("generalmsg").innerHTML = "<br /><%=globals.ResourceHelper.GetString("String491")%>' + err.message;
        }
    }
</script>

    <% If (connessione = "") Then %>

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
        %> 
<body onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh interface ip set address name=\'<%=connessione%>\' source=dhcp gwmetric=0');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh interface ip set dns name=\'<%=connessione%>\' source=dhcp');">
    </body>
<%
    End If

    ' Se richiesto Wins
    If wins <> "" Then

%>
<body onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh interface ip set address name=\'<%=connessione%>\' source=dhcp gwmetric=0');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh interface ip set dns name=\'<%=connessione%>\' source=dhcp');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe netsh interface ip set wins \'<%=connessione%>\' static <%=wins%>');">
</body>
<%
    End If

    %>
