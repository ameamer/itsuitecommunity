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

<%@ Page Language="VB" AspCompat="true" AutoEventWireup="false" CodeFile="conn_server_exec.aspx.vb" Inherits="servizi_rete_conn_server_exec" %>

<meta http-equiv="Refresh" content="3;url=conn_server_home.aspx?so=<%=so %>"/>

<head runat="server">
    <title id="ttl" runat="server"></title>
</head>

<div style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" id="generalmsg">
    <%=globals.ResourceHelper.GetString("String527")%><br />
    <br />
    <%=globals.ResourceHelper.GetString("String489")%>: <%=ip_remoto %><br />
    <%=globals.ResourceHelper.GetString("String528")%>: <%= appconntoshow%><br />
    <%=globals.ResourceHelper.GetString("String490")%>: <%=Session("soselezionatoserver")%><br />
    <br />
    <%=globals.ResourceHelper.GetString("String529")%> <%=appconntoshow %>...<br />

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
      If (utente = "") Or (password = "") Or (ip_remoto = "") Then
%>

<script type="text/javascript">
    alert('<%=globals.ResourceHelper.GetString("String492")%>');
    history.go(-1);
</script>

<% 
        Response.End()
    End If

    Select Case appconn
        Case "mstsc" ' desktop remoto
            %>
<body  onload="CallPgm1('mstsc -v <%=ip_remoto%>')">
    </body>
<%
    Case "dwrcc" ' dameware
            %>
<body  onload="CallPgm1('dwrcc.exe -c: -h: -m:<%=ip_remoto%> -u:<%=utente%> -p:<%=password%>')">
    </body>
<%
        End Select

        %>
