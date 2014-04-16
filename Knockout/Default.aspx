<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            姓名：<span data-bind="text: firstName"></span>
            全名：<span data-bind="text: lastName"></span>
            全名：<span data-bind="text: fullName"></span>

        </div>

        <script src="Script/jquery-1.10.2.min.js"></script>
        <script src="Script/knockout-3.1.0.js"></script>
        <script type="text/javascript">
            function AppViewModel() {
                var self = this;
                self.firstName = ko.observable("Jon");
                self.lastName = ko.observable("Smith");
                self.fullName = ko.computed(function () {
                    return self.firstName() + " " + self.lastName();
                });
            }
            ko.applyBindings(new AppViewModel());
        </script>
    </form>
</body>
</html>
