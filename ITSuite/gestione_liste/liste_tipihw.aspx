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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="liste_tipihw.aspx.vb" Inherits="gestione_liste_liste_tipihw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <%= globals.ResourceHelper.GetString("String357") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%= globals.ResourceHelper.GetString("String358") %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form id="form1" runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

            </asp:Label>
        </div>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="TipihwDataSource" InsertItemPosition="LastItem" OnItemInserting="ListView1_ItemInserting">
            <AlternatingItemTemplate>
                <tr class="tr-alt-list">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%# globals.ResourceHelper.GetString("String147") %>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%# globals.ResourceHelper.GetString("String146") %>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="repartiLabel" runat="server" Text='<%# Eval("tipi_hw") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr class="tr-list-edit">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text='<%# globals.ResourceHelper.GetString("String282") %>' />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text='<%# globals.ResourceHelper.GetString("String46") %>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="repartiTextBox" runat="server" Text='<%# Bind("tipi_hw") %>' Style="width: 70%;" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%= globals.ResourceHelper.GetString("String160") %></td>
                    </tr>
                </table>            
            </EmptyDataTemplate>
            <InsertItemTemplate>
                </table>
            <table style="border: 0px solid green; width: 100%; margin-top: 20px;">
                <tr style="">
                    <td style="width: 100%;">
                        <asp:TextBox ID="repartiTextBox" placeholder='<%# globals.ResourceHelper.GetString("String356") %>' runat="server" Text='<%# Bind("tipi_hw") %>' Style="width: 100%; background-color: #a6ffa6; border: 1px solid black; box-sizing: border-box;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text='<%# globals.ResourceHelper.GetString("String285") %>' />
                    </td>
                </tr>
            </table>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr class="tr-list">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%# globals.ResourceHelper.GetString("String147") %>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%# globals.ResourceHelper.GetString("String146") %>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="repartiLabel" runat="server" Text='<%# Eval("tipi_hw") %>' />
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
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String355") %></th>
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
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text='<%# globals.ResourceHelper.GetString("String147") %>' />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text='<%# globals.ResourceHelper.GetString("String146") %>' />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="repartiLabel" runat="server" Text='<%# Eval("tipi_hw") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>


        <asp:SqlDataSource ID="TipihwDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True" DeleteCommand="DELETE FROM [tipi_hw] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tipi_hw] ([tipi_hw]) VALUES (@tipi_hw)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [tipi_hw]" UpdateCommand="UPDATE [tipi_hw] SET [tipi_hw] = @tipi_hw WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="tipi_hw" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="tipi_hw" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>


    </form>

</asp:Content>

