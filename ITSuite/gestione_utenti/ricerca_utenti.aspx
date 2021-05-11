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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="ricerca_utenti.aspx.vb" Inherits="gestione_utenti_ricerca_utenti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function HideLabel() {
            document.getElementById("cntr-msg").style.display = "block";
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("cntr-msg").style.display = "none";
            }, seconds * 1000);
        };

        function showTopMsg(msg) {
            document.getElementById('cntrmsg').style.display = 'block';
            window.setTimeout("hideTopMsg()", 3000);
        }

        function hideTopMsg() {
            document.getElementById('cntrmsg').style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String98")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String484")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <div class="cntr-msg" id="cntr-msg">
        <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">
        </asp:Label>
    </div>
    <asp:Label ID="ScriptLabel" runat="server" Text="" Visible="true"></asp:Label>

    <form name="SearchTicketForm" method="post" action="risultati_ricerca.aspx">
        <div class="contsearchscreen">
            <input name="schterm" type="text" class="search_box_long" placeholder='<%=globals.ResourceHelper.GetString("String117")%>' style="border: 1px solid black;" />
            <select name="typsearch" class="select-order-searcher">
                <option value="only"><%=globals.ResourceHelper.GetString("String485")%></option>
                <option value="free"><%=globals.ResourceHelper.GetString("String250")%></option>
            </select>
            <input type="submit" class="submit-button-search" value='<%=globals.ResourceHelper.GetString("String251")%>' />
        </div>
    </form>
</asp:Content>

