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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="dettagli_utente.aspx.vb" Inherits="gestione_utenti_dettagli_utente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%= globals.ResourceHelper.GetString("String54") %> ID <%=iduser%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
     <%= globals.ResourceHelper.GetString("String62") %>ID <%=iduser%>
    <div class="settings-button-right-title">
        <img src="../img/logo_edit.png" onclick="toggle_visibility('container-settings', this);" alt="Modifica" style="border: 0px solid black; text-decoration: none; margin-top: 0px; opacity: 0.6" />

        <div class="container-settings" id="container-settings" style="display: none;">

            <div class="context-menu-settings-pc-details" id="dettagli-pc-context-settings-menu">

                <% If Session("Autenticato") = "admin" Then %>
                <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none';location.href='../gestione_utenti/modifica_utente.aspx?id=<%=iduser%>'">
                   <%= globals.ResourceHelper.GetString("String41") %>
                </div>
                <% End If %>
                <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none';document.getElementById('BackCover').style.display='block';document.getElementById('ChangePswScreen').style.display='block';">
                    <%= globals.ResourceHelper.GetString("String42") %>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsgText" Text="" Visible="true">

            </asp:Label>
        </div>

        <div class="backCoverWhite" id="BackCover" style="display: none;">
            &nbsp;
        </div>

        <div class="cntr-msg" id="ChangePswScreen" style="z-index: 150000">

            <asp:Label ID="TitleNewAssign" Text="fd" runat="server" Font-Bold="true"></asp:Label>
            <br />
            <br />
             <%= globals.ResourceHelper.GetString("String43") %> (<%=actUser%>):
        <br />
            <asp:TextBox ID="TextBoxActUserPsw" runat="server" Width="200" Height="35" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <%= globals.ResourceHelper.GetString("String44") %>
        <br />
            <asp:TextBox ID="TextBoxNewPsw1" runat="server" Width="200" Height="35" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <%= globals.ResourceHelper.GetString("String45") %>
        <br />
            <asp:TextBox ID="TextBoxNewPsw2" runat="server" Width="200" Height="35" TextMode="Password"></asp:TextBox>

            <asp:Button Text="OK" ID="OkNewPsw" runat="server" Style="margin-top: 40px; border: 1px solid black" Height="30" Width="50" BackColor="LightGreen" OnClick="OkNewPsw_Click" />
            <input type="button" value=' <%# globals.ResourceHelper.GetString("String46") %>' id="UndoNewAssign" runat="server" style="margin-top: 40px; background-color: lightpink; height: 30px; width: 70px; border: 1px solid black;" onclick="document.getElementById('ChangePswScreen').style.display = 'none'; document.getElementById('BackCover').style.display = 'none';" />

        </div>

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
               <asp:Label ID="UsernameLabel" runat="server"></asp:Label>
               <br />
               <asp:Label ID="CognomeLabel" runat="server"></asp:Label>
               <br />
               <asp:Label ID="NomeLabel" runat="server"></asp:Label>
               <br />
                <asp:Label ID="EmailLabel" runat="server"></asp:Label>
               <br />
               <asp:Label ID="TipoLabel" runat="server"></asp:Label>
   </div>
        </div>

        <asp:DetailsView OnDataBound="DetailsView1_DataBound" ID="DetailsView1" runat="server" Style="width: 100%;" CellPadding="5" AutoGenerateRows="False" DataKeyNames="ID" DataSourceID="DetailsUserSqlSource">
            <FieldHeaderStyle Font-Bold="false" />
            <RowStyle BackColor="White" Font-Bold="true" />
            <AlternatingRowStyle BackColor="LightGray" />
            <Fields>
                <asp:BoundField DataField="matricola_utente" SortExpression="matricola_utente" />
                <asp:BoundField DataField="dettagli_utente" SortExpression="dettagli_utente" />
                <asp:BoundField DataField="database_utente" SortExpression="database_utente" />
                <asp:BoundField DataField="creato_da" SortExpression="creato_da" />
                <asp:BoundField DataField="ubicazione_utente" SortExpression="ubicazione_utente" />
                <asp:BoundField DataField="data_creazione_utente" SortExpression="data_creazione_utente" />
                <asp:BoundField DataField="ora_creazione_utente" SortExpression="ora_creazione_utente" />
                <asp:BoundField DataField="note_utente" SortExpression="note_utente" />
                <asp:BoundField DataField="stato_utente" SortExpression="note_utente" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="DetailsUserSqlSource" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
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

       <div style="width:100%; box-sizing:border-box; border:1px solid black; padding:10px; margin-top:10px;">
        <b><%= globals.ResourceHelper.GetString("String52") %>:</b>
        <br />
           <div style="width:100%; margin-top:5px;">
        <asp:DropDownList runat="server" ID="DropDownLangList" Width="100%" Height="35">
        </asp:DropDownList>
           </div>

           <div style="width:100%; margin-top:5px;">
               <asp:Button runat="server" ID="ButtonSaveLang" Text='<%# globals.ResourceHelper.GetString("String28") %>' style="width:150px; height:35px;" OnClick="ButtonSaveLang_Click" />
           </div>
    </div>

 </form>


</asp:Content>

