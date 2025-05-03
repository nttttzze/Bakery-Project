import { config } from "./config.js";

export const get = async (endpoint) => {
  const url = `${config.apiUrl}/${endpoint}`;

  try {
    const urlResponse = await fetch(url);

    if (urlResponse.ok) {
      return await urlResponse.json();
    } else {
      throw new Error(
        `Något gick fel ${urlResponse.status}, ${urlResponse.statusText}`
      );
    }
  } catch (error) {
    console.error(error);
  }
};

export const post = async (endpoint, data) => {
  const url = `${config.apiUrl}/${endpoint}`;

  try {
    const urlResponse = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (urlResponse.ok) {
      return await urlResponse.json();
    } else {
      throw new Error(
        `POST misslyckades: ${urlResponse.status}, ${urlResponse.statusText}`
      );
    }
  } catch (error) {
    console.error("Fel vid post", error);
    return null;
  }
};

export const patch = async (endpoint, data) => {
  const url = `${config.apiUrl}/${endpoint}`;

  try {
    const urlResponse = await fetch(url, {
      method: 'PATCH',
      headers: {
        'Content-Type' : 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (urlResponse.ok) {
      return await urlResponse.json();
    } else {
      throw new Error(
        `PATCH misslyckades: ${urlResponse.status}, ${urlResponse.statusText}`
      );
    }
  } catch (error) {
    console.error("Fel vid patch", error);
    return null;
  }
};


