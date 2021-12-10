// createuserpopupsection
const createuserbtn = document.querySelector(
    ".main-container-create-section-btn"
);
const createuserclosebtn = document.querySelector(
    ".userlist-adduser-close-btn"
);

createuserclosebtn.addEventListener("click", () => {
    modal.style.display = "none";
});

const modal = document.getElementById("myModal");

createuserbtn.addEventListener("click", () => {
    modal.style.display = "block";

    var sidebarStatus = document.querySelector(".main-container-sidebar-btn");
    if (sidebarStatus.classList.contains("sidebarOpen")) {
        createuserpopupsection.classList.remove("showfullwidthfromsection");
    } else {
        createuserpopupsection.classList.add("showfullwidthfromsection");
    }
});
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
};

const editbtn = document.querySelectorAll(".edit-btn");

editbtn.forEach((eachbtn) => {
    eachbtn.addEventListener("click", () => {
        modal.style.display = "block";
    });
});