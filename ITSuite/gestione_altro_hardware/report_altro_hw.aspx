<%@Page Language="VB" AutoEventWireup="false" CodeFile="report_altro_hw.aspx.vb" Inherits="gestione_altro_hardware_report_altro_hw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Report altro hardware | ITSuite by Ame Amer (admin@ameamer.com)</title>
     <style type="text/css">

        
.table-report-general {
    margin: 0 auto;
    width: 100%;
    height: auto;
    border: 2px solid black;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.report-page-title {
    margin: 0 auto;
    width: 100%;
    text-align: center;
    height: 45px;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    font-size: 18px;
}

.cell-report-general-intest {
    background-color: #D8D8D8;
    border: 1px solid black;
    width: auto;
    font-size: x-small;
    font-weight: bold;
    padding: 3px;
}

.cell-report-general-body {
    background-color: white;
    border: 1px solid black;
    width: auto;
    font-size: x-small;
    font-weight: normal;
    padding: 3px;
}

.cell-report-general-footer {
    border: 0px solid black;
    text-align: right;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    font-size: 14px;
    height: 50px;
}

    </style>

</head>

<body>
    <form id="form1" runat="server">
 <div>
     <div class="report-page-title">
                <%=globals.ResourceHelper.GetString("String454") %> <%=DateTime.Now()%>&nbsp;-&nbsp;ITSuite by Ame Amer
            </div>

          <table class="table-report-general">
                <tr>
                    <td class="cell-report-general-intest">ID</td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String175") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String120") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String122") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String176") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String177") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String131") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String130") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String128") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String132") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String178") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String125") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String126") %></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String127") %></td>
                </tr>

                <% StampReport() %>

                <tr>
                    <td class="cell-report-general-footer" colspan="27">
                            <%= globals.ResourceHelper.GetString("String444") %>:&nbsp;
                                <%
                                    If conteggio=1 Then
                                        Response.Write(conteggio & "</b> " & globals.ResourceHelper.GetString("String180"))
                                    Else
                            %>
                            <%=conteggio%>&nbsp;<%= globals.ResourceHelper.GetString("String179") %>.

                    </td>
                </tr>
            </table>
        <%  End If %>
    </div>
    </form>
</body>
</html>
