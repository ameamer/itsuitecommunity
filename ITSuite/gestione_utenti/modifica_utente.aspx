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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="modifica_utente.aspx.vb" Inherits="gestione_utenti_modifica_utente" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
             document.getElementById('confirm_value').style.display = 'none';
             if (confirm("<%=globals.ResourceHelper.GetString("String472")%>")) {
                 document.getElementById('confirm_value').value = "Yes";
                 document.form1.submit();
             } else {
                 document.getElementById('confirm_value').value = "No";
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String41")%> ID <%=iduser%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <%=globals.ResourceHelper.GetString("String466")%> <%=iduser%>
    <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalForm.submit();">
        <img src="../img/logo_conferma-salva.png" alt="<%=globals.ResourceHelper.GetString("String28") %>" style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server" ClientIDMode="Static">
<div class="cntr-msg" id="cntr-msg">
<asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true" />
</div>

    <form name="generalForm" method="post" action="salva_utente.aspx">
        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                ID:
            </div>
            <div class="section-data-pc">
                <% Response.Write(iduser)%>
                <input type="text" class="input-modifica-elementi-obbligatori" style="display: none;" name="id" value="<%=iduser %>" />
            </div>
        </div>

                <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String48")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="cognome" value="<%=cognome %>" />
            </div>
        </div>

                <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String49")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="nome" value="<%=nome %>" />
            </div>
        </div>

                <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String50")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="email" value="<%=email %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String53")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="matricola_utente" value="<%=matricola_utente %>" />
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String47")%>:
            </div>
            <div class="section-data-pc">
                <%=nome_utente%>
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String51")%>: 
            </div>
            <div class="section-data-pc">
                <% If tipo_utente <> "Cliente" Then%>
                <select class="selector-modifica-elementi-obbligatori" name="tipo_utente">
                    <option value="Amministratore" <% If tipo_utente = "Amministratore" Then Response.Write("selected='selected'") %>><%=globals.ResourceHelper.GetString("String467")%></option>
                    <option value="Tecnico ticketing" <% If tipo_utente = "Tecnico ticketing" Then Response.Write("selected='selected'") %>><%=globals.ResourceHelper.GetString("String468")%></option>
                </select>
                <% end if %>
                <% If tipo_utente = "Cliente" Then%>
                                <%=globals.ResourceHelper.GetString("String212")%>
                        <div style="font-size: 12px; color: red;"><%=globals.ResourceHelper.GetString("String469")%></div>
                <% end If %>
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String54")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="dettagli_utente" value="<%=dettagli_utente %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String55")%>:
            </div>
            <div class="section-data-pc">
                <%=database_utente%>
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String56")%>:
            </div>
            <div class="section-data-pc">
                <%=creato_da%>
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String57")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ubicazione_utente" value="<%=ubicazione_utente%>" />
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String58")%>:
            </div>
            <div class="section-data-pc">
                <%=data_creazione%>
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String59")%>:
            </div>
            <div class="section-data-pc">
                <%=ora_creazione%>
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String60")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="note_utente" value="<%=note_utente%>" />
            </div>
        </div>

                <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String61")%>:
            </div>
            <div class="section-data-pc">
                <select class="selector-modifica-elementi-obbligatori" name="stato_utente" onchange="avvia_input(this.value)">
                    <option selected="selected" value="<%=stato_utente %>"><%=globals.ResourceHelper.GetString("String173")%>&nbsp;<%=stato_utente %></option>
                    <option value="Attivo"><%=globals.ResourceHelper.GetString("String470")%></option>
                    <option value="Disattivo"><%=globals.ResourceHelper.GetString("String471")%></option>
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
                    <form runat="server" name="PhotoForm" >
                    <input type="hidden" runat="server" id="confirm_value" />
                    <asp:LinkButton ID="LabelInfoPhoto" Text="" runat="server"></asp:LinkButton>
                    <asp:Label ID="DivisionBar" Text="|" runat="server" Font-Bold="true" />
                    <asp:LinkButton ID="LinkDeletePhoto" Text="" OnClick="LinkDeletePhoto_Click" runat="server" OnClientClick="Confirm();return false;" />
                    <br />
                    <br />
                    <asp:FileUpload ID="PhotoUpload" runat="server" />
                    <asp:Button ID="ButtonUploadPhoto" runat="server" Text='<%#globals.ResourceHelper.GetString("String441")%>' OnClick="ButtonUploadPhoto_Click" />
                    </form>
                </div>
            </div>

</asp:Content>

