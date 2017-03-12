$(document).ready(function () {
    TallyGrid();
    FromDate();
    ToDate();
    var validatable = $("#divDateRange").kendoValidator().data("kendoValidator");

    $('#btnGetData').on('click', function () {
        var ToDateRange = $('#dpTo').val();
        var fromDateRange = $('#dpFrom').val();

        if (validatable.validate()) {
            TossIt(ToDateRange, fromDateRange);
        }
    });
});

function FromDate() {
    $("#dpFrom").kendoDatePicker({
        animation: false,
        format: "yyyy-MM-dd"
    });
}

function ToDate() {
    $("#dpTo").kendoDatePicker({
        animation: false,
        format: "yyyy-MM-dd"
    });
}


function TossIt(a, b) {
    
    var sendFruitList = JSON.parse(StorageBin.Get("FruitSold"));

    console.log(sendFruitList);

    console.log(JSON.stringify(sendFruitList));

    $.ajax({
        type: "POST",
        url: "/PedrosFruitStandHome/GetFruitTotals?toDate=" + a + "&fromDate=" + b,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ fruitlist: sendFruitList }),
        success: function (data, textStatus, jqXHR) {
            TallyGrid(data);
            //console.log(data);
        },
        complete: function (e) {
        }
    })
}


function TallyGrid(data) {
    $("#grid").kendoGrid({
        noRecords: {
            template: "No Records."
        },
        dataSource: {
            data: data
        },
        columns: [
            { field: "FruitName", title: "Fruit" },
            { field: "TotalPrice", title: "Total Sales", },
            { field: "TotalSold", title: "Total Sold" }
        ]
    });
}