using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("wholesalerstock")]
    public class WholesalerStock
    {
        [Key]
        [Column("id_wss")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Wholesaler")]
        [Column("wholesaler_id")]
        public int WholesalerId { get; set; }

        [Required]
        [ForeignKey("Beer")]
        [Column("beer_id")]
        public int BeerId { get; set; }

        [Required]
        [Column("action")]
        public int Action { get; set; } // 0: Out, 1: In, 2: Rep

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("action_date")]
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
    }
}
