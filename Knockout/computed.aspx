<%@ Page Language="C#" AutoEventWireup="true" CodeFile="computed.aspx.cs" Inherits="computed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>First name: <span data-bind="text: firstName"></span></p>
            <p>Last name: <span data-bind="text: lastName"></span></p>
            <h2>Hello,
                <input data-bind="value: fullName" />!</h2>

            <p>Price：<span data-bind="text: price"></span></p>
            <p>
                Enter bid price:
                <input data-bind="value: formattedPrice" />
            </p>
            <p><span data-bind="text: acceptedNumericValue"></span></p>
            
            <p>Enter a numeric value:
                <input data-bind="value: attemptedValue" /></p>
            <div data-bind="visible: !lastInputWasValid()">That's not a number!</div>
        </div>
        <script src="Script/jquery-1.10.2.min.js"></script>
        <script src="Script/knockout-3.1.0.js"></script>
        <script type="text/javascript">
            function MyViewModel() {
                this.firstName = ko.observable('Planet');
                this.lastName = ko.observable('Earth');
                this.fullName = ko.computed({
                    read: function () {
                        return this.firstName() + " " + this.lastName();
                    },
                    write: function (value) {
                        var lastSpacePos = value.indexOf(' ');
                        if (lastSpacePos > 0) {
                            this.firstName(value.substring(0, lastSpacePos));
                            this.lastName(value.substring(lastSpacePos + 1));
                        }
                    },
                    owner: this
                });
                this.price = ko.observable(25.02);
                this.formattedPrice = ko.computed({
                    read: function () {
                        return '$' + this.price().toFixed(2);
                    },
                    write: function (value) {
                        value = parseFloat(value.replace(/[^\.\d]/g, ""));
                        this.price(isNaN(value) ? 0 : value);
                    },
                    owner: this
                });

                this.acceptedNumericValue = ko.observable(123);
                this.lastInputWasValid = ko.observable(true);
                this.attemptedValue = ko.computed({
                    read: this.acceptedNumericValue,
                    write: function (value) {
                        if (isNaN(value)) {
                            this.lastInputWasValid(false);
                        } else {
                            this.lastInputWasValid(true);
                            this.acceptedNumericValue(value);
                        }
                    },
                    owner: this
                });
            }

            ko.applyBindings(new MyViewModel());
        </script>
    </form>
</body>
</html>
