$('.message button').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
    $('.message').animate({ height: "toggle", opacity: "toggle" }, "slow");
    $('.profileInformation').animate({ height: "toggle", opacity: "toggle" }, "slow");
});