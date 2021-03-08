///Table we place order details into

const ordertable = document.getElementById("orderdetailstable");
const ordertablebody = document.getElementById("ordertablebody");

/// Customer Information Fielda

const customerid = document.getElementById("customerid");
const customerfirst = document.getElementById("customerfirst");
const customerlast = document.getElementById("customerlast");

/// Elements to search

const getdetailsbutton = document.getElementById("getdetailsbutton");

getdetailsbutton.addEventListener('click', GetDetails);

LoadPage(1);

function LoadPage(id) {

    if (localStorage.getItem("currentcustomer") != null) {
        id = localStorage.getItem("currentcustomer");
    }

    GetOrders(id);

    CustomerDetails(id);

};

function UpdatePage(id) {

    GetOrders(id);

    CustomerDetails(id);

};

function CustomerDetails(id) {

    fetch(`/storelocation/${id}`)
        .then(response => response.json())
        .then(storedetails => {
            if (storedetails) {
                storeid.value = storedetails.storeId;
                storecity.value = storedetails.storeCity;
                storestate.value = storedetails.storeState;
            }

        });


};


function GetOrders(id) {

    clearTable();

    fetch(`/customer/getorders/${id}`)
        .then(response => response.json())
        .then(orderdetails => {
            for (const order of orderdetails) {
                const row = ordertablebody.insertRow();
                let color = getColor(order.totalPrice);
                row.innerHTML = `<td">${order.orderId}</td>
                       <td>${order.storeCity}</td>
                       <td>${order.storeState}</td>
                       <td>${order.numberOfProducts}</td>
                       <td style="background-color:${color}">$${order.totalPrice}</td>`;
            }

        });


}

function GetDetails() {

    let searchid = document.getElementById("seachcustomerid").value;

    let customeridint = parseInt(searchid);

    if (!customeridint) {
        alert("Customer id must be an integer.")
        return;
    }
    UpdatePage(customeridint);
}


/// Helper Methods to help select color for price column in table, and remove table data when needing to refresh.

function clearTable() {
    document.querySelectorAll("tbody tr").forEach(function (e) {
        e.remove()
    });


}


function getColor(value) {
    if (value < 1000) {
        return "#90EE90";
    }

    else if (value >= 1000 && value < 10000) {
        return "#FFFFE0";
    }
    else if (value > 10000) {
        return "#CD5C5C";
    }

    return "#FFFFFF";
}

