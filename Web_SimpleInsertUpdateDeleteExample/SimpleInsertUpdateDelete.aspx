<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleInsertUpdateDelete.aspx.cs" Inherits="Web_SimpleInsertUpdateDeleteExample.SimpleInsertUpdateDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Simple Add/Insert, Edit/Update, Delete Gridview Data Example </title>
    <style type="text/css">
        td a
        {
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Ref:http://www.aspneto.com/gridview-inline-add-insert-edit-update-delete-data-in-asp-net-c-vb.html
    <div>
        <h4>
            Simple Add/Insert, Edit/Update, Delete Gridview Data Example</h4>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <table>
            <tr>
                <td>
                    Subject Id:
                </td>
                <td>
                    <asp:TextBox ID="txtSubjectId" runat="server" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td>
                    Subject Name:
                </td>
                <td>
                    <asp:TextBox ID="txtSubjectName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" Text="*" ControlToValidate="txtSubjectName"
                        ForeColor="Red" ValidationGroup="vgAdd" />
                </td>
            </tr>
            <tr>
                <td>
                    Marks:
                </td>
                <td>
                    <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMarks" runat="server" ControlToValidate="txtMarks"
                        Text="*" ForeColor="Red" ValidationGroup="vgAdd" />
                    <asp:RegularExpressionValidator ID="revMarks" runat="server" ControlToValidate="txtMarks"
                        ValidationExpression="^[0-9]*$" Text="*Numbers" ForeColor="Red" ValidationGroup="vgAdd" />
                </td>
            </tr>
            <tr>
                <td>
                    Grade:
                </td>
                <td>
                    <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvGrade" runat="server" ControlToValidate="txtGrade"
                        Text="*" ForeColor="Red" ValidationGroup="vgAdd" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click"
                        ValidationGroup="vgAdd" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                        ValidationGroup="vgAdd" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                        OnClientClick="return confirm('Are you sure you want to delete this record?')"
                        ValidationGroup="vgAdd" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        CausesValidation="false" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvSubDetails" DataKeyNames="SubjectId" AutoGenerateColumns="false"
            runat="server" OnSelectedIndexChanged="gvSubDetails_SelectedIndexChanged" Width="500">
            <HeaderStyle BackColor="#9a9a9a" ForeColor="White" Font-Bold="true" Height="30" />
            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="Select" Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SubjectName">
                    <ItemTemplate>
                        <asp:Label ID="lblSubjectName" runat="server" Text='<%#Eval("SubjectName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marks">
                    <ItemTemplate>
                        <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("Marks") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Grade">
                    <ItemTemplate>
                        <asp:Label ID="lblGrade" runat="server" Text='<%#Eval("Grade") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </div>
    </form>
</body>
</html>
