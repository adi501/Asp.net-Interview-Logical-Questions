<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleInsertUpdateDeleteExample.aspx.cs" Inherits="Web_SimpleInsertUpdateDeleteExample.SimpleInsertUpdateDeleteExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gridview Inline Add/Insert, Edit/Update, Delete Data Example
    </title>
    <style type="text/css">
        td a {
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Ref:http://www.aspneto.com/gridview-inline-add-insert-edit-update-delete-data-in-asp-net-c-vb.html
      <div>
          <h4>Gridview Inline Add/Insert, Edit/Update, Delete Data Example</h4>
          <asp:Label ID="lblMsg" runat="server"></asp:Label>
          <br />
          <asp:GridView ID="gvSubDetails" DataKeyNames="SubjectId" runat="server" AutoGenerateColumns="false"
              ShowFooter="true" OnRowEditing="gvSubDetails_RowEditing" OnRowCommand="gvSubDetails_RowCommand"
              OnRowDeleting="gvSubDetails_RowDeleting" OnRowUpdating="gvSubDetails_RowUpdating"
              OnRowCancelingEdit="gvSubDetails_RowCancelingEdit">
              <HeaderStyle BackColor="#9a9a9a" ForeColor="White" Font-Bold="true" Height="30" />
              <AlternatingRowStyle BackColor="#f5f5f5" />
              <Columns>
                  <asp:TemplateField>
                      <EditItemTemplate>
                          <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="Update" Text="Update" />
                          <asp:LinkButton ID="lbtnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit" Text="Edit" />
                          <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete"
                              OnClientClick="return confirm('Are you sure you want to delete this record?')"
                              CausesValidation="false" />
                      </ItemTemplate>
                      <FooterTemplate>
                          <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" Text="Add New" ValidationGroup="vgAdd" />
                      </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="SubjectName">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtSubjectName" runat="server" Text='<%#Eval("SubjectName") %>' />
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblSubjectName" runat="server" Text='<%#Eval("SubjectName") %>' />
                      </ItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="newSubjectName" runat="server" />
                          <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" ControlToValidate="newSubjectName"
                              Text="*" ForeColor="Red" ValidationGroup="vgAdd" />
                      </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Marks">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtMarks" runat="server" Text='<%#Eval("Marks") %>' />
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("Marks") %>' />
                      </ItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="newMarks" runat="server" />
                          <asp:RequiredFieldValidator ID="rfvMarks" runat="server" ControlToValidate="newMarks"
                              Text="*" ForeColor="Red" ValidationGroup="vgAdd" />
                          <asp:RegularExpressionValidator ID="revMarks" runat="server" ControlToValidate="newMarks"
                              ValidationExpression="^[0-9]*$" Text="*Numbers" ForeColor="Red" ValidationGroup="vgAdd" />
                      </FooterTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Grade">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtGrade" runat="server" Text='<%#Eval("Grade") %>' />
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblGrade" runat="server" Text='<%#Eval("Grade") %>' />
                      </ItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="newGrade" runat="server" />
                          <asp:RequiredFieldValidator ID="rfvGrade" runat="server" ControlToValidate="newGrade"
                              Text="*" ForeColor="Red" ValidationGroup="vgAdd" />
                      </FooterTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
      </div>
        </div>
    </form>
</body>
</html>
