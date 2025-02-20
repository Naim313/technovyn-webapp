//document.addEventListener("DOMContentLoaded", () => {
//    const menu = document.getElementById("menu");
//    const mobileMenuIcon = document.querySelector(".mobile-menu-icon");

//    if (!menu || !mobileMenuIcon) {
//        console.error("Menu or Mobile Menu Icon not found!");
//        return;
//    }

//    // Toggle the menu visibility
//    mobileMenuIcon.addEventListener("click", (event) => {
//        event.stopPropagation(); // Prevent propagation
//        console.log("Hamburger menu clicked");
//        menu.classList.toggle("hidden");
//    });

//    // Close the menu when clicking outside
//    document.addEventListener("click", (event) => {
//        const isClickInsideMenu = menu.contains(event.target);
//        const isClickOnIcon = mobileMenuIcon.contains(event.target);

//        console.log("Clicked outside menu:", !isClickInsideMenu && !isClickOnIcon);

//        if (!isClickInsideMenu && !isClickOnIcon) {
//            menu.classList.add("hidden");
//        }
//    });
//});
