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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="inserisci_stampante.aspx.vb" Inherits="gestione_stampanti_inserisci_stampante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function showTopMsg() {
            document.getElementById('cntrmsg').style.display = 'block';
            window.setTimeout("hideTopMsg()", 3000);
        }

        function hideTopMsg() {
            document.getElementById('cntrmsg').style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
   <%=globals.ResourceHelper.GetString("String437")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <%=globals.ResourceHelper.GetString("String162")%>: <b><%=actUser%></b>. I campi in rosso sono obbligatori.

                  <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalform.submit();">
                      <img src="../img/logo_conferma-salva.png" style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
                  </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <div class="cntr-msg" id="cntr-msg">
        <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true" />
    </div>

    <form name="generalform" action="stampante_inserita.aspx">
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String164")%> <i style="color: gray">(.../...)</i>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="cartella_stampante" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String120")%>: 
            </div>
            <div class="section-data-pc">
                <select name="marca_stampante" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Marche.OpenSelectorMarcheStampantiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String122")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="modello_stampante" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String123")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="numero_serie_stampante" value="" />
            </div>
        </div>


        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String124")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="inventario_stampante" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String131")%>: 
            </div>
            <div class="section-data-pc">
                <select name="anno_stampante" class="selector-modifica-elementi-obbligatori">
                    <option value="Sconosciuto"><%=globals.ResourceHelper.GetString("String165")%></option>
                    <% ITSuite_Listing.Anni.OpenSelectorAnni() %>
                </select>
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String130")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="ip_stampante" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String128")%>: 
            </div>
            <div class="section-data-pc">
                <select name="stato_stampante" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Stati.OpenSelectorStatiConnection() %>
                </select>
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String132")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="note_stampante" value="" />
            </div>
        </div>


        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String125")%>: 
            </div>
            <div class="section-data-pc">
                <select name="reparto_stampante" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String126")%>: 
            </div>
            <div class="section-data-pc">
                <select name="padiglione_stampante" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String127")%>: 
            </div>
            <div class="section-data-pc">

                <select name="presidio_stampante" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
                </select>
            </div>
        </div>

    </form>

</asp:Content>

