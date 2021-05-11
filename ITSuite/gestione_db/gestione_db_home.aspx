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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="gestione_db_home.aspx.vb" Inherits="gestione_db_gestione_db_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String40") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
   <%=globals.ResourceHelper.GetString("String183") %> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
        <div style=" padding-bottom: 5px;">
        <u><%=globals.ResourceHelper.GetString("String184") %>:</u> 
        <asp:Label ID="LabelType" runat="server" Font-Bold="true" ></asp:Label>
    </div>
            <div style=" padding-bottom: 5px;">
        <u><%=globals.ResourceHelper.GetString("String185") %>:</u> 
        <asp:Label ID="LabelSrvVersion" runat="server" Font-Bold="true" ></asp:Label>
    </div>
            <div style=" padding-bottom: 5px;">
        <u><%=globals.ResourceHelper.GetString("String186") %>:</u> 
        <asp:Label ID="LabelTabNumber" runat="server" Font-Bold="true" ></asp:Label>
    </div>

    <div style=" padding-bottom: 5px;">
        <u><%=globals.ResourceHelper.GetString("String39") %>:</u> 
        <asp:Label ID="LabelDbUse" runat="server" Font-Bold="true" ></asp:Label>
    </div>
     
    <div style=" padding-bottom: 5px; margin-top:20px;">
        <u>Auto-Test database:</u> 
        <asp:Label ID="LabelTest" runat="server" Font-Bold="true" ></asp:Label>
    </div>
</asp:Content>
