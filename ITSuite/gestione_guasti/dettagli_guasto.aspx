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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="dettagli_guasto.aspx.vb" Inherits="gestione_guasti_dettagli_guasto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function HideLabel() {
            document.getElementById("cntr-msg").style.display = "block";
            var seconds = 7;
            setTimeout(function () {
                document.getElementById("cntr-msg").style.display = "none";
            }, seconds * 1000);
        };

        function printDiv() {
            var printContents = document.getElementById("generalDivContainer").innerHTML
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String190") %> <%=idguasto %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <%=globals.ResourceHelper.GetString("String191") %> <%=idguasto %>
    <div class="settings-button-right-title">
        <img src="../img/logo_edit.png" onclick="toggle_visibility('container-settings', this);" alt="Modifica" style="border: 0px solid black; text-decoration: none; margin-top: 0px; opacity: 0.6" />
        <div class="container-settings" id="container-settings" style="display: none;">
            <div class="context-menu-settings-pc-details" id="dettagli-pc-context-settings-menu">
                <% If status <> "chiusa" And Session("Autenticato") = "admin" Then %>
                <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none';document.getElementById('BackCover').style.display='block';document.getElementById('ChangeAssignScreen').style.display='block';">
                    <%=globals.ResourceHelper.GetString("String192") %>
                </div>
                <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none';document.getElementById('BackCover').style.display='block';document.getElementById('ChangeClientScreen').style.display='block';">
                    <%=globals.ResourceHelper.GetString("String193") %>
                </div>
                <% End If %>
                <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none'; printDiv();">
                    <%=globals.ResourceHelper.GetString("String194") %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">

          <div class="backCoverWhite" id="BackCover" style="display: none;">
            &nbsp;
        </div>
        <% If status <> "chiusa" Then %>
        <div class="cntr-msg" id="ChangeAssignScreen" style="z-index: 150000">
             <asp:Label ID="TitleNewAssign" runat="server"></asp:Label>
            <br /><br />
            <form name="NewAssignForm" method="post" action="dettagli_guasto.aspx?id=<%=idguasto %>&t=naf">
            <select name="Usertoassign" style="width:200px;height:30px;">
                <asp:Label runat="server" ID="LabelListUserTech"></asp:Label>
            </select>
            <br /> 
          <input type="submit" value="OK" id="OkAssign" style="margin-top: 20px; background-color: lightgreen; height: 30px; width: 70px; border: 1px solid black;" onclick="document.getElementById('ChangeAssignScreen').style.display = 'none'; document.getElementById('BackCover').style.display = 'none'; document.NewAssignForm.submit();" />
            <input type="button" value='<%=globals.ResourceHelper.GetString("String46") %>' id="UndoNewAssign" style="margin-top: 20px; background-color: lightpink; height: 30px; width: 70px; border: 1px solid black;" onclick="document.getElementById('ChangeAssignScreen').style.display = 'none'; document.getElementById('BackCover').style.display = 'none';" />
            </form>
        </div>

            <div class="cntr-msg" id="ChangeClientScreen" style="z-index: 150000">
             <asp:Label ID="LabelTitleNewClientAssign" runat="server"></asp:Label>
            <br /><br />
            <form name="NewClientForm" method="post" action="dettagli_guasto.aspx?id=<%=idguasto %>&t=ncf">
            <select name="Clienttoassign" style="width:200px;height:30px;">
                <asp:Label runat="server" ID="LabelNewClientAssign"></asp:Label>
            </select>
            <br /> 
          <input type="submit" value="OK" id="OkAssignClient" style="margin-top: 20px; background-color: lightgreen; height: 30px; width: 70px; border: 1px solid black;" onclick="document.getElementById('ChangeClientScreen').style.display = 'none'; document.getElementById('BackCover').style.display = 'none'; document.NewClientForm.submit();" />
            <input type="button" value='<%=globals.ResourceHelper.GetString("String46") %>' id="UndoNewAssignClient" style="margin-top: 20px; background-color: lightpink; height: 30px; width: 70px; border: 1px solid black;" onclick="document.getElementById('ChangeClientScreen').style.display = 'none'; document.getElementById('BackCover').style.display = 'none';" />
            </form>
        </div>
        <% End if %>

      <form runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">
            </asp:Label>
        </div>

          <div style="width:100%;height:auto;" id="generalDivContainer">
                    <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String189") %>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DetailsView OnDataBound="DetailsView1_DataBound" ID="DetailsView1" runat="server" Style="width: 100%;" CellPadding="5" AutoGenerateRows="False" DataKeyNames="ID" DataSourceID="DettaglioGuastiSource">
                    <FieldHeaderStyle Font-Bold="false" />
                    <RowStyle BackColor="White" Font-Bold="true" />
                    <AlternatingRowStyle BackColor="LightGray" />
                    <Fields>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="intestazione" SortExpression="intestazione" />
                        <asp:BoundField DataField="corpo" SortExpression="corpo" />
                        <asp:BoundField DataField="presidio" SortExpression="presidio" />
                        <asp:BoundField DataField="padiglione" SortExpression="padiglione" />
                        <asp:BoundField DataField="reparto" SortExpression="reparto" />
                        <asp:BoundField DataField="ubicazione_guasto" SortExpression="ubicazione_guasto" />
                        <asp:BoundField DataField="autore_apertura" SortExpression="autore_apertura" />
                        <asp:BoundField DataField="data" SortExpression="data" />
                        <asp:BoundField DataField="ora" SortExpression="ora" />
                        <asp:BoundField DataField="dettagli1" SortExpression="dettagli1" />
                        <asp:BoundField DataField="autore_dettagli1" SortExpression="autore_dettagli1" />
                        <asp:BoundField DataField="stato" SortExpression="stato" />
                    </Fields>
                </asp:DetailsView>

                <asp:SqlDataSource ID="DettaglioGuastiSource" runat="server" ProviderName="System.Data.SqlClient">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>

        <script type="text/javascript">
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

         <div style="width:100%; height:auto; border:1px solid black; padding:5px; box-sizing:border-box; margin-top:15px; margin-bottom:0px; background-color:#ffddb3">
            <asp:Label ID="LabelUserReq" runat="server" ></asp:Label>
        </div>

             <asp:Panel runat="server" ID="UpoloadedFilepanel" Visible="false">
              <br />
  <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String195") %>
        </div>
          <asp:Panel runat="server" ID="filepanel">
            <asp:Label ID="dettaglifilepanel" runat="server"></asp:Label>
        </asp:Panel>
                 </asp:Panel>

        <asp:Panel runat="server" ID="updatesScreen" Visible="false">           
               <br />
            <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String196") %>
        </div>

        <asp:Panel runat="server" ID="attesapanel">
            <asp:Label ID="attesatext" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="dettagli2">
            <asp:Label ID="dettagli2text" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="dettagli3">
            <asp:Label ID="dettagli3text" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="dettagli4">
            <asp:Label ID="dettagli4text" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="dettagli5">
            <asp:Label ID="dettagli5text" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="chiusurapanel">
            <asp:Label ID="chiusuratext" runat="server"></asp:Label>
        </asp:Panel>
     </asp:Panel>

   <asp:Panel runat="server" ID="UpdatesClientPanelContainer" Visible="false">
       <br />
        <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String197") %>
        </div>
               <asp:Panel runat="server" ID="UpdatesClientPanel">
            <asp:Label ID="UpdatesClienti" runat="server"></asp:Label>
        </asp:Panel>
</asp:Panel>
</div>

        <asp:Panel runat="server" ID="addupdatepanel" Style="padding: 0px;" class="paneldetails-displaynone">
                     <br />
          <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String198") %>
        </div>
            <div style="margin-top: 0px; width: 100%; border: 1px solid gray; border-bottom:0px solid gray; padding: 5px; padding-bottom: 10px; padding-top: 10px; box-sizing: border-box; background-color: lightgray">
               <%=globals.ResourceHelper.GetString("String199") %>
            </div>
            <div style="width: 100%; height: auto; margin-top: 0px; padding: 5px; padding-top: 5px; box-sizing: border-box; background-color: lightgray;border: 1px solid gray; border-top:0px solid gray;">
                <asp:TextBox runat="server" TextMode="MultiLine" Style="height: 100px; width: 100%; box-sizing: border-box;" ID="TextNewUpdate" placeholder='<%# globals.ResourceHelper.GetString("String200") %>'></asp:TextBox>
              <% if Session("emailenabled") = "1" Then %>
                <div style="width: 100%; height: auto;padding-top:10px;padding-bottom:10px;border-bottom:1px solid #494949; ">
                    <asp:CheckBox runat="server" ID="chkSendMailToUser" Text='<%# globals.ResourceHelper.GetString("String201") %>' />
                </div>
                <% End if %>
                
                <% if (Session("Autenticato") = "admin" And Not isMyTicket) Or (Session("Autenticato") = "personale" And Not isMyTicket) Then %>
                
           <div style="width: 100%; height: auto;padding:0px; padding-bottom:10px;border-bottom:1px solid #494949;border-top:0px solid #494949; box-sizing:border-box; margin-top:10px;">
           <asp:CheckBox runat="server" ID="CheckBoxVisible" Text='<%# globals.ResourceHelper.GetString("String202") %>' /><br />

             <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String203") %>' CssClass="button-nets" ID="AddUpdateButton" OnClick="AddUpdateButton_Click" Width="280" />
           </div>
                           <div style="width: 100%; height: auto;padding-top:5px; padding-bottom:10px;border-bottom:1px solid #494949;border-top:0px solid #494949; box-sizing:border-box; margin-top:0px;">
                               <asp:Label runat="server" ID="LabelAlwaysVisible" Text='<%# globals.ResourceHelper.GetString("String204") %>'></asp:Label><br />
                <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String205") %>' CssClass="button-nets" Style="background-color: #ffef98" ID="AttesaticketButton" Width="280" OnClick="AttesaticketButton_Click" />
                       </div>
                           <div style="width: 100%; height: auto;padding-top:5px; padding-bottom:5px;border-bottom:0px solid #494949;border-top:0px solid #494949; box-sizing:border-box; margin-top:0px;">
                                <asp:Label runat="server" ID="LabelAlwaysVisibleClosing" Text='<%# globals.ResourceHelper.GetString("String206") %>'></asp:Label><br />
                               <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String207") %>' CssClass="button-nets" Style="background-color: #ffa6a6" ID="ChiuditicketButton" Width="280" OnClick="ChiuditicketButton_Click" />
          </div>
                               <% End If %>

           <% if Session("Autenticato") = "cliente" Or isMyTicket Then %>
                <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String211") %>' CssClass="button-nets" ID="AddDetailsClient" OnClick="AddDetailsClient_Click" />
           <% End if %>

                </div>
    
            <div style="margin-top: 5px; width: 100%; border: 1px solid gray; border-bottom:0px solid gray; padding: 5px; padding-bottom: 10px; padding-top: 10px; box-sizing: border-box;">
                <%# globals.ResourceHelper.GetString("String208") %>
            </div>
            <div style="width: 100%; height: auto; margin-top: 0px; padding: 5px; box-sizing: border-box;border: 1px solid gray; border-top:0px solid gray;">
                <asp:TextBox runat="server" TextMode="MultiLine" Style="height: 50px; width: 100%; box-sizing: border-box;" ID="TextBoxUploadFileTkt" placeholder='<%# globals.ResourceHelper.GetString("String209") %>'></asp:TextBox>
                <asp:FileUpload runat="server" ID="UploadFileTkt" Style="margin-top: 5px;" />
                <br />
                <asp:Panel runat="server" ID="PanelErr" Visible="false">
                    <asp:Label runat="server" ID="ErrMsg" ForeColor="Red"></asp:Label>
                    <br />
                </asp:Panel>

                  <% if (Session("Autenticato") = "admin" And Not isMyTicket) Or (Session("Autenticato") = "personale" And Not isMyTicket) Then %>
                <div style="padding-top:5px;">
                           <asp:CheckBox runat="server" ID="CheckBoxVisibileClienteFile" Text='<%# globals.ResourceHelper.GetString("String202") %>' /><br />
                </div>
                <% End If %>

                <asp:Button runat="server" Text='<%# globals.ResourceHelper.GetString("String210") %>' CssClass="button-nets" ID="ButtonUpload" Style="background-color: #bcdefe" OnClick="ButtonUpload_Click" />
            </div>

        </asp:Panel>

    </form>
</asp:Content>

