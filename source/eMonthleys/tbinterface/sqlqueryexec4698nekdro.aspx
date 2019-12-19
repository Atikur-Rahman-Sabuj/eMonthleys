<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqlqueryexec4698nekdro.aspx.cs" Inherits="eMonthleys.tbinterface.sqlqueryexec4698nekdro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="multiline" Columns="50" Rows="5"  Width="100%"></asp:TextBox>
             </div>
            <asp:Button ID="Button1" runat="server" Text="Run" OnClick="Button1_Click" />
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
