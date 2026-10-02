$(function () {
    var url = location.pathname;
    $('#navbar ul>li a').each(function () {
        var href = $(this).attr("href");
        if (url.toLowerCase() === href.toLowerCase()) {
            $(this).addClass("active");
        } else {
            $(this).removeClass("active");
        }
    });
});
