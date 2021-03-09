///Table we place order details into

const ordertable = document.getElementById("orderdetailstable");
const ordertablebody = document.getElementById("ordertablebody");

/// Customer Information Fields

const storeid = document.getElementById("storeid");
const storecity = document.getElementById("storecity");
const storestate = document.getElementById("storestate");

/// Elements to search

LoadPage(1);

function LoadPage(id) {

    if (localStorage.getItem("currentstore") != null) {
        id = localStorage.getItem("currentstore");
    }

    GetOrders(id);

    StoreDetails(id);

};

function UpdatePage(id) {

    GetOrders(id);

    StoreDetails(id);

};

function ClickEvent(event) {
    let id = event.target.id;
    localStorage.setItem('currentorder', id);
    window.location.href = "orderdetail.html";

}


function AddClickEvent(row) {
    row.addEventListener('click', event => ClickEvent(event));
}


function StoreDetails(id) {

    fetch(`/storelocation/${id}`)
        .then(response => response.json())
        .then(storedetails => {
            if (storedetails) {
                storeid.value = storedetails.id;
                storecity.value = storedetails.city;
                storestate.value = storedetails.state;
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
                row.innerHTML = `<td id=${order.orderId}>${order.orderId}</td>
                       <td>${order.customerFirstName}</td>
                       <td>${order.customerLastName}</td>
                       <td>${order.numberOfProducts}</td>
                       <td style="background-color:${color}">$${order.totalPrice}</td>`;
                AddClickEvent(row);
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

