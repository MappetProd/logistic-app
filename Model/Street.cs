using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MassTransit;

namespace LogisticApp.Model
{
    public class Street
    {
        [Column("street_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("street_name")]
        public string Name { get; set; }

        [Column("city_id")]
        public Guid CityId { get; set; }

        [Column("street_type_id")]
        public Guid StreetTypeId { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City{ get; set; }

        [ForeignKey(nameof(StreetTypeId))]
        public virtual StreetType StreetType { get; set; }

        public virtual List<House> Houses { get; set; }
    }
}
