function loadTable() {
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "https://localhost:44328/api/trips");//https://localhost:44328/api/trips
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
                trHTML += '<td><buttton type="button" class="btn btn-outline-secondary" onclick="Create(' + object['id'] + ')">Edit</button>';
                trHTML += '<buttton type="button" class="btn btn-outline-danger" onclick="Delete(' + object['id'] + ')">Del</button></td>';//neet to replace by correct create and delete functions
                trHTML += '</tr>';//"</tr>";
            }
            document.getElementById("mytable").innerHTML = trHTML;
        }
    };
}

loadTable();