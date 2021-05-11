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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="dettagli_assistenza.aspx.vb" Inherits="assistenza_prodotti_dettagli_assistenza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function HideLabel() {
            document.getElementById("cntr-msg").style.display = "block";
            var seconds = 7;
            setTimeout(function () {
                document.getElementById("cntr-msg").style.display = "none";
            }, seconds * 1000);
        };

        function printDiv() {
            var printContents = document.getElementById("GeneralDetailsContainerTable").innerHTML + "<br />" + document.getElementById("ContentPlaceHolderCentral_prodass").innerHTML + "<br />" + document.getElementById("ContentPlaceHolderCentral_dettagli1").innerHTML + "<br />" + document.getElementById("ContentPlaceHolderCentral_chiusurapanel").innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String746")%><%=idass %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <%=globals.ResourceHelper.GetString("String747")%><%=idass %>
    <div class="settings-button-right-title">
        <img src="../img/logo_edit.png" onclick="toggle_visibility('container-settings', this);" alt="Modifica" style="border: 0px solid black; text-decoration: none; margin-top: 0px; opacity: 0.6" />

        <div class="container-settings" id="container-settings" style="display: none;">

            <div class="context-menu-settings-pc-details" id="dettagli-pc-context-settings-menu">

                <div class="list-settings-menu" onclick="document.getElementById('container-settings').style.display='none'; printDiv();">
                    <%=globals.ResourceHelper.GetString("String194")%>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">

        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

            </asp:Label>
        </div>
        <div id="GeneralDetailsContainerTable">
            <asp:DetailsView OnDataBound="DetailsView1_DataBound" ID="DetailsView1" runat="server" Style="width: 100%;" CellPadding="5" AutoGenerateRows="False" DataKeyNames="ID" DataSourceID="DetailsAssSql">
                <FieldHeaderStyle Font-Bold="false" />
                <RowStyle BackColor="White" Font-Bold="true" />
                <AlternatingRowStyle BackColor="LightGray" />
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="data_apertura" SortExpression="data_apertura" />
                    <asp:BoundField DataField="ora_apertura" SortExpression="ora_apertura" />
                    <asp:BoundField DataField="autore_apertura" SortExpression="autore_apertura" />
                    <asp:BoundField DataField="intestazione_apertura" SortExpression="intestazione_apertura" />
                    <asp:BoundField DataField="dettagli_apertura" SortExpression="dettagli_apertura" />
                    <asp:BoundField DataField="stato" SortExpression="stato" />
                </Fields>
            </asp:DetailsView>
        </div>
        <asp:SqlDataSource ID="DetailsAssSql" runat="server" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:Panel runat="server" ID="prodass" class="paneldetails-displayupdates" Style="background-color: #eef9ff">
            <div style="width: auto;">
                <b><u><%=globals.ResourceHelper.GetString("String748")%>:</u></b>
            </div>
            <asp:Label ID="prodasslabel" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="dettagli1">
            <asp:Label ID="dettagli1text" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="chiusurapanel">
            <asp:Label ID="chiusuratext" runat="server"></asp:Label>
        </asp:Panel>

        <asp:Panel runat="server" ID="addupdatepanel" CssClass="paneldetails-displayupdates">
            <%#globals.ResourceHelper.GetString("String211")%>
            <div style="width: 100%; height: auto; margin-top: 5px;">
                <asp:TextBox runat="server" TextMode="MultiLine" Style="height: 100px; width: 100%; box-sizing: border-box;" ID="TextNewUpdate" placeholder='<%#globals.ResourceHelper.GetString("String749")%>'></asp:TextBox>
                <asp:Button runat="server" Text='<%#globals.ResourceHelper.GetString("String211")%>' CssClass="button-nets" ID="AddUpdateButton" OnClick="AddUpdateButton_Click" />
                <asp:Button runat="server" Text='<%#globals.ResourceHelper.GetString("String750")%>' CssClass="button-nets" Style="background-color: #ffa6a6" ID="ChiudiRichiestaButton" OnClick="ChiudiRichiestaButton_Click" />
            </div>
        </asp:Panel>

    </form>

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
</asp:Content>

