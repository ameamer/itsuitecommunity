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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="winfirewall_server_home.aspx.vb" Inherits="servizi_rete_winfirewall_server_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String558")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
                     <asp:Label ID="SubLabel" runat="server"></asp:Label>
             <div class="settings-button-right-title" onclick="document.winfirewallpcserver.submit();">
   <img src="../img/logo_conferma-salva.png" style="border:0px solid black; text-decoration:none; margin-top:0px;" />
                     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form name="winfirewallpcserver" action="winfirewall_server_exec.aspx?so=<%=selectedOs%>" method="post">
        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String497")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="utente" id="utente" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String498")%>:
            </div>
            <div class="section-data-pc">
                <input type="password" class="input-modifica-elementi-obbligatori" name="password" id="password" value="" />
            </div>
        </div>

        <div class="details-entire-line-white">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String501")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ip_remoto" id="ip_remoto" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">

            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String590")%>:
            </div>
            <div class="section-data-pc">
                <select name="tipowinfirewall" class="selector-modifica-elementi-obbligatori">
                    <option value="disattiva"><%=globals.ResourceHelper.GetString("String591")%></option>
                    <option value="attiva"><%=globals.ResourceHelper.GetString("String592")%></option>
                    <option value="disattiva_fw"><%=globals.ResourceHelper.GetString("String593")%></option>
                    <option value="attiva_fw"><%=globals.ResourceHelper.GetString("String594")%></option>
                    <option value="reset_fw"><%=globals.ResourceHelper.GetString("String595")%></option>
                </select>
            </div>
        </div>

    </form>
</asp:Content>

