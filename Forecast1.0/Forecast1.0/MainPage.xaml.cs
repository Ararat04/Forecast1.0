using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace Forecast1._0
{
    public partial class MainPage : ContentPage
    {
        const string API = "46af00fe34ceff1b38be8be4a1e72556";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void getWeather_Clicked(object sender, EventArgs e)
        {
            string city = userInput.Text.Trim();
            if (city.Length < 2)
            {
                await DisplayAlert("Error", "City used to be bigger", "Okay :(");
                return;
            }
            

            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={API}";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
            string temp = json["main"]["temp"].ToString();
            string pressure = json["main"]["pressure"].ToString();
            resultLabel.Text = "Погода сайчас " + temp + " °C            " + 
                "Давление " + pressure + " мм рт.ст.";
            
        }
    }
}
