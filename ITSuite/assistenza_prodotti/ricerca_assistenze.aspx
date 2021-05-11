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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="ricerca_assistenze.aspx.vb" Inherits="assistenza_prodotti_ricerca_assistenze" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
            <script type="text/javascript">
      var _0xef96=["\x64\x69\x73\x70\x6C\x61\x79","\x73\x74\x79\x6C\x65","\x63\x6E\x74\x72\x2D\x6D\x73\x67","\x67\x65\x74\x45\x6C\x65\x6D\x65\x6E\x74\x42\x79\x49\x64","\x62\x6C\x6F\x63\x6B","\x6E\x6F\x6E\x65","\x73\x63\x72\x6F\x6C\x6C\x49\x6E\x74\x6F\x56\x69\x65\x77","\x70\x68\x6F\x74\x6F\x44\x69\x76","\x63\x6E\x74\x72\x6D\x73\x67","\x68\x69\x64\x65\x54\x6F\x70\x4D\x73\x67\x28\x29","\x73\x65\x74\x54\x69\x6D\x65\x6F\x75\x74","\x57\x53\x63\x72\x69\x70\x74\x2E\x73\x68\x65\x6C\x6C","\x72\x75\x6E","\x2E","\x6C\x61\x73\x74\x49\x6E\x64\x65\x78\x4F\x66","\x6C\x65\x6E\x67\x74\x68","\x73\x75\x62\x73\x74\x72\x69\x6E\x67","\x6A\x70\x67","\x49\x6C\x20\x66\x69\x6C\x65\x20\x64\x65\x76\x65\x20\x61\x76\x65\x72\x65\x20\x65\x73\x74\x65\x6E\x73\x69\x6F\x6E\x65\x20\x6A\x70\x67\x2E","\x72\x65\x73\x65\x74","\x69\x6E\x76\x69\x61\x5F\x66\x6F\x74\x6F\x5F\x73\x74\x61\x6D\x70\x61\x6E\x74\x65","\x43\x6F\x6E\x74\x65\x6E\x74\x50\x6C\x61\x63\x65\x48\x6F\x6C\x64\x65\x72\x43\x65\x6E\x74\x72\x61\x6C\x5F\x63\x6F\x6E\x66\x69\x72\x6D\x5F\x76\x61\x6C\x75\x65","\x56\x75\x6F\x69\x20\x65\x6C\x69\x6D\x69\x6E\x61\x72\x65\x20\x6C\x61\x20\x66\x6F\x74\x6F\x3F","\x76\x61\x6C\x75\x65","\x59\x65\x73","\x73\x75\x62\x6D\x69\x74","\x66\x6F\x72\x6D\x31","\x4E\x6F"];function HideLabel(){document[_0xef96[3]](_0xef96[2])[_0xef96[1]][_0xef96[0]]= _0xef96[4];var _0xd4ecx2=5;setTimeout(function(){document[_0xef96[3]](_0xef96[2])[_0xef96[1]][_0xef96[0]]= _0xef96[5]},_0xd4ecx2* 1000)}function scrollToPhotoDiv(){document[_0xef96[3]](_0xef96[7])[_0xef96[6]]()}function showTopMsg(_0xd4ecx5){document[_0xef96[3]](_0xef96[8])[_0xef96[1]][_0xef96[0]]= _0xef96[4];window[_0xef96[10]](_0xef96[9],3000)}function hideTopMsg(){document[_0xef96[3]](_0xef96[8])[_0xef96[1]][_0xef96[0]]= _0xef96[5]}function CallPgm1(_0xd4ecx8){var _0xd4ecx9= new ActiveXObject(_0xef96[11]);_0xd4ecx9[_0xef96[12]](_0xd4ecx8,1,true)}function get_estensione(_0xd4ecxb){posizione_punto= _0xd4ecxb[_0xef96[14]](_0xef96[13]);lunghezza_stringa= _0xd4ecxb[_0xef96[15]];estensione= _0xd4ecxb[_0xef96[16]](posizione_punto+ 1,lunghezza_stringa);return estensione}function controlla_estensione(_0xd4ecxb){if(get_estensione(_0xd4ecxb)!= _0xef96[17]){alert(_0xef96[18]);document[_0xef96[20]][_0xef96[19]]();return false}}function Confirm(){document[_0xef96[3]](_0xef96[21])[_0xef96[1]][_0xef96[0]]= _0xef96[5];if(confirm(_0xef96[22])){document[_0xef96[3]](_0xef96[21])[_0xef96[23]]= _0xef96[24];document[_0xef96[26]][_0xef96[25]]()}else {document[_0xef96[3]](_0xef96[21])[_0xef96[23]]= _0xef96[27]}}
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String90")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String763")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
                <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">
            </asp:Label>
        </div>
        <asp:Label ID="ScriptLabel" runat="server" Text="" Visible="true"></asp:Label>
    <form name="SearchTicketForm" method="post" action="risultati_ricerca.aspx">
        <div class="contsearchscreen">
            <input name="schterm" type="text" class="search_box_long" placeholder='<%=globals.ResourceHelper.GetString("String117")%>' style="border:1px solid black;"/>
            <select name="typsearch" class="select-order-searcher">
                <option value="only"><%=globals.ResourceHelper.GetString("String485")%></option>
                <option value="free"><%=globals.ResourceHelper.GetString("String250")%></option>
            </select>
            <input type="submit" class="submit-button-search" value='<%=globals.ResourceHelper.GetString("String251")%>' />
        </div>

    </form>
</asp:Content>