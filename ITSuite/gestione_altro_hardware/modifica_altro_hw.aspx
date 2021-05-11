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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="modifica_altro_hw.aspx.vb" Inherits="gestione_altro_hardware_modifica_altro_hw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/javascript">
      function HideLabel() {
          document.getElementById("cntr-msg").style.display = "block";
          var seconds = 5;
          setTimeout(function () {
              document.getElementById("cntr-msg").style.display = "none";
          }, seconds * 1000);
      };

      function scrollToPhotoDiv() {
          document.getElementById('photoDiv').scrollIntoView();
      }

      function showTopMsg(msg) {
          document.getElementById('cntrmsg').style.display = 'block';
          window.setTimeout("hideTopMsg()", 3000);
      }

      function hideTopMsg() {
          document.getElementById('cntrmsg').style.display = 'none';
      }

      function CallPgm1(cmd) {
          var shell = new ActiveXObject("WScript.shell");
          shell.run(cmd, 1, true);
      };


      function get_estensione(path) {
          posizione_punto = path.lastIndexOf(".");
          lunghezza_stringa = path.length;
          estensione = path.substring(posizione_punto + 1, lunghezza_stringa);
          return estensione;
      };

      function controlla_estensione(path) {
          if (get_estensione(path) != "jpg") {
              alert("<%=globals.ResourceHelper.GetString("String473")%>"); document.invia_foto_stampante.reset(); return false;
          }
      };

      function Confirm() {
          document.getElementById('ContentPlaceHolderCentral_confirm_value').style.display = 'none';
          if (confirm("<%=globals.ResourceHelper.GetString("String472")%>")) {
              document.getElementById('ContentPlaceHolderCentral_confirm_value').value = "Yes";
              document.form1.submit();
          } else {
              document.getElementById('ContentPlaceHolderCentral_confirm_value').value = "No";
          }
      }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
     <%= globals.ResourceHelper.GetString("String169") %>  (ID <%=id_hw%>)
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
          <%= globals.ResourceHelper.GetString("String162") %>: <b><%=activeUser%></b>.

                  <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalform.submit();">
   <img src="../img/logo_conferma-salva.png" alt="Modifica" style="border:0px solid black; text-decoration:none; margin-top:0px;" />
                     </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" Runat="Server">
     <div class="cntr-msg" id="cntr-msg">
<asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

</asp:Label>
</div>
    
          <form name="generalform" action="salva_dati_hw.aspx">
                <input type="hidden" name="id_hw" id="id_hw" value="<%=id_hw%>" />

              <!-- Driver -->
                      <div class="details-entire-line-white">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String164") %>  <i style="color:gray">(.../...)</i>:
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="cartella_hw" value="<%=cartella_hw %>" />
            </div>
            </div>

              <!-- Tipo hw -->
                      <div class="details-entire-line-gray">
    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String51") %>
    </div>
    <div class="section-data-pc">
        <select name="tipo_hardware" class="selector-modifica-elementi">
            <option value="<%=tipo_hardware %>">(In uso) <%=tipo_hardware %></option>
            <% ITSuite_Listing.AltroHW.OpenSelectorTipiHW() %>
            </select>

    </div>
    </div>

              <!-- Marca -->
              <div class="details-entire-line-white">
    <div class="section-data-pc-intest">
        Marca: 
    </div>
    <div class="section-data-pc">
        <select name="marca_hardware" class="selector-modifica-elementi">
            <option value="<%=marca_hardware %>"><%= globals.ResourceHelper.GetString("String173") %>&nbsp;<%=marca_hardware %></option>
         <% ITSuite_Listing.Marche.OpenSelectorMarcheHwConnection() %>
            </select>

    </div>
    </div>

              <!-- Modello -->
              <div class="details-entire-line-gray">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String122") %>:
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="modello_hardware" value="<%=modello_hardware %>" />
            </div>
            </div>

                            <!-- S/N -->
              <div class="details-entire-line-white">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String123") %>: 
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="serie_hardware" value="<%=serie_hardware %>" />
            </div>
            </div>

            <!-- Numero inventario -->
              <div class="details-entire-line-gray">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String124") %>: 
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="inventario_hardware" value="<%=inventario_hardware %>" />
            </div>
            </div>

           <!-- Anno -->
              <div class="details-entire-line-white">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String131") %>: 
    </div>
            <div class="section-data-pc">
 <select name="anno_hardware" class="selector-modifica-elementi">
<option value="<%=anno_hardware %>">(In Uso) <%=anno_hardware %></option>
<option value="Sconosciuto"><%= globals.ResourceHelper.GetString("String165") %></option>
<% ITSuite_Listing.Anni.OpenSelectorAnni() %>
     </select>
            </div>
            </div>

           <!-- Indirizzo IP -->
              <div class="details-entire-line-gray">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String130") %>: 
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="ip_hardware" value="<%=ip_hardware %>" />
            </div>
            </div>

           <!-- Presidio -->
              <div class="details-entire-line-white">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String127") %>: 
    </div>
            <div class="section-data-pc">
               
<select name="presidio_hw" class="selector-modifica-elementi">
<option value="<%=presidio_hw%>"><%= globals.ResourceHelper.GetString("String173") %>&nbsp;<%=presidio_hw%></option>
    <% ITSuite_Listing.Ubicazioni.OpenSelectorPresidiConnection() %>
 </select>
            </div>
            </div>

                <!-- Reparto -->
              <div class="details-entire-line-gray">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String125") %>: 
    </div>
            <div class="section-data-pc">
               
<select name="reparto_hw" class="selector-modifica-elementi">
<option value="<%=reparto_hw%>"><%= globals.ResourceHelper.GetString("String173") %>&nbsp;<%=reparto_hw%></option>
    <%  ITSuite_Listing.Ubicazioni.OpenSelectorRepartiConnection() %>
 </select>
            </div>
            </div>

 <!-- Padiglione -->
              <div class="details-entire-line-white">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String126") %>: 
    </div>
            <div class="section-data-pc">
               
<select name="padiglione_hw" class="selector-modifica-elementi">
<option value="<%=padiglione_hw%>"><%= globals.ResourceHelper.GetString("String173") %>&nbsp;<%=padiglione_hw%></option>
    <%  ITSuite_Listing.Ubicazioni.OpenSelectorPadiglioniConnection() %>
 </select>
            </div>
            </div>

              <!-- Stato -->
              <div class="details-entire-line-gray">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String128") %>: 
    </div>
            <div class="section-data-pc">
               
          <select name="stato_hardware" class="selector-modifica-elementi">
<option value="<%=stato_hardware%>"><%= globals.ResourceHelper.GetString("String173") %>&nbsp;<%=stato_hardware%></option>
    <%  ITSuite_Listing.Stati.OpenSelectorStatiConnection() %>
 </select>
            </div>
            </div>

               <!-- Note -->
              <div class="details-entire-line-white">

    <div class="section-data-pc-intest">
        <%= globals.ResourceHelper.GetString("String132") %>: 
    </div>
            <div class="section-data-pc">
                <input type="text" class="input-modifica-elementi" name="note_hardware" value="<%=note_hardware %>" />
            </div>
            </div>

              </form>
    </div>
        <div class="div-central" style="border-top:1px solid lightgray; border-bottom:1px solid lightgray; min-height:0px; " >
           <div class="section-data-pc" style="font-size:18px; width:100%">
       <u><%= globals.ResourceHelper.GetString("String157") %></u>
    </div>
              <div class="details-entire-line-white" style="height:auto; overflow:auto;">

            <div id="photoDiv" class="section-data-pc" style="width:100%;">
        
           <form id="form1" runat="server">
               <input type="hidden" runat="server" id="confirm_value" />

               <asp:LinkButton ID="LabelInfoPhoto" Text="" runat="server" CausesValidation="false"></asp:LinkButton>
               <asp:Label ID="DivisionBar" Text="|" runat="server" Font-Bold="true" />
               <asp:LinkButton ID="LinkDeletePhoto" OnClick="LinkDeletePhoto_Click" CausesValidation="false" runat="server" OnClientClick="Confirm();return false;" />
               <br /><br />
                <asp:FileUpload ID="PhotoUpload" runat="server" />
               <asp:Button ID="ButtonUploadPhoto" runat="server" Text="Upload" OnClick="ButtonUploadPhoto_Click" />
         
                  
             </form>

                     </div>
            </div>
</asp:Content>

