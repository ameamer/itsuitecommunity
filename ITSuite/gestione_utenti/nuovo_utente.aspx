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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="nuovo_utente.aspx.vb" Inherits="gestione_utenti_nuovo_utente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function HideLabel() {
            document.getElementById("cntr-msg").style.display = "block";
            var seconds = 7;
            setTimeout(function () {
                document.getElementById("cntr-msg").style.display = "none";
            }, seconds * 1000);
        };

        function avvia_input(value) {
            if (value == 'Tecnico ticketing') {
                document.getElementById('t1').value = 'tab_';
                document.getElementById('t1').removeAttribute('readOnly', true);
                document.getElementById('t1').setAttribute('style', 'color:black');
                document.getElementById('stdmsg').style.display = 'none';
            } else if (value == 'Amministratore') {
                document.getElementById('t1').value = 'tab_';
                document.getElementById('t1').removeAttribute('readOnly', true);
                document.getElementById('t1').setAttribute('style', 'color:black')
                document.getElementById('stdmsg').style.display = 'none';
            } else {
                document.getElementById('t1').value = 'tab_general';
                document.getElementById('t1').setAttribute('readOnly', 'readOnly');
                document.getElementById('t1').setAttribute('style', 'color:gray')
                document.getElementById('stdmsg').style.display = 'block';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String37")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String480")%>
         <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalForm.submit();">
   <img src="../img/logo_conferma-salva.png" alt="<%=globals.ResourceHelper.GetString("String28") %>" style="border:0px solid black; text-decoration:none; margin-top:0px;" />
         </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

            </asp:Label>
        </div>
    </form>

    <form name="generalForm" method="post" action="salva_nuovo_utente.aspx">
                  <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String48")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="cognome_utente" />
            </div>
        </div>

        
                <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String49")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="nome_utente" />
            </div>
        </div>

                        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String50")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="email_utente" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String53")%>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="matricola_utente" />
            </div>
        </div>
     
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String47")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="nomeutente" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String481")%>:
            </div>
            <div class="section-data-pc">
                <input type="password" class="input-modifica-elementi-obbligatori" name="password1" />
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String482")%>:
            </div>
            <div class="section-data-pc">
                <input type="password" class="input-modifica-elementi-obbligatori" name="password2" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String51")%>: 
            </div>
            <div class="section-data-pc">
                <select class="selector-modifica-elementi-obbligatori" name="tipo_utente" onchange="avvia_input(this.value)">
                    <option value="Amministratore"><%=globals.ResourceHelper.GetString("String467")%></option>
                    <option value="Tecnico ticketing"><%=globals.ResourceHelper.GetString("String468")%></option>
                    <option value="Cliente"><%=globals.ResourceHelper.GetString("String212")%></option>
                </select>
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String55")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="database_utente" id="t1" value="tab_" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String54")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="dettagli_utente" />
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String57")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ubicazione_utente" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String60")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="note_utente" />
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String61")%>: 
            </div>
            <div class="section-data-pc">
                <select class="selector-modifica-elementi-obbligatori" name="stato_utente">
                    <option value="Attivo"><%=globals.ResourceHelper.GetString("String470")%></option>
                    <option value="Disattivo"><%=globals.ResourceHelper.GetString("String471")%></option>
                </select>
            </div>
        </div>

    </form>

</asp:Content>

