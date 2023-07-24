$(document).ready(function () {
    $('#SearchString').on('input', function () {
        var searchString = $(this).val();
        if (searchString.length < 2) {
            $('#searchResults').empty();
            return;
        }
        $.get('/HangHoas/ProductSearching', { searchString: searchString }, function (data) {
            $('#searchResults').html(data);
        });
    });
});

function newCart() {
    fetch('/HoaDons/newCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                window.location.reload();
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
}
function countChange() {
    var total = parseInt(document.getElementById("total").innerText.replace(/,/g, ""));
    var khachDua = parseInt(document.getElementById("kd").value);
    var change = khachDua - total;
    var changeSpan = document.getElementById("change");
    changeSpan.innerText = change;
}
function checkOut() {
    var amountPaid = parseFloat(document.getElementById('kd').value);
    var totalAmount = parseFloat(document.getElementById('total').textContent.replace(/[^\d.]/g, ''));

    if (amountPaid >= totalAmount) {
        var data = {
            kd: amountPaid,
            change: amountPaid - totalAmount
        };
        $.ajax({
            type: 'POST',
            url: '@Url.Action("CheckOut", "HoaDons")',
            data: data,
            success: function (result) {
                showModal(1);
            },
            error: function (xhr, status, error) {
                console.error('Error during checkout:', error);
            }
        });
    } else {
        showModal(2);
    }

}
function showModal(x) {
    var modal;
    if (x == 2) {
        modal = document.getElementById('errorModal');
    }
    else {
        modal = document.getElementById('checkoutModal');
    }
    modal.style.display = 'block';

    setTimeout(closeModal, 1200, x);

}

function closeModal(x) {
    var modal;
    if (x == 2) {
        modal = document.getElementById('errorModal');

    } else {
        modal = document.getElementById('checkoutModal');
    }
    modal.style.display = 'none';
    if (x == 1)
        window.location.reload();
}