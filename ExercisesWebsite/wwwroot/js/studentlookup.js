$(function () {

    $("#getbutton").click(async (e) => { //click event handler makes asynchronous fetch to server
        try {
            let lastname = $("#TextBoxLastName").val();
            $("#status").text("please wait...");
            let response = await fetch(`api/student/${lastname}`);
            if (response.ok) {
                let data = await response.json(); // this returns a promise, so we await it
                if (data.lastname !== "not found") {
                    $("#email").text(data.email);
                    $("#title").text(data.title);
                    $("#firstname").text(data.firstname);
                    $("#phone").text(data.phoneno);
                    $("#status").text("student found");
                } else {
                    $("#firstname").text("not found");
                    $("#email").text("");
                    $("#title").text("");
                    $("#phone").text("");
                    $("#status").text("no such student");
                }
            } else if (response.status !== 404) { // probably some other client side error
                let problemJson = await response.json();
                errorRtn(problemJson, response.status);
            } else {// else 404 not found
                $("#status").text("no such path on server");
            } // else
        } catch (error) { // catastrophic
            $("#status").text(error.message);
        } // try/catch
    }); // click/event
}); // jQuery ready method

// server was reached but server had a problem with the call
const errorRtn = (problemJson, status) => {
    if (status > 499) {
        $("#status").text("Problem server side, see debug console");
    } else {
        let keys = Object.keys(problemJson.errors)
        problem = {
            status: status,
            statusText: problemJson.errors[keys[0]][0], // first error
        };
        $("#status").text("Problem client side, see browser console");
        console.log(problem);
    } // else
}