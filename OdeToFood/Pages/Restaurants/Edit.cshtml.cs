using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData m_restaurantData;
        private readonly IHtmlHelper m_htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            m_restaurantData = restaurantData;
            m_htmlHelper = htmlHelper;
            Cuisines = m_htmlHelper.GetEnumSelectList<CuisineType>();
        }

        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = m_restaurantData.GetById(restaurantId.Value);
                if (Restaurant == null)
                {
                    return RedirectToPage("./NotFound");
                }

                return Page();
            }

            Restaurant = new Restaurant
            {
                Name = "New Restaurant"
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Restaurant = Restaurant.Id == 0 
                    ? m_restaurantData.Add(Restaurant) 
                    : m_restaurantData.Update(Restaurant);
                m_restaurantData.Commit();
                TempData["Message"] = "Restaurant saved!";
                return RedirectToPage("./Detail", new {restaurantId = Restaurant.Id});
            }

            return Page();
        }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        [BindProperty]
        public Restaurant Restaurant { get; set; }
    }
}