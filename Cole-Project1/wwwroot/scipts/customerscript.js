var customertable = document.getElementById("customertable");
var customersearch = document.getElementById("customersearch");



customersearch.addEventListener('submit', e =>  {

    e.preventDefault();


    const search = {


        firstName: customersearch.elements['firstName'].value,

        lastName: customersearch.elements['lastName'].value,

    };

    if (!search.firstName && !search.lastName) {
        fillTable();
        return;
    }

    fetch(`/customer/search/${search.firstName}/${search.lastName}`)
        .then(response => response.json())
        .then(customers => {
            clearTable();
            for (const customer of customers) {
                const row = customertable.insertRow();
                row.innerHTML = `<td>${customer.id}</td>
                       <td>${customer.firstName}</td>
                       <td>${customer.lastName}</td>`;
                row.addEventListener('click', ClickEvent);
            }

        });
}
)

function ClickEvent(event) {
    window.location.href = "customerdetails.html";
    localStorage.setItem('currentcustomer', event.target.id);
}


function AddClickEvent(row) {
    row.addEventListener('click', event => ClickEvent(event));
}


fillTable();

function fillTable() {
    loadCustomers()
        .then(customers => {
            clearTable();
            for (const customer of customers) {
                const row = customertable.insertRow();
                row.innerHTML = `<td id=${customer.id}>${customer.id}</td>
                       <td id=>${customer.firstName}</td>
                       <td id=>${customer.lastName}</td>`;
                AddClickEvent(row);
            }
        });
}



function clearTable() {
    document.querySelectorAll("td").forEach(function (e) {
        e.remove()
    })
}


function loadCustomers() {
    return fetch('/customer/getall')
        .then(response => {
            return response.json();
        })

}
