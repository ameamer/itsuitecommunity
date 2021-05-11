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

<%@ Page Title="Ricerca stampanti | ITSuite by Ame Amer (admin@ameamer.com)" Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="ricerca_stampante.aspx.vb" Inherits="gestione_stampanti_ricerca_stampante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String80") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String112") %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <!-- Ricerca veloce -->
    <div id="fastsearch_div" class="search_container">
        <div class="tab-active-title-search-left">
            <b><%=globals.ResourceHelper.GetString("String113") %></b>
        </div>

        <div class="tab-inactive-title-search-right" onclick="document.getElementById('fastsearch_div').style.display='none';document.getElementById('advsearch_div').style.display='block';document.getElementById('search_totale').value='';">
            <%=globals.ResourceHelper.GetString("String114") %>
        </div>

        <div style="border: 0px solid black; border-bottom: 1px solid black; width: 100%; height: 25px; padding: 5px; position: relative;">
            &nbsp;
        </div>

        <form name="cerca_stampante" method="post" style="border: 0px solid black;" action="risultati_ricerca_stampanti.aspx">

            <div class="body-search-div">
                <%=globals.ResourceHelper.GetString("String115") %>
                <br />
                <%=globals.ResourceHelper.GetString("String116") %>
   
           <div style="height: auto; width: 100%; min-width: 600px; border: 0px solid black; overflow: hidden; text-align: center;">

               <!-- Parte termini ricerca ricerca veloce -->
               <div class="fast-search-horiz-terms">
                   <input type="text" id="search_totale" name="ricgen_stampante" class="search_box_long" placeholder='<%=globals.ResourceHelper.GetString("String117") %>' />
               </div>

               <select name="ordina_per" class="select-order-searcher">
                   <% OrderByResults() %>
               </select>

               <input type="submit" value="Cerca" class="submit-button-search" />

           </div>
            </div>
        </form>
    </div>

    <!-- Ricerca avanzata -->
    <div id="advsearch_div" class="search_container" style="display: none">

        <div class="tab-inactive-title-search-left" onclick="document.getElementById('advsearch_div').style.display='none';document.getElementById('fastsearch_div').style.display='block'">
            <%=globals.ResourceHelper.GetString("String113") %>
        </div>

        <div class="tab-active-title-search-right">
            <b><%=globals.ResourceHelper.GetString("String114") %></b>
        </div>

        <div style="border: 0px solid black; border-bottom: 1px solid black; width: 100%; height: 25px; padding: 5px; position: relative;">
            &nbsp;
        </div>

        <div class="body-search-div">
            <%=globals.ResourceHelper.GetString("String114") %>
            <br />
            <%=globals.ResourceHelper.GetString("String445") %>
            <br />
            <br />

            <div class="table-adv-search-pc">

                <form name="ricerca_stampanti" method="post" action="risultati_ricerca_stampanti.aspx">

                    <!-- ID -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search" style="min-width: 50px; text-align: left;">
                            ID
                        </div>
                        <input name="id_stampante" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String448") %>' />
                    </div>


                    <!-- Marca -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String120") %>
                        </div>

                        <select name="marca_stampante" class="selector-text-adv-search">
                            <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String136")%></option>
                            <% ITSuite_Listing.Marche.OpenSelectorMarcheStampantiConnection() %>
                        </select>
                    </div>

                    <!-- Modello -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String122") %>
                        </div>
                        <input name="modello_stampante" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String385")%>' />
                    </div>

                    <!-- S/N -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String123")%>
                        </div>
                        <input name="serie_stampante" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String386")%>' />
                    </div>

                    <!-- Numero di inventario -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String124")%>
                        </div>
                        <input name="inventario_stampante" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String387")%>' />
                    </div>

                    <!-- Indirizzo IP -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String130")%>
                        </div>
                        <input name="ip_stampante" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String389")%>' />
                    </div>

                    <!-- Presidio -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String127")%>
                        </div>

                        <select name="presidio_stampante" class="selector-text-adv-search">
                            <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String136")%></option>
                            <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
                        </select>
                    </div>

                    <!-- Reparto -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String125")%>
                        </div>

                        <select name="reparto_stampante" class="selector-text-adv-search">
                            <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String136")%></option>
                            <% ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
                        </select>
                    </div>

                    <!-- Padiglione -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String126")%>
                        </div>

                        <select name="padiglione_stampante" class="selector-text-adv-search">
                            <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String136")%></option>
                            <% ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
                        </select>
                    </div>

                    <!-- Stato -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String128")%>
                        </div>

                        <select name="stato_stampante" class="selector-text-adv-search">
                            <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String136")%></option>
                            <% ITSuite_Listing.Stati.OpenSelectorStatiConnection() %>
                        </select>
                    </div>

                    <!-- Anno -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String131")%>
                        </div>

                        <select name="anno_stampante" class="selector-text-adv-search">
                            <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String136")%></option>
                            <option value="Sconosciuto"><%=globals.ResourceHelper.GetString("String165")%></option>
                          <% ITSuite_Listing.Anni.OpenSelectorAnni() %>
                        </select>
                    </div>

                    <!-- Autore inserimento-->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String129")%>
                        </div>
                        <input name="inserita_da" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String7")%>' />
                    </div>

                    <!-- Cartella driver -->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String164")%>
                        </div>
                        <input name="cartella_stampante" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String446")%>'/>
                    </div>

                    <!-- Note-->
                    <div class="table-cell-adv-search">

                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String132")%>
                        </div>
                        <input name="note_stampante" type="text" class="input-text-adv-search-only" placeholder='<%=globals.ResourceHelper.GetString("String391")%>' />
                    </div>

                    <!-- Ordine risultati -->
                    <div class="table-cell-adv-search" style="background-color: lightgreen">
                        <div class="title-cell-adv-search">
                            <%=globals.ResourceHelper.GetString("String133")%>
                        </div>

                        <select name="ordina_per" class="selector-text-adv-search">
                            <% OrderByResults() %>
                        </select>
                    </div>

                    <!-- Tasto cerca -->
                    <div class="table-cell-adv-search" style="border: 0px solid black; background-color: transparent; width: 100%">
                        <input name="reset_button" type="reset" class="input-text-adv-search-only" style="height: 40px; width: 20%; font-size: 16px; background-color: darkgray; margin-top: 5px;" value='<%=globals.ResourceHelper.GetString("String135")%>' />
                        <input name="search_button" type="submit" class="input-text-adv-search-only" style="height: 40px; width:20%; font-size: 16px; background-color: #0066ff; margin-top: 0px; color: white;" value='<%=globals.ResourceHelper.GetString("String134")%>' />
                    </div>

                </form>
            </div>



        </div>
    </div>
</asp:Content>

