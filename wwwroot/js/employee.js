const employeesidebarbtn = document.querySelector(".employeelist-sidebar-btn");
const employeelist = document.querySelector(".employeelist-main-container");
const employeesidebarsection = document.querySelector(".employeelist-sidebar");
const employeesidebarclosebtn = document.querySelector(
  ".employeelist-sidebar-close-btn"
);
// click event in hamburger menu in employeelist
employeesidebarbtn.addEventListener("click", () => {
  employeesidebarsection.classList.toggle("showsidebar");
  employeesidebarsection.classList.toggle("hide");
  employeelist.classList.toggle("active");
  employeelistcreateuserpopupsection.classList.toggle(
    "showfullwidthfromsection"
  );
});
// click event in  cross icon inside sidebar menu
employeesidebarclosebtn.addEventListener("click", () => {
  employeesidebarsection.classList.remove("showsidebar");
  employeesidebarsection.classList.remove("hide");
  employeelist.classList.remove("active");
});
// user profile and sigout popup section
const employeelistprofile = document.querySelector(
  ".employeelist-image-section img"
);
const employeelistlogoutsection = document.querySelector(
  ".employeelist-logout-section"
);
const employeelogoutsection = document.querySelector(
  ".employeelist-logout-section-close-btn"
);

window.addEventListener("click", (e) => {
  const employeelistprofileimgsection = document.querySelector(
    ".employeelist-user-profile-img "
  );
  const employeelistprofileimg = document.querySelector(
    ".employeelist-user-profile-img img"
  );
  const employeelistprofilename = document.querySelector(
    ".employeelist-logout-section h3"
  );
  const employeelistuseremail = document.querySelector(
    ".employeelist-user-email"
  );
  const employeelistprofilefooter = document.querySelector(
    ".employeelist-logout-footer-section"
  );
  const employeelistprofilefooterh3 = document.querySelector(
    ".employeelist-logout-footer-section h3"
  );
  const employeelistprofilelogoutbtn = document.querySelector(
    ".employeelist-logout-btn"
  );

  if (e.target == employeelistprofile) {
    employeelistlogoutsection.classList.toggle("show");
  } else if (e.target == employeelistprofileimgsection) {
    employeelistlogoutsection.classList.add("show");
  } else if (e.target == employeelistprofileimg) {
    employeelistlogoutsection.classList.add("show");
  } else if (e.target == employeelistprofilename) {
    employeelistlogoutsection.classList.add("show");
  } else if (e.target == employeelistuseremail) {
    employeelistlogoutsection.classList.add("show");
  } else if (e.target == employeelistprofilefooter) {
    employeelistlogoutsection.classList.add("show");
  } else if (e.target == employeelistprofilefooterh3) {
    employeelistlogoutsection.classList.add("show");
  } else if (e.target == employeelistlogoutsection) {
    employeelistlogoutsection.classList.add("show");
  } else if (e.target == employeelistprofilelogoutbtn) {
    employeelistlogoutsection.classList.add("show");
  } else {
    employeelistlogoutsection.classList.remove("show");
  }
});

// createuserpopupsection
const employeelistcreateuserbtn = document.querySelector(
  ".employeelist-create-section-btn"
);
const employeelistcreateuserclosebtn = document.querySelector(
  ".employeelist-adduser-close-btn"
);
const employeelistcreateuserpopupsection = document.querySelector(
  ".employeelist-adduser-form-section"
);

// employeelistcreateuserbtn.addEventListener("click", () => {
//   employeelistcreateuserpopupsection.classList.toggle("showadduser");
// });
// employeelistcreateuserclosebtn.addEventListener("click", () => {
//   employeelistcreateuserpopupsection.classList.remove("showadduser");
// });

employeelistcreateuserclosebtn.addEventListener("click", () => {
  modal.style.display = "none";
});

const modal = document.getElementById("myModal");

employeelistcreateuserbtn.addEventListener("click", () => {
  modal.style.display = "block";
});
window.onclick = function (event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
};

// userlist-toast-section

const employeelisttoast = document.querySelector(".employeelist-toast");
const employeelisttoastclose = document.querySelector(
  ".employeelist-toast-close-btn"
);

employeelisttoastclose.addEventListener("click", () => {
  employeelisttoast.classList.remove("showtoast");
});
let toast = (e) => {
    e.preventDefault();
  modal.style.display = "none";

  function fun() {
    employeelisttoast.classList.remove("showtoast");
  }
  employeelisttoast.classList.add("showtoast");
  setTimeout(fun, 3000);
};

// function for sigout
function newDoc() {
  window.location.assign("http://127.0.0.1:5500/login.html");
}

// edit-delete form

const editbtn = document.querySelectorAll(".edit-btn");

editbtn.forEach((eachbtn) => {
    eachbtn.addEventListener("click", () => {
    modal.style.display = "block";
  });
});


