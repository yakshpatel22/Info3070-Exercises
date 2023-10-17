$(function () { //main jQuery routine - executes every on page load

    // this is declaring a string variable, notice the use of the tick
    // instead of quotes to allow us using multiple lines, here we're 
    // defining 3 students in JSON format
    const stringData =
        `[{ "id": 123, "firstname": "Teachers", "lastname": "Pet" },
          { "id": 234, "firstname": "Brown", "lastname": "Nose" },
          { "id": 345, "firstname": "Always", "lastname": "Late" }]`;

    // an event handler for a button with id attribute of a button
    $("#loadbutton").click(e => {
        // data is currently a string but to process it we need an object array
        // Use const when the data shouldn't mutate
        const studentData = JSON.parse(stringData);

        // we'll manually build a string of html. We use let because 
        // the string will be mutated
        let html = "";

        // using the array map operator here to iterate through the object array
        // for each object it finds we'll label it as a student and then dump
        // out 3 properties using a templated string inside a div node
        studentData.map(student => {
            html += `<div class="list-group-item">${student.id},${student.firstname},${student.lastname}</div>`;
        });

        // dump the dynamically generated html into an element with an
        // id attribute of studentList (in this case a <div></div>)
        $("#studentList").html(html);
        $("#loadbutton").hide();

    }); // loadbutton.click()
}); // jQuery routine