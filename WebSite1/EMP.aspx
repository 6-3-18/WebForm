<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="EMP.aspx.cs" Inherits="EMP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <style type="text/css">
        body { font-family: Arial; font-size: 10pt; }
        table { border: 1px solid #ccc; border-collapse: collapse; }
        table th { background-color: #F7F7F7; color: #333; font-weight: bold; }
        table th, table td { padding: 5px; border: 1px solid #ccc; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
       
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"
            DataKeyNames="EMP_ID" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" AllowPaging="True" OnPageIndexChanging="OnPaging" OnRowUpdating="OnRowUpdating"
            OnRowDeleting="OnRowDeleting" EmptyDataText="目前無記錄.">
            <Columns>
                
                  <asp:TemplateField HeaderText="員工編號" ItemStyle-Width="150" SortExpression="EMP_ID">
                    <ItemTemplate>
                        <asp:Label ID="lblEMP_ID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEMP_ID" runat="server" Text='<%# Eval("EMP_ID") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="員工姓名" ItemStyle-Width="150" SortExpression="EMP_NAME">
                    <ItemTemplate>
                        <asp:Label ID="lblEMP_NAME" runat="server" Text='<%# Eval("EMP_NAME") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEMP_NAME" runat="server" Text='<%# Eval("EMP_NAME") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="年齡" ItemStyle-Width="150" SortExpression="AGE">
                    <ItemTemplate>
                        <asp:Label ID="lblAGE" runat="server" Text='<%# Eval("AGE") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAGE" runat="server" Text='<%# Eval("AGE") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="生日" ItemStyle-Width="150" SortExpression="Birthday">
                    <ItemTemplate>
                        <asp:Label ID="lblBirthday" runat="server" Text='<%# Eval("Birthday") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBirthday" runat="server" Text='<%# Eval("Birthday") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" FooterText="Footer" >

<ItemStyle Width="150px"></ItemStyle>
                  </asp:CommandField>

            </Columns>
        </asp:GridView>

          <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
            <%--    <td style="width: 150px">員工編號:<br />
                    <asp:TextBox ID="txtEmp_ID" runat="server" Width="140" />
                </td>--%>
                <td style="width: 150px">員工姓名:<br />
                    <asp:TextBox ID="txtEmp_Name" runat="server" Width="140" />
                </td>
                  <td style="width: 150px">年齡:<br />
                    <asp:TextBox ID="txtAge" runat="server" Width="140" />
                </td>
                  <td style="width: 150px">生日:<br />
                    <asp:TextBox ID="txtBirthday" runat="server" Width="140" />
                </td>
                <td style="width: 150px">
                    <asp:Button ID="btnAdd" runat="server" Text="新增資料" OnClick="Insert" />
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TESTDBConnectionString %>" SelectCommand="SELECT [EMP_ID], [EMP_NAME], [AGE], [BIRTHDAY] FROM [EMP]"></asp:SqlDataSource>
        <asp:Label ID="lbl_msg" runat="server" Font-Size="Large" ForeColor="Red" Text="系統訊息:"></asp:Label>
    </form>
</body>
</html>
