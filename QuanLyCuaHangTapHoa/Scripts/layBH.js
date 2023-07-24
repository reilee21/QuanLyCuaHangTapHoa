function formatDate(date) {
    var day = String(date.getDate()).padStart(2, "0");
    var month = String(date.getMonth() + 1).padStart(2, "0");
    var year = String(date.getFullYear()).slice(-2);
    return day + month + year;
}

$("#dshd").click(function (event) {
    event.preventDefault(); // Prevent the default link behavior

    // Get today's date and format it as "ddMMyy"
    var today = new Date();
    var formattedToday = formatDate(today);

    // Build the URL with the date parameters and navigate to it
    var url = '/HoaDons/DanhSachHoaDon?dateStart=' + formattedToday + '&dateEnd=' + formattedToday;
    window.location.href = url;
});
