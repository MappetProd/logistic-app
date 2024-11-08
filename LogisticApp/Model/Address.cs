﻿using MassTransit;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LogisticApp.Model
{
    public class Address
    {
        [Column("address_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("city_id")]
        public Guid CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }
        /*{
            get
            {
                return City;
            }
            set
            {
                City = value;
                CityId = value.Id;
            }
        }*/

        [Column("street_id")]
        public Guid StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public virtual Street Street { get; set; }
        /*{
            get
            {
                return Street;
            }
            set
            {
                Street = value;
                StreetId = value.Id;
            }
        }*/

        [Column("house_id")]
        public Guid HouseId { get; set; }

        [ForeignKey(nameof(HouseId))]
        public virtual House House { get; set; }
        /*{
            get
            {
                return House;
            }
            set
            {
                House = value;
                HouseId = value.Id;
            }
        }*/
        public Address() { }
        public Address(Postcode postcode, string houseNumber)
        {
            House = postcode.Houses.Single(h => h.Number == houseNumber);
            HouseId = House.Id;

            Street = House.Street;
            StreetId = Street.Id;

            City = Street.City;
            CityId = City.Id;
        }

        public static Dictionary<string, string>? SplitInCityAddressString(string fullInCityAddress)
        {
            //var pattern = @"(ул\.)|(д\.)|(,)|(проспект)|(улица)";


            Regex streetPattern = new Regex(@"(^улица.\w*)|(^проспект.\w*)");
            Regex housePattern = new Regex(@"(д\.?.\w*)");
            Regex postcodePattern = new Regex(@"(\,?.\d*$)");

            Match streetMatch = streetPattern.Match(fullInCityAddress);
            Match houseMatch = housePattern.Match(fullInCityAddress);
            Match postcodeMatch = postcodePattern.Match(fullInCityAddress);
            if (!(streetMatch.Success && houseMatch.Success && postcodeMatch.Success))
            {
                return null;
            }

            Dictionary<string, string> addressComponents = new Dictionary<string, string>();

            int index = streetMatch.Value.IndexOf("улица");
            string street;
            if (index < 0)
            {
                street = streetMatch.Value.Replace("проспект", "").Trim();
            }
            else
            {
                street = streetMatch.Value.Replace("улица", "").Trim();
            }

            addressComponents["street"] = street;
            addressComponents["house"] = houseMatch.Value.Remove(0, 3);
            addressComponents["postcode"] = postcodeMatch.Value.Remove(0, 2);
            /*string fullInCityAddressStringFormated = pattern.Replace(fullInCityAddress, " ");
            string[] addressSplited = fullInCityAddressStringFormated.Split(' ');
            addressSplited = addressSplited.Where(s => s != " ").ToArray();

            Dictionary<string, string> addressComponents = new Dictionary<string, string>();
            addressComponents["street"] = addressSplited[0];
            addressComponents["house"] = addressSplited[1];
            addressComponents["postcode"] = addressSplited[2];*/

            return addressComponents;
        }
    }
}
