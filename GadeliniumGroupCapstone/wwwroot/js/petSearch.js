﻿"use strict";

// Global
let isPetSearch;
////

jQuery(document).ready(function () {

    if (sessionStorage.getItem("lastPetSearch")) {
        var pets = sessionStorage.getItem("lastBusinessSearch");
        var parsedPets = JSON.parse(pets);
        displayPetSearchCards(parsedPets);
    }
    if (sessionStorage.getItem("lastSearchValue")) {
        document.getElementById("SearchValue").value = sessionStorage.getItem("lastSearchValue");
    }



});

var connection = new signalR.HubConnectionBuilder().withUrl("/PetAppHub").build();

$("#searchType").change(function () {
    if ($("#searchType option:selected").val() == 1) {
        $("#searchValue").html('');
        $("#searchValue").append('<option value="1">Name</option>');
    }
    else {
        $("#searchValue").html('');
        $("#searchValue").append('<option value="1">Name</option>');
        //$("#searchValue").append('<option value="2">Option Tag</option>');
    }
});

$('#searchValue').change(function () {
    if ($("#searchValue option:selected").val() == 1) {
        $("#searchArea").html('');
        $("#searchArea").append(
            `<input type="text" id="SearchValue" class="form-control m-2" placeholder="Search by Pet Name" />`
        );
    } else {
        $("#searchArea").html('');
        $("#searchArea").append(`
        <select id="tagSelect" class="custom-select m-2">
            <option selected>Choose one...</option>
            <option value="Vet">Vet</option>
            <option value="Toy">Pet Toys</option>
            <option value="Food">Pet Food</option>
            <option value="Boarding">Boarding</option>
            <option value="Sitter">Sitter</option>
            <option value="Trainer">Trainer</option>
        </select>
        `);
    }


})


//Disable send button until connection is established
document.getElementById("sendPetButton").disabled = true;


// Business Searches
connection.on("RecievePetList", function (pets) {
    var lastSearch = document.getElementById("SearchPetValue").value;
    console.log(pets);
    var petStored = JSON.stringify(pets);

    sessionStorage.setItem("lastPetSearch", petStored);
    sessionStorage.setItem("lastSearchValue", lastSearch);
    displayPetSearchCards(pets);
});

connection.on("FavoriteMessage", function (value) {

    sendSignal()

});


connection.start().then(function () {
    document.getElementById("sendPetButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendPetButton").addEventListener("click", sendSignal);

function sendSignal() {
    let searchValue;


    if ($("#searchType option:selected").val() == 1) {
        isPetSearch = true;
        searchValue = document.getElementById("SearchPetValue").value;
        connection.invoke("SendPetList", searchValue).catch(function (err) {
            return console.error(err.toString());
        });
    }

    if ($("#searchType option:selected").val() == 2 && $("#searchPetValue option:selected").val() == 1) {
        isPetSearch = false;
        searchValue = document.getElementById("SearchPetValue").value;
        connection.invoke("SendServiceList", searchValue).catch(function (err) {
            return console.error(err.toString());
        });
    }

    if ($("#searchType option:selected").val() == 2 && $("#searchPetValue option:selected").val() == 2) {
        isPetSearch = false;
        let tagSelection = $("#tagSelect").val();
        connection.invoke("SendServiceTagList", tagSelection).catch(function (err) {
            return console.error(err.toString());
        });
    }

    event.preventDefault();

};


function displayPetSearchCards(pets) {
    $('#searchResultContainer').html('');
    $.each(pets, function (index, value) {
        let favButton = DisplayIsFavorited(value.isFavorited);


        $("#searchResultContainer").append(
            `<div class="col-md-4">
                    <div class="profile-card-4 text-center">
                        <img id="${value.petAccountId}-img" src="data:image/png;base64,${value.petProfileImage.content}" class="img" width="200">
                        <div class="profile-content">
                            <div class="profile-name">
                                <p></p>
                            </div>
                            <div class="profile-description py-4">${value.petName}</div>
                            <div class="d-flex justify-content-around">
                                 <a href="Details/${value.petAccountId}" alt="Business Page">Details</a>
                                <button type="button" class="btn btn-outline-warning" id="${value.petAccountId}-fav-btn">Favorite ${favButton} </button>
                            </div>
                        </div>
                    </div>
                </div>`
        );
    }
    )
};

function DisplayIsFavorited(isFavorite) {
    if (isFavorite) {
        return `<svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-suit-heart-fill" fill="gold" xmlns="http://www.w3.org/2000/svg">
  <path d="M4 1c2.21 0 4 1.755 4 3.92C8 2.755 9.79 1 12 1s4 1.755 4 3.92c0 3.263-3.234 4.414-7.608 9.608a.513.513 0 0 1-.784 0C3.234 9.334 0 8.183 0 4.92 0 2.755 1.79 1 4 1z"/>
</svg>`;
    } else {
        return `<svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-suit-heart" fill="gold" xmlns="http://www.w3.org/2000/svg">
  <path fill-rule="evenodd" d="M8 6.236l.894-1.789c.222-.443.607-1.08 1.152-1.595C10.582 2.345 11.224 2 12 2c1.676 0 3 1.326 3 2.92 0 1.211-.554 2.066-1.868 3.37-.337.334-.721.695-1.146 1.093C10.878 10.423 9.5 11.717 8 13.447c-1.5-1.73-2.878-3.024-3.986-4.064-.425-.398-.81-.76-1.146-1.093C1.554 6.986 1 6.131 1 4.92 1 3.326 2.324 2 4 2c.776 0 1.418.345 1.954.852.545.515.93 1.152 1.152 1.595L8 6.236zm.392 8.292a.513.513 0 0 1-.784 0c-1.601-1.902-3.05-3.262-4.243-4.381C1.3 8.208 0 6.989 0 4.92 0 2.755 1.79 1 4 1c1.6 0 2.719 1.05 3.404 2.008.26.365.458.716.596.992a7.55 7.55 0 0 1 .596-.992C9.281 2.049 10.4 1 12 1c2.21 0 4 1.755 4 3.92 0 2.069-1.3 3.288-3.365 5.227-1.193 1.12-2.642 2.48-4.243 4.38z"/>
</svg>`;
    }
}

function toggleFavorite(businessId) {
    connection.invoke("AddRemoveBusinessToFavorites", businessId).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
}