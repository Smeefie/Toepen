$(".sidebarMenu ul li").on("click", e => {
    document.location.href = $(e.target).closest("li").data("href");
});