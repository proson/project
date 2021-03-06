﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_paging_database_sorting.aspx.cs"
    Inherits="FineUI.Examples.grid.grid_paging_database_sorting" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="表格" EnableFrame="true" EnableCollapse="true" Width="800px" PageSize="5" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
        DataKeyNames="Id,Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
        AllowSorting="true" SortField="Name" SortDirection="ASC"
        OnSort="Grid1_Sort">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="100px" DataField="Name" SortField="Name" DataFormatString="{0}"
                HeaderText="姓名" />
            <f:TemplateField Width="80px" SortField="Gender" HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# GetGender(Eval("Gender")) %>'></asp:Label>
                </ItemTemplate>
            </f:TemplateField>
            <f:BoundField Width="80px" SortField="EntranceYear" DataField="EntranceYear" HeaderText="入学年份" />
            <f:CheckBoxField Width="80px" SortField="AtSchool" RenderAsStaticField="true" DataField="AtSchool"
                HeaderText="是否在校" />
            <f:HyperLinkField HeaderText="所学专业" DataToolTipField="Major" DataTextField="Major"
                DataTextFormatString="{0}" DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                DataNavigateUrlFieldsEncode="true" Target="_blank" ExpandUnusedSpace="True" />
            <f:ImageField Width="80px" DataImageUrlField="Group" DataImageUrlFormatString="~/images/16/{0}.png"
                HeaderText="分组">
            </f:ImageField>
        </Columns>
    </f:Grid>
    <br />
    <f:Button ID="Button1" runat="server" Text="选中了哪些行" OnClick="Button1_Click">
    </f:Button>
    <br />
    <f:Label ID="labResult" EncodeText="false" runat="server">
    </f:Label>
    </form>
</body>
</html>
