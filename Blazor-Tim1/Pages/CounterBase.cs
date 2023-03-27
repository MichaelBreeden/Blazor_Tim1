using Blazor_Tim1.Data;
using Microsoft.AspNetCore.Components;
//using Microsoft.Extensions.Logging;

namespace Blazor_Tim1.Pages
{
    /*** There is a new way to do this. Look at the FetchData Page for it.  ***/

    // To move this here, it must interit from ComponentBase
    //public class CounterBase
    public class CounterBase : ComponentBase
    {
        /*** private declarations must be changed to protected ***/

        [Parameter]
        public int StarterValue { get; set; } // Property name matches to route is expecting

        // So how to bring in a logger? ... THis can easily be replaced for testing as well.
        [Inject]
        protected ILogger<CounterBase>? Log { get; set; }

        //private int currentCount = 0;
        protected int currentCount = 0;

        // So Parameter can be used... Only runs on initial start of page.
        protected override void OnParametersSet() // From video
        {
            base.OnParametersSet();
            currentCount = StarterValue; // This is crazy for doing routing... Wow.
            //Log.LogInformation("the new value is {CounterValue}.", currentCount);
        }
        //protected override void OnParametersSet() => base.OnParametersSet(); // From Ctl .

        //private void IncrementCount()
        protected void IncrementCount()

        {
            // Error handling Section2 Lesson 5 At 1:00
            // throw new exceptio("I just broke this");
            currentCount+=2;
            Log.LogInformation("the new value is {CounterValue}.", currentCount);

        }
    }
}
