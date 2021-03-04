const addcustomerbutton = document.getElementById('addcustomerbutton');
const addcustomerform = document.getElementById('addcustomerform');

addcustomerbutton.addEventListener('click', event => createPerson(event));

function createPerson(event) {
    event.preventDefault();

    const newCustomer = {


        firstName: addcustomerform.elements['firstName'].value,

        lastName: addcustomerform.elements['lastName'].value,

    };


    console.log(newCustomer);

    fetch('/customer/addnew', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newCustomer)
    }).then(response => {
        if (response.ok) {
            location.reload();
        }
    });

}