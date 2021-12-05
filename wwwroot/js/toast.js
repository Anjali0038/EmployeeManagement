const modalSection = document.getElementById("myModal");

let submitbtn = document.querySelector(".adduser-submit-section");

submitbtn.addEventListener("click", (e) => {
  //e.preventDefault();
  modalSection.style.display = "none";
  let inputValue = document.querySelectorAll(".text-from");
  let obj = {};
  let formvalidate = inputValue.forEach((eachinput) => {
    obj = { ...obj, [eachinput.name]: eachinput.value };
  });
  if (obj.UserName != "" && obj.password != "" && obj.Confirmpassword != "") {
    // console.log("Submit");
    alertcall(
      "User",
      "Create Successfully",
      "showsuccess",
      '<i class="fas fa-check-circle"></i>'
    );
  }
  // else if(){

  // }
  else {
    // console.log("not submit");
    alertcall(
      "Error",
      "Please Input the value",
      "showdanger",
      '<i class="fas fa-exclamation-circle"></i>'
    );
  }
});

// //alert mssg display
let alertcall = (texts, mssg, classnames, icon) => {
  let bodySection = document.getElementsByTagName("body")[0];

  let toastsection = document.createElement("div");
  toastsection.classList = `userlist-toast ${classnames}`;
  let icons = document.createElement("div");
  icons.classList = `userlist-conform-icon ${classnames}`;
  //   icons.textContent = icon;
  icons.innerHTML = icon;
  //   icon.innerHTML = `<i class="fas fa-check-circle"></i>`;

  let toastmssg = document.createElement("div");
  toastmssg.classList = "toast-success-mssg";

  let toastmssgTitle = document.createElement("p");
  toastmssgTitle.textContent = texts;
  toastmssg.appendChild(toastmssgTitle);

  let toastmssgSucess = document.createElement("p");
  toastmssgSucess.textContent = mssg;
  toastmssg.appendChild(toastmssgSucess);

  let toastclosebtn = document.createElement("button");
  //   toastclosebtn.textContent = ` &times;`;
  toastclosebtn.innerHTML = ` &times;`;
  toastclosebtn.classList = "toast-close-btn ";

  toastclosebtn.addEventListener("click", () => {
    toastsection.classList.remove(`${classnames}`);
  });

  toastsection.appendChild(icons);
  toastsection.appendChild(toastmssg);
  toastsection.appendChild(toastclosebtn);
  bodySection.appendChild(toastsection);

  setTimeout(() => {
    toastsection.textContent = "";
    toastsection.classList.remove(`${classnames}`);
  }, 3000);
};
