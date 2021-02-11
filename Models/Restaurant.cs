using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoganHardy413Assignment4.Models
{
    //class used for my top 5 favorite restaurants 
    public class Restaurant
    {
        //Restaurant constructor to set RestaurantRank
        public Restaurant(int rank)
        {
            RestaurantRank = rank;
        }

        [Required]
        //Read Only.  No set attatched to RestaurantRank
        public int RestaurantRank { get; } 

        [Required]
        public string RestaurantName { get; set; }
        public string? FavoriteDish { get; set; }
        [Required]
        public string Address { get; set; }
        [Phone]
        //Must enter phone number as 10 digits, no spaces, no parentheses, dashe after the first three digits and after the second three digits
        //ex. XXX-XXX-XXXX; 801-678-1328
        [RegularExpression("^([0-9]{3}-[0-9]{3}-[0-9]{4})$", ErrorMessage = "Please enter a 10 digit phone number as: XXX-XXX-XXXX")]
        public string? PhoneNumber { get; set; }
        public string Website { get; set; } = "Coming soon";


        //hard coded object array of top 5 favorite restaurants
        public static Restaurant[] GetRestaurants()
        {
            
            Restaurant r1 = new Restaurant(1)
            {
                RestaurantName = "outback",
                FavoriteDish = "ribs",
                Address = "372 e university pkwy, orem, ut 84058",
                PhoneNumber = "801-764-0552",
                //Website = "https://locations.outback.com/" //When webiste is left null, "Coming soon" is the default for the website in the model
            };
            Restaurant r2 = new Restaurant(2)
            {
                RestaurantName = "in-n-out",
                //FavoriteDish = "burger", //FavoriteDish is stored as null, later will be displayed as "It's all tasty!" through the controller
                Address = "350 e university pkwy, orem, ut 84058",
                PhoneNumber = "800-786-1000",
                Website = "https://locations.in-n-out.com/235"
            };
            Restaurant r3 = new Restaurant(3)
            {
                RestaurantName = "cubby's",
                FavoriteDish = "burger",
                Address = "1258 n state st, provo, ut 84604",
                //PhoneNumber = "801-919-3023", //accepts null phone numbers and is handled in the controller
                Website = "http://cubbys.co/"
            };
            Restaurant r4 = new Restaurant(4)
            {
                RestaurantName = "culver's",
                FavoriteDish = "burger",
                Address = "943 n 700 e, spanish fork, ut 84660",
                PhoneNumber = "801-504-6249",
                Website = "https://www.culvers.com/"
            };
            Restaurant r5 = new Restaurant(5)
            {
                RestaurantName = "cravings bistro",
                FavoriteDish = "turkey sandwich",
                Address = "25 w center st, pleasant grove, ut 84062",
                PhoneNumber = "801-785-2439",
                Website = "https://cravingsbistro.com/"
            };

            return new Restaurant[] { r1, r2, r3, r4, r5 };
        }
    }
}
