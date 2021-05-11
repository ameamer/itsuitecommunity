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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="inserisci_pc_home.aspx.vb" Inherits="gestione_pc_inserisci_pc_home" %>

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
    <%= globals.ResourceHelper.GetString("String402") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
   <%= globals.ResourceHelper.GetString("String162") %>: <b><%=Session("username")%></b>. <%= globals.ResourceHelper.GetString("String163") %>

                  <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalform.submit();">
                      <img src="../img/logo_conferma-salva.png" alt='<%= globals.ResourceHelper.GetString("String146") %>' style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
                  </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <div class="cntr-msg" id="cntr-msg">
        <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

        </asp:Label>
    </div>

    <form name="generalform" method="post" action="pc_inserito.aspx">

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String164") %> <i style="color: gray">(.../...)</i>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="cartella_pc" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String120") %>: 
            </div>
            <div class="section-data-pc">
                <select name="marca_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Marche.OpenSelectorMarchePCConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String122") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="modello_pc" value="" />
            </div>
        </div>


        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String322") %>:
            </div>
            <div class="section-data-pc">
                <select name="dominio_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Rete.OpenSelectorDominiConnection() %>
                </select>
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String366") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="nome_pc" value="" />
            </div>
        </div>


        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String131") %>: 
            </div>
            <div class="section-data-pc">
                <select name="anno_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="Sconosciuto"><%= globals.ResourceHelper.GetString("String165") %></option>
                    <% ITSuite_Listing.Anni.OpenSelectorAnni() %>
                </select>

            </div>
        </div>


        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
               <%= globals.ResourceHelper.GetString("String123") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="serie_pc" value="" />
            </div>
        </div>


        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String124") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="inventario_pc" value="" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String351") %>: 
            </div>
            <div class="section-data-pc">
                <select name="so_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.PC.OpenSelectorOSConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">


            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String128") %>: 
            </div>
            <div class="section-data-pc">
                <select name="stato_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Stati.OpenSelectorStatiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String377") %> (MB): 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ram_pc" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String344") %>: 
            </div>
            <div class="section-data-pc">
                <select name="processore_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.PC.OpenSelectorProcessoriConnection() %>
                </select>

            </div>
        </div>
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String130") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="indirizzo_ip_pc" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String378") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="stanza_pc" value="" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String379") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="piano_pc" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String125") %>: 
            </div>
            <div class="section-data-pc">
                <select name="reparto_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String126") %>: 
            </div>
            <div class="section-data-pc">
                <select name="padiglione_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String127") %>: 
            </div>
            <div class="section-data-pc">
                <select name="presidio_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String380") %>: 
            </div>
            <div class="section-data-pc">
                <select name="swprivate_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.PC.OpenSelectorOtherSWConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String51") %>: 
            </div>
            <div class="section-data-pc">
                <select name="tipo_pc" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.PC.OpenSelectorTipiPCConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%= globals.ResourceHelper.GetString("String132") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="note_pc" value="" />
            </div>
        </div>

        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; background-color: #dddddd;">
            <div class="section-data-pc" style="font-size: 18px;">
                <u><%= globals.ResourceHelper.GetString("String371") %></u>
            </div>

            <% 
            %>
            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String120") %>: 
                </div>
                <div class="section-data-pc">
                    <select name="marca_video_pc" class="selector-modifica-elementi">
                        <option value="" style="color: black"></option>
                        <% ITSuite_Listing.Marche.OpenSelectorMarcheMonitorConnection() %>
                    </select>

                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String122") %>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="modello_video_pc" value="" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String372") %>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="pollici_video_pc" value="" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                   <%= globals.ResourceHelper.GetString("String393") %>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="inventario_video_pc" value="" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String394") %>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="serie_video_pc" value="" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String128") %>: 
                </div>
                <div class="section-data-pc">
                    <select name="stato_video_pc" class="selector-modifica-elementi">
                        <option value="" style="color: black"></option>
                        <% ITSuite_Listing.Stati.OpenSelectorStatiMonitorConnection() %>
                    </select>

                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String131") %>: 
                </div>
                <div class="section-data-pc">
                    <select name="anno_video_pc" class="selector-modifica-elementi">
                        <option value="" style="color: black"></option>
                        <option value="Sconosciuto">Sconosciuto</option>

                        <% ITSuite_Listing.Anni.OpenSelectorAnni() %>
                    </select>

                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String132") %>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="note_video_pc" value="" />
                </div>
            </div>

        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; min-height: 0px;">
            <div class="section-data-pc" style="font-size: 18px;">
                <u><%= globals.ResourceHelper.GetString("String373") %></u>
            </div>

            <div class="details-entire-line-white">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String403") %>: 
                </div>
                <div class="section-data-pc">
                    <select name="id_stampante_collegata" class="selector-modifica-elementi">
                        <% ITSuite_Listing.Stampanti.OpenSelectorStampantiConnection(Nothing) %>
                    </select>

                </div>
            </div>

        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; background-color: #dddddd; min-height: 0px;">
            <div class="section-data-pc" style="font-size: 18px;">
                <u><%= globals.ResourceHelper.GetString("String375") %></u>
            </div>
            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%= globals.ResourceHelper.GetString("String404") %>: 
                </div>
                <div class="section-data-pc">
                    <select name="id_altrohw_collegato" class="selector-modifica-elementi">
                        <% ITSuite_Listing.AltroHW.OpenSelectorOtherHwConnection(Nothing) %>
                    </select>
                </div>
            </div>

        </div>
    </form>

    <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; min-height: 0px;">
        <div class="section-data-pc" style="font-size: 18px; width: 100%">
            <u><%= globals.ResourceHelper.GetString("String157") %></u>
        </div>
        <div class="details-entire-line-white" style="height: auto; overflow: auto;">
            <div id="photoDiv" class="section-data-pc" style="width: 100%;">
                <%= globals.ResourceHelper.GetString("String405") %>
            </div>
        </div>
</asp:Content>

