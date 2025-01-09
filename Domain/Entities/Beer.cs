using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("beer")]   
    public class Beer
    {
        [Key]  
        [Column("id_beer")]  
        public int Id { get; set; }

        [Required]  
        [Column("name", TypeName = "VARCHAR(120)")]  
        public string Name { get; set; }

        [Required]
        [Column("alcohol_content", TypeName = "DECIMAL(5,2)")]  
        public decimal AlcoholContent { get; set; }

        [Required]
        [Column("price", TypeName = "DECIMAL(10,2)")]
        public decimal Price { get; set; }

        [ForeignKey("Brewer")] 
        [Column("brewer_id")]
        public int BrewerId { get; set; }

    }
}
