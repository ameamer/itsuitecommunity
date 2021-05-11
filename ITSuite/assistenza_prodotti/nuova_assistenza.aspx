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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="nuova_assistenza.aspx.vb" Inherits="assistenza_prodotti_nuova_assistenza" %>

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
            if (value == '0') {
                document.getElementById('sel-stamp').style.display = 'none';
                document.getElementById('sel-otherhw').style.display = 'none';
                document.getElementById('sel-pc').style.display = 'none';
            } else if (value == '1') {
                document.getElementById('sel-stamp').style.display = 'none';
                document.getElementById('sel-otherhw').style.display = 'none';
                document.getElementById('sel-pc').style.display = 'block';
            } else if (value == '2') {
                document.getElementById('sel-otherhw').style.display = 'none';
                document.getElementById('sel-pc').style.display = 'none';
                document.getElementById('sel-stamp').style.display = 'block';
            } else if (value == '3') {
                document.getElementById('sel-pc').style.display = 'none';
                document.getElementById('sel-stamp').style.display = 'none';
                document.getElementById('sel-otherhw').style.display = 'block';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String32")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String759")%>
                          <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.form_inserisciassistenza.submit();">
   <img src="../img/logo_conferma-salva.png" alt="<%=globals.ResourceHelper.GetString("String28") %>" style="border:0px solid black; text-decoration:none; margin-top:0px;" />
                     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">

        <div class="cntr-msg" id="cntr-msg" style="border: 2px solid red;">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

            </asp:Label>
        </div>
    </form>
    <form name="form_inserisciassistenza" action="assistenza_inserita.aspx" method="post">
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String229")%> <i style="color: gray"><%=globals.ResourceHelper.GetString("String244")%></i>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="intest-ass" value="<%=intest %>" maxlength="250" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String230")%>:
            </div>
            <div class="section-data-pc">
                <textarea class="input-modifica-elementi" style="height: 100px; background-color: lightpink" name="dettagli-ass"><%=body %></textarea>
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String760")%>:
            </div>
            <div class="section-data-pc">
                <select name="tipo_prodass" id="seltypehw" class="selector-modifica-elementi-obbligatori" onchange="avvia_input(this.value)">
                    <option value="0"><%=globals.ResourceHelper.GetString("String761")%></option>
                    <option value="1"><%=globals.ResourceHelper.GetString("String754")%></option>
                    <option value="2"><%=globals.ResourceHelper.GetString("String753")%></option>
                    <option value="3"><%=globals.ResourceHelper.GetString("String752")%></option>
                </select>
            </div>
        </div>

        <div class="details-entire-line-gray" id="sel-pc" style="display: none;">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String762")%>:
            </div>
            <div class="section-data-pc">
                <select name="pcsel" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.PC.OpenSelectorPcConnection(Nothing) %>
                </select>
            </div>
        </div>

        <div class="details-entire-line-gray" id="sel-stamp" style="display: none;">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String403")%>:
            </div>
            <div class="section-data-pc">
                <select name="stmp" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.Stampanti.OpenSelectorStampantiConnection(Nothing) %>
                </select>
            </div>
        </div>

        <div class="details-entire-line-gray" id="sel-otherhw" style="display: none;">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String404")%>:
            </div>
            <div class="section-data-pc">
                <select name="altrohw" class="selector-modifica-elementi-obbligatori">
                    <% ITSuite_Listing.AltroHW.OpenSelectorOtherHwConnection(Nothing) %>
                </select>
            </div>
        </div>
    </form>
</asp:Content>
