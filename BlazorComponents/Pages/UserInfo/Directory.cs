using BlazorComponents.Models;

namespace BlazorComponents.Pages.UserInfo
{
    public partial class Directory
    {
        // Get people info
        List<PersonModel> People { get; set; }

        protected override async Task OnInitializedAsync()
        {
            People = new List<PersonModel>
        {
            new PersonModel
            {
                FirstName = "Bob",
                LastName = "Hope",
                Addresses =  new List<AddressModel>
                {
                    new AddressModel
                    {
                        AddressType = "Home",
                        StreetAddress = "234 Globe St.",
                        City = "Encino",
                        State = "CA",
                        ZipCode = "91368"
                    },
                    new AddressModel
                    {
                        AddressType = "Work",
                        StreetAddress = "224 Van Nuys Blvd.",
                        City = "Van Nuys",
                        State = "CA",
                        ZipCode = "91377"
                    }
                }
            },
            new PersonModel
            {
                FirstName = "Tiny",
                LastName = "Tim",
                Addresses =  new List<AddressModel>
                {
                    new AddressModel
                    {
                        AddressType = "Home",
                        StreetAddress = "123 Glitter Dr.",
                        City = "Palm Beach",
                        State = "FL",
                        ZipCode = "01368"
                    },
                    new AddressModel
                    {
                        AddressType = "Work",
                        StreetAddress = "234 Orange Blvd.",
                        City = "Homestead",
                        State = "FL",
                        ZipCode = "01377"
                    }
                }
            },
            new PersonModel
            {
                FirstName = "Sue",
                LastName = "Storm",
                Addresses =  new List<AddressModel>
                {
                    //new AddressModel()
                    //{
                    //    AddressType = "Home",
                    //    StreetAddress = "123 Glitter Dr.",
                    //    State = "FL",
                    //    ZipCode = "01368"
                    //}
                }
            }
        }; // End People = new List<PersonModel>
    }  // End protected override async Task OnInitializedAsync()

        /* Will use this when it pulls from Db - Now do it in the constructor though
        protected override async Task OnInitializedAsync()
        {
            //forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }*/
    } // End public class Directory
}
