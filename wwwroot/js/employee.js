////////const employeesidebarbtn = document.querySelector(
////////  ".main-container-sidebar-btn"
////////);
////////const employeelist = document.querySelector(".main-container");
////////const employeesidebarsection = document.querySelector(".sidebar");
////////const employeesidebarclosebtn = document.querySelector(".sidebar-close-btn");
////////const employeelistcreateuserpopupsection = document.querySelector(
////////  ".employeelist-adduser-form-section"
////////);
////////// click event in hamburger menu in employeelist
////////employeesidebarbtn.addEventListener("click", () => {
////////  employeesidebarsection.classList.toggle("showsidebar");
////////  employeesidebarsection.classList.toggle("hide");
////////  employeelist.classList.toggle("active");
////////  employeelistcreateuserpopupsection.classList.toggle("showfullwidth");
////////});
////////// click event in  cross icon inside sidebar menu
////////employeesidebarclosebtn.addEventListener("click", () => {
////////  employeesidebarsection.classList.remove("showsidebar");
////////  employeesidebarsection.classList.remove("hide");
////////  employeelist.classList.remove("active");
////////});

////////// createuserpopupsection
////////const employeelistcreateuserbtn = document.querySelector(
////////  ".main-container-create-section-btn"
////////);
////////const employeelistcreateuserclosebtn = document.querySelector(
////////  ".employeelist-adduser-close-btn"
////////);

////////employeelistcreateuserclosebtn.addEventListener("click", () => {
////////  modal.style.display = "none";
////////});

////////const modal = document.getElementById("myModal");

////////employeelistcreateuserbtn.addEventListener("click", () => {
////////  modal.style.display = "block";
////////});
////////window.onclick = function (event) {
////////  if (event.target == modal) {
////////    modal.style.display = "none";
////////  }
////////};

////////// userlist-toast-section

////////// const employeelisttoast = document.querySelector(".employeelist-toast");
////////// const employeelisttoastclose = document.querySelector(
//////////   ".employeelist-toast-close-btn"
////////// );

////////// employeelisttoastclose.addEventListener("click", () => {
//////////   employeelisttoast.classList.remove("showtoast");
////////// });
////////// let toast = (e) => {
//////////   e.preventDefault();
//////////   modal.style.display = "none";

//////////   function fun() {
//////////     employeelisttoast.classList.remove("showtoast");
//////////   }
//////////   employeelisttoast.classList.add("showtoast");
//////////   setTimeout(fun, 3000);
////////// };

////////// edit-delete form

////////const editbtn = document.querySelectorAll(".edit-btn");

////////editbtn.forEach((eachbtn) => {
////////  eachbtn.addEventListener("click", () => {
////////    modal.style.display = "block";
////////  });
////////});

////const employeelistcreateuserpopupsection = document.querySelector(
////    ".employeelist-adduser-form-section"
////);

////// createuserpopupsection
////const employeelistcreateuserbtn = document.querySelector(
////    ".main-container-create-section-btn"
////);
////const employeelistcreateuserclosebtn = document.querySelector(
////    ".employeelist-adduser-close-btn"
////);

////employeelistcreateuserclosebtn.addEventListener("click", () => {
////    modal.style.display = "none";
////});

////const modal = document.getElementById("myModal");

//////employeelistcreateuserbtn.addEventListener("click", () => {
//////    //modal.style.display = "block";
//////    var sidebarStatus = document.querySelector(".main-container-sidebar-btn");
//////    if (sidebarStatus.classList.contains("sidebarOpen")) {
//////        employeelistcreateuserpopupsection.classList.remove("showfullwidth");
//////    } else {
//////        employeelistcreateuserpopupsection.classList.add("showfullwidth");
//////    }
//////});
////window.onclick = function (event) {
////    if (event.target == modal) {
////        modal.style.display = "none";
////    }
////};

////// edit-delete form

////const editbtn = document.querySelectorAll(".edit-btn");

////editbtn.forEach((eachbtn) => {
////    eachbtn.addEventListener("click", () => {
////        modal.style.display = "block";
////    });
////});
