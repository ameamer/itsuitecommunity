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

<%@ Page Language="VB" MasterPageFile="../MasterPage.master" AutoEventWireup="false" CodeFile="strumenti_home.aspx.vb" Inherits="Strumenti_strumenti_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String107")%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderSubTitle" Runat="Server">
    <%=globals.ResourceHelper.GetString("String622")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderCentral" runat="Server">
    <form runat="server">
        <asp:Panel runat="server" ID="Panel1" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link1 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link1title %>" title="<%=link1title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link1title %>"><%=link1title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel2" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link2 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link1title %>" title="<%=link2title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link2title %>"><%=link2title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel3" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link3 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link3title %>" title="<%=link3title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link3title %>"><%=link3title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel4" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link4 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link4title %>" title="<%=link4title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link4title %>"><%=link4title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel5" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link5 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link5title %>" title="<%=link5title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link5title %>"><%=link5title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel6" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link6 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link6title %>" title="<%=link6title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link6title %>"><%=link6title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel7" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link7 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link7title %>" title="<%=link7title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link7title %>"><%=link7title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel8" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link8 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link8title %>" title="<%=link8title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link8title %>"><%=link8title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel9" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link9 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link9title %>" title="<%=link9title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link9title %>"><%=link9title %></a>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel10" Visible="false">
            <div class="listservice-container" onclick="location.href='<%=link10 %>'">
                <img src="../img/ip_icon_50x50.png" alt="<%=link10title %>" title="<%=link10title %>" style="vertical-align: middle;" />
                <a href="#" class="a-listprincipal" title="<%=link10title %>"><%=link10title %></a>
            </div>
        </asp:Panel>
    </form>

</asp:Content>

