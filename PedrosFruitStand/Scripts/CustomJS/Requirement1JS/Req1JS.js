$(document).ready(function () {

    ShowTallyGrid();

    var validatable = $("#divAddFruit").kendoValidator().data("kendoValidator");

    $.getScript("/Scripts/CustomJS/Storage/StorageBinJS.js");

    var theDate = new Date();
    FruitsList();
    Quantities();

    $('#btnSave').on('click', function () {
        var fruitText = $('#ddFruits').data("kendoDropDownList");

        if (validatable.validate()) {
            soldData.SoldFruit.push({ FruitName: fruitText.text(), Qty: $('#Qty').val(), Price: $('#txtCost').val(), DateSold: $('#soldDate').text() });
            StorageBin.Keys("FruitSold", soldData.SoldFruit);
            ShowTallyGrid(JSON.parse(StorageBin.Get("FruitSold")));
        }
    });
});


var soldData = {
    SoldFruit: []
}

function FruitsList() {
    $("#ddFruits").kendoDropDownList({
        dataSource: [
            { FruitName: "Apples" },
            { FruitName: "Bananas" },
            { FruitName: "Oranges" },
            { FruitName: "Pears" },
            { FruitName: "Watermelons" }
        ],
        dataTextField: "FruitName",
        animation: false,
        optionLabel: {
            FruitName: "-- Select --"
        }
    });
}

function Quantities() {
    $('#Qty').kendoNumericTextBox({
        min: 0,
        max: 100,
        step: 1,
        format: "#",
        decimals: 0,
        placeholder: "Select A Value"
    });
}

function LoadTally(a) {
    ShowTallyGrid(a);
}

function ShowTallyGrid(a) {
    $('#gdTally').kendoGrid({
        noRecords: {
            template: "No Records."
        },
        dataSource: {
            data: a
        },
        columns: [
            {
                field: "FruitName",
                title: "Fruit"
            },
            {
                field: "Qty",
                title: "Quantity"
            },
            {
                field: "Price",
                title: "Price"
            }
        ],
        scrollable: true,
        selectable: "row",
        change: function (e) {

        }
    }).data("kendoGrid");
}


