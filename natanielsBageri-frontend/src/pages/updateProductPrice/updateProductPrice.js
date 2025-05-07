import { patch } from "../../lib/helpers/httpClient.js";

const add = document.getElementById('update-form')



const updatePrice = async (e) => {
    e.preventDefault();

    const id = document.getElementById('productId').value;
    const endpoint = `products/${id}`;
    console.log(endpoint);

    const prodData = new FormData(e.target);
    const prodInfo = Object.fromEntries(prodData.entries());

    const response = await patch(endpoint, prodInfo);
    console.log("Resultat:", response, prodInfo);

    if(response)
        {
            window.location.href = '../products/products.html'
            alert("Pris uppdaterat!")
        };


}
add.addEventListener('submit', updatePrice);