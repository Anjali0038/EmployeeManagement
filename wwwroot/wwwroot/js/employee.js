const employeelistcreateuserpopupsection = document.querySelector(
    ".employeelist-adduser-form-section"
);
var sidebarStatus = document.querySelector(".main-container-sidebar-btn");
if (sidebarStatus.classList.contains("sidebarOpen"))
{
    employeelistcreateuserpopupsection.classList.remove("showfullwidth");
}
else
{
   employeelistcreateuserpopupsection.classList.add("showfullwidth");
 }

