<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CacheApplication.index" %>
<%@ OutputCache Duration="10" VaryByParam="none" VaryByCustom="Index_Key" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn" runat="server" Text="Button" OnClick="btn_Click" />
    </div>
    </form>
</body>
</html>
