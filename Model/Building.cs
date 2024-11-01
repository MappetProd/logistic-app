using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MassTransit;

namespace LogisticApp.Model
{
    public class Building
    {
        [Column("building_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("building_number")]
        public string Number { get; set; }

        [Column("house_id")]
        public Guid HouseId { get; set; }

        [ForeignKey(nameof(HouseId))]
        public House House { get; set; }
    }
}
