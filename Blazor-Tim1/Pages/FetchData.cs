using Blazor_Tim1.Data;
using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components;

namespace Blazor_Tim1.Pages
{
    /*** This is the second way of moving code off of a page as compared to Counterbase.cs 
         This way does not inherit from Counterbase
    ***/

    //public class FetchData // - Not sure why it says this exists elsewhere. Can't find it.
    public partial class FetchData
    {
        private WeatherForecast[]? forecasts;

        // Inject here instead of on the page
        [Inject]
        public WeatherForecastService ForecastService { get; set; }
        protected override async Task OnInitializedAsync() // Page Event... there are many more.
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
