function save(event) {
    var productTarget = event.target;
    var tdElements = productTarget.parentElement.parentElement.querySelectorAll('td');
    var productName = tdElements[0].innerText;
    var description = tdElements[1].innerText;
    var SKU = tdElements[2].innerText;
    var price = tdElements[3].innerText;
    var product = {};
    product.name = productName;
    product.description = description;
    product.SKU = SKU;
    product.price = price;
    if (localStorage.getItem('data') == null) {
        localStorage.setItem('data', '[]');
    }
    var oldData = JSON.parse(localStorage.getItem('data'));
    if (oldData.length == 0) {
        oldData.push(product);
    } else {
        var isMatch = false;
        for (var i = 0; i < oldData.length; i++) {
            if (oldData[i].name === productName) {
                isMatch = true;
                break;
            }
        }
        if (!isMatch) {
            oldData.push(product);
        }
    }

    localStorage.setItem('data', JSON.stringify(oldData));
}