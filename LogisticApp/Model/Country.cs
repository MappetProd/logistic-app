using MassTransit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticApp.Model
{
    public class Country
    {
        [Column("country_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("country_name")]
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
