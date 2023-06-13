
using System.ComponentModel.DataAnnotations;


namespace GreenPantryApp.Shared
{
    public class ShoppingListModel
    {

            public int Id { get; set; }

            public string UserId { get; set; }

            [Required]
            [Display(Name = "Food")]
            public string FoodName { get; set; }
 
    }
}
