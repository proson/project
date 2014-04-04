<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlBulkCopyTest.aspx.cs" Inherits="SqlServer.SqlBulkCopyTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        开始时间：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        结束时间：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br/>
        时间差：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="Button1" runat="server" Text="执行" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
