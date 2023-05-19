using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenPantryApp.Server.Models
{
    public class Food
    {

        [Table("Food", Schema = "dbo")]
        public class Person
        {
            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required]
            public string GroceryItem { get; set; }
            [Required]
            public string PurchaseDate { get; set; }
            [Required]
            public string ExpirationDate { get; set; }
        }
    }
}
