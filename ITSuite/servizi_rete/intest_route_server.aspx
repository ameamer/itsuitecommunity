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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="intest_route_server.aspx.vb" Inherits="servizi_rete_intest_route_server" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function CallPgm1(cmd) {
        try {
            var shell = new ActiveXObject("WScript.shell");
            shell.run(cmd, 1, true);
        }
        catch (err) {
                  alert("<%=globals.ResourceHelper.GetString("String554")%>")
        }

    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String523")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <asp:Label ID="SubLabel" runat="server"></asp:Label>
    <div class="settings-button-right-title" title="Avvia" onclick="document.cambiaroute.submit();">
        <img src="../img/logo_conferma-salva.png" alt="Avvia" style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
    </div>

    <div class="settings-button-right-title" title='<%=globals.ResourceHelper.GetString("String547")%>' onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit psexec \\\\' + document.getElementById('ip_remoto').value + ' -u ' + document.getElementById('utente').value + ' -p ' + document.getElementById('password').value + ' route print')">
        <img src="../img/logo_info.png" alt='<%=globals.ResourceHelper.GetString("String547")%>' style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
    </div>

    <div class="settings-button-right-title" title='<%=globals.ResourceHelper.GetString("String555")%>' onclick="location.href='../servizi_rete/eliminarotte_server.aspx?so=<%=selectedOs %>';">
        <img src="../img/logo_delete.png" alt='<%=globals.ResourceHelper.GetString("String555")%>' style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form name="cambiaroute" action="cambiaroute_server.aspx?so=<%=selectedOs%>" method="post">
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
                <%=globals.ResourceHelper.GetString("String518")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="ip" value="" />
            </div>
        </div>

        <div class="details-entire-line-white">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String519")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="submask" value="" />
            </div>
        </div>

        <div class="details-entire-line-gray">
            <div class="section-data-pc-intest">
                <%=globals.ResourceHelper.GetString("String520")%>:
            </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi-obbligatori" name="gwy" value="" />
            </div>
        </div>

        <div class="details-entire-line-white">
            <div style="float: left; margin-top: 10px; margin-bottom: 10px;">
                &nbsp;<%=globals.ResourceHelper.GetString("String521")%>
            <input type="checkbox" style="float: left; margin-top: 5px;" name="perm_route" />
            </div>
        </div>

    </form>
</asp:Content>

