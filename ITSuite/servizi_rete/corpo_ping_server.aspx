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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="corpo_ping_server.aspx.vb" Inherits="servizi_rete_corpo_ping_server" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String536")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
     <asp:Label ID="SubLabel" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <%
                If queryip = "" Then
    %>
<%=globals.ResourceHelper.GetString("String537")%>
    <%
            Response.End()
        Else
    %>
    <asp:Label ID="Result" runat="server" Text='<%# globals.ResourceHelper.GetString("String538")%>'></asp:Label>
    <%  
                    StartServerPing()
                End If
    %>
</asp:Content>

