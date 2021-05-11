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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="cambiaroute_server.aspx.vb" Inherits="servizi_rete_cambiaroute_server" %>

<meta http-equiv="Refresh" content="3;url=intest_route_server.aspx?so=<%=so %>"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
    <%=globals.ResourceHelper.GetString("String524")%>
    <br />
    <br />
    <%=globals.ResourceHelper.GetString("String501")%>: <%=ind %><br />
    <%=globals.ResourceHelper.GetString("String490")%>: <%=Session("soselezionatoserver")%><br />
    <%=globals.ResourceHelper.GetString("String525")%>: <%
                                                            If perm_route = "" Then
                                                                Response.Write("<font color='red'>" & globals.ResourceHelper.GetString("String144") & "</font>")
                                                            Else
                                                                Response.Write("<font color='green'>" & globals.ResourceHelper.GetString("String145") & "</font>")
                                                            End If
    %>
    <br />
    <br />
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
    If (ind = "") Or (gwy = "") Or (submask = "") Or (utente = "") Or (password = "") Or (ip_remoto = "") Then
%>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
        Response.end
    end If


    If Session("soselezionatoserver") = "Windows XP" Then %>
<body onload="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_remoto%> -u <%=utente%> -p <%=password%> route ADD <%=ind%> MASK <%=submask%> <%=gwy%>')">
    </body>
<% Else %>
<body style="overflow:hidden;*overflow:inherit;" onload="CallPgm1('%windir%/system32/cmdkey /add:<%=ip_remoto%> /user:<%=utente%> /pass:<%=password%>');CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe psexec \\\\<%=ip_remoto%> -u <%=utente%> -p <%=password%> route ADD <%=ind%> MASK <%=submask%> <%=gwy%>');CallPgm1('%windir%/system32/cmdkey /delete:<%=ip_remoto%>');">
    </body>
<% 
    End If
%>