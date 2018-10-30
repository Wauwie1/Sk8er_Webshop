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

    Basket = JSON.parse(localStorage.getItem("BasketKey"));

    if (!Array.isArray(Basket)) {
        Basket = [];
        Basket.push(orderItem);
    } else {
        Basket.push(orderItem);

    }
    localStorage.setItem("BasketKey", JSON.stringify(Basket));

    $("#text_added").fadeIn(500);

}

