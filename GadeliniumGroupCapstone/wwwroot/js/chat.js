"use strict";

jQuery(document).ready(function () {

    if (sessionStorage.getItem("lastBusinessSearch")) {
        var businesses = sessionStorage.getItem("lastBusinessSearch");
        var parsedBusinesses = JSON.parse(businesses);
        displaySearchCards(parsedBusinesses);
    }
    if (sessionStorage.getItem("lastSearchValue")) {
        document.getElementById("SearchValue").value = sessionStorage.getItem("lastSearchValue");
    }

});

var connection = new signalR.HubConnectionBuilder().withUrl("/PetAppHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("RecieveBusinessList", function (businesses) {
    var lastSearch = document.getElementById("SearchValue").value;
    console.log(typeof businesses);
    var businessStored = JSON.stringify(businesses);

    sessionStorage.setItem("lastBusinessSearch", businessStored);
    sessionStorage.setItem("lastSearchValue", lastSearch); 
    displaySearchCards(businesses);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var searchValue = document.getElementById("SearchValue").value;
    connection.invoke("SendBusinessList", searchValue).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function displaySearchCards(businesses) {
    $('#searchResultContainer').html('');
    $.each(businesses, function (index, value) {

        $("#searchResultContainer").append(
            `<div class="col-md-4">
                    <div class="profile-card-4 text-center">
                        <img id="${value.BusinessId}-img" src="data:image/png;base64,${value.businessLogo.content}" class="img" width="200">
                        <div class="profile-content">
                            <div class="profile-name">
                                <p></p>
                            </div>
                            <div class="profile-description bg-">${value.businessName}</div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <div class="profile-overview">
                                        <a href="info/${value.businessId}" alt="Business Page">Details</a>
                                    </div>
                                </div>
                                <div class="col-xs-6">
                                    <div class="profile-overview">
                                        <p>Favorite</p>
                                        <h4>click here</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`
        );
    }
    )
};