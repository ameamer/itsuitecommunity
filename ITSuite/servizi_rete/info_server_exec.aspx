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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="info_server_exec.aspx.vb" Inherits="servizi_rete_info_server_exec" %>
<meta http-equiv="Refresh" content="3;url=info_server_home.aspx?so=<%=so %>"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
    <%=globals.ResourceHelper.GetString("String551")%><br />
    <br />
    <%=globals.ResourceHelper.GetString("String501")%>: <%=ip_remoto %><br />
    <%=globals.ResourceHelper.GetString("String490")%>: <%=Session("soselezionatoserver")%><br />
    <br />
    <%=globals.ResourceHelper.GetString("String505")%><br />
    <%=globals.ResourceHelper.GetString("String552")%><br />

</div>

<script type="text/javascript">
    function CallPgm1(cmd) {
        try {
            var shell = new ActiveXObject("WScript.shell");
            shell.run(cmd, 1, true);
        }
        catch (err) {
            document.getElementById("generalmsg").innerHTML = "<br />" + <%=globals.ResourceHelper.GetString("String491")%> + err.message;
        }

    }
</script>

    <%
        If (utente = "") Or (password = "") Or (ip_remoto = "") Then
%>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
        Response.End()
    End If

    If Session("soselezionatoserver") = "Windows XP" Then %>
<body  onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit psexec \\\\<%=ip_remoto%> -u <%=utente%> -p <%=password%> tasklist /svc');">
    </body>
<% Else %>
<body style="overflow:hidden;*overflow:inherit;" onload="CallPgm1('%windir%/system32/cmdkey.exe /add:<%=ip_remoto%> /user:<%=utente%> /pass:<%=password%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit psexec \\\\<%=ip_remoto%> tasklist /svc');CallPgm1('%windir%/system32/cmdkey.exe /delete:<%=ip_remoto%>');">
    </body>
<% 
    End If
        %>
