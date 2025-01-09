using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("orderdetail")]
    public class OrderDetail
    {
        [Key]
        [Column("id_od")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Orders")]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("Beer")]
        [Column("beer_id")]
        public int BeerId { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
