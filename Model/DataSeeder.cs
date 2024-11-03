namespace LogisticApp.Model
{
    public class DataSeeder
    {
        public static void SeedData(LogisticAppContext context)
        {
            if (context.Postcodes.Any() ||
                context.Cities.Any() ||
                context.Streets.Any() ||
                context.Houses.Any() ||
                context.StreetTypes.Any() ||
                context.Countries.Any())
            {
                return;
            }

            Country country = new Country { Name = "Российская Федерация" };
            context.Countries.AddRange(country);

            var streetTypes = new List<StreetType>()
            {
                new StreetType { Name = "улица" },
                new StreetType { Name = "проспект" },
            };

            context.StreetTypes.AddRange(streetTypes);

            var postcodes = new List<Postcode>
            {
                new Postcode { Code = "101000" },
                new Postcode { Code = "190000" },
                new Postcode { Code = "620000" },
                new Postcode { Code = "191028" },
                new Postcode { Code = "350000" }
            };
            context.Postcodes.AddRange(postcodes);

            var cities = new List<City>
            {
                new City { Name = "Москва", CountryId = country.Id },
                new City { Name = "Санкт-Петербург", CountryId = country.Id },
                new City { Name = "Екатеринбург", CountryId = country.Id },
                new City { Name = "Краснодар", CountryId = country.Id }
            };
            context.Cities.AddRange(cities);

            var streets = new List<Street>
            {
                new Street { Name = "Тверская", CityId = cities[0].Id, StreetTypeId = streetTypes[0].Id },
                new Street { Name = "Невский", CityId = cities[1].Id, StreetTypeId = streetTypes[1].Id },
                new Street { Name = "Ленина", CityId = cities[2].Id, StreetTypeId = streetTypes[0].Id },
                new Street { Name = "Литейный", CityId = cities[1].Id, StreetTypeId = streetTypes[1].Id },
                new Street { Name = "Красная", CityId = cities[3].Id, StreetTypeId = streetTypes[0].Id }
            };
            context.Streets.AddRange(streets);

            var houses = new List<House>
            {
                new House { StreetId = streets[0].Id, Number = "1", PostcodeId = postcodes[0].Id },
                new House { StreetId = streets[1].Id, Number = "2", PostcodeId = postcodes[1].Id },
                new House { StreetId = streets[2].Id, Number = "15А", PostcodeId = postcodes[2].Id },
                new House { StreetId = streets[3].Id, Number = "50", PostcodeId = postcodes[3].Id },
                new House { StreetId = streets[4].Id, Number = "100", PostcodeId = postcodes[4].Id }
            };
            context.Houses.AddRange(houses);
            context.SaveChanges();
        }
    }
}
