using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public enum TypeOfCuisine {Thai=1, Mexican, American, Chinese, Sushi, Italian, German, Polish, French, Jamiacan, Ethopian, Greek, English, Indian }
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        public TypeOfCuisine CuisineType { get; set; }
    }

    public class RestaurantDbContext : DbContext 
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}