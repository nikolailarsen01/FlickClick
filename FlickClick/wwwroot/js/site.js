// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function LoadNewsAndComingSoon() {

}

function HomePage() {
    window.location.href = "/Home";
}

function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function validateForm(form) {
    var inputs = form.getElementsByTagName('input');
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].value.replace(/\s/g, '') == "") {
            alert("Please fill all empty fields");
            return false;
        }
    }

    if (document.forms["registerForm"]["email"].value != document.forms["registerForm"]["confirmEmail"].value) {
        alert("Emails do not match");
        return false;
    }

    if (document.forms["registerForm"]["phoneNumber"].value.length != 8) {
        alert("Invalid phone number");
        return false;
    }

    if (document.forms["registerForm"]["password"].value != document.forms["registerForm"]["passwordEmail"].value) {
        alert("Passwords do not match");
        return false;
    }

    if (!validateEmail(document.forms["registerForm"]["email"].value)) {
        alert("Please insert a valid email");
        return false;
    }

    return true;
}

function search() {
    window.location.href = "/View/Movies/" + document.getElementById("search").value;
}