using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [Column("id_order")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Wholesaler")]
        [Column("wholesaler_id")]
        public int WholesalerId { get; set; }

        [Required]
        [Column("order_date", TypeName = "TIMESTAMP")]
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public decimal Devis { get; set; }
        public int QtBeers {get; set;}

        public void SetDevisDetails(decimal devis, int qt) {
            Devis += devis;
            QtBeers += qt;
        }

        public decimal GetDevis() {
            if(QtBeers > 20) {
                return  Devis - (Devis * (decimal)0.2); // discount 20%
            }
            if(QtBeers > 10) {
                return Devis - (Devis * (decimal)0.1); // discount 10%
            }
            return Devis;
        }
    }
}
