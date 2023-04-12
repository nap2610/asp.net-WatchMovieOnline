'use strict';


// Add event on multiple elements
const addEventOnElements = function (elements, eventType, callback) {
    for (const elm of elements) elm.addEventListener(eventType, callback);
}

// Toggle search box in mobile device || small screen
const searchBox = document.querySelector("[search-box]");
const searchTogglers = document.querySelectorAll("[search-toggler]");

addEventOnElements(searchTogglers, "click", function () {
    searchBox.classList.toggle("active");
});

const toggleSidebar = function (sidebar) {
    const sidebarBtn = document.querySelector("[menu-tbn]");
    const sidebarTogglers = document.querySelectorAll("[menu-toggler]");
    const sidebarClose = document.querySelectorAll("[menu-close]");
    const overlay = document.querySelector("[overlay]");

    addEventOnElements(sidebarTogglers, "click", function () {
        sidebar.classList.toggle("active");
        sidebarBtn.classList.toggle("active");
        overlay.classList.toggle("active");
    })

    addEventOnElements(sidebarClose, "click", function () {
        sidebar.classList.remove("active");
        sidebarBtn.classList.remove("active");
        overlay.classList.remove("active");
    })
}

const sidebar = document.querySelector("[sidebar]");
toggleSidebar(sidebar);
