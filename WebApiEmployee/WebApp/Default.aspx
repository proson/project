<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:HyperLinkField HeaderText="姓名" DataTextField="Name" DataNavigateUrlFields="Name,Id" DataNavigateUrlFormatString="~/employees/{0}/{1}"></asp:HyperLinkField>
                    <asp:BoundField DataField="Gender" HeaderText="性别" />
                    <asp:BoundField DataField="BirthDate"  HeaderText="出生日期" DataFormatString="{0:dd/MM/yyyy}" />
                     <asp:BoundField DataField="Department" HeaderText="部门" />
                </Columns>
            </asp:GridView>

            <asp:DetailsView ID="DetailsViewEmployee" runat="server" AutoGenerateRows="False"  Width="100%">
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="姓名"/>
                    <asp:BoundField DataField="Gender" HeaderText="姓名"/>
                    <asp:BoundField DataField="BirthDate" HeaderText="出生日期" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="Department" HeaderText="部门"/>
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>
