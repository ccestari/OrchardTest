using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoAccounts.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NoAccounts.DataAccessLayer
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(): base("RestaurantString")
        {
        }

        public DbSet<RestaurantGrade> RestaurantGrades { get; set; }

    }
}