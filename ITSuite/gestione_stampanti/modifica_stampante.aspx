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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="modifica_stampante.aspx.vb" Inherits="gestione_stampanti_modifica_stampante" %>

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
    <%=globals.ResourceHelper.GetString("String440")%> (ID <%=id_stamp%>)
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String162")%>: <b><%=Session("username")%></b>.

                  <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalform.submit();">
   <img src="../img/logo_conferma-salva.png" alt="Modifica" style="border:0px solid black; text-decoration:none; margin-top:0px;" />
                     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <div class="cntr-msg" id="cntr-msg">
        <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true" />
    </div>

    <form name="generalform" action="salva_dati_stampante.aspx">
        <input type="hidden" name="id_stamp" id="id_stamp" value="<%=id_stamp%>" />
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String164")%> <i style="color: gray">(.../...)</i>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="cartella_stampante" value="<%=cartella_stampante %>" />
            </div>
        </div>
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String120")%>: 
            </div>
            <div class="section-data-pc">
                <select name="marca_stampante" class="selector-modifica-elementi">
                    <option value="<%=marca_stampante %>">(In uso) <%=marca_stampante %></option>
                    <% ITSuite_Listing.Marche.OpenSelectorMarcheStampantiConnection %>
                </select>
            </div>
        </div>
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String122")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="modello_stampante" value="<%=modello_stampante %>" />
            </div>
        </div>
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String123")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="numero_serie_stampante" value="<%=numero_serie_stampante %>" />
            </div>
        </div>
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String124")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="inventario_stampante" value="<%=inventario_stampante %>" />
            </div>
        </div>
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String131")%>: 
            </div>
            <div class="section-data-pc">
                <select name="anno_stampante" class="selector-modifica-elementi">
                    <option value="<%=anno_stampante %>"><%=globals.ResourceHelper.GetString("String173")%> <%=anno_stampante %></option>
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
                <input type="text" class="input-modifica-elementi" name="ip_stampante" value="<%=ip_stampante %>" />
            </div>
        </div>
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String128")%>: 
            </div>
            <div class="section-data-pc">
                <select name="stato_stampante" class="selector-modifica-elementi">
                    <option value="<%=stato_stampante%>"><%=globals.ResourceHelper.GetString("String173")%> <%=stato_stampante%></option>
                    <% ITSuite_Listing.Stati.OpenSelectorStatiConnection() %>
                </select>
            </div>
        </div>
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String132")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="note_stampante" value="<%=note_stampante %>" />
            </div>
        </div>
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String125")%>: 
            </div>
            <div class="section-data-pc">
                <select name="reparto_stampante" class="selector-modifica-elementi">
                    <option value="<%=reparto_stampante%>"><%=globals.ResourceHelper.GetString("String173")%> <%=reparto_stampante%></option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
                </select>
            </div>
        </div>
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String126")%>: 
            </div>
            <div class="section-data-pc">
                <select name="padiglione_stampante" class="selector-modifica-elementi">
                    <option value="<%=padiglione_stampante%>"><%=globals.ResourceHelper.GetString("String173")%> <%=padiglione_stampante%></option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
                </select>
            </div>
        </div>
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String127")%>: 
            </div>
            <div class="section-data-pc">

                <select name="presidio_stampante" class="selector-modifica-elementi">
                    <option value="<%=presidio_stampante%>"><%=globals.ResourceHelper.GetString("String173")%> <%=presidio_stampante%></option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
                </select>
            </div>
        </div>
    </form>

    </div>

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
                        <asp:Button ID="ButtonUploadPhoto" runat="server" Text='<%# globals.ResourceHelper.GetString("String441")%>' OnClick="ButtonUploadPhoto_Click" />
                    </form>
                </div>
            </div>
</asp:Content>

