using MassTransit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticApp.Model
{
    public class Order
    {
        [Column("order_id")]
        [Key]
        public Guid Id { get; set; } = NewId.NextGuid();

        [Column("order_unique_number")]
        public int UniqueNumber { get; set; }

        [Column("sender_address_id")]
        public Address SenderAdress { get; set; }

        [Column("recipient_address_id")]
        public Address RecipientAddress { get; set; }

        [Column("cargo_weight_in_grams")]
        public int CargoWeightInGrams { get; set; }

        [Column("order_creation_dtm")]
        public DateTime CreationDtm { get; set; }

    }
}
