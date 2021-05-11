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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="opzioni_generali_home_swaz.aspx.vb" Inherits="opzioni_generali_opzioni_generali_home_swaz" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <div class="HorizontalTopMenuContainer">
        <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home.aspx'" style="border-left: 1px solid lightgray;">
            <a href="../opzioni_generali/opzioni_generali_home.aspx" title='<%=globals.ResourceHelper.GetString("String26")%>'><%=globals.ResourceHelper.GetString("String26")%></a>
        </div>
                          <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../gestione_liste/gestione_liste_home.aspx'">
            <a href="../gestione_liste/gestione_liste_home.aspx" title='<%=globals.ResourceHelper.GetString("String101")%>'><%=globals.ResourceHelper.GetString("String101")%></a>
        </div>
        <div class="HorizontalTopMenuItemSelected">
            <%=globals.ResourceHelper.GetString("String94")%>
        </div>
                          <div class="HorizontalTopMenuItemNotSelected" onclick="location.href='../opzioni_generali/opzioni_generali_home_comp.aspx'">
            <a href="../opzioni_generali/opzioni_generali_home_comp.aspx" title='<%=globals.ResourceHelper.GetString("String103")%>'><%=globals.ResourceHelper.GetString("String103")%></a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String705")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">
            </asp:Label>
        </div>

        <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="SwAzDataSource" InsertItemPosition="LastItem" OnItemInserting="ListView1_ItemInserting">
            <AlternatingItemTemplate>
                <tr class="tr-alt-list">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%#globals.ResourceHelper.GetString("String147")%>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%#globals.ResourceHelper.GetString("String146")%>' />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeswLabel" runat="server" Text='<%# Eval("nomesw") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="linkswLabel" runat="server" Text='<%# Eval("linksw") %>' PostBackUrl='<%# Eval("linksw") %>' />
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
                        <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="nomeswTextBox" runat="server" Text='<%# Bind("nomesw") %>' Style="width: 70%;" />
                    </td>
                    <td>
                        <asp:TextBox ID="linkswTextBox" runat="server" Text='<%# Bind("linksw") %>' Style="width: 70%;" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%#globals.ResourceHelper.GetString("String160")%></td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                </table>
            <table style="border: 0px solid green; width: 100%; margin-top: 20px;">
                <tr>
                    <td style="width: 100%;">
                        <asp:TextBox ID="nomeswTextBox" placeholder='<%#globals.ResourceHelper.GetString("String706")%>' runat="server" Text='<%# Bind("nomesw") %>' Style="width: 100%; background-color: #a6ffa6; border: 1px solid black; box-sizing: border-box;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%;">
                        <asp:TextBox ID="linkswTextBox" placeholder='<%#globals.ResourceHelper.GetString("String707")%>' runat="server" Text='<%# Bind("linksw") %>' Style="width: 100%; background-color: #a6ffa6; border: 1px solid black; box-sizing: border-box;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text='<%#globals.ResourceHelper.GetString("String701")%>' />
                    </td>
                </tr>
            </table>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr class="tr-list">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%#globals.ResourceHelper.GetString("String147")%>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%#globals.ResourceHelper.GetString("String146")%>' />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeswLabel" runat="server" Text='<%# Eval("nomesw") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="linkswLabel" runat="server" Text='<%# Eval("linksw") %>' PostBackUrl='<%# Eval("linksw") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" class="tableresult">
                    <tr runat="server">
                        <td runat="server">
                            <table class="ricerca-pc-tab" id="itemPlaceholderContainer" runat="server">
                                <tr runat="server" class="ricerca-pc-tab-tr">
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String99")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th">Id</th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String708")%></th>
                                    <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String709")%></th>
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
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%#globals.ResourceHelper.GetString("String147")%>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%#globals.ResourceHelper.GetString("String146")%>' />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nomeswLabel" runat="server" Text='<%# Eval("nomesw") %>' />
                    </td>
                    <td>
                        <asp:Label ID="linkswLabel" runat="server" Text='<%# Eval("linksw") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="SwAzDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True;Connect Timeout=30" DeleteCommand="DELETE FROM [swaziendali] WHERE [Id] = @Id" InsertCommand="INSERT INTO [swaziendali] ([nomesw], [linksw]) VALUES (@nomesw, @linksw)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [swaziendali] ORDER BY [nomesw]" UpdateCommand="UPDATE [swaziendali] SET [nomesw] = @nomesw, [linksw] = @linksw WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="nomesw" Type="String" />
                <asp:Parameter Name="linksw" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="nomesw" Type="String" />
                <asp:Parameter Name="linksw" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </form>
</asp:Content>

