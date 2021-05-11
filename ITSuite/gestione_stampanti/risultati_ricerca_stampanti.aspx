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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="risultati_ricerca_stampanti.aspx.vb" Inherits="gestione_stampanti_risultati_ricerca_stampanti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String181")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String447")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">

        <form runat="server">
        <asp:Panel runat="server" ID="searchList" />
    </form>

    <table class="ricerca-pc-tab-footer">
        <tr>
            <td class="footer-search-container">
                <% If conteggio > 0 Then %>
                <form name="report_pc" action="report_stampanti.aspx" target="_blank">
                    <div class="pager-footer-button-container-report">
                        <input type="hidden" name="report" value="<%=id_report%>" />
                        <input class="pager-button" type="submit" value="<%=globals.ResourceHelper.GetString("String367")%>" />
                    </div>
                </form>
                <% end If %>
            </td>
         
        <td class="footer-search-container">
                <form>
                    <div class="counter-bottom-search">
                        <%=globals.ResourceHelper.GetString("String365")%> <%=conteggio%>
                    </div>
                </form>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        <% If (pagecount = 0) Then pagecount = 1 %>
        document.getElementById("sub-found-result").innerHTML = '<%=globals.ResourceHelper.GetString("String365")%>: <%=conteggio%>';
    </script>
</asp:Content>

