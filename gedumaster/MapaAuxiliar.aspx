<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapaAuxiliar.aspx.cs" Inherits="MapaAuxiliar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Mapa Auxiliar</title>
    <style>
        #map {
            height: 100%;
        }
        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 100%;
            width:250px;
            margin: 0;
            padding: 0;
        }
    </style>

</head>
<body>
    <div id="map"></div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDiB9wl9opTaUAh60CpLbHnT3he_-1brJE&callback=initMap">
    </script>


</body>
</html>
