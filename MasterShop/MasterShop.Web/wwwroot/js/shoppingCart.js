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

function showProducts() {
    var button = document.createElement('button');
    button.className = 'btn btn-danger';
    button.innerHTML = 'Remove';
    button.onclick = 'remove(event)';
    var body = document.getElementById('body');
    var trElement = document.createElement('tr');
    var tdNameElement = document.createElement('td');
    var tdDescriptionElement = document.createElement('td');
    var tdSKUElement = document.createElement('td');
    var tdPriceElement = document.createElement('td');
    var tdDelBtnElement = document.createElement('td');

    var data = JSON.parse(localStorage.getItem('data'));
    if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            tdNameElement.innerHTML = data[i].name;
            tdDescriptionElement.innerHTML = data[i].description;
            tdSKUElement.innerHTML = data[i].SKU;
            tdPriceElement.innerHTML = data[i].price;
            tdDelBtnElement.appendChild(button);

            trElement.appendChild(tdNameElement);
            trElement.appendChild(tdDescriptionElement);
            trElement.appendChild(tdSKUElement);
            trElement.appendChild(tdPriceElement);
            trElement.appendChild(tdDelBtnElement)

            body.appendChild(trElement);
        }
    }
}

function remove(event) {
    var target = event.target;

}