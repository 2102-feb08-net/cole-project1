var producttable = document.getElementById("producttable");

function loadProduct() {
    return fetch('/products')
        .then(response => {
            return response.json();
        })

}

loadProduct()
    .then(products => {
        for (const product of products) {
            console.log(product);
            const row = producttable.insertRow();
            row.innerHTML = `<td>${product.id}</td>
                       <td>${product.productName}</td>
                       <td>${product.price}</td>`;
        }
    });