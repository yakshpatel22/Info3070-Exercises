$(function () { // main jQuery routine - executes every on page load

    const studentData = JSON.parse(
        `[{ "id": 123, "firstname": "Teachers", "lastname": "Pet" },
          { "id": 234, "firstname": "Brown", "lastname": "Nose" },
          { "id": 345, "firstname": "Always", "lastname": "Late" }]`);

    $("#loadbutton").click(e => {
        let html = "";
        studentData.map(student => {
            html += `<div id="${student.id}"
                          class="list-group-item">${student.firstname},${student.lastname}
                     </div>`;
        });
        $("#studentList").html(html);
        $("#loadbutton").hide();

    });  // loadbutton.click()

    $("#studentList").click(e => {
        // find the student the user has clicked on
        const student = studentData.find(s => s.id === parseInt(e.target.id));
        // dump out a templated string to the bottom of the page
        $("#results").text(`you selected ${student.firstname}, ${student.lastname}`);
    }); // studentList div click


}); // jQuery routine