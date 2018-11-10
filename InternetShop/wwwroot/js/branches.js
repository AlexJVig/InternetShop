﻿function weather(lat, lon) {
    var api_url = 'http://api.openweathermap.org/data/2.5/weather?lat=' +
        lat + '&lon=' +
        lon + '&units=metric&appid=42f325f217132a2fa4b282b44d4a873e';

    $.ajax({
        url: api_url,
        method: 'GET',
        success: function (data) {

            var tempr = data.main.temp;
            var icon = data.weather[0].icon;

            $('#cbForcast').text(tempr + '°');
            $('#cbForcast').append('<img src=http://openweathermap.org/img/w/' + icon + '.png>');
        }
    });
}

// When the user select branch:
// 1. zooms in
// 2. show the card with the current branch details
// 3. mark the currect branch list item
function branchSelected(args, branchListItem) {
    var pushpin;
    if (branchListItem === undefined) {
        pushpin = args.target;
        branchListItem = $("#" + pushpin.metadata.branchID);
    } else {
        pushpin = map.entities.get(branchListItem.context.id - 1);
    }

    $("li.branch-list-item").css('background-color', 'white');
    $(branchListItem).css('background-color', '#f2f2f2');
    $("#branch-details").css('display', 'inherit');

    map.setView({ center: pushpin.getLocation(), zoom: 15 });
    $("#cbCity").text(pushpin.metadata.city);
    $("#cbAddress").text(pushpin.metadata.address);
    $("#cbPhoneNumber").text(pushpin.metadata.phoneNumber);
    $("#cbSundayThursday").text(pushpin.metadata.sundayThursday);
    $("#cbFriday").text(pushpin.metadata.friday);
    $("#cbSaturday").text(pushpin.metadata.saturday);
    weather(pushpin.getLocation().latitude, pushpin.getLocation().longitude);
}

$("#cb-x-card").click(function () {
    $("#branch-details").css('display', 'none');
    $("li.branch-list-item").css('background-color', 'white');
    map.setView({
        center: new Microsoft.Maps.Location(31.96482358762261, 34.99964556250001),
        zoom: 8
    });
});

// When the user closes the card the map zooms out
// unmark the currect branch list item
function infoboxClosed() {
    if (!infobox.getVisible()) {
        $("li.branch-list-item").css('background-color', 'white');
        map.setView({
            center: new Microsoft.Maps.Location(31.96482358762261, 34.99964556250001),
            zoom: 8
        });
    }
}

function loadMapScenario() {
    map = new Microsoft.Maps.Map(document.getElementById('myMap'), {
        // Map settings when loading. Map center set to Sgula, Israel.
        credentials: 'Aoe9qNuzrXqzV9N97QUrO_TDmXB1mKLe9cSAsj6MhBvWV5GfJwFnmzs1KxxbG-BG',
        center: new Microsoft.Maps.Location(31.96482358762261, 34.99964556250001),
        zoom: 8
    });

    // Push pin for every branch
    // Get the branches list from the srver side and convert to JSON array
    var branches = @Html.Raw(Json.Serialize(Model));
    var base64Image = 'data:image/png;base64,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';
    var location, pushpin;
    for (var i = 0; i < branches.length; i++) {
        location = new Microsoft.Maps.Location(branches[i].latitude, branches[i].longitude);
        pushpin = new Microsoft.Maps.Pushpin(location, { icon: base64Image });
        pushpin.metadata = branches[i];
        map.entities.push(pushpin);
        Microsoft.Maps.Events.addHandler(pushpin, 'click', (args) => { branchSelected(args); });
    }
}

// Handel list iten click
$(".branch-list-item").click(function () {
    branchSelected(null, $(this));
});