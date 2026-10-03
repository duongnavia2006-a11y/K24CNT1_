document.addEventListener("DOMContentLoaded", () => {
    const ntdToggle = document.querySelector(".ntd-sidebar-toggle");
    const ntdSidebar = document.querySelector(".ntd-sidebar");
    if (ntdToggle && ntdSidebar) {
        ntdToggle.addEventListener("click", () => ntdSidebar.classList.toggle("ntd-sidebar-open"));
    }
});
