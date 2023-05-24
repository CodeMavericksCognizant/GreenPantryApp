using System.ComponentModel.DataAnnotations.Schema;

namespace GreenPantryApp.Server.Models
{
    public class GroceryItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
    }
}
