import { handlePostSubmit } from '../../lib/helpers/formHandler.js';

const add = document.getElementById('post-form')
add.addEventListener('submit', (e) => handlePostSubmit(e, 'supplier', '../suppliers/suppliers.html', "Leverantör tillagd!"));
