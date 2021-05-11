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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="inserisci_hw_home.aspx.vb" Inherits="gestione_altro_hardware_inserisci_hw_home" %>

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
    <%= globals.ResourceHelper.GetString("String15") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
     <%= globals.ResourceHelper.GetString("String162") %> <b><%=Session("username")%></b>. <%= globals.ResourceHelper.GetString("String163") %> 

                  <div class="settings-button-right-title" title="<%= globals.ResourceHelper.GetString("String28") %> " onclick="document.generalform.submit();">
                      <img src="../img/logo_conferma-salva.png" alt="<%= globals.ResourceHelper.GetString("String28") %> " style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
                  </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <div class="cntr-msg" id="cntr-msg">
        <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

        </asp:Label>

    </div>
    <form name="generalform" action="salva_hw.aspx">

        <!-- Driver -->
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String164") %> <i style="color: gray">(.../...)</i>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="cartella_hw" value="" />
            </div>
        </div>

        <!-- Tipo hw -->
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String51") %>
            </div>
            <div class="section-data-pc">
                <select name="tipo_hardware" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.AltroHW.OpenSelectorTipiHW() %>
                </select>

            </div>
        </div>

        <!-- Marca -->
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String120") %> 
            </div>
            <div class="section-data-pc">
                <select name="marca_hardware" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Marche.OpenSelectorMarcheHwConnection() %>
                </select>

            </div>
        </div>

        <!-- Modello -->
        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
               <%= globals.ResourceHelper.GetString("String122") %>
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="modello_hardware" value="" />
            </div>
        </div>

        <!-- S/N -->
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String123") %>
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="serie_hardware" value="" />
            </div>
        </div>

        <!-- Numero inventario -->
        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String124") %>
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="inventario_hardware" value="" />
            </div>
        </div>

        <!-- Anno -->
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String131") %> 
            </div>
            <div class="section-data-pc">
                <select name="anno_hardware" class="selector-modifica-elementi-obbligatori">
                            <option value="Sconosciuto"><%= globals.ResourceHelper.GetString("String165") %> </option>
                            <% ITSuite_Listing.Anni.OpenSelectorAnni() %>
                </select>
            </div>
        </div>

        <!-- Indirizzo IP -->
        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String130") %> 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="ip_hardware" value="" />
            </div>
        </div>

         <!-- Stato -->
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String128") %> 
            </div>
            <div class="section-data-pc">

                <select name="stato_hardware" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Stati.OpenSelectorStatiConnection() %>
                </select>
            </div>
        </div>
        
        <!-- Reparto -->
        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String125") %> 
            </div>
            <div class="section-data-pc">

                <select name="reparto_hw" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
                </select>
            </div>
        </div>
        
        <!-- Padiglione -->
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String126") %> 
            </div>
            <div class="section-data-pc">

                <select name="padiglione_hw" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
                </select>
            </div>
        </div>

        <!-- Presidio -->
        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String127") %> 
            </div>
            <div class="section-data-pc">

                <select name="presidio_hw" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
                </select>
            </div>
        </div>
 
        <!-- Note -->
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
               <%= globals.ResourceHelper.GetString("String132") %> 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="note_hardware" value="" />
            </div>
        </div>


    </form>
    </div>
        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; min-height: 0px;">
            <div class="section-data-pc" style="font-size: 18px; width: 100%">
                <u><%= globals.ResourceHelper.GetString("String157") %></u>
            </div>
            <div class="details-entire-line-white" style="height: auto; overflow: auto;">
                <%= globals.ResourceHelper.GetString("String166") %> 
            </div>
</asp:Content>

