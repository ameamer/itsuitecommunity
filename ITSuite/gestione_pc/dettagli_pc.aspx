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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="dettagli_pc.aspx.vb" Inherits="gestione_pc_det_pc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript">
        var id_pc_js = <%=id_pc %>;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
       <div id="cntrmsg" class="cntr-msg" runat="server">
        <asp:Label ID="StatusLabel"
            runat="server">
        </asp:Label>
    </div>

    <div id="deleteMsgScreen" class="cntr-msg" style="border: 2px solid red;">
        <%=globals.ResourceHelper.GetString("String143") %>
        <br />
        <br />

        <input type="button" onclick="document.getElementById('deleteMsgScreen').style.display = 'none';" value="NO" id="ButtonCancDelete" />
        <input type="button" value="SI" onclick="location.href = 'elimina_pc.aspx?id_pc=' + id_pc_js;" id="ButtonConirmDelete" />

    </div>

     <%=globals.ResourceHelper.GetString("String369") %> (ID <%=id_pc %>)
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String370") %>
    
    <div class="settings-button-right-title">
        <img src="../img/logo_edit.png" onclick="toggle_visibility('container-settings', this);" alt="Modifica" style="border: 0px solid black; text-decoration: none; margin-top: 0px; opacity: 0.6" />

        <div class="container-settings" id="container-settings" style="display: none;">

            <div class="context-menu-settings-pc-details" id="dettagli-pc-context-settings-menu">
                <div class="list-settings-menu" onclick="location.href='modifica_pc.aspx?id_pc=<%=id_pc%>';">
                     <%=globals.ResourceHelper.GetString("String146") %>
                </div>

                <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none';document.getElementById('deleteMsgScreen').style.display='block';">
                     <%=globals.ResourceHelper.GetString("String147") %>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
    <form runat="server" >
        <div class="imgcontdetails">
            <div class="imgcelldetails">
<asp:HyperLink ID="Aimage" runat="server">
    <img src="#" id="generalImage" runat="server" />
</asp:HyperLink>
            </div>
           <div class="infoceldetails">
              <asp:Label ID="IdLabel" runat="server"></asp:Label>
               <br /><br />
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
        <asp:DetailsView OnDataBound="DetailsView1_DataBound" ID="DetailsView1" runat="server" Style="width: 100%;" CellPadding="5" AutoGenerateRows="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <FieldHeaderStyle Font-Bold="false" />
            <RowStyle BackColor="White" Font-Bold="true" />
            <AlternatingRowStyle BackColor="LightGray" />
            <Fields>
                <asp:BoundField DataField="dominio_pc" SortExpression="dominio_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="nome_dominio_pc" SortExpression="nome_dominio_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="inventario_pc" SortExpression="inventario_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="so_pc" SortExpression="so_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="stato_pc" SortExpression="stato_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="ram_pc" SortExpression="ram_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="processore_pc" SortExpression="processore_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="stanza_pc" SortExpression="stanza_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="piano_pc" SortExpression="piano_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="reparto_pc" SortExpression="reparto_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="padiglione_pc" SortExpression="padiglione_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="presidio_pc" SortExpression="presidio_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="swprivate_pc" SortExpression="swprivate_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="note_pc" SortExpression="note_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="inserito_da" SortExpression="inserito_da" ItemStyle-Width="70%" />
                <asp:BoundField DataField="data_ins_pc" SortExpression="data_ins_pc" ItemStyle-Width="70%" />
                <asp:BoundField DataField="ora_ins_pc" SortExpression="ora_ins_pc" ItemStyle-Width="70%" />
            </Fields>
        </asp:DetailsView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="Id" QueryStringField="id_pc" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>


        <table style="width:100%; border:1px solid black; border-top:0px solid black; padding:0px; border-collapse:collapse; background-color:white;">
                        <tr>
                <td style="padding:5px;border-top:0px solid black; background-color:lightgray;">
                     <%=globals.ResourceHelper.GetString("String64") %>
                </td>

                <td style="width:70%; padding:5px; border-left:1px solid black;border-top:0px solid black; background-color:lightgray;">
                    <asp:Label runat="server" ID="LabelAutoreUltimaPC"></asp:Label>
                </td>
            </tr>

                                    <tr>
                <td style="padding:5px;border-top:1px solid black; background-color:white;">
                     <%=globals.ResourceHelper.GetString("String155") %>
                </td>

                <td style="width:70%; padding:5px; border-left:1px solid black;border-top:1px solid black; background-color:white;">
                    <asp:Label runat="server" ID="LabelDataoraUltimaPC"></asp:Label>
                </td>
            </tr>


            <tr>
                <td style="padding:5px;border-top:1px solid black; background-color:lightgray;">
                     <%=globals.ResourceHelper.GetString("String156") %>
                </td>

                <td style="width:70%; padding:5px; border-left:1px solid black;border-top:1px solid black; background-color:lightgray;">
                    <asp:Label runat="server" ID="LabelDrivers"></asp:Label>
                </td>
            </tr>

                        <tr>
                <td style="padding:5px; border-top:1px solid black; background-color:white;">
                     <%=globals.ResourceHelper.GetString("String130") %>
                </td>

                <td style="width:70%; padding:5px; border-left:1px solid black;border-top:1px solid black;background-color:white;">
                    <asp:Label runat="server" ID="LabelIP"></asp:Label>
  &nbsp; 
                    <%   If Not String.IsNullOrEmpty(ip_pc) And (Session("servizi_rete") = "1") Then %>
 <b><a href="#" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit tracert <%=ip_pc %>')" style="color:#999999">tracert</a>&nbsp;|
 <a href="#" onclick="CallPgm1('%windir%/system32/WindowsPowerShell/v1.0/powershell.exe -noexit ping <%=ip_pc %>')" style="color:#333333">ping</a>&nbsp;|
 <a href="#" onclick="CallPgm1('dwrcc.exe -c: -h: -m:<%=ip_pc %>')" style="color:#6600FF">DW</a>&nbsp;|
 <a href="#" onclick="CallPgm1('mstsc -v <%=ip_pc %>')" style="color:#000099">DR</a>
  </b>                  <% end if %>
                </td>
            </tr>
        </table>

                        <asp:Panel runat="server" ID="FilePanel" Visible="false">
            <table style="width:100%; border:1px solid black;border-top:0px solid black; padding:0px; border-collapse:collapse; background-color:lightgray; margin-top:0px;">
                        <tr>
                <td style="padding:5px; border-top:0px solid black; background-color:lightgray;">
                     <%=globals.ResourceHelper.GetString("String157") %>
                    </td>

                        <td style="width:70%;padding:5px; border-top:0px solid black; border-left:1px solid black; background-color:lightgray;font-weight:bold">
                           <asp:LinkButton runat="server" ID="FileLabel"></asp:LinkButton>
                        </td>
                    </tr>
                </table>

                    </asp:Panel>

          <asp:Panel runat="server" ID="MonitorPanel" Visible="false">
            <table style="width:100%; border:1px solid black; padding:0px; border-collapse:collapse; background-color:#fff1b0; margin-top:20px;">
                     <tr>
                <td style="padding:5px; border-top:1px solid black; background-color:#fff1b0; font-weight:bold" colspan="2">
                     <%=globals.ResourceHelper.GetString("String371") %>
                    </td>
                      </tr>

                    <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fff7d1;">
                            <%=globals.ResourceHelper.GetString("String120") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fff7d1;font-weight:bold">
                           <asp:Label runat="server" ID="MarcaMonitorLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fcfaf0;">
                            <%=globals.ResourceHelper.GetString("String122") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fcfaf0;font-weight:bold">
                           <asp:Label runat="server" ID="ModelloMonitorLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fff7d1;">
                            <%=globals.ResourceHelper.GetString("String372") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fff7d1;font-weight:bold">
                           <asp:Label runat="server" ID="PolliciMonitorLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fcfaf0;">
                            <%=globals.ResourceHelper.GetString("String124") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fcfaf0;font-weight:bold">
                           <asp:Label runat="server" ID="InvMonitorLabel"></asp:Label>
                        </td>
                    </tr>

                                                            <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fff7d1;">
                            <%=globals.ResourceHelper.GetString("String123") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fff7d1;font-weight:bold">
                           <asp:Label runat="server" ID="SerieMonitorLabel"></asp:Label>
                        </td>
                    </tr>

                                  <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fcfaf0;">
                            <%=globals.ResourceHelper.GetString("String128") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fcfaf0;font-weight:bold">
                           <asp:Label runat="server" ID="StatoMonitorLabel"></asp:Label>
                        </td>
                    </tr>

                                                            <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fff7d1;">
                            <%=globals.ResourceHelper.GetString("String131") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fff7d1;font-weight:bold">
                           <asp:Label runat="server" ID="AnnoMonitorLabel"></asp:Label>
                        </td>
                    </tr>

                                                  <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#fcfaf0;">
                            <%=globals.ResourceHelper.GetString("String132") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#fcfaf0;font-weight:bold">
                           <asp:Label runat="server" ID="NoteMonitorLabel"></asp:Label>
                        </td>
                    </tr>
                    </table>
</asp:Panel>

        <asp:Panel runat="server" ID="StampPanel" Visible="false">
            <table style="width:100%; border:1px solid black; padding:0px; border-collapse:collapse; background-color:#bbe5f2; margin-top:20px;">
                        <tr>
                <td style="padding:5px; border-top:1px solid black; background-color:#bbe5f2; font-weight:bold" colspan="2">
                    <%=globals.ResourceHelper.GetString("String373") %> - <a href="../gestione_stampanti/dettagli_stampante.aspx?id_stampante=<%=id_stamp %>"><%=globals.ResourceHelper.GetString("String374") %></a>
                    </td>

                            </tr>

                    <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#d0f0f8;">
                            <%=globals.ResourceHelper.GetString("String120") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#d0f0f8;font-weight:bold">
                           <asp:Label runat="server" ID="MarcaStampanteLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#ecf8fb;">
                            <%=globals.ResourceHelper.GetString("String122") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#ecf8fb;font-weight:bold">
                           <asp:Label runat="server" ID="ModelloStampanteLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#d0f0f8;">
                            <%=globals.ResourceHelper.GetString("String123") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#d0f0f8;font-weight:bold">
                           <asp:Label runat="server" ID="SerieStampanteLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#ecf8fb;">
                            <%=globals.ResourceHelper.GetString("String124") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#ecf8fb;font-weight:bold">
                           <asp:Label runat="server" ID="InvStampanteLabel"></asp:Label>
                        </td>
                    </tr>

                                                            <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#d0f0f8;">
                            <%=globals.ResourceHelper.GetString("String128") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#d0f0f8;font-weight:bold">
                           <asp:Label runat="server" ID="StatoStampanteLabel"></asp:Label>
                        </td>
                    </tr>

                    </table>
</asp:Panel>

         <asp:Panel runat="server" ID="AltroHWPanel" Visible="false">
            <table style="width:100%; border:1px solid black; padding:0px; border-collapse:collapse; background-color:#b7ffb8; margin-top:20px;">
                        <tr>
                <td style="padding:5px; border-top:1px solid black; background-color:#b7ffb8; font-weight:bold" colspan="2">
                    <%=globals.ResourceHelper.GetString("String375") %> - <a href="../gestione_altro_hardware/dettagli_altro_hw.aspx?id_hw=<%=id_hw %>"><%=globals.ResourceHelper.GetString("String381") %></a>
                    </td>

                            </tr>

                    <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#dafed7;">
                            <%=globals.ResourceHelper.GetString("String175") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#dafed7;font-weight:bold">
                           <asp:Label runat="server" ID="TipoHWLabel"></asp:Label>
                        </td>
                    </tr>

                                    <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#ecffea;">
                            <%=globals.ResourceHelper.GetString("String120") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#ecffea;font-weight:bold">
                           <asp:Label runat="server" ID="MarcaHWLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#dafed7;">
                            <%=globals.ResourceHelper.GetString("String122") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#dafed7;font-weight:bold">
                           <asp:Label runat="server" ID="ModelloHWLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#ecffea;">
                            <%=globals.ResourceHelper.GetString("String123") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#ecffea;font-weight:bold">
                           <asp:Label runat="server" ID="SerieHWLabel"></asp:Label>
                        </td>
                    </tr>

                                        <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#dafed7;">
                            <%=globals.ResourceHelper.GetString("String124") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#dafed7;font-weight:bold">
                           <asp:Label runat="server" ID="InvHWLabel"></asp:Label>
                        </td>
                    </tr>

                                                            <tr>
                        <td style="padding:5px; border-top:1px solid black; background-color:#ecffea;">
                            <%=globals.ResourceHelper.GetString("String128") %>
                        </td>

                        <td style="width:70%;padding:5px; border-top:1px solid black; border-left:1px solid black; background-color:#ecffea;font-weight:bold">
                           <asp:Label runat="server" ID="StatoHWLabel"></asp:Label>
                        </td>
                    </tr>

                    </table>
</asp:Panel>

    </form>


</asp:Content>

