﻿///Table we place products

const producttable = document.getElementById("productdetailstable");
const producttablebody = document.getElementById("producttablebody");

/// Order Information Fielda

const orderid = document.getElementById("orderid");
const customerfirst = document.getElementById("customerfirst");
const customerlast = document.getElementById("customerlast");
const orderprice = document.getElementById("orderprice");
const orderlocation = document.getElementById("orderlocation");

/// Select Picker 

const storeproducts = document.getElementById("storeproducts");

/// Elements to search

const getdetailsbutton = document.getElementById("getdetailsbutton");
const addproductbutton = document.getElementById("addproductbutton");

getdetailsbutton.addEventListener('click', LoadPage);
addproductbutton.addEventListener('click', AddProductToOrder);

LoadPage();

function LoadPage() {

    let searchid = document.getElementById("seachcustomerid").value;

    let searchidint = parseInt(searchid);

    if (!searchidint) {
        alert("Customer id must be an integer.")
        return;
    }

    GetProducts(searchidint);

    CustomerDetails(searchidint);

    GetProductByOrderId(searchidint);

};

function CustomerDetails(id) {

    fetch(`/customer/GetOrder/${id}`)
        .then(response => response.json())
        .then(customerdetails => {
            if (customerdetails) {
                orderid.value = customerdetails.orderId;
                customerfirst.value = customerdetails.customerFirstName;
                customerlast.value = customerdetails.customerLastName;
                orderlocation.value = `${customerdetails.storeCity},${customerdetails.storeState}`;
               
            }

        });


};

function GetProducts(id) {

    clearTable();

    fetch(`/storeinventory/${id}`)
        .then(response => response.json())
        .then(order => {
            for (const orderline of order) {
                const option = document.createElement("option");
                option.text = orderline.productName;
                storeproducts.add(option);
                   
            }

        });


}

function GetDetails(id) {

    let customeridint = parseInt(id);

    if (!customeridint) {
        alert("Customer id must be an integer.")
        return;
    }
    LoadPage(customeridint);
}

function GetProductByOrderId(id) {
    fetch(`/customer/GetOrderDetail/${id}`)
        .then(response => response.json())
        .then(order => {
            for (const orderline of order) {
                const row = ordertablebody.insertRow();
                row.innerHTML = `<td">${orderline.productId}</td>
                       <td>${orderline.productName}</td>
                       <td>$${orderline.price}</td>
                       <td>${orderline.quantity}</td>`

            }

        });
}

function AddProductToOrder() {

    let productquantity = document.getElementById('productquantity').value;
    let productname = document.getElementById('storeproducts').value;
    let currentorderid = document.getElementById('orderid').value;

    let productquantityint = parseInt(productquantity);
    let currentorderidint = parseInt(currentorderid);

    let request = {

        ProductName: productname,

        Quantity: productquantityint,

        OrderId: currentorderidint

    };

    fetch('/processrequest/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: request
    }).then(response => {
        if (!response.ok) {
            throw new Error(`Network response was not ok (${response.status})`);
        }
    });
  

    debugger;
}

/// Helper Methods to help select color for price column in table, and remove table data when needing to refresh.

function clearTable() {
    document.querySelectorAll("tbody tr").forEach(function (e) {
        e.remove()
    });

    document.querySelectorAll("option").forEach(function (e) {
        e.remove()
    });


}

