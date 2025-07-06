const initApp = () => {};
const add = document.getElementById("register-form");

const register = async (e) => {
  e.preventDefault();
  const registerData = new FormData(e.target);
  const registerInfo = Object.fromEntries(registerData.entries());

  try {
    var url = "http://localhost:5010/api/auth/register/";
    const respone = await fetch(url, {
      method: "POST",
      headers: {
        "content-type": "application/json",
      },
      body: JSON.stringify(registerInfo),
    });
    console.log("Data: ", registerData, "Info: ", registerInfo);

    if (respone.ok) {
      const result = await respone.json();
      console.log(result);
    }
  } catch (error) {
    console.log("Error", error);
  }
};
document.addEventListener("DOMContentLoaded", initApp);
document.querySelector("#register-form").addEventListener("submit", register);
