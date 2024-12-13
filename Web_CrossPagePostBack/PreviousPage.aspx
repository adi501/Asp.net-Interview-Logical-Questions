<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviousPage.aspx.cs" Inherits="Web_CrossPagePostBack.PreviousPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div>
        <h4>
            Previous Page Values</h4>
        <table>
            <tr>
                <td>
                    Your Name is "<asp:Label ID="lblFullName" runat="server" />" and Your country is
                    "<asp:Label ID="lblCountry" runat="server" />"
                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
