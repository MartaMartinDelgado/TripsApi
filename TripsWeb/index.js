function loadTable() {
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://localhost:44328/api/trips");//https://www.mecallapi.com/api/users
    xhttp.send();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(this.responseText);
            var trHTML = '';
            const objects = JSON.parse(this.responseText);
            for (let object of objects) {
                trHTML += '<tr>';
                trHTML += '<td>' + object['id'] + '</td>';
                trHTML += '<td>' + object['name'] + '</td>';
                trHTML += '<td>' + object['activity'] + '</td>';
                trHTML += '<td>' + object['tripDate'] + '</td>';
                trHTML += '<td>' + object['spotsAvailable'] + '</td>';
                trHTML += '<td><buttton type="button" class="btn btn-outline-secondary" onclick="showTripEditBox(' + object['id'] + ')">Edit</button>';
                trHTML += '<buttton type="button" class="btn btn-outline-danger" onclick="tripDelete(' + object['id'] + ')">Del</button></td>';
                trHTML += '</tr>';//"</tr>";
            }
            document.getElementById("mytable").innerHTML = trHTML;
        }
    };
}

loadTable();

function showTripCreateBox() {
    Swal.fire({
        title: 'Create Trip',
        html:
            '<input id="id" type="hidden">' +
            '<input id="name" class="swal2-input" placeholder="Name">' +
            '<input id="activity" class="swal2-input" placeholder="Activity">' +
            '<input id="tripDate" class="swal2-input" placeholder="TripDate">' +
            '<input id="spotsAvailable" class="swal2-input" placeholder="SpotsAvailable">',
        focusConfirm: false,
        preConfirm: () => {
            tripCreate();
        }
    })
}

function tripCreate() {
    const name = document.getElementById("name").value;
    const activity = document.getElementById("activity").value;
    const tripDate = document.getElementById("tripDate").value;
    const spotsAvailable = document.getElementById("spotsAvailable").value;

    const xhttp = new XMLHttpRequest();
    xhttp.open("POST", "https://localhost:44328/api/trips/create");
    xhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhttp.send(JSON.stringify({
        "name": name, "activity": activity, "tripDate": tripDate, "spotsAvailable": spotsAvailable
    }));
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const objects = JSON.parse(this.responseText);
            Swal.fire(objects['message']);
            loadTable();
        }
    };
}

function showTripEditBox(id) {
    console.log(id);
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://localhost:44328/api/trips/" + id);
    xhttp.send();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const objects = JSON.parse(this.responseText);
            const trip = objects['trip'];
            console.log(trip);
            Swal.fire({
                title: 'Edit Trip',
                html:
                    '<input id="id" type="hidden" value=' + trip['id'] + '>' +
                    '<input id="name" class="swal2-input" placeholder="Name" value=' + trip['name'] + '>' +
                    '<input id="activity" class="swal2-input" placeholder="Activity" value=' + trip['activity'] + '>' +
                    '<input id="tripDate" class="swal2-input" placeholder="TripDate" value=' + trip['tripDate'] + '>' +
                    '<input id="spotsAvailable" class="swal2-input" placeholder="SpotsAvailable" value=' + trip['spotsAvailable'] + '>',
                focusConfirm: false,
                preConfirm: () => {
                    tripEdit();
                }
            })
        }
    };
}

function tripEdit() {
    const id = document.getElementById("id").value;
    const name = document.getElementById("name").value;
    const activity = document.getElementById("activity").value;
    const tripDate = document.getElementById("tripDate").value;
    const spotsAvailable = document.getElementById("spotsAvailable").value;

    const xhttp = new XMLHttpRequest();
    xhttp.open("PUT", "https://localhost:44328/api/trips/update");
    xhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhttp.send(JSON.stringify({
        "id": id, "name": name, "activity": activity, "tripDate": tripDate, "spotsAvailable": spotsAvailable
    }));
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const objects = JSON.parse(this.responseText);
            Swal.fire(objects['message']);
            loadTable();
        }
    };
}

function tripDelete(id) {
    const xhttp = new XMLHttpRequest();
    xhttp.open("DELETE", "https://localhost:44328/api/trips/delete");
    xhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhttp.send(JSON.stringify({
        "id": id
    }));
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const objects = JSON.parse(this.responseText);
            Swal.fire(objects['message']);
            loadTable();
        }
    };
}