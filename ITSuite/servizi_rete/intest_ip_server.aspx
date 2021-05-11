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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="intest_ip_server.aspx.vb" Inherits="servizi_rete_intest_ip_server" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function abilita() {
            document.cambiaip.ip.value = "DHCP";
            document.cambiaip.ip.disabled = true;

            document.cambiaip.submask.value = "DHCP";
            document.cambiaip.submask.disabled = true;

            document.cambiaip.gwy.value = "DHCP";
            document.cambiaip.gwy.disabled = true;

            document.cambiaip.dns1.value = "DHCP";
            document.cambiaip.dns1.disabled = true;

            document.cambiaip.dns2.value = "DHCP";
            document.cambiaip.dns2.disabled = true;

        };

        function disabilita() {
            document.cambiaip.ip.value = "<%if Session("abilita_autocompip") <> 0 Then Response.Write(Session("ip_predefinito"))%>";
            document.cambiaip.ip.disabled = false;

            document.cambiaip.submask.value = "<%if Session("abilita_autocompip") <> 0 Then Response.Write(Session("submask_predefinita"))%>";
            document.cambiaip.submask.disabled = false;

            document.cambiaip.gwy.value = "<%if Session("abilita_autocompip") <> 0 Then Response.Write(Session("gwy_predefinito"))%>";
            document.cambiaip.gwy.disabled = false;

            document.cambiaip.dns1.value = "<%if Session("abilita_autocompip") <> 0 Then Response.Write(Session("dns1_predefinito"))%>";
            document.cambiaip.dns1.disabled = false;

            document.cambiaip.dns2.value = "<%if Session("abilita_autocompip") <> 0 Then Response.Write(Session("dns2_predefinito"))%>";
            document.cambiaip.dns2.disabled = false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String534")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <asp:Label ID="SubLabel" runat="server"></asp:Label>
                      <div class="settings-button-right-title" title="Avvia" onclick="document.cambiaip.submit();">
   <img src="../img/logo_conferma-salva.png" alt="Modifica" style="border:0px solid black; text-decoration:none; margin-top:0px;" />
                     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form name="cambiaip" action="corpo_ip_server.aspx?ip=2&so=<%=selectedOs%>" method="post">
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String497")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="utente" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String498")%>:
            </div>
            <div class="section-data-pc">
                <input type="password" class="input-modifica-elementi-obbligatori" name="password" value="" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String501")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="hostpc" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String508")%> (<a href="#" onclick="javascript:document.getElementById('connessione').value = '<%=Session("lan_predefinita")%>'">pre</a>, <a href="#" onclick="javascript:document.getElementById('connessione').value = '<%=Session("lan_alternativa1")%>'">alt1</a>, <a href="#" onclick="javascript:document.getElementById('connessione').value = '<%=Session("lan_alternativa2")%>'">alt2</a>, <a href="#" onclick="javascript:document.getElementById('connessione').value = '<%=Session("lan_alternativa3")%>'">alt3</a>):
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" id="connessione" name="connessione" value="<%=Session("lan_predefinita") %>" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String509")%> (<a href="#" onclick="javascript:document.getElementById('ip').value = '<%=Session("ip_predefinito")%>'">pre</a>, <a href="#" onclick="javascript:document.getElementById('ip').value = '<%=Session("ip_alternativo")%>'">alt</a>):
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ip" id="ip" value="<% if Session("abilita_autocompip") = 1 Then Response.Write(Session("ip_predefinito")) %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String510")%> (<a href="#" onclick="javascript:document.getElementById('submask').value = '<%=Session("submask_predefinita")%>'">pre</a>, <a href="#" onclick="javascript:document.getElementById('submask').value = '<%=Session("submask_alternativa")%>'">alt</a>):
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="submask" id="submask" value="<% if Session("abilita_autocompip") = 1 Then Response.Write(Session("submask_predefinita"))%>" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String511")%> (<a href="#" onclick="javascript:document.getElementById('gwy').value = '<%=Session("gwy_predefinito")%>'">pre</a>, <a href="#" onclick="javascript:document.getElementById('gwy').value = '<%=Session("gwy_alternativo")%>'">alt</a>):
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="gwy" id="gwy" value="<% if Session("abilita_autocompip") = 1 Then Response.Write(Session("gwy_predefinito")) %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String512")%> (<a href="#" onclick="javascript:document.getElementById('dns1').value = '<%=Session("dns1_predefinito")%>'">pre</a>, <a href="#" onclick="javascript:document.getElementById('dns1').value = '<%=Session("dns1_alternativo")%>'">alt</a>):
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="dns1" id="dns1" value="<% if Session("abilita_autocompip") = 1 Then Response.Write(Session("dns1_predefinito")) %>" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String513")%> (<a href="#" onclick="javascript:document.getElementById('dns2').value = '<%=Session("dns2_predefinito")%>'">pre</a>, <a href="#" onclick="javascript:document.getElementById('dns2').value = '<%=Session("dns2_alternativo")%>'">alt</a>):
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="dns2" id="dns2" value="<% if Session("abilita_autocompip") = 1 Then Response.Write(Session("dns2_predefinito")) %>" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String514")%> (<a href="#" onclick="javascript:document.getElementById('wins').value = '<%=Session("wins_predefinito")%>'">pre</a>, <a href="#" onclick="javascript:document.getElementById('wins').value = '<%=Session("wins_alternativo")%>'">alt</a>):
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="wins" id="wins" value="" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div style="float: left; margin-top: 10px; margin-bottom: 10px;">
                &nbsp;<%=globals.ResourceHelper.GetString("String515")%>
            <input type="checkbox" style="float: left; margin-top: 5px;" name="dhcp" onclick="if (this.checked) { abilita(); } else { disabilita(); }" />
            </div>
        </div>
    </form>
</asp:Content>

