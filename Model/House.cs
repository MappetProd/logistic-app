using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MassTransit;

namespace LogisticApp.Model
{
    public class House
    {
        [Column("house_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("house_number")]
        public string Number { get; set; }

        [Column("street_id")]
        public Guid StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public Street Street { get; set; }

        public List<Building> Buildings { get; set; }
    }
}
