import * as http from "../../lib/helpers/httpClient.js";

const customerList = document.querySelector("#customers");

const initApp = () => {
  loadCustomer();
};

const loadCustomer = async () => {
  const result = await http.get("customer");
  console.log("Data: ", result);

  result.c.forEach((customer) => {
    customerList.appendChild(createHtml(customer));
  });
};

const createHtml = (customer) => {
  const display = document.createElement("div");

  let html = `<section class="card">
    <div class="card-body">
    <h3 class="p-name"> ${customer.name}</h3>

    <p> Nummer: ${customer.phone}</p>
    <p> Kontaktperson: ${customer.contactPerson}</p>
        <p> Leveransadress: ${customer.deliveryAddress}</p>
            <p class="p-price"> Fakturaadress: ${customer.invoiceAddress}</p>
    <p>Kund Id: ${customer.id}</p>
    </div>
    
    </section>`;

  display.innerHTML = html;
  return display;
};

document.addEventListener("DOMContentLoaded", initApp);
