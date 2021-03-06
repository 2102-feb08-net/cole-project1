﻿///Table we place order details into

const ordertable = document.getElementById("orderdetailstable");
const ordertablebody = document.getElementById("ordertablebody");

/// Customer Information Fielda

const customerid = document.getElementById("customerid");
const customerfirst = document.getElementById("customerfirst");
const customerlast = document.getElementById("customerlast");

/// Elements to search

const getdetailsbutton = document.getElementById("getdetailsbutton");

getdetailsbutton.addEventListener('click', GetDetails);

LoadPage();

function LoadPage() {

        storageid = localStorage.getItem("currentcustomer");

        GetOrders(storageid);

        CustomerDetails(storageid);


};

function UpdatePage(id) {

    GetOrders(id);

    CustomerDetails(id);
}

function CustomerDetails(id) {

    fetch(`/customer/${id}`)
        .then(response => response.json())
        .then(customerdetails => {
            if (customerdetails) {
                customerid.value = customerdetails.id;
                customerfirst.value = customerdetails.firstName;
                customerlast.value = customerdetails.lastName;
            }

        });


};

function GetOrders(id) {

    clearTable();

    fetch(`/customer/getorders/${id}`)
        .then(response => response.json())
        .then(orderdetails => {
            if (!orderdetails) {
                return;
            }

            for (const order of orderdetails) {
                const row = ordertablebody.insertRow();
                let color = getColor(order.totalPrice);
                row.innerHTML = `<td id=${order.orderId}>${order.orderId}</td>
                       <td id=${order.orderId}>${order.storeCity}</td>
                       <td id=${order.orderId}>${order.storeState}</td>
                       <td id=${order.orderId}>${order.numberOfProducts}</td>
                       <td style="background-color:${color}">$${order.totalPrice}</td>`;
                AddClickEvent(row);
            }

        }); 


}

function ClickEvent(event) {
    let id = event.target.id;
    localStorage.setItem('currentorder', id);
    window.location.href = "orderdetail.html";

}


function AddClickEvent(row) {
    row.addEventListener('click', event => ClickEvent(event));
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

