import * as http from "../../lib/helpers/httpClient.js";

const productsList = document.querySelector("#products");

const initApp = () => {
  loadProducts();
};

const loadProducts = async () => {
  const result = await http.get("products");
  console.log("Data: ", result);

  result.products.forEach((product) => {
    productsList.appendChild(createHtml(product));
  });
};

const createHtml = (product) => {
  const display = document.createElement("div");

  let html = `<section class="card">
    <div class="card-body">
    <h3 class="p-name"> ${product.articleName}</h3>

    <p> Bäst före: ${product.bestBeforeDate}</p>
    <p> Utgångsdatum: ${product.expirationDate}</p>
        <p> Antal per paket: ${product.quantityPerPackage}</p>
            <p class="p-price"> Pris: ${product.pricePerKg} Kr/Kg</p>

    

    </div>
    
    </section>`;

  display.innerHTML = html;
  return display;
};

document.addEventListener("DOMContentLoaded", initApp);
