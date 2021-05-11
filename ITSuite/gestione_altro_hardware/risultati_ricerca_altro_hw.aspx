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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="risultati_ricerca_altro_hw.aspx.vb" Inherits="gestione_altro_hardware_risultati_ricerca_altro_hw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String181") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
<%=globals.ResourceHelper.GetString("String182") %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
    
        <form runat="server">
        <asp:Panel runat="server" ID="searchList" />
    </form>
     <table class="ricerca-pc-tab-footer">
        <tr>
            <td class="footer-search-container">
          <% If conteggio > 0 Then %>
                <form name="report_pc" action="report_altro_hw.aspx" target="_blank">
                    <div class="pager-footer-button-container-report">
                        <input type="hidden" name="report" value="<%=id_report%>" />
                        <input class="pager-button" type="submit" value="Crea report" />
                    </div>
                </form>
                <% end If %>
            </td>
            <td class="footer-search-container">

                <% If (pag > 1) Then %>

                <form name="pagina_prec" method="post" action="risultati_ricerca_altro_hw.aspx?pag=<%=pag - 1%>">
                    <input type="hidden" name="inventario_hardware" value="<%=inventario_hardware%>" />
                    <input type="hidden" name="marca_hardware" value="<%=marca_hardware%>" />
                    <input type="hidden" name="modello_hardware" value="<%=modello_hardware%>" />
                    <input type="hidden" name="anno_hardware" value="<%=anno_hardware%>" />
                    <input type="hidden" name="id_hardware" value="<%=id_hardware%>" />
                    <input type="hidden" name="stato_hardware" value="<%=stato_hardware %> " />
                    <input type="hidden" name="serie_hardware" value="<%=serie_hardware%>" />
                    <input type="hidden" name="ordina_per" value="<%=ordina_per%>" />

                    <div class="pager-footer-button-container-prec">
                        <input class="pager-button" type="submit" value="<< Pagina precedente" />
                    </div>
                </form>

                <% End If %>

            </td>

            <td class="footer-search-container">

                <% If (pag < pagecount) Then %>
                <form name="pagina_succ" method="post" action="risultati_ricerca_altro_hw.aspx?pag=<%=pag + 1%>">
                    <input type="hidden" name="inventario_hardware" value="<%=inventario_hardware%>" />
                    <input type="hidden" name="marca_hardware" value="<%=marca_hardware%>" />
                    <input type="hidden" name="modello_hardware" value="<%=modello_hardware%>" />
                    <input type="hidden" name="anno_hardware" value="<%=anno_hardware%>" />
                    <input type="hidden" name="id_hardware" value="<%=id_hardware%>" />
                    <input type="hidden" name="stato_hardware" value="<%=stato_hardware%>" />
                    <input type="hidden" name="serie_hardware" value="<%=serie_hardware%>" />
                      <input type="hidden" name="ordina_per" value="<%=ordina_per%>" />

                    <div class="pager-footer-button-container-suc">
                        <input class="pager-button" type="button" onclick="document.pagina_succ.submit();" value="Pagina successiva >>" />
                    </div>
                </form>

                <% End If %>

            </td>

            <td class="footer-search-container">
                <form>
                    <div class="counter-bottom-search">
                        Elementi trovati: <%=conteggio%>
                    </div>
                </form>
            </td>
        </tr>
      </table>

    <script type="text/javascript">
        <% If (pagecount = 0) Then pagecount = 1 %>
        document.getElementById("sub-found-result").innerHTML = 'Elementi trovati: <%=conteggio & " | Pagina " & pag & " di " & pagecount%>';
    </script>
</asp:Content>

