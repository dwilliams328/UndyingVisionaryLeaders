function pasuser(form) {
    if (form.id.value == "user") {
        if (form.pass.value == "password") {
            location = "index.html"
        } else {
            alert("Invalid Password")
        }
    } else {
        alert("Invalid UserID")
    }
}

function validate() {
    var un = document.myform.username.value;
    var pw = document.myform.pword.value;
    var valid = false;

    var unArray = ["Philip", "George", "Sarah", "Michael"];  // as many as you like - no comma after final entry
    var pwArray = ["Password1", "Password2", "Password3", "Password4"];  // the corresponding passwords;

    for (var i=0; i <unArray.length; i++) {
        if ((un == unArray[i]) && (pw == pwArray[i])) {
            valid = true;
            break;
        }
    

        if (valid) {
            alert ("Login was successful");
            window.location.href = "Home.html";
            return false;
        }
    }
}