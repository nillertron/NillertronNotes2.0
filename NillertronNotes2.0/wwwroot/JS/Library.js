function RemoveDiv(divId) {
    var div = document.getElementById(divId);
    div.hidden = true;
}
function ShowDiv(divId) {
    var div = document.getElementById(divId);
    div.hidden = false;
}
function GoBack() {
    try {
        window.history.back();
    }
    catch (error) {
        window.close();
    }
    
}
function WriteCookie(name, value, days) {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}
function GetCookie(cookieName) {
    var name = cookieName + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return null;
}

function CheckCookie(cookieName) {
    var cookie = GetCookie(cookieName)
    if (cookie != null)
        return true;
    else
        return false;
}

function openNav() {
    var menu = document.getElementById("MenuCol");
    menu.className = "col-2";
    menu.nextElementSibling.className = "col-10";
    
}
function closeNav() {
    document.getElementById("mySidenav").style.width = "5%";
    var menu = document.getElementById("MenuCol");
    menu.className = "";
    menu.style.width = "2%";
    menu.nextElementSibling.className = "";
    menu.nextElementSibling.style.width = "98%";
}