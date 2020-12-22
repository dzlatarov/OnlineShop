var productsTargets = document.getElementsByClassName("shoppingCart");
for (var i = 0; i < productsTargets.length; i++) {
    productsTargets[i].addEventListener("click", function () {
        save(event)
    })
}

function save(event) {
    var productTarget = event.target;
    var tdElements = productTarget.parentElement.parentElement.querySelectorAll('td');
    var productNmae = tdElements[0].innerText;
    var description = tdElements[1].innerText;
    var SKU = tdElements[2].innerText;
    var price = tdElements[3].innerText;    
}