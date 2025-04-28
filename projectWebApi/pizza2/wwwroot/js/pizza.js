var baseURL = "http://localhost:5078";
function load() {
    fetch(baseURL + '/pizza2')
        .then((res) => res.json())
        .then((data) => fillPizzaTbl(data))
        .catch((error) => console.log(error))

}
function fillPizzaTbl(data) {
    var table = document.getElementById('pizzaList');
    data.forEach(function (pizza) {
        var tr = document.createElement('tr');
        tr.innerHTML = '<td>' + pizza.id + '</td>' +
            '<td>' + fly.id + '</td>' +
            '<td>' + fly.name + '</td>' +
            '<td>' + fly.isGluten + '</td>';
        var tBody = table.getElementsByTagName('tbody')[0];
        tBody.appendChild(tr);
    });
}
function addPizza() {
    var pizza={};
    pizza.Id=document.getElementById('id').value;
    pizza.name=document.getElementById('name').value;
    pizza.isGluten=document.getElementById('isGluten').value;

    // var myHeaders = new Headers();
    // myHeaders.append("Content-Type", "application/json");

    // var raw = JSON.stringify(pizza);

    const requestOptions = {
        method: "POST",
        redirect: "follow"
      };
      
      fetch(`http://localhost:5078/api/pizzamiri/addPizza/${pizza.name}/${pizza.Id}/${pizza.isGluten}`, requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error));

    
    // fetch("http://localhost:5078/api/pizzamiri/addPizza/"+pizza.name+"/"+pizza.Id+"/"+pizza.isGluten, requestOptions)
    // .then((response) => response.text())
    // .then((result) => console.log(result))
    // .catch((error) => console.error(error));


    //  var requestOptions = {
    //      method: 'POST',
    //      headers: myHeaders,
    //      body: raw
    //  };

    // fetch(baseURL+"/pizza2", requestOptions)
    //     .then(response => afterPost())
     
    //     .catch(error => console.log('error', error));
}

function afterPost(params) {
    alert("");
    load();
}