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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="dettagli_altro_hw.aspx.vb" Inherits="gestione_altro_hardware_dettagli_altro_hw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var id_altro_hw_js = <%=id_altro_hw %>;
  function showTopMsg() {
            document.getElementById('cntrmsg').style.display = 'block';
            window.setTimeout("hideTopMsg()", 3000);
        }

        function hideTopMsg() {
            document.getElementById('cntrmsg').style.display = 'none';
        }

        function CallPgm1(cmd) {
            var shell = new ActiveXObject("WScript.shell");
            shell.run(cmd, 1, true);
        }

            function toggle_visibility(id, button) {
        var e = document.getElementById(id);
        if (e.style.display == 'block') {
            e.style.display = 'none';
            button.style.opacity = '0.6';
        }

        else {
            e.style.display = 'block';
            button.style.opacity = '1.0';
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <div id="cntrmsg" class="cntr-msg" runat="server">
        <asp:Label ID="StatusLabel"
            runat="server">
        </asp:Label>
    </div>

    <div id="deleteMsgScreen" class="cntr-msg" style="border: 2px solid red;">
        <%= globals.ResourceHelper.GetString("String143") %>
        <br />
        <br />

        <input type="button" onclick="document.getElementById('deleteMsgScreen').style.display = 'none';" value=" <%= globals.ResourceHelper.GetString("String144") %>" id="ButtonCancDelete" />
        <input type="button" value=" <%= globals.ResourceHelper.GetString("String145") %>" onclick="location.href = 'elimina_altro_hw.aspx?id_altro_hw=' + id_altro_hw_js;" id="ButtonConirmDelete" />

    </div>

    <%= globals.ResourceHelper.GetString("String142") %> (ID <%=id_altro_hw %>)
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
     <%= globals.ResourceHelper.GetString("String148") %>
                  <div class="settings-button-right-title">
                      <img src="../img/logo_edit.png" onclick="toggle_visibility('container-settings', this);" alt="Modifica" style="border: 0px solid black; text-decoration: none; margin-top: 0px; opacity: 0.6" />

                      <div class="container-settings" id="container-settings" style="display: none;">

                          <div class="context-menu-settings-pc-details" id="dettagli-pc-context-settings-menu">
                              <div class="list-settings-menu" onclick="location.href='modifica_altro_hw.aspx?id_hw=<%=id_altro_hw%>';">
                                  <%= globals.ResourceHelper.GetString("String146") %>
                              </div>

                              <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none';document.getElementById('deleteMsgScreen').style.display='block';">
                                   <%= globals.ResourceHelper.GetString("String147") %>
                              </div>

                          </div>
                      </div>
                  </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">       
    <form runat="server">
               <div class="imgcontdetails">
            <div class="imgcelldetails">
<asp:HyperLink ID="Aimage" runat="server">
    <img src="#" id="generalImage" runat="server" />
</asp:HyperLink>
            </div>
           <div class="infoceldetails">
              <asp:Label ID="IdLabel" runat="server"></asp:Label>
               <br />
               <br />
               <asp:Label ID="TipoLabel" runat="server"></asp:Label>
               <br />
               <asp:Label ID="MarcaLabel" runat="server"></asp:Label>
               <br />
               <asp:Label ID="ModelloLabel" runat="server"></asp:Label>
               <br />
                <asp:Label ID="SNLabel" runat="server"></asp:Label>
               <br />
               <asp:Label ID="AnnoLabel" runat="server"></asp:Label>
   </div>
        </div>

    <asp:DetailsView OnDataBound="DetailsView1_DataBound" ID="DetailsView1" runat="server" Style="width: 100%;" CellPadding="5" AutoGenerateRows="False" DataKeyNames="ID" DataSourceID="SqlOtherHWSource">
            <FieldHeaderStyle Font-Bold="false" />
            <RowStyle BackColor="White" Font-Bold="true" />
            <AlternatingRowStyle BackColor="LightGray" />
            <Fields>
                <asp:BoundField DataField="inventario_hardware" SortExpression="inventario_hardware" ItemStyle-Width="70%" />
                <asp:BoundField DataField="reparto_hw" SortExpression="reparto_hardware" ItemStyle-Width="70%" />
                <asp:BoundField DataField="padiglione_hw" SortExpression="padiglione_hardware" ItemStyle-Width="70%" />
                <asp:BoundField DataField="presidio_hw" SortExpression="presidio_hardware" ItemStyle-Width="70%" />
                <asp:BoundField DataField="stato_hardware" SortExpression="stato_hardware" ItemStyle-Width="70%" />
                <asp:BoundField DataField="note_hardware" SortExpression="note_hardware" ItemStyle-Width="70%" />
                <asp:BoundField DataField="autoreinserimento_hardware" SortExpression="inserita_da" ItemStyle-Width="70%" />
                <asp:BoundField DataField="datainserimento_hardware" SortExpression="data_inserimento" ItemStyle-Width="70%" />
                <asp:BoundField DataField="orainserimento_hardware" SortExpression="ora_inserimento" ItemStyle-Width="70%" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlOtherHWSource" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="Id" QueryStringField="id_hw" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
          <table style="width: 100%; border: 1px solid black; border-top: 0px solid black; padding: 0px; border-collapse: collapse; background-color: white;">
            <tr>
                <td style="padding: 5px; border-top: 0px solid black; background-color: lightgray;"><%=globals.ResourceHelper.GetString("String64") %>
                </td>

                <td style="width: 70%; padding: 5px; border-left: 1px solid black; border-top: 0px solid black; background-color: lightgray;">
                    <asp:Label runat="server" ID="LabelAutoreUltima"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; border-top: 1px solid black; background-color: white;"><%=globals.ResourceHelper.GetString("String155") %>
                </td>

                <td style="width: 70%; padding: 5px; border-left: 1px solid black; border-top: 1px solid black; background-color: white;">
                    <asp:Label runat="server" ID="LabelDataoraUltima"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; border-top: 1px solid black; background-color: lightgray;"><%=globals.ResourceHelper.GetString("String156") %>
                </td>

                <td style="width: 70%; padding: 5px; border-left: 1px solid black; border-top: 1px solid black; background-color: lightgray;">
                    <asp:Label runat="server" ID="LabelDrivers"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; border-top: 1px solid black; background-color: white;"><%=globals.ResourceHelper.GetString("String130") %>
                </td>

                <td style="width: 70%; padding: 5px; border-left: 1px solid black; border-top: 1px solid black; background-color: white;">
                    <asp:Label runat="server" ID="LabelIP"></asp:Label>
                    &nbsp; 
                     <%   If Not String.IsNullOrEmpty(ip_altrohw) And (Session("servizi_rete") = "1") Then %>
                    <b><a href="#" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit tracert <%=ip_altrohw %>')" style="color: #999999">tracert</a>&nbsp;|
 <a href="#" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit ping <%=ip_altrohw %>')" style="color: #333333">ping</a>
                   </b> <% end if %>
                </td>
            </tr>
        </table>

        <table style="width: 100%; border: 1px solid black; border-top: 0px solid black; padding: 0px; border-collapse: collapse; background-color: lightgray; margin-top: 0px;">
            <tr>
                <td style="padding: 5px; border-top: 0px solid black; background-color: lightgray;"><%=globals.ResourceHelper.GetString("String157") %>
                </td>

                <td style="width: 70%; padding: 5px; border-top: 0px solid black; border-left: 1px solid black; background-color: lightgray; font-weight: bold">
                    <asp:LinkButton runat="server" ID="PhotoDetails"></asp:LinkButton>
                </td>
            </tr>
        </table>
      </form>
</asp:Content>

