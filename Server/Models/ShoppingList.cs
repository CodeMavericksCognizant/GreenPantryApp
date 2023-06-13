using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GreenPantryApp.Server.Models
{
    public class ShoppingList
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }

        [Required]
        public string FoodName { get; set; }
    }
}
