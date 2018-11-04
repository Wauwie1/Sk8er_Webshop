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

var Basket = [];
function AddItemToBasket(id, amount) {
    $("#text_added").hide();
    var orderItem = {
        Id: id,
        Amount: amount,
        Size: $("#selectSize option:selected").text()
    };

    //GET BASKET
    var JSONBasket = Cookies.get("BasketCookie");
    alert(JSONBasket);
    Basket = JSON.parse(JSONBasket);
   
    if (!Array.isArray(Basket)) {
        Basket = [];
        Basket.push(orderItem);
    } else {
        Basket.push(orderItem);

    }

    JSONBasket = JSON.stringify(Basket);
    alert(JSONBasket);
    //SET BASKET
    Cookies.set("BasketCookie", JSONBasket);

    $("#text_added").fadeIn(500);

}
