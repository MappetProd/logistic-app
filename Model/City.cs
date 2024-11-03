using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MassTransit;

namespace LogisticApp.Model
{
    public class City
    {
        [Column("city_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("city_name")]
        public string Name { get; set; }

        [Column("country_id")]
        public Guid CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        public virtual List<Street> Streets { get; set; }

    }
}
