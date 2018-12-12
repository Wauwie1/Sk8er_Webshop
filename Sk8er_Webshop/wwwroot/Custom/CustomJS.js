function SearchStock() {
    var input, search, table, tr, td, i;
    input = document.getElementById("searchStock");
    search = input.value.toUpperCase();
    table = document.getElementById("StockTable");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            if (td.innerHTML.toUpperCase() == search) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
        if (search == "") {
            tr[i].style.display = "";
        }
    }
}


function AddItemToBasket(id, amount) {
    var Basket = [];
    $("#text_added").hide();

    //Creates basketitem
    var orderItem = {
        Id: id,
        Amount: amount,
        Size: $("#selectSize option:selected").text()
    };

    //Tries to get the basket if the cookie exists
    try {
        var JSONBasket = Cookies.get("BasketCookie");
        Basket = JSON.parse(JSONBasket);
    } catch (err) {
        console.log(err.message);
    }

    if (!Array.isArray(Basket)) {
        Basket = [];
        Basket.push(orderItem);
    } else {
        Basket.push(orderItem);

    }

    //Save basket
    JSONBasket = JSON.stringify(Basket);
    Cookies.set("BasketCookie", JSONBasket);

    //Show text
    $("#text_added").fadeIn(500);

}

function RemoveItemFromBasket(id) {
    //Set Basket from cookie
    var Basket = [];
    var JSONBasket = Cookies.get("BasketCookie");
    Basket = JSON.parse(JSONBasket);

    //Find item to be deleted and delete it
    var index = Basket.findIndex(item => item.Id === id);
    Basket.splice(index, 1);

    //Save updated basket
    JSONBasket = JSON.stringify(Basket);
    Cookies.set("BasketCookie", JSONBasket);

    //Reload page
    location.reload();
}

function passValidation() {
    let pass = document.querySelector("#inputPassword").value;
    let passConfirm = document.querySelector("#inputPasswordConfirm").value;

    let length = false;
    let match = false;

    if (pass.length < 8) {
        $("#shortText").fadeIn(500);
    } else {
        $("#shortText").fadeOut(500)
        length = true;
    }

    if (pass != passConfirm) {
        $("#matchText").fadeIn(500);
    } else {
        $("#matchText").fadeOut(500);
        match = true;
    }

    if (match && length) {
        console.log("Match");
        document.getElementById("registerButton").disabled = false;
    } else {
        document.getElementById("registerButton").disabled = true;
    }
}
    