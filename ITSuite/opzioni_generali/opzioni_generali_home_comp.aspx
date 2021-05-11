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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="opzioni_generali_home_comp.aspx.vb" Inherits="opzioni_generali_opzioni_generali_home_comp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <div class="HorizontalTopMenuContainer">
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home.aspx'" style="border-left: 1px solid lightgray;">
            <a href="../opzioni_generali/opzioni_generali_home.aspx" title='<%=globals.ResourceHelper.GetString("String26")%>'><%=globals.ResourceHelper.GetString("String26")%></a>
        </div>
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../gestione_liste/gestione_liste_home.aspx'">
            <a href="../gestione_liste/gestione_liste_home.aspx" title='<%=globals.ResourceHelper.GetString("String101")%>'><%=globals.ResourceHelper.GetString("String101")%></a>
        </div>
        <div class="HorizontalTopMenuItemNotSelected">
            <a href="../opzioni_generali/opzioni_generali_home_swaz.aspx" title='<%=globals.ResourceHelper.GetString("String94")%>'><%=globals.ResourceHelper.GetString("String94")%></a>
        </div>
        <div class="HorizontalTopMenuItemSelected">
            <%=globals.ResourceHelper.GetString("String103")%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String683")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
    <div class="cntr-msg" id="cntr-msg">
        <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true" />
        <asp:Label runat="server" ID="ScriptLabel" Visible="true"></asp:Label>
    </div>

    <div class="title-container-listpage-first">
        <%=globals.ResourceHelper.GetString("String684")%>
    </div>

    <div style="margin-top: 10px;">
        <asp:Label ID="LabelAddsOnInstalled" runat="server"></asp:Label>
    </div>

    <div class="title-container-listpage-first" style="margin-top: 20px;">
        <%=globals.ResourceHelper.GetString("String685")%>
    </div>

    <div style="margin-top: 10px;">
        <div id="AddOnDiv" class="section-data-pc" style="width: 100%;">
            <form runat="server" name="InstallAddOnForm">
                <asp:Label ID="TitleInstallAddOn" Text="" runat="server" Font-Bold="true" />
                <br />
                <br />
                <asp:FileUpload ID="AddOnUpload" runat="server" />
                <asp:Button ID="ButtonUploadAddOn" runat="server" Text='<%#globals.ResourceHelper.GetString("String441")%>' OnClick="ButtonUploadAddOn_Click" />
            </form>
        </div>
    </div>

</asp:Content>

