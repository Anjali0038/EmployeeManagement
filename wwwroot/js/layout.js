////// user profile and sigout popup section
//////const userlistprofile = document.querySelector(
//////  ".main-container-image-section img"
//////);
//////const userlistlogoutsection = document.querySelector(
//////  ".main-container-logout-section"
//////);
////const userlogoutsection = document.querySelector(
////  ".main-container-logout-section-close-btn"
////);

////window.addEventListener("click", (e) => {
////  const userlistprofileimgsection = document.querySelector(
////    ".main-container-user-profile-img "
////  );
////  const userlistprofileimg = document.querySelector(
////    ".main-container-user-profile-img img"
////  );
////  const userlistprofilename = document.querySelector(
////    ".main-container-logout-section h3"
////  );
////  const userlistuseremail = document.querySelector(
////    ".main-container-user-email"
////  );
////  const userlistprofilefooter = document.querySelector(
////    ".main-container-logout-footer-section"
////  );
////  const userlistprofilefooterh3 = document.querySelector(
////    ".main-container-logout-footer-section h3"
////  );
////  const userlistprofilelogoutbtn = document.querySelector(
////    ".main-container-logout-btn"
////  );

////  if (e.target == userlistprofile) {
////    userlistlogoutsection.classList.toggle("show");
////  } else if (e.target == userlistprofileimgsection) {
////    userlistlogoutsection.classList.add("show");
////  } else if (e.target == userlistprofileimg) {
////    userlistlogoutsection.classList.add("show");
////  } else if (e.target == userlistprofilename) {
////    userlistlogoutsection.classList.add("show");
////  } else if (e.target == userlistuseremail) {
////    userlistlogoutsection.classList.add("show");
////  } else if (e.target == userlistprofilefooter) {
////    userlistlogoutsection.classList.add("show");
////  } else if (e.target == userlistprofilefooterh3) {
////    userlistlogoutsection.classList.add("show");
////  } else if (e.target == userlistlogoutsection) {
////    userlistlogoutsection.classList.add("show");
////  } else if (e.target == userlistprofilelogoutbtn) {
////    userlistlogoutsection.classList.add("show");
////  } else {
////    userlistlogoutsection.classList.remove("show");
////  }
////});

////const sidebarActiveSection = document.querySelectorAll(".sidebarbtn");
////sidebarActiveSection.forEach((eachList) => {
////  console.log(eachList);
////  eachList.addEventListener("click", (e) => {
////    console.log(e.target);
////    // if (e.target.classList == "actives") {
////    //   e.target.classList.remove("actives");
////    // } else {
////    //   e.target.classList.add("activess");
////    // }
////    // if (e.target.classList.contains("actives")) {
////    //   e.target.classList.remove("actives");
////    // } else {
////    //   e.target.classList.add("actives");
////    // }
////    // if (this.classList.contains("actives")) {
////    //   this.classList.remove("actives");
////    // } else this.classList.add("actives");
////  });
////  // eachList.addEventListener("click", (ev) => {
////  //   console.log(ev.target);
////  // });
////});
////// function for sigout
////function newDoc() {
////  window.location.assign("http://127.0.0.1:5500/login.html");
////}

// user profile and sigout popup section
const userlistprofile = document.querySelector(
    ".main-container-image-section img"
);
const userlistlogoutsection = document.querySelector(
    ".main-container-logout-section"
);
const userlogoutsection = document.querySelector(
    ".main-container-logout-section-close-btn"
);

window.addEventListener("click", (e) => {
    const userlistprofileimgsection = document.querySelector(
        ".main-container-user-profile-img "
    );
    const userlistprofileimg = document.querySelector(
        ".main-container-user-profile-img img"
    );
    const userlistprofilename = document.querySelector(
        ".main-container-logout-section h3"
    );
    const userlistuseremail = document.querySelector(
        ".main-container-user-email"
    );
    const userlistprofilefooter = document.querySelector(
        ".main-container-logout-footer-section"
    );
    const userlistprofilefooterh3 = document.querySelector(
        ".main-container-logout-footer-section h3"
    );
    const userlistprofilelogoutbtn = document.querySelector(
        ".main-container-logout-btn"
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

const sidebarbtn = document.querySelector(".main-container-sidebar-btn");
const sidebarsection = document.querySelector(".sidebar");
const userlist = document.querySelector(".main-container");
const sidebarclosebtn = document.querySelector(".sidebar-close-btn");

sidebarbtn.addEventListener("click", () => {
    sidebarsection.classList.toggle("showsidebar");
    sidebarsection.classList.toggle("hide");
    userlist.classList.toggle("active");
    sidebarbtn.classList.toggle("sidebarOpen");
});