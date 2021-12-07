////const sidebarbtn = document.querySelector(".main-container-sidebar-btn");
////const sidebarsection = document.querySelector(".sidebar");
////const userlist = document.querySelector(".main-container");
////const sidebarclosebtn = document.querySelector(".sidebar-close-btn");
////const createuserpopupsection = document.querySelector(
////  ".userlist-adduser-form-section"
////);

////// click event in hamburger menu in userlist
////sidebarbtn.addEventListener("click", () => {
////  sidebarsection.classList.toggle("showsidebar");
////  sidebarsection.classList.toggle("hide");
////  userlist.classList.toggle("active");
////  createuserpopupsection.classList.toggle("showfullwidthfromsection");
////});
////// click event in  cross icon inside sidebar menu
////sidebarclosebtn.addEventListener("click", () => {
////  sidebarsection.classList.remove("showsidebar");
////  sidebarsection.classList.remove("hide");
////  userlist.classList.remove("active");
////});

////// createuserpopupsection
////const createuserbtn = document.querySelector(
////  ".main-container-create-section-btn"
////);
////const createuserclosebtn = document.querySelector(
////  ".userlist-adduser-close-btn"
////);

////createuserclosebtn.addEventListener("click", () => {
////  modal.style.display = "none";
////});

////const modal = document.getElementById("myModal");

////createuserbtn.addEventListener("click", () => {
////  modal.style.display = "block";
////});
////window.onclick = function (event) {
////  if (event.target == modal) {
////    modal.style.display = "none";
////  }
////};
////// userlist-toast-section

////// const userlisttoast = document.querySelector(".userlist-toast");
////// const userlisttoastclose = document.querySelector(".toast-close-btn");

////// userlisttoastclose.addEventListener("click", () => {
//////   userlisttoast.classList.remove("showtoast");
////// });
////// let toast = (e) => {
//////   e.preventDefault();
//////   modal.style.display = "none";

//////   function fun() {
//////     userlisttoast.classList.remove("showtoast");
//////   }
//////   userlisttoast.classList.add("showtoast");
//////   setTimeout(fun, 3000);
////// };

////// edit-delete form

////const editbtn = document.querySelectorAll(".edit-btn");

////editbtn.forEach((eachbtn) => {
////  eachbtn.addEventListener("click", () => {
////    modal.style.display = "block";
////  });
////});


//const createuserpopupsection = document.querySelector(".adduser-form-section");

//// createuserpopupsection
//const createuserbtn = document.querySelector(
//    ".main-container-create-section-btn"
//);
//const createuserclosebtn = document.querySelector(
//    ".userlist-adduser-close-btn"
//);

//createuserclosebtn.addEventListener("click", () => {
//    modal.style.display = "none";
//});

//const modal = document.getElementById("myModal");

//createuserbtn.addEventListener("click", () => {
//    modal.style.display = "block";

//    var sidebarStatus = document.querySelector(".main-container-sidebar-btn");
//    if (sidebarStatus.classList.contains("sidebarOpen")) {
//        createuserpopupsection.classList.remove("showfullwidthfromsection");
//    } else {
//        createuserpopupsection.classList.add("showfullwidthfromsection");
//    }
//});
//window.onclick = function (event) {
//    if (event.target == modal) {
//        modal.style.display = "none";
//    }
//};

//const editbtn = document.querySelectorAll(".edit-btn");});

//editbtn.forEach((eachbtn) => {
//    eachbtn.addEventListener("click", () => {
//        modal.style.display = "block";
//    });
//