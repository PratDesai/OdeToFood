#region Copyright

// Copyright © 2020 Rice Lake Weighing Systems

#endregion

using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> m_restaurants;

        public InMemoryRestaurantData()
        {
            m_restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1, Name = "Dave's Pizza", CuisineType = CuisineType.Italian, Location = "NY"
                },
                new Restaurant
                {
                    Id = 2, Name = "The Curry House", CuisineType = CuisineType.Indian, Location = "London"
                },
                new Restaurant
                {
                    Id = 3, Name = "Casa Mexicana", CuisineType = CuisineType.Mexican, Location = "Rice Lake"
                }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return m_restaurants.OrderBy(x => x.Name);
        }

        public IEnumerable<Restaurant> GetByName(string name = null)
        {
            return string.IsNullOrWhiteSpace(name)
                ? GetAll()
                : m_restaurants
                    .OrderBy(x => x.Name)
                    .Where(x => x.Name.ToLower().Contains(name.ToLower()));
        }

        public Restaurant Update(Restaurant update)
        {
            var current = m_restaurants
                .SingleOrDefault(x => x.Id.Equals(update.Id));
            if (current != null)
            {
                UpdateRestaurant(current, update);
                Commit();
            }

            return current;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            var nextId = 1 + GetAll().Max(x => x.Id);
            newRestaurant.Id = nextId;
            m_restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant GetById(int id)
        {
            return m_restaurants.SingleOrDefault(x => x.Id.Equals(id));
        }

        private static void UpdateRestaurant(Restaurant current, Restaurant update)
        {
            current.Name = update.Name;
            current.Location = update.Location;
            current.CuisineType = update.CuisineType;
        }
    }
}