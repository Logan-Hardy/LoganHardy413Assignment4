using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoganHardy413Assignment4.Models
{
    //Class used for when users add another restaurant to the list
    public class AddRestaurant
    {
        //Not required
        public string? UserName { get; set; }

        //Restaurant name is required because... because their restaurant suggestion would otherwise be hard to determine without it
        [Required]
        public string RestaurantName { get; set; }
        //Not required
        public string? FavoriteDish { get; set; }
        //Must enter phone number as 10 digits, no spaces, no parentheses, dashe after the first three digits and after the second three digits
        //ex. XXX-XXX-XXXX; 801-678-1328
        [Phone]
        [RegularExpression("^([0-9]{3}-[0-9]{3}-[0-9]{4})$", ErrorMessage = "Please enter a 10 digit phone number as: XXX-XXX-XXXX")]
        public string? PhoneNumber { get; set; }
    }
}
