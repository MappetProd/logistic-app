using MassTransit;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogisticApp.Model
{
    public class Postcode
    {
        [Column("postcode_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("code")]
        public string Code { get; set; }

        public virtual List<House> Houses { get; set; }

    }
}
