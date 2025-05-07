import { handlePostSubmit } from "../../lib/helpers/formHandler.js";

const add = document.getElementById('post-form')
add.addEventListener('submit', (e) => handlePostSubmit(e, 'customer', '../customers/customers.html', "Kund tillagd!"));









// const add = document.getElementById('post-form')
// const addCustomer = async (e) => {
//     e.preventDefault();

//     const cusData = new FormData(e.target);
//     const cusInfo = Object.fromEntries(cusData.entries());

//     const response = await post('customer', cusInfo);
//     console.log("Resultat: ", response, cusInfo);

//     if(response)
//         {
//         window.location.href = '../customers/customers.html'
//     };
// };
// add.addEventListener('submit', addCustomer);