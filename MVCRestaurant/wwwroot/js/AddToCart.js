function AddToCart(itemid, inc) {
    //console.log(event.target)
    var tar = event.target
    $.ajax({
        url: "/Order/AddToCart?itemId=" + itemid + "&increment=" + inc,
        type: 'GET',
        dataType: 'json', //data type
        success: function (res) {
            //console.log("++Message: \n");
            //console.log(res)
            //console.log(res.quantity)
            if (res.quantity > 0) {
                createQuantityControllerUI(itemid, res.quantity, tar)
            }
            else {
                createOrderButton(itemid, tar);
            }
            setShoppingCounter(res.total)
        },
        error: function (jqXHR, exception) {
            console.log(jqXHR);
            // error handling logic here...
        }
    });
}


//function AddToCart_t(itemid, inc) {
//    console.log(event.target);
//    max = 10; min = 1;
//    var r = Math.floor(Math.random() * (max - min + 1) + min)
//    console.log("random number is: " + r)
//    if (r > 2) {
//        createQuantityControllerUI(itemid, r)
//    }
//    else {
//        createOrderButton(itemid);
//    }
//}

//QC-UI
function createQuantityControllerUI(itemId, quantity, tar) {
    //debugger;
    //console.log(event.target);
    QCdiv = document.createElement('template');
    QCdiv.innerHTML =
        '<span id=foodItem_' + itemId + ' class="QCUI">' +
        '<i class="bi bi-caret-up-square-fill" style="display:inline;" onclick="AddToCart(' + itemId + ', true)"></i> ' +
        '<p style="display:inline"> ' + quantity + ' </p>' +
        '<i class="bi bi-caret-down-square-fill" style="display:inline" onclick="AddToCart(' + itemId + ', false)"></i>' +
        '</span >';
    if (tar.tagName != "I") {
        tar.replaceWith(QCdiv.content.firstChild)
    }
    else {
        tar.parentNode.replaceWith(QCdiv.content.firstChild)
    }
    
}

function createOrderButton(itemId, tar) {
    QCdiv = document.createElement('template');
    QCdiv.innerHTML =
    '<a class="btn btn-primary" onclick="AddToCart(' + itemId + ',true)">افزودن به سبد خرید</a>'

    if (tar.tagName != "I") {
        tar.replaceWith(QCdiv.content.firstChild)
    }
    else {
        tar.parentNode.replaceWith(QCdiv.content.firstChild)
    }
}

function getOrdersCount(func) {
    $.ajax({
        url: "/Order/TotalCount",
        type: 'GET',
        dataType: 'json', //data type
        success: function (res) {
            cnt = res.quantity
            //console.log("1: " + cnt);
            func(cnt);
        },
        error: function (jqXHR, exception) {
            console.log(jqXHR);
            // error handling logic here...
            func(0);
        }
    });

}

function setShoppingCounter(cnt) {
    let div = document.getElementById("ItemsQuantity");
    let div2 = document.getElementById("navOrderButton");
    if (cnt > 0) {
        div.innerHTML = cnt
        div2.style.display = "block";
    }
    else {
        div.innerHTML = ""
        div2.style.display = "none";
    }
    //console.log("3: " + cnt);
}

//window.addEventListener('pageshow', function () {
//    console.log("window.onload1");
//    getOrdersCount(setShoppingCounter);
//    console.log("window.onload2");
//    alert('window.addEventListener');
//})


$(document).ready(function () {
    //console.log("window.onload1");
    getOrdersCount(setShoppingCounter);
    //console.log("window.onload2");
})
