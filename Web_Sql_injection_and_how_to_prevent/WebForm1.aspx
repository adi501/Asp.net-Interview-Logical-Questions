<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web_Sql_injection_and_how_to_prevent.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        Ref:http://www.aspneto.com/sql-injections-what-is-sql-injection-and-how-to-prevent-it.html
        <h4>
            Simple test SQL Injection Example in asp.net</h4>
        <table>
            <tr>
                <td>
                    UserName:
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnWithSqlInjection" runat="server" Text="With Injection" OnClick="btnWithSqlInjection_Click" />
                    &nbsp;
                    <asp:Button ID="btnWithProtection" runat="server" Text="With Protection" OnClick="btnWithProtection_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    </div>
    </form>
</body>
</html>
