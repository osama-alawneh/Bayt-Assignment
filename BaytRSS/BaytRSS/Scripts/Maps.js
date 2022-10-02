let map;
let service;
let infowindow;

function initMap() {
    infowindow = new google.maps.InfoWindow();

    map = new google.maps.Map(document.getElementById("GoogleMaps"), {
        zoom: 15,
    });
    const division = document.getElementById("Division").innerText;

    const request = {
        query: division,
        fields: ["name", "geometry"],
    };

    service = new google.maps.places.PlacesService(map);

    service.findPlaceFromQuery(request, (results, status) => {
        if (status == google.maps.places.PlacesServiceStatus.OK && results) {

            console.log('if');

            for (let i = 0; i < results.length; i++) {
                createMarker(results[i]);
            }

            map.setCenter(results[0].geometry.location);
        }

        console.log(results, status);
    });

}

function createMarker(place) {

    console.log(place);
    console.log(!place.geometry);
    console.log(!place.geometry.location);

    if (!place.geometry || !place.geometry.location) return;

    console.log('5ara');

    const marker = new google.maps.Marker({
        map,
        position: place.geometry.location,
    });

    google.maps.event.addListener(marker, "click", () => {
        infowindow.setContent(place.name || "");
        infowindow.open(map);
    });
}

window.initMap = initMap;