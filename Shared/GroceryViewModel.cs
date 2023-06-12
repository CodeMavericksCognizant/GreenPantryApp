using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPantryApp.Shared;

public class GroceryViewModel{
    public int Id
    {
        get;
        set;
    }
    public string UserId
    {
        get;
        set;
    }
    [Required]
    [Display(Name = "Grocery Item")]
    public string GroceryItem
    {
        get;
        set;
    }
    [Required]
    [Display(Name = "Purchase date")]
    public DateTime PurchaseDate
    {
        get;
        set;
    }
    [Required]
    [Display(Name = "Expiration Date")]
    public DateTime ExpirationDate
    {
        get;
        set;
    }
    [Required]
    [Display(Name = "Cost")]
    public Decimal Cost {
        get; 
        set; 
    }
}
