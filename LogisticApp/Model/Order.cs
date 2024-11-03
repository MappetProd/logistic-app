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

        [Column("order_display_id")]
        public string DisplayId { get; set; }

        [Column("sender_address_id")]
        public Guid SenderAddressId { get; set; }

        [ForeignKey(nameof(SenderAddressId))]
        public virtual Address SenderAddress { get; set; }

        [Column("recipient_address_id")]
        public Guid RecipientAddressId { get; set; }

        [ForeignKey(nameof(RecipientAddressId))]
        public virtual Address RecipientAddress { get; set; }

        [Column("cargo_weight_in_grams")]
        public int CargoWeightInGrams { get; set; }

        [Column("order_creation_dtm")]
        public DateTime CreationDtm { get; set; }

    }
}
