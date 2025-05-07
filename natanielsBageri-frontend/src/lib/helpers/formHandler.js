import { post } from './httpClient.js'

export const handlePostSubmit = async (e, route, redirectLink, popup) => {
    e.preventDefault();

    const data = new FormData(e.target);
    const info = Object.fromEntries(data.entries());

    const response = await post(route, info);
    console.log("Resultat:", response, info);

    if(response)
        {
            location.href = redirectLink;
            alert(popup)
        };

};


