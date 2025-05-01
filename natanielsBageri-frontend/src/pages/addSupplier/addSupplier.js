import { post } from '../../lib/helpers/httpClient.js';

const add = document.getElementById('post-form')

const addSupplier = async (e) => {
    e.preventDefault();

    const supData = new FormData(e.target);
    const supInfo = Object.fromEntries(supData.entries());

    const response = await post('supplier', supInfo);
    console.log("Resultat:", response, supInfo);

    if(response)
    {
        window.location.href = '../suppliers/suppliers.html'
    };

};
add.addEventListener('submit', addSupplier);