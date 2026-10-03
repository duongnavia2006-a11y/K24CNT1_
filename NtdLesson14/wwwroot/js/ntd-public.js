document.addEventListener("DOMContentLoaded", () => {
    const ntdToggle = document.querySelector(".ntd-menu-toggle");
    const ntdLinks = document.querySelector(".ntd-nav-links");
    if (ntdToggle && ntdLinks) {
        ntdToggle.addEventListener("click", () => {
            const ntdExpanded = ntdToggle.getAttribute("aria-expanded") === "true";
            ntdToggle.setAttribute("aria-expanded", String(!ntdExpanded));
            ntdLinks.classList.toggle("ntd-open", !ntdExpanded);
        });
    }
});
