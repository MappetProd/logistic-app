using MassTransit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticApp.Model
{
    public class Address
    {
        [Column("address_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        public City City { get; set; }
        public Street Street { get; set; }
        public House House { get; set; }
    }
}
