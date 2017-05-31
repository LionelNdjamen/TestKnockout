//$(document).ready(function () {
var MyData; 
function GetCustomer() {
    $.ajax({
        url: 'api/Customer/GetCustomer',
        type: 'GET',
        data: MyData
    }).success(function (data, status) {
        console.log("status => " + status);
        ko.applyBindings({
            Customers: data,
        }, document.getElementById("bindingCustomer")
        );

    }).error(function (request, status, errorThrown) {
        console.log("status => " + status);
        console.log(errorThrown);
    })
}

function LesAges() {
    var tabAges = new Array();
    for (var i = 0; i < 120; i++) {
        tabAges.push(i+1);
    }
    return tabAges;
}

$(document).ready(function () {
    GetCustomer();
    var ViewModel = {
        id: ko.observable(0),
        lastName: ko.observable(""),
        firstName: ko.observable(""),
        age: ko.observable(10),
        sexe: ko.observable("Feminin")
    }
    ko.applyBindings(ViewModel, document.getElementById("creationCustomer")); 
})