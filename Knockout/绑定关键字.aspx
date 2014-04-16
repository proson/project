<%@ Page Language="C#" AutoEventWireup="true" CodeFile="绑定关键字.aspx.cs" Inherits="绑定关键字" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Visible绑定通过绑定一个值来确定DOM元素显示或隐藏</h2>
        <div data-bind="visible: shouldShowMessage">
            You will see this message only when "shouldShowMessage" holds a true value.   
        </div>
        <div data-bind="visible:myValues().length > 0">
            You will see this message only when 'myValues' has at least one member.   
        </div>
        
        <h2>Text绑定主要是让DOM元素显示参数值。</h2>
        Today's message is: <span data-bind="text: myMessage"></span>   
        
        <h2>foreach绑定主要是让DOM元素显示参数值。</h2>
        <div>
            <select data-bind="foreach: myArrary()">
                <option data-bind="value:value">Item <!--ko text:name--><!--/ko--></option>
            </select>
        </div>
        <h2>Html绑定会让关联的DOM元素显示你参数指定的HTML内容。</h2>
        <div data-bind="html: details"></div>
        <h2>Css绑定主要是给DOM元素对象添加或移除一个或多个css class类名</h2>
        <div data-bind="css: { profitWarning: currentProfit() < 0 }"> Profit Information   </di>

        <script src="Script/jquery-1.10.2.min.js"></script>
        <script src="Script/knockout-3.1.0.js"></script>
        <script type="text/javascript">
            var viewModel = {
                shouldShowMessage: ko.observable(true),
                myValues: ko.observableArray([]),
                myMessage: ko.observable(),
                myArrary: ko.observableArray([]),
                details: ko.observable(),
                currentProfit: ko.observable(150000) 
            };
            viewModel.shouldShowMessage(false);
            viewModel.shouldShowMessage(true);
            viewModel.myValues.push("some value");
            viewModel.myMessage("Hello, world!");
            viewModel.myArrary.push({ name: "Json1", value: "1" });
            viewModel.myArrary.push({ name: "Json2", value: "2" });
            viewModel.details("<em>For further details, view the report <a href='report.html'>here</a>.</em>");
            viewModel.currentProfit(-50);
            ko.applyBindings(viewModel);
        </script>

    </form>
</body>
</html>
