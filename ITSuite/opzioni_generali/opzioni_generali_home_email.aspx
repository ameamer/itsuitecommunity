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

<%@ Page Language="VB" AspCompat="true" MasterPageFile="../MasterPage.master" CodeFile="opzioni_generali_home_email.aspx.vb" Inherits="opzioni_generali_opzioni_generali_home_email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ChangeText() {
            var chkb = document.getElementById('<%= username.ClientID %>');
                if (chkb.checked)
                    document.getElementById('<%= username.ClientID %>').enabled = true;
        else
            document.getElementById('<%= username.ClientID %>').disabled = false;
        };

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
    <%=globals.ResourceHelper.GetString("String690")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String691")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">
        <div class="cntr-msg" id="cntr-msg" style="max-height: 400px; overflow-y: auto">
            <asp:Label runat="server" ID="ErrorMsg" Text="" Visible="true" />
            <asp:Label runat="server" ID="ScriptLabel" Visible="true"></asp:Label>
        </div>

        <div class="title-container-listpage-first">
            <%=globals.ResourceHelper.GetString("String26")%>
        </div>

        <div style="width: auto; padding: 10px; height: auto; background-color: lightgreen; border: 1px solid green">

            <asp:CheckBox runat="server" AutoPostBack="true" Text='<%#globals.ResourceHelper.GetString("String692")%>' ID="chckenable" OnCheckedChanged="chckenable_CheckedChanged" />

        </div>
        <br />

        <asp:Panel runat="server" ID="emailpanel" Visible="false">
            <div class="title-container-listpage-first">
                <%=globals.ResourceHelper.GetString("String693")%>
            </div>

            <div style="margin-top: 10px;">
                <%=globals.ResourceHelper.GetString("String47")%>:<br />
                <asp:TextBox ID="username" runat="server" Width="300"></asp:TextBox>
            </div>
            <div style="margin-top: 10px;">
                <%=globals.ResourceHelper.GetString("String498")%>:<br />
                <asp:TextBox ID="password" TextMode="Password" runat="server" Width="300"></asp:TextBox>
            </div>

            <div style="margin-top: 10px;">
                <%=globals.ResourceHelper.GetString("String694")%>:<br />
                <asp:TextBox ID="mailsrvaddr" runat="server" Width="300"></asp:TextBox>
            </div>
            <div style="margin-top: 10px;">
                <%=globals.ResourceHelper.GetString("String574")%>:<br />
                <asp:TextBox ID="mailsrvport" runat="server" Width="300"></asp:TextBox>
            </div>

            <div style="margin-top: 10px;">
                <asp:CheckBox ID="SSLcheckbox" runat="server" Text="SSL"></asp:CheckBox>
            </div>
            <br />
            <asp:Button runat="server" ID="ButtonSrvMail" Width="150" Text='<%#globals.ResourceHelper.GetString("String28")%>' Height="35" OnClick="ButtonSrvMail_Click" />
            <asp:Button runat="server" ID="TestMailButton" Width="150" Text="Test" Height="35" OnClick="TestMailButton_Click" />
            <br />
            <br />
            <div class="title-container-listpage-first">
                <%=globals.ResourceHelper.GetString("String695")%>
            </div>
            <div style="margin-top: 10px;">
                <%=globals.ResourceHelper.GetString("String696")%><br />
                <asp:TextBox ID="mittentemail" runat="server" Width="400"></asp:TextBox>
            </div>
            <div style="margin-top: 10px;">
                <%=globals.ResourceHelper.GetString("String697")%><br />
                <asp:TextBox ID="intestmail" runat="server" TextMode="MultiLine" Width="400" Height="50"></asp:TextBox>
            </div>
            <div style="margin-top: 10px;">
                <%=globals.ResourceHelper.GetString("String698")%><br />
                <asp:TextBox ID="closemail" runat="server" TextMode="MultiLine" Width="400" Height="50"></asp:TextBox>
            </div>
            <br />
            <asp:Button runat="server" ID="ButtonMsgMail" Width="150" Text='<%#globals.ResourceHelper.GetString("String28")%>' Height="35" OnClick="ButtonMsgMail_Click" />

            <br />
            <br />
            <div class="title-container-listpage-first">
                <%=globals.ResourceHelper.GetString("String699")%>
            </div>
            <div style="margin-top: 10px;">
                <asp:ListView ID="ListViewDest" runat="server" DataKeyNames="Id" DataSourceID="EmailDataSource" InsertItemPosition="LastItem" OnItemInserting="ListView1_ItemInserting">
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
                                <asp:Label ID="mailLabel" runat="server" Text='<%# Eval("mail") %>' />
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
                                <asp:TextBox ID="mailTextBox" runat="server" Text='<%# Bind("mail") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" class="nodatalistelement">
                            <tr>
                                <td><%=globals.ResourceHelper.GetString("String160")%></td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        </table>
            <table style="border: 0px solid green; width: 100%; margin-top: 20px;">
                <tr>
                    <td style="width: 100%;">
                        <asp:TextBox ID="mailTextBox" placeholder='<%#globals.ResourceHelper.GetString("String700")%>' runat="server" Text='<%# Bind("mail") %>' Style="width: 100%; background-color: #a6ffa6; border: 1px solid black; box-sizing: border-box;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text='<%#globals.ResourceHelper.GetString("String701")%>'  />
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
                                <asp:Label ID="mailLabel" runat="server" Text='<%# Eval("mail") %>' />
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
                                            <th runat="server" class="ricerca-pc-tab-th"><%=globals.ResourceHelper.GetString("String50")%></th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
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
                                <asp:Label ID="mailLabel" runat="server" Text='<%# Eval("mail") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="EmailDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itstdb.mdf;Integrated Security=True" DeleteCommand="DELETE FROM [email] WHERE [Id] = @Id" InsertCommand="INSERT INTO [email] ([mail]) VALUES (@mail)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [email] ORDER BY [mail]" UpdateCommand="UPDATE [email] SET [mail] = @mail WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="mail" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="mail" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </asp:Panel>
    </form>
</asp:Content>

