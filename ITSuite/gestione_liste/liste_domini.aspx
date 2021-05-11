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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="liste_domini.aspx.vb" Inherits="gestione_liste_liste_domini" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function HideLabel() {
            document.getElementById("cntr-msg").style.display = "block";
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("cntr-msg").style.display = "none";
            }, seconds * 1000);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
   <%=globals.ResourceHelper.GetString("String288")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
     <%=globals.ResourceHelper.GetString("String289")%>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form id="form1" runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

            </asp:Label>
        </div>

<asp:Panel ID="PanelGen" runat="server">

                        <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String290")%>
        </div>

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String292")%> <b>[pre]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("ip_predefinito")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="ip_predefinito" placeholder='<%# globals.ResourceHelper.GetString("String294")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="ip_predefinito_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String293")%> <b>[alt]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("ip_alternativo")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="ip_alternativo" placeholder='<%# globals.ResourceHelper.GetString("String295")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="ip_alternativo_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String297")%> <b>[pre]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("submask_predefinita")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="submask_predefinita" placeholder='<%# globals.ResourceHelper.GetString("String296")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="submask_predefinita_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String298")%> <b>[alt]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("submask_alternativa")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="submask_alternativa" placeholder='<%# globals.ResourceHelper.GetString("String301")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="submask_alternativa_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String299")%> <b>[pre]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("gwy_predefinito")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="gwy_predefinito" placeholder='<%# globals.ResourceHelper.GetString("String302")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="gwy_predefinito_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String300")%> <b>[alt]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("gwy_alternativo")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="gwy_alternativo" placeholder='<%# globals.ResourceHelper.GetString("String303")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="gwy_alternativo_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />


        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String304")%> <b>[pre]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("dns1_predefinito")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="dns1_predefinito" placeholder='<%#globals.ResourceHelper.GetString("String308")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="dns1_predefinito_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String305")%> <b>[alt]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("dns1_alternativo")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="dns1_alternativo" placeholder='<%#globals.ResourceHelper.GetString("String309")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="dns1_alternativo_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String306")%> <b>[pre]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("dns2_predefinito")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="dns2_predefinito" placeholder='<%#globals.ResourceHelper.GetString("String310")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="dns2_predefinito_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String307")%> <b>[alt]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("dns2_alternativo")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="dns2_alternativo" placeholder='<%#globals.ResourceHelper.GetString("String311")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="dns2_alternativo_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String312")%> <b>[pre]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("wins_predefinito")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="wins_predefinito" placeholder='<%#globals.ResourceHelper.GetString("String314")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="wins_predefinito_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
             <%=globals.ResourceHelper.GetString("String313")%> <b>[alt]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("wins_alternativo")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="wins_alternativo" placeholder='<%#globals.ResourceHelper.GetString("String315")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="wins_alternativo_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
             <%=globals.ResourceHelper.GetString("String316")%> <b>[pre]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("lan_predefinita")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="lan_predefinita" placeholder='<%#globals.ResourceHelper.GetString("String317")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="lan_predefinita_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String318")%> 1 <b>[alt1]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("lan_alternativa1")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="lan_alternativa1" placeholder='<%#globals.ResourceHelper.GetString("String319")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="lan_alternativa1_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String318")%> 2 <b>[alt2]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("lan_alternativa2")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="lan_alternativa2" placeholder='<%#globals.ResourceHelper.GetString("String319")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="lan_alternativa2_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>

        <br />

        <div class="title-net">
            <%=globals.ResourceHelper.GetString("String318")%> 3 <b>[alt3]</b>
        </div>
        <div class="body-net">
            <%=globals.ResourceHelper.GetString("String291")%>:&nbsp;<b><%=Session("lan_alternativa3")%></b>
        </div>
        <div class="container-net-input">
            <asp:TextBox ID="lan_alternativa3" placeholder='<%#globals.ResourceHelper.GetString("String319")%>' runat="server" Text='' Style="border: 1px solid gray; width: 100%; box-sizing: border-box; height: 30px;" />
            <asp:Button ID="lan_alternativa3_confirmbutton" CssClass="button-nets" runat="server" Text='<%# globals.ResourceHelper.GetString("String28")%>' OnClick="SaveSettings_Click" />
        </div>
    
</asp:Panel>

        <br />

                <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String320")%>
        </div>

        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="DominiDataSource" InsertItemPosition="LastItem" OnItemInserting="ListView1_ItemInserting">
            <AlternatingItemTemplate>
                <tr class="tr-alt-list">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%#globals.ResourceHelper.GetString("String147")%>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%#globals.ResourceHelper.GetString("String146")%>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="repartiLabel" runat="server" Text='<%# Eval("domini") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr class="tr-list-edit">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text='<%#globals.ResourceHelper.GetString("String282")%>' />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text='<%#globals.ResourceHelper.GetString("String46")%>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="repartiTextBox" runat="server" Text='<%# Bind("domini") %>' Style="width: 70%;" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%#globals.ResourceHelper.GetString("String160")%></td>
                    </tr>
                </table>            </EmptyDataTemplate>
            <InsertItemTemplate>
                </table>
            <table style="border: 0px solid green; width: 100%; margin-top: 20px;">
                <tr style="">
                    <td style="width: 100%;">
                        <asp:TextBox ID="repartiTextBox" placeholder='<%# globals.ResourceHelper.GetString("String321")%>' runat="server" Text='<%# Bind("domini") %>' Style="width: 100%; background-color: #a6ffa6; border: 1px solid black; box-sizing: border-box;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text='<%# globals.ResourceHelper.GetString("String285")%>' />
                    </td>
                </tr>
            </table>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr class="tr-list">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%# globals.ResourceHelper.GetString("String147")%>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%# globals.ResourceHelper.GetString("String146")%>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="repartiLabel" runat="server" Text='<%# Eval("domini") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" class="tableresult">
                    <tr runat="server">
                        <td runat="server">
                            <table class="ricerca-pc-tab" id="itemPlaceholderContainer" runat="server">
                                <tr runat="server" class="ricerca-pc-tab-tr">
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String99") %></th>
                                    <th runat="server" class="ricerca-pc-tab-th">ID</th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String322") %></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%# globals.ResourceHelper.GetString("String147")%>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%# globals.ResourceHelper.GetString("String146")%>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="repartiLabel" runat="server" Text='<%# Eval("domini") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="DominiDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True" DeleteCommand="DELETE FROM [listadomini] WHERE [Id] = @Id" InsertCommand="INSERT INTO [listadomini] ([domini]) VALUES (@domini)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [listadomini]" UpdateCommand="UPDATE [listadomini] SET [domini] = @domini WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="domini" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="domini" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </form>

</asp:Content>

