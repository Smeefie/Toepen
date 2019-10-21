//$('.message a').click(function () {
//    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
//});

$(".form a").on("click", e => {
    document.location.href = $(e.target).data("href");
});