import { handlePostSubmit } from "../../lib/helpers/formHandler.js";

const add = document.getElementById('order-form')
add.addEventListener('submit', (e) => handlePostSubmit(e, 'orders', '../products/products.html', "Order skapad!" ));


// const addOrder = async (e) => {
//     e.preventDefault();

//     const orderData = new FormData(e.target);
//     const orderInfo = Object.fromEntries(orderData.entries());

//     const response = await post('orders', orderInfo);
//     console.log("Resultat:", response, orderInfo);

//     if(response){
//     alert("Order skapad!")
//     }
// };
// add.addEventListener('submit', addOrder);