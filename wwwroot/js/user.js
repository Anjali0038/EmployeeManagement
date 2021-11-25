const sidebarbtn = document.querySelector(".userlist-sidebar-btn");
const sidebarsection = document.querySelector(".userlist-sidebar");
const userlist = document.querySelector(".userlist-main-container");
const sidebarclosebtn = document.querySelector(".userlist-sidebar-close-btn");
const createuserpopupsection = document.querySelector(
  ".userlist-adduser-form-section"
);

// click event in hamburger menu in userlist
sidebarbtn.addEventListener("click", () => {
  sidebarsection.classList.toggle("showsidebar");
  sidebarsection.classList.toggle("hide");
  userlist.classList.toggle("active");
  createuserpopupsection.classList.toggle("showfullwidthfromsection");
});
// click event in  cross icon inside sidebar menu
sidebarclosebtn.addEventListener("click", () => {
  sidebarsection.classList.remove("showsidebar");
  sidebarsection.classList.remove("hide");
  userlist.classList.remove("active");
});

// user profile and sigout popup section
const userlistprofile = document.querySelector(".userlist-image-section img");
const userlistlogoutsection = document.querySelector(
  ".userlist-logout-section"
);
const userlogoutsection = document.querySelector(
  ".userlist-logout-section-close-btn"
);

window.addEventListener("click", (e) => {
  const userlistprofileimgsection = document.querySelector(
    ".userlist-user-profile-img "
  );
  const userlistprofileimg = document.querySelector(
    ".userlist-user-profile-img img"
  );
  const userlistprofilename = document.querySelector(
    ".userlist-logout-section h3"
  );
  const userlistuseremail = document.querySelector(".userlist-user-email");
  const userlistprofilefooter = document.querySelector(
    ".userlist-logout-footer-section"
  );
  const userlistprofilefooterh3 = document.querySelector(
    ".userlist-logout-footer-section h3"
  );
  const userlistprofilelogoutbtn = document.querySelector(
    ".userlist-logout-btn"
  );

  if (e.target == userlistprofile) {
    userlistlogoutsection.classList.toggle("show");
  } else if (e.target == userlistprofileimgsection) {
    userlistlogoutsection.classList.add("show");
  } else if (e.target == userlistprofileimg) {
    userlistlogoutsection.classList.add("show");
  } else if (e.target == userlistprofilename) {
    userlistlogoutsection.classList.add("show");
  } else if (e.target == userlistuseremail) {
    userlistlogoutsection.classList.add("show");
  } else if (e.target == userlistprofilefooter) {
    userlistlogoutsection.classList.add("show");
  } else if (e.target == userlistprofilefooterh3) {
    userlistlogoutsection.classList.add("show");
  } else if (e.target == userlistlogoutsection) {
    userlistlogoutsection.classList.add("show");
  } else if (e.target == userlistprofilelogoutbtn) {
    userlistlogoutsection.classList.add("show");
  } else {
    userlistlogoutsection.classList.remove("show");
  }
});

// createuserpopupsection
const createuserbtn = document.querySelector(".userlist-create-section-btn");
const createuserclosebtn = document.querySelector(
  ".userlist-adduser-close-btn"
);

createuserclosebtn.addEventListener("click", () => {
  modal.style.display = "none";
});

const modal = document.getElementById("myModal");

createuserbtn.addEventListener("click", () => {
  modal.style.display = "block";
});
window.onclick = function (event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
};
// userlist-toast-section

const userlisttoast = document.querySelector(".userlist-toast");
const userlisttoastclose = document.querySelector(".toast-close-btn");

userlisttoastclose.addEventListener("click", () => {
  userlisttoast.classList.remove("showtoast");
});
let toast = (e) => {
  e.preventDefault();
  modal.style.display = "none";

  function fun() {
    userlisttoast.classList.remove("showtoast");
  }
  userlisttoast.classList.add("showtoast");
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
