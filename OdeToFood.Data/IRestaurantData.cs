using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetByName(string name = null);
        Restaurant Update(Restaurant update);
        int Commit();

        Restaurant Add(Restaurant newRestaurant);
    }
}