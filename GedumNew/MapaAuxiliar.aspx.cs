using System;
using System.Text;


public partial class MapaAuxiliar : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        string vlat = Request.QueryString["lat"];
        string vlng = Request.QueryString["lng"];

        if (vlat == "0") {
            // cordenadas de Salvador
            vlat = "-12";
            vlng = "-38";
        }

        MontaMapa(vlat, vlng);

    }

    private void MontaMapa(string Lat, string Lng)
    {
        string rowTxt = "";
        str.Clear();

        rowTxt = "<script type=\"text/javascript\">"; str.Append(rowTxt);
        rowTxt = "function initMap() {"; str.Append(rowTxt);
        rowTxt = "var myLatLng = { lat: " + Lat + ", lng: " + Lng + "};"; str.Append(rowTxt);
        rowTxt = "var map = new google.maps.Map(document.getElementById('map'), {"; str.Append(rowTxt);
        rowTxt = "zoom: 12,"; str.Append(rowTxt);
        rowTxt = "center: myLatLng"; str.Append(rowTxt);
        rowTxt = "});"; str.Append(rowTxt);
        rowTxt = "var marker = new google.maps.Marker({"; str.Append(rowTxt);
        rowTxt = "position: myLatLng,"; str.Append(rowTxt);
        rowTxt = "map: map"; str.Append(rowTxt);
        rowTxt = "});"; str.Append(rowTxt);
        rowTxt = " }"; str.Append(rowTxt);
        rowTxt = "</script>"; str.Append(rowTxt);

        Literal1.Text = str.ToString();
        
    }
}