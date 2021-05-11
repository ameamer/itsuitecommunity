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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="telnet_home.aspx.vb" Inherits="servizi_rete_telnet_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String571")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String596")%>
                 <div class="settings-button-right-title" onclick="document.telnet.submit();">
   <img src="../img/logo_conferma-salva.png" style="border:0px solid black; text-decoration:none; margin-top:0px;" />
                     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">

    <form name="telnet" action="telnet_exec.aspx" method="post">
    <div class="details-entire-line-white">

    <div class="section-data-pc-intest">
        <%=globals.ResourceHelper.GetString("String130")%>:
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ind" id="ind" value="" />
            </div>
            </div>

            <div class="details-entire-line-gray">

    <div class="section-data-pc-intest">
        <%=globals.ResourceHelper.GetString("String574")%>:
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="porta" id="porta" value="" />
            </div>
            </div>
        </form>
</asp:Content>

