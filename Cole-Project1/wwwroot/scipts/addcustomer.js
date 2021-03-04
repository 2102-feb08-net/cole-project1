const addcustomerbutton = document.getElementById('addcustomerbutton');
const addcustomerform = document.getElementById('addcustomerform');

addcustomerbutton.addEventListener('click', event => createPerson(event));

function createPerson(event) {
    event.preventDefault();
    console.log("yooo");
}