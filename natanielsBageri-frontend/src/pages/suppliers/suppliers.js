import * as http from '../../lib/helpers/httpClient.js';

const supplierList = document.querySelector('#suppliers')

const initApp = () => {
    loadSuppliers();
};

const loadSuppliers = async() => {
    const result = await http.get('supplier');
    console.log("Data: ", result);

    result.p.forEach((suppliers) => {
        supplierList.appendChild(createHtml(suppliers));
      });
    };
    
    const createHtml = (supplier) => {
      const display = document.createElement("div");
    
      let html = `<section class="card">
        <div class="card-body">
        <h3 class="p-name"> ${supplier.name}</h3>
    
        <p> Nummer: ${supplier.phone}</p>
        <p> Address: ${supplier.address}</p>
   
                <p class="p-price"> Email: ${supplier.email}</p>
    
        
    
        </div>
        
        </section>`;
    
      display.innerHTML = html;
      return display;
    };

document.addEventListener('DOMContentLoaded', initApp);