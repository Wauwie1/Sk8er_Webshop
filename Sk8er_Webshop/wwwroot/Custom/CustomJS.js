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

    var orderItem = {
        Id: id,
        Amount: amount,
        Size: $("#selectSize option:selected").text()
    };

    alert("ID: " + orderItem.Id + ". Amount: " + orderItem.Amount + ". Size: " + orderItem.Size);
}

