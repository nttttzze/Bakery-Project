function validatePassword() {
  var password = $("#password").val();

  if (password.length >= 8) {
    $("password-error").text("");
    return true;
  } else {
    $("#password-error").text("Password must be 8 characters");
    return false;
  }
}
