using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NoAccounts.Models;

namespace NoAccounts.DataAccessLayer
{
    public class RestaurantInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<RestaurantContext>
    {
    }
}