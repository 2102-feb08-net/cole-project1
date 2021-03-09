addorderbutton = document.getElementById('addorderbutton');
storeorderid = document.getElementById('addorderstoreid');

addorderbutton.addEventListener('click', AddOrder);

function AddOrder() {


    let order = {
        customerId: parseInt(customerid.value),

        storeId: parseInt(storeorderid.value)
    }

    fetch('/addorder', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    }).then(response => {
        if (response.ok) {
            location.reload();
        }
    });
}


