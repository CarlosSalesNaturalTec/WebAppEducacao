var map;

function initMap() {

    // Mapa
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -12.990281, lng: -38.472187 },
        zoom: 12
    });

    // Autocomplete
    var input1 = document.getElementById('input_end');

    var autocomplete1 = new google.maps.places.Autocomplete(input1);
    autocomplete1.bindTo('bounds', map);

}