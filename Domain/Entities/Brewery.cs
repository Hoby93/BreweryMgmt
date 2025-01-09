using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("brewery")]   
    public class Brewery
    {
        [Key]  
        [Column("id_brewery")]  
        public int Id { get; set; }

        [Required]  
        [Column("name", TypeName = "VARCHAR(120)")]  
        public string Name { get; set; }

        public virtual ICollection<Brewer> Brewers { get; set; }
    }
}
