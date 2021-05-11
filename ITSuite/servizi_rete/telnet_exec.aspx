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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="telnet_exec.aspx.vb" Inherits="servizi_rete_telnet_exec" %>
<meta http-equiv="Refresh" content="3;url=telnet_home.aspx"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
<%=globals.ResourceHelper.GetString("String573")%><br /><br />
<%=globals.ResourceHelper.GetString("String130")%>: <%=ip_telnet %><br />
<%=globals.ResourceHelper.GetString("String574")%>: <%=porta_telnet%><br /><br />
<%=globals.ResourceHelper.GetString("String575")%><br />

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
        If (ip_telnet = "") Or (porta_telnet = "") Then
%>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
        Response.End()
    End If
   %>

<body  onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit telnet <%=ip_telnet%><%=" "%><%=porta_telnet%>');">
    </body>


