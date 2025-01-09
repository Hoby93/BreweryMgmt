using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("brewer")]   
    public class Brewer
    {
        [Key]  
        [Column("id_brewer")]  
        public int Id { get; set; }

        [Required]  
        [Column("name", TypeName = "VARCHAR(120)")]  
        public string Name { get; set; }

        [ForeignKey("Brewery")] 
        [Column("brewery_id")]  
        public int BreweryId { get; set; }


        public virtual ICollection<Beer> Beers { get; set; }
    }
}
