// För hamburgarmeny
function toggleMenu() {
  const nav = document.getElementById("nav-links");
  nav.classList.toggle("show");
}

function showPsw() {
  var x = document.getElementById("password");
  var y = document.getElementById("confirmPassword");
  if (x.type === "password") {
    x.type = "text";
    y.type = "text";
  } else {
    x.type = "password";
    y.type = "password";
  }
}

function hideElements() {
  var x = document.querySelectorAll(".add-product-button");
  if (sessionStorage.getItem("user") === null) {
    x.forEach((x) => (x.style.display = "none"));
  }
}
document.addEventListener("DOMContentLoaded", function () {
  hideElements();
});
