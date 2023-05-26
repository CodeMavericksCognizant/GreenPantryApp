using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenPantryApp.Server.Models
{
    [Table("Food", Schema = "dbo")]
    public class Food
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public string GroceryItem { get; set; }
        [Required] public DateTime PurchaseDate { get; set; }
        [Required] public DateTime ExpirationDate { get; set; }
        
    }
}
