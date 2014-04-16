<%@ Page Language="C#" AutoEventWireup="true" CodeFile="observableArray.aspx.cs" Inherits="observableArray" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <script src="Script/jquery-1.10.2.min.js"></script>
        <script src="Script/knockout-3.1.0.js"></script>
        <script type="text/javascript">
            //var anotherObservableArray = ko.observableArray([
            //    { name: "Bungle", type: "Bear" },
            //    { name: "George", type: "Hippo" },
            //    { name: "Zippy", type: "Zippy" }
            //]);
            //anotherObservableArray.push({ name: "Jon", type: "Smith" });
            //alert('The length of the array is ' + anotherObservableArray().length);
            //alert('The first element is ' + anotherObservableArray()[0].name);
            //alert('Bungle的索引：' + anotherObservableArray()[0].name.indexOf('Bungle'));
            //ko.applyBindings(new anotherObservableArray);

            var myObservableArray = ko.observableArray();
            myObservableArray.push("Some value1");
            myObservableArray.push("Some value2");
            myObservableArray.push("Some value3");//插入数组的最后一项
            myObservableArray.pop();//移除数组最后一项并返回它
            myObservableArray.unshift('Some new value');//在数组头部插入新项
            myObservableArray.shift();//移除数组中第一项并返回它
            myObservableArray.reverse();//翻转整个数组的顺序
            myObservableArray.sort();//对数组内容进行排序 //默认情况下，按照字符（如果是字符串）或数字（如果是数字）顺序排序
            myObservableArray.splice();//删除指定索引和指定数目的数组元素对象。例如：myObservableArray.splice(1, 3) 从1开始删除3个元素，并将这3个元素作为元素数组返回
            myObservableArray.sort(function(left,right) {
                
            });
            myObservableArray.remove(someItem);//删除所有值等于someItem 的数组项，并将删除元素作为一个数组返回
            myObservableArray.remove(function (item) { return item.age < 18; });//删除所有元素age 属性小于18的数组项，并将删除元素作为一个数组返回
            myObservableArray.removeAll(['Chad', 132, undefined]);//删除所有值等于'Chad'、132、undefined的数组项，并将删除元素作为一个数组返回
            myObservableArray.removeAll();//删除所有的数组项，并将删除元素作为一个数组返回
            


            alert("myObservableArray长度：" + myObservableArray().length);
            alert("myObservableArray索引为1的值：" + myObservableArray()[1]);

        </script>
    </form>
</body>
</html>
