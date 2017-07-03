function initMap() {

    // Autocomplete
    var input1 = document.getElementById('input_end');
    var places = new google.maps.places.Autocomplete(input1);
    
    //Marcador
    google.maps.event.addListener(places, 'place_changed', function () {

        var place = places.getPlace(); 

        var latitude = place.geometry.location.lat();
        var longitude = place.geometry.location.lng();

        document.getElementById('input_lat').value = latitude;
        document.getElementById('input_lng').value = longitude;

        var urlMapa = "MapaAuxiliar.aspx?lat=" + latitude + "&lng=" + longitude;
        window.open(urlMapa, 'MapFrame');

    });

}


