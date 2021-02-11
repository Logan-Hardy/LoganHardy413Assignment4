using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoganHardy413Assignment4.Models
{
    //temporary storgae for when running 
    public static class TempStorage
    {
        private static List<AddRestaurant> applications = new List<AddRestaurant>();

        public static IEnumerable<AddRestaurant> Applications => applications;

        public static void AddApplication(AddRestaurant application)
        {
            applications.Add(application);
        }
    }
}
