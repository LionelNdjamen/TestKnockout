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
            Customers: data
        });
    }).error(function (request, status, errorThrown) {
        console.log("status => " + status);
        console.log(errorThrown);
    })
}

function OpenModal() {
    //$("myModal").focus();
    console.log('good'); 
}

//$("#idLink").click(GetCustomer);
//$("#idLink").click(function () {
//    location.reload();
//})
//$("#tableCustomer").change(GetCustomer); 

$(document).ready(function () {
    GetCustomer();
})