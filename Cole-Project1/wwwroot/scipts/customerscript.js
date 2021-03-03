var customertable = document.getElementById("customertable");

function loadCustomers() {
    return fetch('/customer/getall')
        .then(response => {
            return response.json();
        })

}

loadCustomers()
    .then(customers => {
        for (const customer of customers) {
            const row = customertable.insertRow();
            row.innerHTML = `<td>${customer.id}</td>
                       <td>${customer.firstName}</td>
                       <td>${customer.lastName}</td>`;
        }
    });