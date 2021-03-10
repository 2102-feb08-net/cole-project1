var storetable = document.getElementById("storetable");

function loadTables() {
    return fetch('/storelocations')
        .then(response => {
            return response.json();
        })

}

function ClickEvent(event) {
    let id = event.currentTarget.dataset.id;
    localStorage.setItem('currentstore', id);
    debugger;
    window.location.href = "storedetail.html";

}


function AddClickEvent(row) {
    row.addEventListener('click', event => ClickEvent(event));
}

loadTables()
    .then(stores => {
        for (const store of stores) {
            console.log(store);
            const row = storetable.insertRow();
            row.innerHTML = `<td id=${store.id}>${store.id}</td>

                       <td>${store.city}</td>
                 <td>${store.state}</td>
                       <td>${store.address}</td>
                       <td>${store.phoneNumber}</td>`;
            row.dataset.id = store.id;

            AddClickEvent(row);
        }
    });
