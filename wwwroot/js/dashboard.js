function Toast(timeInterval, toastType) {
    if (timeInterval == undefined) {
        //if timeinterval is not provided, add defualt timeinterval 3s.
        timeInterval = 3000;
    }
    if (toastType == undefined) {
        toastDiv.style.backgroundColor = "#088b08f2";
        paragraphText.textContent = "Sucessfully Submitted";
        fontDiv.className = "far fa-check-circle";
    } else if (toastType == "warning") {
        toastDiv.style.backgroundColor = "rgb(236 50 50 / 87%)";
        paragraphText.style.color = "white";
        fontDiv.className = "far fa-times-circle";
        paragraphText.textContent = "Error";
    }

    // var a = document.getElementById("toastr");
    // a.className = "show";

    setTimeout(function () {
        a.className = a.className.replace("show", "");
    }, timeInterval);

    var a = document.getElementById("toastr");
    a.className = "show";
    setTimeout(function () {
        a.className = a.className.replace("show", "");
    }, 3000);
}
var toastDiv = document.createElement("div");
toastDiv.id = "toastr";
toastDiv.className = "toastr";
var body = document.getElementsByTagName("body")[0].appendChild(toastDiv);

var fontDiv = document.createElement("i");
fontDiv.className = "far fa-check-circle";
toastDiv.appendChild(fontDiv);

var paragraphText = document.createElement("p");
paragraphText.className = "toastPara";
paragraphText.textContent = "Submitted";
toastDiv.appendChild(paragraphText);

// var paragraph = document.createElement("p");
// paragraph.className = "toast";
// paragraph.textContent = "Submitted by";
// toastDiv.appendChild(paragraph);

buttonDiv = document.createElement("div");
document.getElementsByTagName("body")[0].appendChild(buttonDiv);

function openForm() {
    if (document.getElementById("myForm")) {
        document.getElementById("myForm").style.display = "block";
        document.getElementById("myForm").classList.add("opened");
    }
}

function closeForm() {
    if (document.getElementById("myForm")) {
        document.getElementById("myForm").style.display = "none";
        document.getElementById("myForm").classList.remove("opened");
    }
}

// function validateForm() {
//   let xForm = document.forms["user-form"]["fname"].value;
//   if (xForm == "") {
//     alert("Name must be filled out");
//     return false;
//   }
// }
//let y = document.querySelector(".iconImage span");
//let x = document.querySelector(".closebtn");
//y.addEventListener("click", () => {
//    document.querySelector(".mysidenav").classList.add("showbar");
//});
//x.addEventListener("click", () => {
//    document.querySelector(".mysidenav").classList.remove("showbar");
//});
window.addEventListener("click", function (e) {

    var element = document.getElementById("myForm");
    var imgItm = document.querySelector(".fa-user-tie");

    if (e.target !== element && !element.contains(e.target)) {
        if (element.classList.contains("opened") && e.target !== imgItm) {
            closeForm();

        }
    }
});

// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var edit = document.querySelectorAll(".fa-user-edit");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
//
// When the user clicks the button, open the modal
var btn = document.getElementById("myBtn");
if (btn) {
    btn.onclick = function () {
        modal.style.display = "block";
    };

}
edit.forEach((each) => {
    each.addEventListener("click", () => {
        modal.style.display = "block";
    });
});

// When the user clicks on <span> (x), close the modal
if (span) {
    span.onclick = function () {
        modal.style.display = "none";
    };

}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
};

var sub = document.getElementById("formSubmit");
if (sub) {
    sub.onclick = function () {

        let formPr = this.closest("form").getAttribute("name");
        let formBox = this.closest("form").getAttribute("id");
        let xForms = document.forms[formPr].querySelectorAll("input[required]");
        let validCheck;
        xForms.forEach(function (xForm) {
            let formName = xForm.getAttribute("name");
            let formX = document.forms[formPr][formName].value;

            if (formX == "") {
                validCheck = false;

            } else {
                if (validCheck == false) {
                    validCheck = false;
                } else {
                    validCheck = true;
                }
            }
        });

        if (validCheck == false) {
            Toast(3000, "warning");
        } else {
            Toast();

            let formName = document.getElementById(formBox);
            setTimeout(() => {
                formName.submit();
            }, 3000);
        }

    };
}



// dropdown----------------------------------------------------------------------------------
function myFunction() {
    var dropdown = document.getElementById("myDIV");

    if (dropdown.style.display === "block") {
        dropdown.style.display = "none";
    } else {
        dropdown.style.display = "block";
    }
}

function myFunctions() {
    var dropdown = document.getElementById("myDIVs");
    if (dropdown.style.display === "block") {
        dropdown.style.display = "none";
    } else {
        dropdown.style.display = "block";
    }
}

// document.addEventListener("DOMContentLoaded", function () {
//   const selector = ".nav__link";
//   const elems = Array.from(document.querySelectorAll(selector));

//   const navigation = document.querySelector("nav");

//   function makeActive(evt) {
//     const target = evt.target;

//     if (!target || !target.matches(selector)) {
//       return;
//     }

//     elems.forEach((elem) => elem.classList.remove("active"));

//     evt.target.classList.add("active");
//   }

//   navigation.addEventListener("mouseup", makeActive);
// });

// password show hide--------------------------------------------------------------------------------------------------------------------
function myPass() {
    var x = document.getElementById("myInput");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
function myWord() {
    var x = document.getElementById("myInputs");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

// let activeS = document.getElementsByClassName('dropdown-container');
// let href = document.querySelectorAll('.dropdown-container a');
// let items = [];

// href.forEach((e)=>{
//  items = [...items,e.innerHTML]

// });
// console.log(items)
const currentLocation = location.href;
// console.log(currentLocation)
const menuItems = document.querySelectorAll('a');
// console.log(menuItems)
const menuLength = menuItems.length;
// console.log(menuLength)
for (let i = 0; i < menuLength; i++) {
    if (menuItems[i].href === currentLocation) {
        // console.log((menuItems[i].href === currentLocation))
        menuItems[i].className = "active"
        menuItems[i].parentElement.style.display = "block";
        // menuItems[i].parentElement.style.background = "blue"
        // console.log(menuItems[i])




    }
}

window.addEventListener("load", function () {
    debugger
    // (C1) INLINE DATE PICKER
    picker.attach({
        target: "input-inline",
        container: "pick-inline",
    });

    // (C2) POPUP DATE PICKER
    picker.attach({
        target: "input-pop",
    });
    modifyCalend();

    // Select the node that will be observed for mutations
    const targetNode = document.getElementById("pick-inline");

    // Options for the observer (which mutations to observe)
    const config = {
        attributes: true,
        childList: true,
        subtree: true,
    };

    // Callback function to execute when mutations are observed
    const callback = function (mutationsList, observer) {
        // Use traditional 'for loops' for IE 11
        for (const mutation of mutationsList) {
            if (mutation.type === "childList") {
                modifyCalend();
            }
        }
    };

    // Create an observer instance linked to the callback function
    const observer = new MutationObserver(callback);

    let demoList = [
        {
            id: 1,
            event: "Sick Leave",
            reason: "Fevar",
            Color: "008000",
        },
        {
            id: 2,
            event: "Weekends",
            reason: "Fevar",
        },
        {
            id: 3,
            event: "Public Holiday",
            reason: "Fevar",
        },
        {
            id: 4,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 5,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 6,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 7,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 8,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 9,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 10,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 11,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 12,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 13,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 14,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 15,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 16,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 17,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 18,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 19,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 20,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 21,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 22,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 23,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 24,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 25,
            event: "Sick Leave",
            reason: "Fevar",
        },

        {
            id: 26,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 27,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 28,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 29,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 30,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 31,
            event: "Sick Leave",
            reason: "Fevar",
        },
        {
            id: 32,
            event: "Sick Leave",
            reason: "Fevar",
        },
    ];

    // document.getElementsByClassName("picker-d-d").style.color = "#ff0000"
    // console.log(picker - d - d)

    // Start observing the target node for configured mutations
    observer.observe(targetNode, config);

    function modifyCalend() {
        let cDate = document.querySelectorAll(".picker-d-d");
        let vDate = document.querySelector(".date");
        // console.log(vDate)

        let event = document.querySelector(".events");

        cDate.forEach((e) => {
            e.addEventListener("click", (minal) => {
                event.innerHTML = "";
                // console.log(event)
                // console.log(cDate.toString().indexOf(minal.currentTarget))
                let holiTxt = minal.currentTarget.nextElementSibling;
                let styleds = window
                    .getComputedStyle(minal.currentTarget)
                    .getPropertyValue("border-color");
                // console.log(styleds)
                // console.log(window.getComputedStyle(minal.currentTarget).getPropertyValue("background-color"))
                vDate.firstElementChild.innerText =
                    minal.currentTarget.textContent;
                // console.log(vDate.firstElementChild.innerText)
                // if (holiTxt) {
                //     vDate.nextElementSibling.lastElementChild.innerText = holiTxt.innerText;
                //     console.log(holiTxt.innerText);
                // }
                vDate.style.backgroundColor = styleds;

                const filterdumydata = demoList.filter((items) => {
                    return items.id == minal.currentTarget.textContent;
                });
                // console.log(filterdumydata)

                let createH = document.createElement("h4");
                createH.innerHTML = "Events/Reasons";

                event.appendChild(createH);

                let createP = document.createElement("p");
                let createPa = document.createElement("p");

                createP.textContent = filterdumydata[0].event;
                // console.log( filterdumydata[0].event)
                createPa.textContent = filterdumydata[0].reason;

                createPa.textContent = filterdumydata[0].Color;
                // console.log(filterdumydata[0].color)
                event.appendChild(createP);
                event.appendChild(createP);
            });
        });
    }
});
// const currentPage = window.location.pathname;
// console.log(currentPage)