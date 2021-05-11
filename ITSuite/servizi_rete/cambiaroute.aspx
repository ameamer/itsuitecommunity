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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="cambiaroute.aspx.vb" Inherits="servizi_rete_cambiaroute" %>
<meta http-equiv="Refresh" content="3;url=cambiarotte.aspx"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
<%=globals.ResourceHelper.GetString("String522")%><br /><br />
<%=globals.ResourceHelper.GetString("String518")%>: <%=ind %><br /><br />
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
    If (ind = "") Or (gwy = "") Or (submask = "") Then
%>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
        response.end
    end If

    ' Se non richiesta permanentemente
    If perm_route = "" Then
        %> 
<body onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe route ADD <%=ind%> MASK <%=submask%> <%=gwy%>');">
    </body>
<% Else %>
<body onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe route -p ADD <%=ind%> MASK <%=submask%> <%=gwy%>');">
    </body>
<% End If %>