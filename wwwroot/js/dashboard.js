
window.addEventListener("load", function () {
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