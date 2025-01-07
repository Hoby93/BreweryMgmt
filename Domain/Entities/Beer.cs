using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryManagementAPI.Domain.Entities
{
    [Table("beer")]   
    public class Beer
    {
        [Key]  // Indique que cette propriété est la clé primaire
        [Column("id_beer")]  // Spécifie le nom de la colonne dans la base de données
        public int Id { get; set; }

        [Required]  // Indique que cette propriété est obligatoire
        [Column("name", TypeName = "VARCHAR(120)")]  // Spécifie le nom de la colonne et le type dans la base de données
        public string Name { get; set; }

        [Required]
        [Column("alcohol_content", TypeName = "DECIMAL(5,2)")]  // Spécifie le nom et le type de la colonne
        public decimal AlcoholContent { get; set; }

        [Required]
        [Column("price", TypeName = "DECIMAL(10,2)")]  // Spécifie le nom et le type de la colonne
        public decimal Price { get; set; }

        [ForeignKey("Brewer")]  // Spécifie la clé étrangère vers la table Brewery
        [Column("brewer_id")]  // Spécifie le nom de la colonne pour la clé étrangère
        public int BrewerId { get; set; }
    }
}
