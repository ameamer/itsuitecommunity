<%@ Page Language="VB" AutoEventWireup="false" CodeFile="report_pc.aspx.vb" Inherits="gestione_pc_report_pc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

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
<b
    <form id="form1" runat="server" >
        <div>
            <div class="report-page-title">
                <%=globals.ResourceHelper.GetString("String419")%> <%=DateTime.Now()%>&nbsp;-&nbsp;ITSuite by Ame Amer
            </div>

            <table class="table-report-general">
                <tr>
                    <td class="cell-report-general-intest">ID</td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String420")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String120")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String122")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String421")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String422")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String125")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String378")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String379")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String126")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String127")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String423")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String377")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String344")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String427")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String424")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String128")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String131")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String51")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String132")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String392")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String428")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String372")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String425")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String426")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String396")%></td>
                    <td class="cell-report-general-intest"><%=globals.ResourceHelper.GetString("String429")%></td>
                </tr>

                <% StampReportPC() %>

                <tr>
                    <td class="cell-report-general-footer" colspan="27"><%=globals.ResourceHelper.GetString("String444")%>:&nbsp;
 <%
     if conteggio = 1 Then
         Response.Write(conteggio & "</b> " & globals.ResourceHelper.GetString("String180"))
     Else
 %>
                        <%=conteggio%>&nbsp;<%=globals.ResourceHelper.GetString("String179")%>.
            <% End If %>

                    </td>
                </tr>
            </table>

                     

        </div>
    </form>
</body>
</html>
