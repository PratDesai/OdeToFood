using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData m_restaurantData;

        public ListModel(
            IRestaurantData restaurantData)
        {
            m_restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurants = m_restaurantData.GetByName(SearchTerm);
        }

        public string Message { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
    }
}