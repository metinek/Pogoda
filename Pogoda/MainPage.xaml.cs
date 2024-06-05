using System.Net;
using System.Text.Json;

namespace Pogoda
{

    public class Forecast
    {
        public string? cod { get; set; }
        public City? city { get; set; }
        public IList<Prognoza>? list { get; set; }
    }


    public class Prognoza
    {
        public int? dt { get; set; }

        public string? dt_txt { get; set; }

        public MainInfo? main { get; set; }

    }


    public class City
    {
        public int? id { get; set; }
        public string? name { get; set; }

    }





    class Clouds
    {
        public int? id { set; get; }

        public string? main { get; set; }

        public string? description { get; set; }

        public string? icon { get; set; }

    }






    class Weather
    {
        public string? baza { get; set; }

        public int? timezone { get; set; }

        public int? id { get; set; }

        public string? name { get; set; }

        public int? cod { get; set; }


        public Coord? coord{ get; set; }

        public MainInfo? main { get; set; }

        public List<Clouds>? weather { get; set; }
    }



    public class Coord
    {

        public double? lon { get; set; }

        public double? lat { get; set; }

    }



    public class MainInfo
    {
        public double? temp { get; set; }
        public double? pressure { get; set; }
        public double? humidity { get; set; }
    }




    public partial class MainPage : ContentPage
    {

        private static string j = "{\r\n  \"coord\": {\r\n    \"lon\": 10.99,\r\n    \"lat\": 44.34\r\n  },\r\n  \"weather\": [\r\n    {\r\n      \"id\": 501,\r\n      \"main\": \"Rain\",\r\n      \"description\": \"moderate rain\",\r\n      \"icon\": \"10d\"\r\n    }\r\n  ],\r\n  \"base\": \"stations\",\r\n  \"main\": {\r\n    \"temp\": 298.48,\r\n    \"feels_like\": 298.74,\r\n    \"temp_min\": 297.56,\r\n    \"temp_max\": 300.05,\r\n    \"pressure\": 1015,\r\n    \"humidity\": 64,\r\n    \"sea_level\": 1015,\r\n    \"grnd_level\": 933\r\n  },\r\n  \"visibility\": 10000,\r\n  \"wind\": {\r\n    \"speed\": 0.62,\r\n    \"deg\": 349,\r\n    \"gust\": 1.18\r\n  },\r\n  \"rain\": {\r\n    \"1h\": 3.16\r\n  },\r\n  \"clouds\": {\r\n    \"all\": 100\r\n  },\r\n  \"dt\": 1661870592,\r\n  \"sys\": {\r\n    \"type\": 2,\r\n    \"id\": 2075663,\r\n    \"country\": \"IT\",\r\n    \"sunrise\": 1661834187,\r\n    \"sunset\": 1661882248\r\n  },\r\n  \"timezone\": 7200,\r\n  \"id\": 3163858,\r\n  \"name\": \"Zocca\",\r\n  \"cod\": 200\r\n}";



        public MainPage()
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?lat=50.72&lon=23.22&appid=0c48b0e78aaf745e4cb29b309aa64923";
            //string url = "https://api.openweathermap.org/data/2.5/forecast?lat=50.50&lon=23.11&appid=0c48b0e78aaf745e4cb29b309aa64923";
            string? json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            InitializeComponent();
            Weather w = JsonSerializer.Deserialize<Weather>(json);


            lblMiasto.Text = $"{w.name}";
            string s = "";
            //s += $"coord: lat: {w.coord.lat} lon: {w.coord.lon}\n";
            //s += $"timezone: {w.timezone}\n";
            s += $"temperatura: {(int)(w.main.temp-273)} °C\n";
            s += $"ciśnienie: {w.main.pressure} hPa\n";
            s += $"wilgotność: {w.main.humidity} %\n";





            /*
             * Forecast f = JsonSerializer.Deserialize<Forecast>(json);


            string s="";
            s += $"kod {f.cod}\n";
            s += $"miasto {f.city.name}\n\n";
            lblMiasto.Text = s;
            s = "";
            foreach (var e in f.list)
            {
                s += e.dt_txt + "\n";
                s += $"temperatura: {(int)(e.main.temp - 273)} stopni\t";
                s += $"ciśnienie: {e.main.pressure} hPa\t";
                s += $"wilgotność: {e.main.humidity} %\n\n";
            }
            */

            lblWynik.Text = s;
            string imgURL = "http://openweathermap.org/img/wn/";
            imgURL += w.weather[0].icon + ".png";
            imgPogoda.Source=imgURL;
        }

        private void OnCounterClicked(object sender, EventArgs e){}


    }
    
}