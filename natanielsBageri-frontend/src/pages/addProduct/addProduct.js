import { handlePostSubmit } from '../../lib/helpers/formHandler.js';


const add = document.getElementById('post-form')
add.addEventListener('submit', (e) => handlePostSubmit(e, 'products', '../products/products.html', "Produkt tillagd!"));




// --------------------------------------------------
// const add = document.getElementById('post-form')

// const addProduct = async (e) => {
//     e.preventDefault();

//     const prodData = new FormData(e.target);
//     const prodInfo = Object.fromEntries(prodData.entries());

//     const response = await post('products', prodInfo);
//     console.log("Resultat:", response, prodInfo);

//     if(response)
//     {
//         window.location.href = '../products/products.html'
//     };
// };
// add.addEventListener('submit', addProduct);
// --------------------------------------------------