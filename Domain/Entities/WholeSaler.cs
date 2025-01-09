using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("wholesaler")]
    public class WholeSaler
    {
        [Key]
        [Column("id_wholesaler")]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        [Column("Name")]
        public string Name { get; set; }
    }
}
