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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="modifica_pc.aspx.vb" Inherits="gestione_pc_modifica_pc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script type="text/javascript">
     function HideLabel() {
         document.getElementById("cntr-msg").style.display = "block";
         var seconds = 5;
         setTimeout(function () {
             document.getElementById("cntr-msg").style.display = "none";
         }, seconds * 1000);
     };

     function scrollToPhotoDiv() {
         document.getElementById('photoDiv').scrollIntoView();
     }

     function showTopMsg(msg) {
         document.getElementById('cntrmsg').style.display = 'block';
         window.setTimeout("hideTopMsg()", 3000);
     }

     function hideTopMsg() {
         document.getElementById('cntrmsg').style.display = 'none';
     }

     function CallPgm1(cmd) {
         var shell = new ActiveXObject("WScript.shell");
         shell.run(cmd, 1, true);
     };


     function get_estensione(path) {
         posizione_punto = path.lastIndexOf(".");
         lunghezza_stringa = path.length;
         estensione = path.substring(posizione_punto + 1, lunghezza_stringa);
         return estensione;
     };

     function controlla_estensione(path) {
         if (get_estensione(path) != "jpg") {
             alert("<%=globals.ResourceHelper.GetString("String473")%>"); document.invia_foto_stampante.reset(); return false;
         }
     };

     function Confirm() {
         document.getElementById('ContentPlaceHolderCentral_confirm_value').style.display = 'none';
         if (confirm("<%=globals.ResourceHelper.GetString("String472")%>")) {
             document.getElementById('ContentPlaceHolderCentral_confirm_value').value = "Yes";
             document.form1.submit();
         } else {
             document.getElementById('ContentPlaceHolderCentral_confirm_value').value = "No";
         }
     }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String414")%> (ID <%=id_pc%>)
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <%=globals.ResourceHelper.GetString("String162")%> : <b><%=username%></b>.
                      <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalform.submit();">
                          <img src="../img/logo_conferma-salva.png" alt="<%=globals.ResourceHelper.GetString("String28") %>" style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
                      </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">

    <div class="cntr-msg" id="cntr-msg">
        <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true" />
    </div>

    <form name="generalform" action="salva_dati_pc.aspx" method="post">
        <input type="hidden" name="id_pc" id="id_pc" value="<%=id_pc%>" />


        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String164")%>  <i style="color: gray">(.../...)</i>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="cartella_pc" value="<%=cartella %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String120")%> : 
            </div>
            <div class="section-data-pc">
                <select name="marca_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=marca_pc %>">(In uso) <%=marca_pc %></option>
                    <% ITSuite_Listing.Marche.OpenSelectorMarchePCConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String122")%> : 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="modello_pc" value="<%=modello_pc %>" />
            </div>
        </div>


        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String322")%> :
            </div>
            <div class="section-data-pc">

                <% If not String.IsNullOrEmpty(dominio_pc) Then %>

                <select name="dominio_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=dominio_pc%>" style="color: maroon">(In Uso) <%=dominio_pc%></option>
                    <% ITSuite_Listing.Rete.OpenSelectorDominiConnection() %>
                </select>

                <% Else %>

                <select name="dominio_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="" style="color: maroon"><%=globals.ResourceHelper.GetString("String415")%></option>
                    <option value="" style="color: red"><%=globals.ResourceHelper.GetString("String416")%></option>
                    <% ITSuite_Listing.Rete.OpenSelectorDominiConnection() %>
                </select>

                <% End If %>
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String366")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="nome_pc" value="<%=nome_pc %>" />
            </div>
        </div>


        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String131")%>: 
            </div>
            <div class="section-data-pc">
                <select name="anno_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=anno_pc %>"><%=globals.ResourceHelper.GetString("String173")%> <%=anno_pc %></option>
                    <option value="Sconosciuto"><%=globals.ResourceHelper.GetString("String165")%></option>
                    <% ITSuite_Listing.Anni.OpenSelectorAnni() %>
                </select>
            </div>
        </div>


        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String123")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="serie_pc" value="<%=serie_pc %>" />
            </div>
        </div>


        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String124")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="inventario_pc" value="<%=inv_pc %>" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String351")%>: 
            </div>
            <div class="section-data-pc">
                <select name="so_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=so_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=so_pc%></option>
                    <% ITSuite_Listing.PC.OpenSelectorOSConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">


            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String128")%>: 
            </div>
            <div class="section-data-pc">
                <select name="stato_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=stato_pc%>">(In Uso) <%=stato_pc%></option>
                    <% ITSuite_Listing.Stati.OpenSelectorStatiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String377")%> (MB): 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ram_pc" value="<%=ram_pc %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String344")%>: 
            </div>
            <div class="section-data-pc">
                <select name="processore_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=proc_pc%>">(In Uso) <%=proc_pc%></option>
                    <% ITSuite_Listing.PC.OpenSelectorProcessoriConnection() %>
                </select>

            </div>
        </div>
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String130")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="indirizzo_ip_pc" value="<%=ip_pc %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String378")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="stanza_pc" value="<%=stanza_pc %>" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String379")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="piano_pc" value="<%=piano_pc %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String125")%>: 
            </div>
            <div class="section-data-pc">
                <select name="reparto_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=reparto_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=reparto_pc %></option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String126")%>: 
            </div>
            <div class="section-data-pc">
                <select name="padiglione_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=pad_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=pad_pc%></option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String127")%>: 
            </div>
            <div class="section-data-pc">
                <select name="presidio_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=presidio_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=presidio_pc%></option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String380")%>: 
            </div>
            <div class="section-data-pc">
                <select name="swprivate_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=sw_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=sw_pc%></option>
                    <% ITSuite_Listing.PC.OpenSelectorOtherSWConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String51")%>: 
            </div>
            <div class="section-data-pc">
                <select name="tipo_pc" class="selector-modifica-elementi-obbligatori">
                    <option value="<%=tipo_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=tipo_pc%></option>
                    <% ITSuite_Listing.PC.OpenSelectorTipiPCConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String132")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="note_pc" value="<%=note_pc %>" />
            </div>
        </div>
        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; background-color: #dddddd;">
            <div class="section-data-pc" style="font-size: 18px;">
                <u><%=globals.ResourceHelper.GetString("String371")%></u>
            </div>

            <% 
            %>
            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String392")%>: 
                </div>
                <div class="section-data-pc">
                    <select name="marca_video_pc" class="selector-modifica-elementi">
                        <option value="<%=marca_video_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=marca_video_pc%></option>
                        <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String416")%></option>
                        <% ITSuite_Listing.Marche.OpenSelectorMarcheMonitorConnection() %>
                    </select>

                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String122")%>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="modello_video_pc" value="<%=mod_video_pc %>" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String372")%>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="pollici_video_pc" value="<%=pollici_video_pc %>" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String393")%>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="inventario_video_pc" value="<%=inv_video_pc %>" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String123")%>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="serie_video_pc" value="<%=serie_video_pc %>" />
                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String396")%>: 
                </div>
                <div class="section-data-pc">
                    <select name="stato_video_pc" class="selector-modifica-elementi">
                        <option value="<%=stato_video_pc%>"><%=globals.ResourceHelper.GetString("String173")%> <%=stato_video_pc %></option>
                        <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String416")%></option>
                        <% ITSuite_Listing.Stati.OpenSelectorStatiMonitorConnection() %>
                    </select>

                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String131")%>: 
                </div>
                <div class="section-data-pc">
                    <select name="anno_video_pc" class="selector-modifica-elementi">
                        <option value="<%=anno_video_pc %>"><%=globals.ResourceHelper.GetString("String173")%> <%=anno_video_pc %></option>
                        <option value="" class="selector-option-text-adv-search"><%=globals.ResourceHelper.GetString("String416")%></option>
                        <option value="Sconosciuto"><%=globals.ResourceHelper.GetString("String165")%></option>
                        <% ITSuite_Listing.Anni.OpenSelectorAnni() %>
                    </select>

                </div>
            </div>

            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String132")%>: 
                </div>
                <div class="section-data-pc">
                    <input type="text" class="input-modifica-elementi" name="note_video_pc" value="<%=note_video_pc %>" />
                </div>
            </div>

        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; min-height: 0px;">
            <div class="section-data-pc" style="font-size: 18px;">
                <u><%=globals.ResourceHelper.GetString("String373")%></u>
            </div>

            <div class="details-entire-line-white">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String403")%>: 
                </div>
                <div class="section-data-pc">
                    <select name="id_stampante_collegata" class="selector-modifica-elementi">
                        <% ITSuite_Listing.Stampanti.OpenSelectorStampantiConnection(id_stampante_collegata) %>
                    </select>

                </div>
            </div>

        </div>

        <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; background-color: #dddddd; min-height: 0px;">
            <div class="section-data-pc" style="font-size: 18px;">
                <u><%=globals.ResourceHelper.GetString("String375")%></u>
            </div>
            <div class="details-entire-line-gray">
                <div class="section-data-pc-intest">
                    <%=globals.ResourceHelper.GetString("String404")%>: 
                </div>
                <div class="section-data-pc">
                    <select name="id_altrohw_collegato" class="selector-modifica-elementi">
                        <%  ITSuite_Listing.AltroHW.OpenSelectorOtherHwConnection(id_altrohw_collegato) %>
                    </select>
                </div>
            </div>
        </div>
    </form>

    <div class="div-central" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; min-height: 0px;">

        <div class="section-data-pc" style="font-size: 18px; width: 100%">
            <u><%=globals.ResourceHelper.GetString("String157")%></u>
        </div>
        <div class="details-entire-line-white" style="height: auto; overflow: auto;">
            <div id="photoDiv" class="section-data-pc" style="width: 100%;">
                <form id="form1" runat="server">
                    <input type="hidden" runat="server" id="confirm_value" />
                    <asp:LinkButton ID="LabelInfoPhoto" Text="" runat="server"></asp:LinkButton>
                    <asp:Label ID="DivisionBar" Text="|" runat="server" Font-Bold="true" />
                    <asp:LinkButton ID="LinkDeletePhoto" Text="" OnClick="LinkDeletePhoto_Click" runat="server" OnClientClick="Confirm();return false;" />
                    <br />
                    <br />
                    <asp:FileUpload ID="PhotoUpload" runat="server" />
                    <asp:Button ID="ButtonUploadPhoto" runat="server" Text="Carica" OnClick="ButtonUploadPhoto_Click" />
                </form>
            </div>
        </div>
</asp:Content>

