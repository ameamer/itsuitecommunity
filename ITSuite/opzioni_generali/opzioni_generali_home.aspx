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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="opzioni_generali_home.aspx.vb" Inherits="opzioni_generali_opzioni_generali_home" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <div class="HorizontalTopMenuContainer">
        <div class="HorizontalTopMenuItemSelected" style="border-left: 1px solid lightgray;">
            <%=globals.ResourceHelper.GetString("String26")%>
        </div>
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../gestione_liste/gestione_liste_home.aspx'">
            <a href="../gestione_liste/gestione_liste_home.aspx" title='<%=globals.ResourceHelper.GetString("String101")%>'><%=globals.ResourceHelper.GetString("String101")%></a>
        </div>
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home_swaz.aspx'">
            <a href="../opzioni_generali/opzioni_generali_home_swaz.aspx" title='<%=globals.ResourceHelper.GetString("String94")%>'><%=globals.ResourceHelper.GetString("String94")%></a>
        </div>
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home_comp.aspx'">
            <a href="../opzioni_generali/opzioni_generali_home_comp.aspx" title='<%=globals.ResourceHelper.GetString("String103")%>'><%=globals.ResourceHelper.GetString("String103")%></a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" runat="Server">
    <%=globals.ResourceHelper.GetString("String629")%>

         <div class="settings-button-right-title" title="<%=globals.ResourceHelper.GetString("String28") %>" onclick="document.generalForm.submit();">
             <img src="../img/logo_conferma-salva.png" alt="<%=globals.ResourceHelper.GetString("String28") %>" style="border: 0px solid black; text-decoration: none; margin-top: 0px;" />
         </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

            </asp:Label>
        </div>
    </form>

    <form name="generalForm" method="post" action="salva_opzioni.aspx">
                <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String630")%>
        </div>
              <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="srvgenerallabel"><%=globals.ResourceHelper.GetString("String658") %></label>
            <br />
            <input type="text" style="height:35px; font-size:14px;" class="input-modifica-elementi" name="srvgeneral" value="<%=srvgen %>" id="srvgeneral" placeholder='<%=globals.ResourceHelper.GetString("String630")%>' />
                  <font style="color:gray;font-size:small; font-style:italic">
                   <%=globals.ResourceHelper.GetString("String631")%>   
              </font>
              </div>

        <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String632")%>   
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="enableTechUsers" value="1" id="enableTechUsers" <% If tchusr = "1" Then Response.Write("checked='checked'") %> />
            <label for="enableTechUsers"><%=globals.ResourceHelper.GetString("String633")%></label>
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="enableTechUsersToMod" value="1" id="enableTechUsersToMod" <% If tchusrmod = "1" Then Response.Write("checked='checked'") %> />
            <label for="enableTechUsersToMod"><%=globals.ResourceHelper.GetString("String635")%></label>
        </div>

        <div style="margin-top: 10px;">
            <input type="checkbox" name="enableTechUsersToAss" value="1" id="enableTechUsersToAss" <% If tchusrass = "1" Then Response.Write("checked='checked'") %> />
            <label for="enableTechUsersToAss"><%=globals.ResourceHelper.GetString("String636")%></label>
        </div>

        <div class="title-container-listpage-first" style="margin-top: 20px;">
            <%=globals.ResourceHelper.GetString("String637")%>
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="enableTicketing" value="1" id="enableTicketing" <% If gestguast = "1" Then Response.Write("checked='checked'") %> />
            <label for="enableTicketing"><%=globals.ResourceHelper.GetString("String638")%></label>
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="enableSw" value="1" id="enableSw" <% If enableintsw = "1" Then Response.Write("checked='checked'") %> />
            <label for="enableSw"><%=globals.ResourceHelper.GetString("String639")%></label>
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="assProd" value="1" id="assProd" <% If enableassprd = "1" Then Response.Write("checked='checked'") %> />
            <label for="assProd"><%=globals.ResourceHelper.GetString("String640")%></label>
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="ServWin" value="1" id="ServWin" <% If enablewinsvc = "1" Then Response.Write("checked='checked'") %> />
            <label for="ServWin"><%=globals.ResourceHelper.GetString("String641")%></label>
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="ServNet" value="1" id="ServNet" <% If enablenet = "1" Then Response.Write("checked='checked'") %> />
            <label for="ServNet"><%=globals.ResourceHelper.GetString("String642")%></label>
        </div>

        <div class="title-container-listpage-first" style="margin-top: 20px;">
            <%=globals.ResourceHelper.GetString("String643")%>
        </div>
        <div style="margin-top: 10px;">
            <input type="checkbox" name="AutoIP" value="1" id="AutoIP" <% If autoipint = "1" Then Response.Write("checked='checked'") %> />
            <label for="AutoIP"><%=globals.ResourceHelper.GetString("String644")%></label>
        </div>
        <div style="margin-top: 10px; margin-bottom: 10px;">
            <input type="checkbox" name="NetInt" value="1" id="NetInt" <% If enableservnet = "1" Then Response.Write("checked='checked'") %> />
            <label for="NetInt"><%=globals.ResourceHelper.GetString("String645")%></label>
        </div>

        <div class="title-container-listpage-first" style="margin-top: 20px;">
            <%=globals.ResourceHelper.GetString("String646")%>
        </div>
        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="PagingN"><%=globals.ResourceHelper.GetString("String647")%></label>
            <br />
            <input type="text" class="input-modifica-elementi" name="PagingN" value="<%=resultpaging %>" id="PagingN" />
        </div>

        <div class="title-container-listpage-first" style="margin-top: 20px;">
            <%=globals.ResourceHelper.GetString("String648")%>
        </div>
        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum1"><%=globals.ResourceHelper.GetString("String651")%> 1:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum1T" value="<%=strum1T %>" id="Strum1T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum1N" value="<%=strum1 %>" id="Strum1N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum2"><%=globals.ResourceHelper.GetString("String651")%> 2:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum2T" value="<%=strum2T %>" id="Strum2T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum2N" value="<%=strum2 %>" id="Strum2N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum3"><%=globals.ResourceHelper.GetString("String651")%> 3:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum3T" value="<%=strum3T %>" id="Strum3T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum3N" value="<%=strum3 %>" id="Strum3N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum4"><%=globals.ResourceHelper.GetString("String651")%> 4:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum4T" value="<%=strum4T %>" id="Strum4T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum4N" value="<%=strum4 %>" id="Strum4N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum5"><%=globals.ResourceHelper.GetString("String651")%> 5:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum5T" value="<%=strum5T %>" id="Strum5T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum5N" value="<%=strum5 %>" id="Strum5N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum6"><%=globals.ResourceHelper.GetString("String651")%> 6:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum6T" value="<%=strum6T %>" id="Strum6T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum6N" value="<%=strum6 %>" id="Strum6N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum7"><%=globals.ResourceHelper.GetString("String651")%> 7:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum7T" value="<%=strum7T %>" id="Strum7T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum7N" value="<%=strum7 %>" id="Strum7N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum8"><%=globals.ResourceHelper.GetString("String651")%> 8:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum8T" value="<%=strum8T %>" id="Strum8T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum8N" value="<%=strum8 %>" id="Strum8N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum9"><%=globals.ResourceHelper.GetString("String651")%> 9:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum9T" value="<%=strum9T %>" id="Strum9T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum9N" value="<%=strum9 %>" id="Strum9N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div style="margin-top: 10px; margin-bottom: 10px;">
            <label for="Strum10"><%=globals.ResourceHelper.GetString("String651")%> 10:</label>
            <br />
            <input type="text" class="input-modifica-elementi" name="Strum10T" value="<%=strum10T %>" id="Strum10T" placeholder='<%=globals.ResourceHelper.GetString("String649")%>' />
            <input type="text" class="input-modifica-elementi" style="margin-top: 3px;" name="Strum10N" value="<%=strum10 %>" id="Strum10N" placeholder='<%=globals.ResourceHelper.GetString("String650")%>' />
        </div>

        <div class="title-container-listpage-first" style="margin-top: 20px;">
            <%=globals.ResourceHelper.GetString("String652")%>
        </div>
        <label><%=globals.ResourceHelper.GetString("String653")%></label>
        <br />
        <label><%=globals.ResourceHelper.GetString("String654")%> (<a href="https://opensource.org/licenses/bsd-license.php">https://opensource.org/licenses/bsd-license.php</a>)</label>
        <br />
        <br />
        <%=globals.ResourceHelper.GetString("String655")%>: <a href="http://www.ameamer.com/itsuite/guide" target="_blank" title='<%=globals.ResourceHelper.GetString("String655")%>'>www.ameamer.com/itsuite/guide</a>
        <br />
        <%=globals.ResourceHelper.GetString("String656")%>: <a href="http://www.ameamer.com/itsuite" target="_blank" title='<%=globals.ResourceHelper.GetString("String656")%>'>www.ameamer.com/itsuite</a>
        <br />
        <%=globals.ResourceHelper.GetString("String657")%>: <a href="http://www.ameamer.com" target="_blank" title='<%=globals.ResourceHelper.GetString("String657")%>'>www.ameamer.com</a>
    </form>
</asp:Content>

