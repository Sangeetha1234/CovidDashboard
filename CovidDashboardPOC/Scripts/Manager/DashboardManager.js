$(document).ready(function () {
    var dashBoardViewModel = function () {
        var self = this;
        this.locationDataSource = ko.observable(new kendo.data.DataSource({
            type: "json",
            transport: {
                read: "/Dashboard/getCovidDataByDate",
            },
            pageSize: 10
        }));
    }
    var objBind = new dashBoardViewModel();
    $("#locationsGrid").kendoGrid({
        dataSource: objBind.locationDataSource(),
        noRecords: true,
        scrollable: false,
        sortable: true,
        filterable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
           { field: "", title: "", width: "30px", template: '#if(Indicator==\'1\'){#<span style=\'background-color:red\' title=\'up\'><i class="fas fa-arrow-up"></i></span>#} else if (Indicator==\'3\') {#<span style=\'background-color:green\' title=\'equal\'><i class="fas fa-equals"></i></span>#} else if (Indicator==\'4\') {#<span style=\'background-color:yellow\' title=\'unpredictable\'><i class="fas fa-tape"></i></span>#} else if (Indicator==\'2\') {#<span style=\'background-color:blue\' title=\'down\'><i class="fas fa-download"></i></span>#}#' },
           { field: "LocationName", title: "Location Name", width: "230px"},
           { field: "Date", title: "Date", width: "160px", template: "#= kendo.toString(kendo.parseDate(Date, 'dd MMM yyyy hh:mm'), 'dd MMM yyyy hh:mm') #" },
           { field: "ActiveCases", title: "Active Cases", width: "230px" },
           { field: "DischargedCases", title: "Discharge Cases", width: "230px" },
           { field: "Deaths", title: "Deaths", width: "230px" },
        ]
    });


    ko.applyBindings(objBind);
});