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
            }

        });
}
)

fillTable();

function fillTable() {
    loadCustomers()
        .then(customers => {
            clearTable();
            for (const customer of customers) {
                const row = customertable.insertRow();
                row.innerHTML = `<td>${customer.id}</td>
                       <td>${customer.firstName}</td>
                       <td>${customer.lastName}</td>`;
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
