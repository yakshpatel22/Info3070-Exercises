$(function () { // main jQuery routine - executes every on page load
    let data;

    $("#loadbutton").click(async e => {
        if (sessionStorage.getItem("studentData") === null) { //if not loaded get data from GitHub
            //location of data
            const url = "https://raw.githubusercontent.com/elauersen/info3070/master/jqueryex5.json";
            $('#results').text('Location student data on GitHub, please wait...');

            //fetch api is asyncronous, notice the use of the await keyword
            try {
                let response = await fetch(url);
                if (!response.ok) //check response
                    throw new Error(`Status - ${response.status}, Text - ${response.statusText}`);//fires catch
                data = await response.json(); //this returns a promise, await it
                sessionStorage.setItem("studentData", JSON.stringify(data));
                $('#results').text('Student data os GitHub loaded!');

            } catch (error) {
                $("#results").text(error.message);
            }
        } else {
            data = JSON.parse(sessionStorage.getItem("studentData"));
        }

        let html = "";
        data.map(student => {
            html += `<div id="${student.id}"class="list-group-item">${student.firstname},${student.lastname}</div>`;
        });
        //dump the dynamically generated html into an element with an id attribute of studentList (in this case <div></div>)
        $("#studentList").html(html);
        $("#loadbutton").hide();
        $("#inputstuff").show();


    });  // loadbutton.click()

    $("#studentList").click(e => {
        const student = data.find(s => s.id === parseInt(e.target.id));
        $("#results").text(`you selected ${student.firstname}, ${student.lastname}`);
    }); //div click

    // add button event handler
    $("#addbutton").click(e => {
        //data from textboxes 
        const first = $("#txtfirstname").val();
        const last = $("#txtlastname").val();

        if (first.length > 0 && last.length > 0) { //only add if we have something

            if (data.length > 0) {
                const student = data[data.length - 1];
                data.push({ "id": student.id + 101, "firstname": first, "lastname": last });
                $("#results").text(`added student ${student.id + 101}`);
            } else {//need a seed value if array is empty
                data.push({ "id": 101, "firstname": first, "lastname": last });
            }

            //clear out the textboxes
            $("#txtlastname").val("");
            $("#txtfirstname").val("");
            sessionStorage.setItem("studentData", JSON.stringify(data));
            let html = "";
            data.map(student => {
                html += `<div id = "${student.id}" class="list-group-item">${student.firstname},${student.lastname}</div>`;
            });
            $("#studentList").html(html);
        }

    });//add button click

    //remove button handler
    $("#removebutton").click(e => {
        //make sure there is still data in the array
        if (data.length > 0) {
            const student = data[data.length - 1];
            data.splice(-1, 1); // remove last entry in array
            $("#results").text(`remove student ${student.id}`);
            //put the update data back to session storage
            sessionStorage.setItem("studentData", JSON.stringify(data));
            let html = "";
            data.map(student => {
                html += `<div id = "${student.id}" class="list-group-item">${student.firstname},${student.lastname}</div>`;
            });
            $("#studentList").html(html);
        } else {
            $("#results").text(`no students to remove`);
        }

    });//remove button click


}); // jQuery routine