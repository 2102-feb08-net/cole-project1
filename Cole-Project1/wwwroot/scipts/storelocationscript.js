var storetable = document.getElementById("storetable");

function loadTables() {
    return fetch('/storelocations')
        .then(response => {
            return response.json();
        })

}

loadTables()
    .then(stores => {
        for (const store of stores) {
            console.log(store);
            const row = storetable.insertRow();
            row.innerHTML = `<td>${store.id}</td>
                       <td>${store.city}</td>
                       <td>${store.state}</td>
                       <td>${store.address}</td>
                       <td>${store.phoneNumber}</td>`;
        }
    });