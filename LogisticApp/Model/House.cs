using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MassTransit;
using System.Xml.Linq;

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

        [Column("postcode_id")]
        public Guid PostcodeId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public virtual Street Street { get; set; }
        
        [ForeignKey(nameof(PostcodeId))]
        public virtual Postcode Postcode { get; set; }
        public string BuildFullAddress()
        {
            string streetType = Street.StreetType.Name;
            return $"{streetType} {Street.Name}, д. {Number}, {Postcode.Code}";
        }

    }
}
