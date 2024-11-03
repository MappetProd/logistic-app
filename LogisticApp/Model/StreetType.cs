using MassTransit;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticApp.Model
{

    public class StreetType
    {
        [Column("street_type_id")]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("street_type_name")]
        public string Name { get; set; }
    }
}
