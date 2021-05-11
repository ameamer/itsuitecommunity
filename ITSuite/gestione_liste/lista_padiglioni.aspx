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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="lista_padiglioni.aspx.vb" Inherits="gestione_liste_lista_padiglioni" %>

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
      <%= globals.ResourceHelper.GetString("String264") %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
      <%= globals.ResourceHelper.GetString("String281") %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form id="form1" runat="server">
        <div class="cntr-msg" id="cntr-msg">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true">

            </asp:Label>
        </div>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="padiglioniDataSource" InsertItemPosition="LastItem" OnItemInserting="ListView1_ItemInserting">
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
                        <asp:Label ID="padiglioniLabel" runat="server" Text='<%# Eval("padiglioni") %>' />
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
                        <asp:TextBox ID="padiglioniTextBox" runat="server" Text='<%# Bind("padiglioni") %>' Style="width: 70%;" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" class="nodatalistelement">
                    <tr>
                        <td><%= globals.ResourceHelper.GetString("String160") %></td>
                    </tr>
                </table>            </EmptyDataTemplate>
            <InsertItemTemplate>
                </table>
            <table style="border: 0px solid green; width: 100%; margin-top: 20px;">
                <tr style="">
                    <td style="width: 100%;">
                        <asp:TextBox ID="padiglioniTextBox" placeholder='<%# globals.ResourceHelper.GetString("String284") %>' runat="server" Text='<%# Bind("padiglioni") %>' Style="width: 100%; background-color: #a6ffa6; border: 1px solid black; box-sizing: border-box;" />
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
                        <asp:Label ID="padiglioniLabel" runat="server" Text='<%# Eval("padiglioni") %>' />
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
                                    <th runat="server" class="ricerca-pc-tab-th"><%= globals.ResourceHelper.GetString("String283") %></th>
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
                        <asp:Label ID="padiglioniLabel" runat="server" Text='<%# Eval("padiglioni") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="padiglioniDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True" DeleteCommand="DELETE FROM [listapadiglioni] WHERE [Id] = @original_Id" InsertCommand="INSERT INTO [listapadiglioni] ([padiglioni]) VALUES (@padiglioni)" OldValuesParameterFormatString="original_{0}" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [listapadiglioni]" UpdateCommand="UPDATE [listapadiglioni] SET [padiglioni] = @padiglioni WHERE [Id] = @original_Id">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="padiglioni" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="padiglioni" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </form>
</asp:Content>

