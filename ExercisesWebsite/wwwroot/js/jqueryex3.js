$(function () { // main jQuery routine - executes every on page load

    // back to a string again, start array
    const stringData = 
        `[{ "id": 123, "firstname": "Teachers", "lastname": "Pet" },
          { "id": 234, "firstname": "Brown", "lastname": "Nose" },
          { "id": 345, "firstname": "Always", "lastname": "Late" }]`;

    // do we already have it loaded from a previous run in the current session?
    // if not load the start array to session storage now
    sessionStorage.getItem("studentData") === null ? sessionStorage.setItem("studentData", stringData) : null;

    // get the session data to an object format
    let data = JSON.parse(sessionStorage.getItem("studentData"));

    $("#loadbutton").click( e => {
        let html = "";
        data.map(student => {
            html += `<div id="${student.id}" class="list-group-item">${student.firstname},${student.lastname}</div>`;
        });
        $("#studentList").html(html);
        $("#loadbutton").hide();
        $("#addbutton").show();

    });  // loadbutton.click()

    $("#studentList").click( e => {
        const student = data.find( s => s.id === parseInt(e.target.id));
        // dump out a templated string to the bottom of the page
        $("#results").text(`you selected ${student.firstname}, ${student.lastname}`);
    }); // div click

    // add button event handler 
    $("#addbutton").click( e => {
        // find the last student
        const student = data[data.length - 1];
        // add 101 to the id
        $("#results").text(`adding student ${student.id + 101}`);
        // add a new student to the object array
        data.push({ "id": student.id + 101, "firstname": "new", "lastname": "student" });
        // convert the object array back to a string and put it in session storage
        sessionStorage.setItem("studentData", JSON.stringify(data));
        let html = "";
        data.map(student => {
            html += `<div id="${student.id}" class="list-group-item">${student.firstname},${student.lastname}</div>`;
        });
        $("#studentList").html(html);
    });

}); // jQuery routine