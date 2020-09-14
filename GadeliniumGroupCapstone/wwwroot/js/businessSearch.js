document.getElementById("sendButton").addEventListener("click", sendSignal);

function sendSignal() {
    let searchValue;


    if ($("#searchType option:selected").val() == 1) {
        isBusinessSearch = true;
        searchValue = document.getElementById("SearchValue").value;
        connection.invoke("SendBusinessList", searchValue).catch(function (err) {
            return console.error(err.toString());
        });
    }

    if ($("#searchType option:selected").val() == 2 && $("#searchValue option:selected").val() == 1) {
        isBusinessSearch = false;
        searchValue = document.getElementById("SearchValue").value;
        connection.invoke("SendServiceList", searchValue).catch(function (err) {
            return console.error(err.toString());
        });
    }

    if ($("#searchType option:selected").val() == 2 && $("#searchValue option:selected").val() == 2) {
        isBusinessSearch = false;
        let tagSelection = $("#tagSelect").val();
        connection.invoke("SendServiceTagList", tagSelection).catch(function (err) {
            return console.error(err.toString());
        });
    }

    event.preventDefault();

};