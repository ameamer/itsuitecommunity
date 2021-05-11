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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="nuovo_guasto.aspx.vb" Inherits="gestione_guasti_nuovo_guasto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
            <script type="text/javascript">
            function HideLabel() {
                document.getElementById("cntr-msg").style.display = "block";
                var seconds = 7;
                setTimeout(function () {
                    document.getElementById("cntr-msg").style.display = "none";
                }, seconds * 1000);
            };
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
     <%=globals.ResourceHelper.GetString("String22") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <%=globals.ResourceHelper.GetString("String243") %>
                  <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.form_inserisciguasto.submit();">
                      <img src="../img/logo_conferma-salva.png" alt="<%=globals.ResourceHelper.GetString("String28") %>" style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
                  </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">

        <div class="cntr-msg" id="cntr-msg" style="border: 2px solid red;">
            <asp:label runat="server" id="ErrorMsg" text="" visible="true">

            </asp:label>
        </div>
    </form>
    <form name="form_inserisciguasto" action="guasto_inserito.aspx" method="post">
     
         <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String212") %>:
            </div>
             <div class="section-data-pc">
                 <select name="utente" class="selector-modifica-elementi-obbligatori">
                     <% ITSuite_Listing.Utenti.OpenClientiSelector() %>
                 </select>
             </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String229") %> <i style="color: gray"><%=globals.ResourceHelper.GetString("String244") %></i>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="intest-guasto" value="<%If isempty = True Then Response.Write(intest) %>" maxlength="250" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String230") %>:
            </div>
            <div class="section-data-pc">
                <textarea class="input-modifica-elementi" style="height: 100px; background-color: lightpink" name="dettagli-guasto"><%If isempty = True Then Response.Write(body) %></textarea>
            </div>
        </div>
        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String125") %>: 
            </div>
            <div class="section-data-pc">
                <select name="reparto_guasto" class="selector-modifica-elementi-obbligatori">
                                         <option value=""><%=globals.ResourceHelper.GetString("String125") %>...</option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String126") %>: 
            </div>
            <div class="section-data-pc">
                <select name="padiglione_guasto" class="selector-modifica-elementi-obbligatori">
                                         <option value=""><%=globals.ResourceHelper.GetString("String126") %>...</option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String127") %>: 
            </div>
            <div class="section-data-pc">
                <select name="presidio_guasto" class="selector-modifica-elementi-obbligatori">
                                         <option value=""><%=globals.ResourceHelper.GetString("String127") %>...</option>
                    <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
                </select>

            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String234") %>: 
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ubicazione_guasto" value="" />
            </div>
        </div>

        <% If HttpContext.Current.Session("Autenticato") = "admin" Then %>
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String245") %>: 
            </div>
            <div class="section-data-pc">
                <select name="assegnazione_utente" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Utenti.OpenUtentiSelector() %>
                </select>

            </div>
        </div>
                <% End if %>

        <% If Session("emailenabled") = "1" Then %>
        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
               <%=globals.ResourceHelper.GetString("String246") %>: 
            </div>
            <div class="section-data-pc">
            <input type="checkbox" name="inviacopia" id="inviacopia" value="1" />
                <label for="inviacopia" style="font-size:small"><%=globals.ResourceHelper.GetString("String247") %></label>
            </div>
        </div>
        <% End if %>
    </form>
</asp:Content>

